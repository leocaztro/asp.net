<?php
/**
 * este es la elminacion del form.php
 */

include("../connetdb/conexion.php");
$con=conectar();

$id_semilla=$_GET['id'];

$sql="DELETE FROM semilla  WHERE ID_SEMILLA='$id_semilla'";
$query=mysqli_query($con,$sql);

    if($query){
        Header("Location: ../form.php");
    }
?>
