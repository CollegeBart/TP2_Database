<html>
    <head>
        <title>API Homepage</title>
        <link rel="stylesheet" type="text/css" href="css/core.css"></link>
        <script src="js/core.js"></script>
    </head>
    <body>
        <form action="/api/sign-in.php" method="post">
            Email<span class="required">*</span>
            <input required type="text" name="email"></input><br/>

            Birthdate<span class="required">*</span>
            <input required type="date" name="birthdate"></input><br/>
            
            Firstname<span class="required">*</span>
            <input required type="text" name="firstname"></input><br/>
            
            Lastname<span class="required">*</span>
            <input required type="text" name="lastname"></input><br/>
            
            Username<span class="required">*</span>
            <input required type="text" name="username"></input><br/>
            
            Password<span class="required">*</span>
            <input id="password" required type="password" name="password"></input><br/>
            
            Confirm password<span class="required">*</span>
            <input onkeyup="processError();" id="passwordconfirmation" required type="password" name="passwordconfirmation"></input><span class="handler"></span><br/>
            
            <input type="submit" value="Sign in"/>
        </form>
    </body>
</html>