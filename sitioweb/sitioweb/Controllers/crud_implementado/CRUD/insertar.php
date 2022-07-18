<?php
/**
 * este linea de codigo es para insertar un producto a la tabla
 */
include("../connetdb/conexion.php");
$con=conectar();

$codigo_S=$_POST['cod'];
$nombre_S=$_POST['nombre'];
$mensaje_S=$_POST['descrip'];
$precio=$_POST['precio'];


$sql="INSERT INTO semilla VALUES('NULL','$codigo_S','NULL','$nombre_S','$mensaje_S','$precio')";
$query= mysqli_query($con,$sql);

if($query){
    Header("location: ../form.php");
    
}else {
    echo("hubo problema al enviar");
}
?>