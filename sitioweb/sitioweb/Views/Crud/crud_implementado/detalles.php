<?php
include("connetdb/conexion.php");
$con = conectar();
/**
 * se captura la id del cliente al pedir una orden del producto y nos muestra la orden del cliente
 */
$id = $_GET['id'];

$sql = "SELECT * FROM detalle_compra WHERE id_compra='$id'";
$query = mysqli_query($con, $sql);

//$row_detalle = mysqli_fetch_array($query);
?>
<!DOCTYPE html>
<html lang="en" xmlns:th="http://www.thymeleaf.org">

<head>
    <title>User Information and Form</title>

    <!--JQUERY-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

    <!-- FRAMEWORK BOOTSTRAP para el estilo de la pagina-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"
        integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous">
    </script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"
        integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous">
    </script>

    <!-- Los iconos tipo Solid de Fontawesome-->
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.8/css/solid.css">
    <script src="https://use.fontawesome.com/releases/v5.0.7/js/all.js"></script>

    <!-- Nuestro css-->
    <link rel="stylesheet" type="text/css" href="static/css/user-form.css" th:href="@{/css/user-form.css}">
    <!-- DATA TABLE -->
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.1/css/bootstrap.css">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css">

    <script type="text/javascript">
    $(document).ready(function() {
        //Asegurate que el id que le diste a la tabla sea igual al texto despues del simbolo #
        $('#userList').DataTable();
    });
    </script>
</head>

<body>
    <div class="container">
        <div class="mx-auto col-sm-12 main-section" id="myTab" role="tablist">
            <ul class="nav nav-tabs justify-content-end">
                <li class="nav-item">
                    <a class="nav-link active" id="form-tab" data-toggle="tab" href="#form" role="tab"
                        aria-controls="form" aria-selected="false">Detalles</a>
                </li>
            </ul>
            <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade show active" id="form" role="tabpanel" aria-labelledby="form-tab">
                    <div class="card">
                        <div class="card-header">
                            <h4>detalles del producto</h4>
                        </div>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table id="userLis" class="table table-bordered table-hover table-striped">
                                    <thead class="thead-light">
                                        <tr>
                                            <th>#</th>
                                            <th>ID compra</th>
                                            <th>ID producto</th>
                                            <th>nombre</th>
                                            <th>precio</th>
                                            <th>cantidad</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <?php
										while ($row_detalle = mysqli_fetch_array($query)/*mysqli_fetch_assoc($query)*/) {
										?>
                                        <tr>
                                            <th><?php echo $row_detalle['id']; ?></th>
                                            <th><?php echo $row_detalle['id_compra']; ?></th>
                                            <th><?php echo $row_detalle['id_producto']; ?></th>
                                            <th><?php echo $row_detalle['nombre']; ?></th>
                                            <th>$<?php echo number_format($row_detalle['precio'],0,'','.'); ?></th>
                                            <th><?php echo $row_detalle['cantidad']; ?></th>
                                        </tr>
                                        <?php
										}
										?>
                                    </tbody>
                                </table>
                                <div class="form-group row">
									<div class="col-lg-12 text-center">
										<a href="form.php"><input type="button" class="btn btn-secondary" value="Volver"></a>
										<!-- <input type="submit" class="btn btn-primary" value="Guardar Cambios"> -->
									</div>
								</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>

</html>