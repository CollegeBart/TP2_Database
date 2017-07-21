<?php

if(isset($_POST['username']))
{
    if($_POST['password'] === $_POST['passwordconfirmation']){

    //Sign in user.
    include_once '/lib/DatabaseManager.php';
    $database = new DatabaseManager('unity');
    $query = "INSERT INTO unity.user VALUES(NULL,'" .$_POST['username']."','" .md5($_POST['password'])."','"
        . $_POST['firstname']."','". $_POST['lastname']."','"
        . $_POST['birthdate']."','". $_POST['email']."');";
   
    $database->FetchDatabase($query);
    }
}














header('location: /api');



?>