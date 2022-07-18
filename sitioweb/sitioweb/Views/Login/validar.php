<?php
/**
 * SE ENCLUYE LA bASE DE DATOS
 */
require '../../model/connect_db/conexion.php';
/**
 * CAPUTRAR INFORMACON DEL FORMULARIO
 */
$usuario= $_POST['usuario'];
$contra= $_POST['contraseña'];
$contramd5 = md5($contra);
session_start();
$_SESSION['usuario'] = $usuario;
/**
 * SE ESTABLECE LA CONEXION, SE PREGUNTA A LA BASE DE DATOS Y ESTARA EN UNA QUERY Y LUEGO SE ENTRARA EN UN ARRAY
 */
$connection=mysqli_connect("localhost","root","","db_semillas");
$consulta="SELECT*FROM cliente where correo_cliente='$usuario' and password='$contramd5'";
$resultado= mysqli_query($connection,$consulta);
//$filas=mysqli_num_rows($resultado);
$filas= mysqli_fetch_array($resultado);
/**
 * SI LA SESSION DE ROL ES 1 VOLVERA AL ADMIN SI ES EL 2 VOLVERA AL CLIENTE
 * si la varificaion es incorrecta te devuelve al login co mensaje de "error al verificar"
 */

/*if ($filas['id_rol'] = null) {
    ?>
<?php
    require '../view/pagina_login/index.php';
    
    ?>
    <!-- Custom fonts for this template-->
    <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="../css/img.css">
    <!-- Custom styles for this template-->
    <link href="../css/sb-admin-2.min.css" rel="stylesheet">
<h1 style="text-align: center; width: 100%; padding: 12px; background-color: #a22; color: #fff">ERROR DE AUTENTIFICACION
</h1>
<?php
}*/
//print_r($_SESSION);
error_reporting(E_ALL ^ E_NOTICE );
if ($filas['id_rol']==1)/*ADMIN*/ {
    header("location: ../paginaprincipal/page.php");
} if ($filas['id_rol']==2)/*CLIENTE*/ {
    # code...
    header('location: ../paginacliente/page.php');
} else {
?>
    <?php
        include ("index.php");
    ?>
        <!-- Custom fonts for this template-->
        <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
        <link rel="stylesheet" type="text/css" href="../css/img.css">
        <!-- Custom styles for this template-->
        <link href="../css/sb-admin-2.min.css" rel="stylesheet">
    <h1 style="text-align: center; width: 100%; padding: 12px; background-color: #a22; color: #fff">ERROR DE AUTENTIFICACION</h1>
<?php
}
mysqli_free_result($resultado);
mysqli_close($connection);
?>