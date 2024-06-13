<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BIO.aspx.vb" Inherits="BIOMETRICO.BIO" %>

<!DOCTYPE html>

<html lang="en">
<head>
	<title>Login</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">
<!--===============================================================================================-->
     <!-- mensajes para mostrar -->
    <link rel="stylesheet" href="assets/css/sweetalert.css"  />
    <!-- Sweet Alert -->
    <script src="assets/js/plugin/sweetalert/sweetalert.min.js" type ="text/javascript"></script>


</head>
<body>
	
	<div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<div class="login100-form-title" style="background-image: url(images/bg-01.jpg);">
					<span class="login100-form-title-1">
						LOGIN
					</span>
				</div>

				 <form id="FormLogin" method="post" runat="server" class="login100-form validate-form">
					<div class="wrap-input100 validate-input m-b-26" data-validate="Ingrese su código de usuario">
						<span class="label-input100">Usuario:</span>
						   <asp:TextBox ID="txtCodigoUsuario" runat="server" class="input100 text-uppercase" placeholder="Ingrese el código de usuario" Font-Bold="True" ForeColor="Black" TabIndex="1"></asp:TextBox>
						<span class="focus-input100"></span>
                       
					</div>

					<div class="wrap-input100 validate-input m-b-18" data-validate = "Ingrese su contraseña">
						<span class="label-input100">Contraseña:</span>
                        <asp:TextBox ID="txtContraseñaUsuario" runat="server" class="input100" placeholder="Ingrese la Contraseña" Font-Bold="True" ForeColor="Black" TabIndex="2" TextMode="Password"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>

					<div class="flex-sb-m w-full p-b-30">
						<div class="contact100-form-checkbox">
                            <asp:Label ID="lblMensaje" runat="server" Text="" Font-Bold="True" ForeColor="Red" ></asp:Label>
						</div>
					</div>

					<div class="container-login100-form-btn">
                         <asp:Button ID="btnLogin" runat="server" Text="Ingresar" class="login100-form-btn"/>                     
					</div>
				</form>
			</div>
		</div>
	</div>
	
<!--===============================================================================================-->
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>

 <!-- Bootstrap Notify -->
	<script src="assets/js/plugin/bootstrap-notify/bootstrap-notify.min.js"></script>   

   <script>
       $(function fAlerta(mensaje){
            var placementFrom = 'top';
			var placementAlign ='center';
			var state = 'warning';
			var style = 'withicon';
			var content = {};

            content.message = mensaje;
			content.title = 'Error al iniciar sesión ';
			if (style == "withicon") {
				content.icon = 'fa fa-bell';
			} else {
				content.icon = 'none';
			}
			content.url = 'index.html';
			content.target = '_blank';

			$.notify(content,{
				type: state,
				placement: {
					from: placementFrom,
					align: placementAlign
				},
				time: 1000,
				delay: 0,
			});
		}));
	</script>
</body>
</html>
