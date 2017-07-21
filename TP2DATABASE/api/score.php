<?php 
    include_once 'lib/Utils.php';
    include_once 'lib/DatabaseManager.php';

    $Database = new DatabaseManager(.unity);

    $score = (int)$_GET['score'];

    $query = "SELECT user.score FROM unity.user WHERE username='" .$_GET['username']."'";
    $vScore = $Database->FetchDatabase($query);

    if($score < $vScore[0]['score']){
        $score = $vScore[0]['score'];
    }

    $query = "SELECT * FROM unity.token WHERE value = '" . $_GET['token']. "' AND (expiration > NOW());";
    $vToken = $Database->FetchDatabase($query);

    if(!empty($vToken)){
        $query = "UPDATE unity.user SET score=$score WHERE username='".$_GET['username']."' ";
        $Database->FetchDatabase($query);
        die;
    }
    print("Token expired");









?>



