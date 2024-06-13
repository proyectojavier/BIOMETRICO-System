<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Plantilla.Master" CodeBehind="BIO1.aspx.vb" Inherits="BIOMETRICO.BIO1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloPagina" runat="server">
    Indice
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPage" runat="server">

    <div class="main-panel">
				<div class="content">
					<div class="panel-header bg-primary-gradient">
						<div class="page-inner py-5">
							<div class="d-flex align-items-left align-items-md-center flex-column flex-md-row">
								<div>
									<h2 class="text-white pb-2 fw-bold"></h2>
									<h5 class="text-white op-7 mb-2"></h5>
								</div>
								<div class="ml-md-auto py-2 py-md-0">
									
								</div>
							</div>
						</div>
					</div>
					<div class="page-inner mt--5">
						<div class="row row-card-no-pd mt--2">
							<div class="col-sm-6 col-md-3">
								<div class="card card-stats card-round">
									<div class="card-body ">
										<div class="row">
											<div class="col-5">
												<div class="icon-big text-center">
													<i class="flaticon-user-2 text-warning"></i>
												</div>
											</div>
											<div class="col-7 col-stats">
												<div class="numbers">
													<p class="card-category">Total de Empleados Activos de Marcaje</p>
													<h4 class="card-title"><asp:Label ID="lblTotalEmpleados" runat="server" Text="10">
														                   </asp:Label></h4>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-sm-6 col-md-3">
								<div class="card card-stats card-round">
									<div class="card-body ">
										<div class="row">
											<div class="col-5">
												<div class="icon-big text-center">
													<i class="flaticon-calendar text-success"></i>
												</div>
											</div>
											<div class="col-7 col-stats">
												<div class="numbers">
													<p class="card-category">Total de Marcajes del Día &ensp;</p>&ensp;
													<h4 class="card-title"><asp:Label ID="lblTotalMarcajesDia" runat="server" Text="50">
														                  </asp:Label></h4>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-sm-6 col-md-3">
								<div class="card card-stats card-round">
									<div class="card-body">
										<div class="row">
											<div class="col-5">
												<div class="icon-big text-center">
													<i class="flaticon-list text-danger"></i>
												</div>
											</div>
											<div class="col-7 col-stats">
												<div class="numbers">
													<p class="card-category">Total de Marcajes</p>&ensp;
													<h4 class="card-title"><asp:Label ID="lblTotalMarcajes" runat="server" Text="100">
														                  </asp:Label></h4>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-sm-6 col-md-3">
								<div class="card card-stats card-round">
									<div class="card-body">
										<div class="row">
											<div class="col-5">
												<div class="icon-big text-center">
													<i class="flaticon-stopwatch text-primary"></i>
												</div>
											</div>
											<div class="col-7 col-stats">
												<div class="numbers">
													<p class="card-category">Biométricos en Uso</p>&nbsp; &nbsp;
													<h4 class="card-title"><asp:Label ID="lblBiometricos" runat="server" Text="Label">
														                   </asp:Label></h4>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>

						<div class="row">
							<div class="col-md-4">
								<div class="card">
									<div class="card-header">
										<div class="card-title">Tipos de Personal de Marcaje</div>
									</div>
									<div class="card-body pb-0">
										<div class="d-flex">
											<div class="avatar">
												<img src="../assets/img/personal1.svg" alt="..." class="avatar-img rounded-circle">
											</div>
											<div class="flex-1 pt-1 ml-2">
												<h6 class="fw-bold mb-1">011</h6>
												<small class="text-muted">Personal Permanente</small>
											</div>
											<div class="d-flex ml-auto align-items-center">
												<h3 class="text-info fw-bold">
                                                    <asp:Label ID="lblPersonal011" runat="server" Text="Label"></asp:Label></h3>
											</div>
										</div>
										<div class="separator-dashed"></div>
										<div class="d-flex">
											<div class="avatar">
												<img src="../assets/img/personal2.svg" alt="..." class="avatar-img rounded-circle">
											</div>
											<div class="flex-1 pt-1 ml-2">
												<h6 class="fw-bold mb-1">021</h6>
												<small class="text-muted">Personal Supernumerario</small>
											</div>
											<div class="d-flex ml-auto align-items-center">
												<h3 class="text-info fw-bold">
                                                    <asp:Label ID="lblPersonal021" runat="server" Text="Label"></asp:Label></h3>
											</div>
										</div>
										<div class="separator-dashed"></div>
										<div class="d-flex">
											<div class="avatar">
												<img src="../assets/img/personal3.svg" alt="..." class="avatar-img rounded-circle">
											</div>
											<div class="flex-1 pt-1 ml-2">
												<h6 class="fw-bold mb-1">022</h6>
												<small class="text-muted">Personal por Contrato</small>
											</div>
											<div class="d-flex ml-auto align-items-center">
												<h3 class="text-info fw-bold">
                                                    <asp:Label ID="lblPersonal022" runat="server" Text="Label"></asp:Label></h3>
											</div>
										</div>
										<div class="separator-dashed"></div>
										<div class="d-flex">
											<div class="avatar">
												<img src="../assets/img/personal4.svg" alt="..." class="avatar-img rounded-circle">
											</div>
											<div class="flex-1 pt-1 ml-2">
												<h6 class="fw-bold mb-1">031</h6>
												<small class="text-muted">Jornales</small>
											</div>
											<div class="d-flex ml-auto align-items-center">
												<h3 class="text-info fw-bold">
                                                    <asp:Label ID="lblPersonal031" runat="server" Text="Label"></asp:Label></h3>
											</div>
										</div>
										<div class="separator-dashed"></div>
										<div class="d-flex">
											<div class="avatar">
												<img src="../assets/img/personal5.svg" alt="..." class="avatar-img rounded-circle">
											</div>
											<div class="flex-1 pt-1 ml-2">
												<h6 class="fw-bold mb-1">035</h6>
												<small class="text-muted">Retribuciones a Destajo</small>
											</div>
											<div class="d-flex ml-auto align-items-center">
												<h3 class="text-info fw-bold">
                                                    <asp:Label ID="lblPersonal035" runat="server" Text="Label"></asp:Label></h3>
											</div>
										</div>
										<div class="separator-dashed"></div>
										<div class="pull-in">
											<canvas id="topProductsChart"></canvas>
										</div>
									</div>
								</div>
							</div>
							<div class="col-md-4">
								<div class="card">
									<div class="card-body">
										<div class="card-title fw-mediumbold">Biométricos en Uso</div>
										<div class="card-list">
											<div class="item-list">
												<div class="avatar">
													<img src="../assets/img/marcaje1.jpg" alt="..." class="avatar-img rounded-circle">
												</div>
												<div class="info-user ml-3">
													<div class="username">Administración</div>
													<div class="status">Oficinas Centrales</div>
												</div>
											</div>
											<div class="item-list">
												<div class="avatar">
													<img src="../assets/img/marcaje2.jpg" alt="..." class="avatar-img rounded-circle">
												</div>
												<div class="info-user ml-3">
													<div class="username">Técnico</div>
													<div class="status">Salón 10</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-md-4">
								<div class="card card-primary bg-primary-gradient">
									<div class="card-body">
										<h4 class="mt-3 b-b1 pb-2 mb-4 fw-bold">Active user right now</h4>
										<h1 class="mb-4 fw-bold">17</h1>
										<h4 class="mt-3 b-b1 pb-2 mb-5 fw-bold">Page view per minutes</h4>
										<div id="activeUsersChart"></div>
										<h4 class="mt-5 pb-3 mb-0 fw-bold">Top active pages</h4>
										<ul class="list-unstyled">
											<li class="d-flex justify-content-between pb-1 pt-1"><small>/product/readypro/index.html</small> <span>7</span></li>
											<li class="d-flex justify-content-between pb-1 pt-1"><small>/product/atlantis/demo.html</small> <span>10</span></li>
										</ul>
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
