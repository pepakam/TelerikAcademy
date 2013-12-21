<?php
session_start();
$pageTitle = 'Качване на файл';
include 'includes/header.php';
?>
<a href="destroy.php" class="exit">Изход</a>
<h1><?= $pageTitle; ?></h1>
<?php
if ($_POST) {
   
    if (count($_FILES)>0) {
        if (move_uploaded_file($_FILES['picture']['tmp_name'],
                'userdata'.DIRECTORY_SEPARATOR.$_FILES['picture']['name'])) {
            echo 'Файла е качен успешно';
        }
        } else {
            echo 'Грешка';
        }
}
?>


<form method="POST" action="upload.php" enctype="multipart/form-data">
    <div>
        <label>Снимка:</label><input type="file" name="picture"/>
    </div>   
    <div><input type="submit" name="fileUpload" value="Качи"/></div>
</form>
<a href="files.php">Списък на качените файлове</a>
<?php
include 'includes/footer.php';
?>