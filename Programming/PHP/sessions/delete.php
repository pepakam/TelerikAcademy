?php
$pageTitle = "Delete File";
include 'includes/header.php';
session_start();
?>

<h1><?= $pageTitle; ?></h1>

<?php
if (isset($_GET['path'])) {
    if (file_exists('userdata' . DIRECTORY_SEPARATOR . $_SESSION['username'] . DIRECTORY_SEPARATOR . $_GET['path'])) {
        unlink('userdata' . DIRECTORY_SEPARATOR . $_SESSION['username'] . DIRECTORY_SEPARATOR . $_GET['path']);
        header('Location: files.php');
    }
    echo '<p>Файла беше изтрит</p>';
    header("refresh:1;url=index.php");
} else {
    echo '<p>Няма такъв файл</p>';
    header("refresh:2;url=files.php");
}
?>

<?php
include 'functions.php';
include 'includes/footer.php';
?>