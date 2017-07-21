<?php
    include_once 'lib/Utils.php';
    include_once 'lib/DatabaseManager.php';

    
    $database = new DatabaseManager('unity');

    $expiration = date('Y-m-d H:i:s', strtotime("+1 day"));

    if(isset($_GET['value']))
    {
        $query = "SELECT * FROM unity.token WHERE value = '" .$_GET['value'].  "' AND (expiration > NOW());";
        $vToken = $database->FetchDatabase($query);

        if(!empty($vToken))
        {

            $query = "SELECT user.username ,user.score FROM unity.user ORDER BY user.score DESC;";
            $vUser = $database->FetchDatabase($query);

            foreach($vUser as $user)
            {
                print_r($user["username"]. '-'. $user["score"] . '<br/>');
               
            }

            die;
        }

    }
    
    print 'An error occured..!';
    die;
?>