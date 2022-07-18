<?php
/**
 * INICIO SESSION DE LA BASE DE DATOS
 */
session_start();
/**
 * SI EXISTE YA UNA SESSION USUARIO, SE DESDRUYE LA SESSION Y VUELVE A AL LOGIN
 */
if (isset($_SESSION['usuario'])) {
    echo"existe session";
    session_destroy();
    header("location: ../view/pagina_default/page.html");
} else {
    echo"no existe session";
    header("loaction: ../view/pagina_default/page.html");
}
?>