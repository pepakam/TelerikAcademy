<?php
$pageTitle = "Разходи";
include 'includes/header.php';
?>
<a href="expence.php" >Добави нов разход</a>
<form method="GET"/>
<select name="type-filter">

    <?php
    foreach ($typesFilter as $key => $value) {
        echo "<option value=\"$key\"" . (isset($_GET['type-filter']) &&
        $key == $_GET['type-filter'] ? ' selected="selected"' : '') . ">$value</option>";
    }
    ?>
</select>
<input type="submit" value="Филтрирай"/>
</form>
<table>
    <tr>
        <td> Дата </td>
        <td> Име </td>
        <td> Сума </td>
        <td> Вид </td>
    </tr>
    <?php
    if (file_exists('data.txt')) {
        $result = file('data.txt');
        $amount = 0;
        foreach ($result as $value) {
            $columns = explode('!', $value);

            if ($_GET) {

                $filter = (int) $_GET['type-filter'];
                $error = false;

                if (!array_key_exists($filter, $typesFilter)) {
                    echo '<p>Невалидeн вид</p>';
                    $error = true;
                }

                if (!$error && ($filter == 0 ||
                        ($filter == 1 && $types[trim($columns[3])] == 'Храна') ||
                        ($filter == 2 && $types[trim($columns[3])] == 'Транспорт') ||
                        ($filter == 3 && $types[trim($columns[3])] == 'Дрехи') ||
                        ($filter == 4 && $types[trim($columns[3])] == 'Други'))) {
                    echo '<tr>
				<td>' . $columns[0] . '</td>
				<td>' . $columns[1] . '</td>
				<td>' . $columns[2] . '</td>
				<td>' . $types[trim($columns[3])] . '</td>						
				</tr>';
                    $amount += $columns[2];
                }
            } else {
                echo '<tr>
				<td>' . $columns[0] . '</td>
				<td>' . $columns[1] . '</td>
				<td>' . $columns[2] . '</td>
				<td>' . $types[trim($columns[3])] . '</td>						
				</tr>';
                $amount += $columns[2];
            }
        }
        if ($amount > 0) {
            echo ' <tr>
                    <td>' . '---' . '</td>
                    <td>' . 'Общо' . '</td>
                    <td>' . number_format($amount,2) . '</td>
                    <td>' . '---' . '</td>    
                </tr>';
        }
    }
    ?>
</table>
<?php
include 'includes/footer.php';
?>