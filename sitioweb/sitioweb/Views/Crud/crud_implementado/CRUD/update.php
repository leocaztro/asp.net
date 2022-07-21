<?php
/**
 * espara actaulizar la tabla al modificar una columna
 */
include("../connetdb/conexion.php");
$con=conectar();

$codigo_S=$_POST['cod'];
$nombre_S=$_POST['nombre'];
$mensaje_S=$_POST['descrip'];
$precio=$_POST['precio'];

$sql="UPDATE semilla SET  NOMBRESEM='$nombre_S',DESCR_SEMI='$mensaje_S',PRECIO_SEM='$precio' WHERE ID_SEMILLA='$codigo_S'";
$query=mysqli_query($con,$sql);

    if($query){
        Header("Location: ../form.php");
    }
?>