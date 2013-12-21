<?php
$pageTitle = 'Влез в системата';
include 'includes/header.php';

?>
<form method="POST">
    <div><label>Име:</label><input type="text" name="username"/></div>
    <div><label>Пaрола:</label><input type="password" name="pass"/></div>
    <div><input type="submit" value="Вход"/></div>
</form> 
<?php
include 'includes/footer.php';
?>
