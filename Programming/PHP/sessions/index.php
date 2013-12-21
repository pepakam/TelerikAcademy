<?php

session_start();
if (isset($_SESSION['isLogged'])) {
    include 'files.php';
} else {
    if ($_POST) {
        $username = trim($_POST['username']);
        $pass = trim($_POST['pass']);
        
        //валидация
        
        $error = FALSE;
        if (mb_strlen($username) < 3) {
            echo '<p>Името е прекалено късо!</p>';
            $error = TRUE;
        }
        if (mb_strlen($pass) < 3) {
            echo '<p>Паролата е прекалено къса!</p>';
            $error = TRUE;
        }
        if (!$error) {

            if ($username == 'user' && $pass == 'qwerty') {
                $_SESSION['isLogged'] = true;
                header('Location:index.php');
                exit();
            } else {
                echo 'Грешни данни';
            }
        }
    }
    include 'login-form.php';
}
?>