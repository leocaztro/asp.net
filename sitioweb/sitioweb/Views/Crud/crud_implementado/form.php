<?php
include("connetdb/conexion.php");
$con = conectar();
/**
 * esta es la base de CRUD nos muestra la informacion de lista de producto, ingresar producto y la orden del cliente
 */
$sql = "SELECT * FROM semilla";
$query = mysqli_query($con, $sql);

?>
<!DOCTYPE html>
<html lang="en" xmlns:th="http://www.thymeleaf.org">

<head>
	<title>CRUD</title>

	<!--JQUERY-->
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>

	<!-- FRAMEWORK BOOTSTRAP para el estilo de la pagina-->
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
	<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>

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
		<!--col-sm-8-->
		<div class="mx-auto col-sm-20 main-section" id="myTab" role="tablist">
			<ul class="nav nav-tabs justify-content-end">
				<li class="nav-item">
					<a class="nav-link active" id="list-tab" data-toggle="tab" href="#list" role="tab" aria-controls="list" aria-selected="false">Lista</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" id="form-tab" data-toggle="tab" href="#form" role="tab" aria-controls="form" aria-selected="true">Ingresar Datos</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" id="for-tab" data-toggle="tab" href="#for" role="tab" aria-controls="for" aria-selected="true">lista de orden</a>
				</li>
			</ul>
			<div class="tab-content" id="myTabContent">
				<div class="tab-pane fade show active" id="list" role="tabpanel" aria-labelledby="list-tab">
					<div class="card">
						<div class="card-header">
							<h4>Lista</h4>
						</div>
						<div class="card-body">
							<div class="table-responsive">
								<table id="userList" class="table table-bordered table-hover table-striped">
									<thead class="thead-light">
										<tr>
											<th>#</th>
											<th>nombre de semilla</th>
											<th>descripcion</th>
											<th>precio</th>
											<th></th>
										</tr>
									</thead>
									<tbody>
										<?php
										while ($row = mysqli_fetch_assoc($query)) {
										?>
											<tr>
												<th><?php echo $row['ID_SEMILLA'] ?></th>
												<th><?php echo $row['NOMBRESEM'] ?></th>
												<th><?php echo $row['DESCR_SEMI'] ?></th>
												<th>$<?php echo $row['PRECIO_SEM'] ?></th>
												<td>
													<a href="actualizar.php?id=<?php echo $row['ID_SEMILLA'] ?>"><i class="fas fa-edit"></i></a> |
													<a href="CRUD/delete.php?id=<?php echo $row['ID_SEMILLA'] ?>"><i class="fas fa-user-times"></i></a>
												</td>
											</tr>
										<?php
										}
										?>
									</tbody>
								</table>
							</div>
						</div>
					</div>
				</div>
				<div class="tab-pane fade" id="form" role="tabpanel" aria-labelledby="form-tab">
					<div class="card">
						<div class="card-header">
							<h4>ingrese datos:</h4>
						</div>
						<div class="card-body">
							<form class="form" role="form" autocomplete="off" action="CRUD/insertar.php" method="POST">
								<div class="form-group row text-center">
									<label class="col-lg-4 col-form-label form-control-label">Codigo semilla:</label>
									<div class="col-lg-6 text-center">
										<input class="form-control" type="text" name="cod">
									</div>
								</div>
								<div class="form-group row text-center">
									<label class="col-lg-4 col-form-label form-control-label">nombre de semilla:</label>
									<div class="col-lg-6 text-center">
										<input class="form-control" type="text" name="nombre">
									</div>
								</div>
								<div class="form-group row text-center">
									<label class="col-lg-4 col-form-label form-control-label">descripcion:</label>
									<div class="col-lg-6 text-center">
										<!--<input class="form-control" type="text" name="descrip">-->
										<textarea name="descrip" class="form-control"></textarea>
									</div>
								</div>
								<div class="form-group row text-center">
									<label class="col-lg-4 col-form-label form-control-label">precio:</label>
									<div class="col-lg-6 text-center">
										<input class="form-control" type="text" name="precio">
									</div>
								</div>
								<div class="form-group row">
									<div class="col-lg-12 text-center">
										<input type="reset" class="btn btn-secondary" value="Cancelar">
										<input type="submit" class="btn btn-primary" value="Enviar">
									</div>
								</div>
							</form>
						</div>
					</div>
				</div>					
				<div class="tab-pane fade" id="for" role="tabpanel" aria-labelledby="for-tab">
					<?php 
					$sqlcompra = "SELECT * FROM compra";
					$queryy = mysqli_query($con, $sqlcompra);
					?>
					<div class="card">
						<div class="card-header">
							<h4>orden del producto</h4>
						</div>
						<div class="card-body">
							<div class="table-responsive">
								<table id="userLis" class="table table-bordered table-hover table-striped">
									<thead class="thead-light">
										<tr>
											<th>#</th>
											<th>ID transaccion</th>
											<th>fecha</th>
											<th>estado</th>
											<th>E-mail</th>
											<th>cliente</th>
											<th>el pago</th>
											<th></th>
										</tr>
									</thead>
									<tbody>
										<?php
										while ($row_compra = mysqli_fetch_assoc($queryy)) {
										?>
											<tr>
												<th><?php echo $row_compra['Id']; ?></th>
												<th><?php echo $row_compra['id_transaccion']; ?></th>
												<th><?php echo $row_compra['fecha']; ?></th>
												<th><?php echo $row_compra['status']; ?></th>
												<th><?php echo $row_compra['email']; ?></th>
												<th><?php echo $row_compra['Id_cliente']; ?></th>
												<th>$<?php echo $row_compra['total']; ?></th>
												<td>
													<a href="detalles.php?id=<?php echo $row_compra['Id'] ?>"><i class="fas fa-edit"></i></a>
													<!-- <a href="CRUD/delete.php?id=<?php //echo $row['ID_SEMILLA'] ?>"><i class="fas fa-user-times"></i></a> -->
												</td>
											</tr>
										<?php
										}
										?>
									</tbody>
								</table>
							</div>
						</div>
					</div>
				</div>

			</div>
		</div>
	</div>
</body>

</html>