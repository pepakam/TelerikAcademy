<?php
$pageTitle = 'Списък на файловете';
include 'includes/header.php';
include 'functions.php';
?>

<a href="destroy.php" class="exit">Изход</a>

<h1><?= $pageTitle; ?></h1>
<table>
    <thead>
        <tr>
            <th>Име на файл</th>
            <th>Размер</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <?php
        $path = 'userdata';
        if (file_exists($path)) {
            $files = scandir($path);
            for ($i = 2; $i < count($files); $i++) {
                $size = formatSizeUnits(filesize($path . DIRECTORY_SEPARATOR . $files[$i]));
                $link = '<a href="userdata/' . $files[$i] . '" >';

                echo '<tr><td>' . $link . $files[$i] . '</a></td>
					<td>' . $size . '</td>
					<td><a href="delete.php?path=' . urlencode($files[$i]) . '" data-toggle="tooltip" 
                                            title="Delete" onClick="return confirm(\'Are you sure you want to delete ' . $files[$i] . '?\')">
                                                <i class="del"></i></a></td></tr>';
            }
        }
        ?>
    </tbody>
</table>
<a href="upload.php">Качи файл</a>
<?php
include 'includes/footer.php';
?>