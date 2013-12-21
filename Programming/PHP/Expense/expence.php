<?php
mb_internal_encoding('UTF-8');
$pageTitle = 'Нов Разход';
include 'includes/header.php';

if ($_GET) {
    $date = date("d.m.Y");
    $product = trim($_GET['product']);
    $product = str_replace('!', '', $product);
    $sum = trim($_GET['sum']);
    $sum = str_replace('!', '', $sum);
    $sum = str_replace(',', '.', $sum);
    $selectedType = (int) $_GET['type'];
    $error = FALSE;
    if (mb_strlen($product) < 4) {
        echo '<p>Името е прекалено късо!</p>';
        $error = TRUE;
    }
    if ($sum <= 0) {
        $error = TRUE;
    }
    if (!array_key_exists($selectedType, $types)) {
        echo '<p>Hевалиден вид</p>';
        $error = true;
    }
    if (!$error) {
        $result = $date . '!' . $product . '!' . $sum . '!' . $selectedType . "\n";
        if (file_put_contents('data.txt', $result, FILE_APPEND)) {
            echo 'Записа е успешен!';
        }
    }
}
?>
<a href="index.php"> Списък <a/>
    <form method="GET">
        <label> Име </label><input type="text" name="product"/>

        <label> Сума </label><input type="text" name="sum"/>
        <label> Вид </label>
        <select name="type">
            <?php
            foreach ($types as $key => $value) {
                echo '<option value="' . $key . '">' . $value .
                '</option>';
            }
            ?>
        </select>
        <input type="submit" value="Добави"/>
    </form>
    <?php
    include 'includes/footer.php';
    ?>
