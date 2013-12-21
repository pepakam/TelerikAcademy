<?php
session_start();
include 'includes/header.php';
if ($_POST) {
    $username = trim($_POST['username']);
    $pass = trim($_POST['pass']);
    //валидация тук
    if ($username=='user' && $pass=='qwerty') {
        $_SESSION['isLogged']=true;
    }
 else {
        echo 'Грешни данни';
        }
}

?>
<form method="POST">
    <div><label>Име:</label><input type="text" name="username"/></div>
     <div><label>Пaрола:</label><input type="password" name="pass"/></div>
     <div><input type="submit" value="Вход"/></div>
</form>