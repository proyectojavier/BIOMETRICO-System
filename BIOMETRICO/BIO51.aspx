<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Plantilla.Master" CodeBehind="BIO51.aspx.vb" Inherits="BIOMETRICO.BIO51" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloPagina" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPage" runat="server">

    <div class="main-panel">
    		<div class="content">
				<div class="page-inner">
					<div class="page-header">
						<h4 class="page-title">Biométricos</h4>
						<ul class="breadcrumbs">
							<li class="nav-home">
								<a href="#">
									<i class="flaticon-home"></i>
								</a>
							</li>
							<li class="separator">
								<i class="flaticon-right-arrow"></i>
							</li>
							<li class="nav-item">
								<a href="#">Dispositivos</a>
							</li>
							<li class="separator">
								<i class="flaticon-right-arrow"></i>
							</li>
							<li class="nav-item">
								<a href="#">Biométricos</a>
							</li>
                            <li class="separator">
								<i class="flaticon-right-arrow"></i>
							</li>
							<li class="nav-item">
								<a href="#">Modificar</a>
							</li>
						</ul>
					</div>

					<div class="row">
						<div class="col-md-12">
							<div class="card">
								<div class="card-header">
                                    <div class="d-flex align-items-center">
									  <div class="card-title">Datos del Modelo</div>
                                    </div>
								</div>
								<div class="card-body">
								  <div class="table-responsive">  
                                    <asp:Panel ID="Panel1" runat="server" Height="200px" >
                                        	<div class="col-md-6 col-lg-4">
											<div class="form-group">
                                                <asp:Label ID="lblCodigo" runat="server" Text="Código de Modelo" Font-Bold="True"></asp:Label><p></p>
                                                <asp:TextBox ID="txtCodigo" runat="server" class="form-control" placeholder="Código de Modelo"></asp:TextBox>
											</div>
											<div class="form-group">
												<asp:Label ID="lblDescripcion" runat="server" Text="Descripción del Modelo" Font-Bold="True"></asp:Label><p></p>
                                                <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" placeholder="Descripción del Modelo" required></asp:TextBox>
											</div>
										</div>
                                    </asp:Panel>
								  </div>
								</div>
                                <div class="card-action">
                                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="btn btn-success"/>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
            
            <footer class="footer">
				<div class="container-fluid">
					<nav class="pull-left">
						<ul class="nav">
							<li class="nav-item">
								<a class="nav-link" href="#">
									Ayuda
								</a>
							</li>
						</ul>
					</nav>
					<div class="copyright ml-auto">
						Sistema de Extracción de Datos del BIOMÉTRICO
					</div>				
				</div>
			</footer>
        </div>

</asp:Content>
