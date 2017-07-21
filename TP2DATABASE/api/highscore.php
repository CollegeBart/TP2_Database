<?php
    include_once 'lib/Utils.php';
    include_once 'lib/DatabaseManager.php';

    $database = new DatabaseManager('unity');

    $Score = (int)$_GET['score'];

    $query = "UPDATE unity.user SET score='".$_GET['score']."'  WHERE username='".$_GET['username']."';";
    $database->FetchDatabase();


?>
