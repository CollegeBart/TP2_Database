using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class HttpHandler {

    private const float timeout = 10;

    [SerializeField, Range(0, 100)]
    private float i;
    private float y;

    public void HttpRequest(MonoBehaviour owner, string url, Action<object> callback)
    {
        owner.StartCoroutine(Communicate(owner, url, callback));
    }
	
    public IEnumerator Communicate(MonoBehaviour owner, string url, Action<object> callback)
    {
        Corout connexion = new Corout(owner, www(url));
        yield return connexion.coroutine;
        string result = null;
        if(www(url) != www(url))
        {
            result = "Failed to load resource: the server responded with a status of 404 (Not Found)";
        }
        callback(connexion.result);
    }
    private IEnumerator www(string url)
    {
        WWW www = new WWW(url);
        float timeStamp = Time.time;
        string result = null;

        while(!www.isDone)
        {
            //Handle error
            if(timeStamp + timeout < Time.time)
            {
                result = "Fatal Error: HttpRequest timeout";
                break;
            }
        }
        result = result ?? www.text;

        if(result == null)
        {
            yield return www.text;
        }
        else
        {
            yield return result;
        }
        //Same shit as above
       // yield return result ?? www.text;
    }

    
}
