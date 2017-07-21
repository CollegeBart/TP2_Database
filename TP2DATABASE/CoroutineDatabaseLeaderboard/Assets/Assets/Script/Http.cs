using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Http : MonoBehaviour {
    private HttpHandler connexion;

    public InputField username_input;
    public InputField password_input;
    public InputField score_input;

    public GameObject GoPLaybutton;
    public GameObject leaderboardtexts;
    public GameObject user_input_obj;
    public GameObject user_text;
    public GameObject pass_text;
    public GameObject pass_input_obj;
    public GameObject submit;
    public GameObject score;
    public GameObject submit_button;
    public GameObject Text;
    public GameObject[] leaderboard;

    public Text leaderboardtext;

    public string username;
    public string password;
    public string apikey;

    private string[] _leaderboard;
    private string adb;
    private string setscore;
    private string token;

	void Start () {
        connexion = new HttpHandler();

        connexion.HttpRequest(this, "localhost/api/connect.php?apikey=harambart", result);

	}
	
    void result(object result)
    {
        Debug.Log(result);
        token = result.ToString().Trim();
        
    }


    void readLeaderBoard(object result)
    {
        Debug.Log(result);
    }

    public void connectionEffective()
    {
        username = username_input.text;
        password = password_input.text;
        connexion.HttpRequest(this, "localhost/api/login.php?username=" + username + "&password=" + password + "&token=" + token.Trim(), loginrequest);

    }

    public void loginrequest(object result)
    {
        if(Regex.IsMatch(result.ToString(), username))
        {
            user_input_obj.SetActive(false);
            pass_input_obj.SetActive(false);
            user_text.SetActive(false);
            pass_text.SetActive(false);
            submit.SetActive(false);
            score.SetActive(true);
            submit_button.SetActive(true);
            Text.SetActive(true);
        }else
        {
            Debug.Log(result.ToString());
        }
    }

    void Leader(object result)
    {
        for(int i=0; i < leaderboard.Length; i++ )
        {
            leaderboard[i].SetActive(true);
            if(i >= leaderboard.Length || _leaderboard[i] == "" )
            {
                break;
            }
            string[] User = _leaderboard[i].Split(' ');
            username_input.text += (1 + i).ToString() + ". " + User[0] + "\n";
            leaderboardtext.text += User[1] + "\n";
        }
    }

    public void SetScore()
    {
        setscore = score_input.text;

        connexion.HttpRequest(this, "localhost/api/newscore.php?username=" + username + "&score=" + score_input.text + "&token=" + token, Score);
    }

    void Score(object score)
    {
        Leader(score);
        leaderboardtexts.SetActive(true);
    }

    public void goBackToScore()
    {
        score.SetActive(true);
        submit_button.SetActive(true);
        Text.SetActive(true);
        GoPLaybutton.SetActive(false);
        leaderboardtexts.SetActive(false);
    }
}
