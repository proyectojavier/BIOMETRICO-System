<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Plantilla.Master" CodeBehind="BIO3.aspx.vb" Inherits="BIOMETRICO.BIO3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloPagina" runat="server">
Total de Marcajes

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPage" runat="server">

    <div class="main-panel">
			<div class="content">
				<div class="page-inner">
					<div class="page-header">
						<h4 class="page-title">Personal</h4>
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
								<a href="#">Personal</a>
							</li>
							<li class="separator">
								<i class="flaticon-right-arrow"></i>
							</li>
							<li class="nav-item">
								<a href="#">Total de Marcajes</a>
							</li>
						</ul>
					</div>
					<div class="row">
						<div class="col-md-12">
							<div class="card">
								<div class="card-header">
									<div class="d-flex align-items-center">
										<h4 class="card-title">Marcajes de los Empleados</h4>
									</div>
                                    <p></p>
                                    <div class="d-flex align-items-center">
                                          <table style="width: 45%;">
                                            <tr>
                                                <td></td>
                                                <td>
                                                     <asp:Label ID="lblTextoFechaInicio" runat="server" Text="Fecha de Inicio" Font-Bold="True" 
                                                               ForeColor="Maroon" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Final" Font-Bold="True" 
                                                               ForeColor="Maroon" Font-Size="Medium"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" required="true"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFechaFinal" runat="server" TextMode="Date" required="true"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-info  ml-auto btn-sm"/>
                                                </td>
                                            </tr>
                                        </table>            
									</div>
                                
								</div>
								<div class="card-body">
									<!-- Modal -->								
									<div class="table-responsive">  
                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" 
                                               Height="500px" >
                                    <table class="table table-bordered table-bordered-bd-succfess table-head-bg-success table-hover" >
                                      <asp:Repeater ID="TablaDeDatos" runat="server" >
                                          <HeaderTemplate>
										        <thead>
											        <tr>
                                                        <th>Código de Marcaje</th>
                                                        <th>Nombre del Empleado</th>
												        <th>Fecha Marcaje</th>
												        <th>Hora Marcaje 1</th>
														<th>Hora Marcaje 2</th>
														<th>Hora Marcaje 3</th>
														<th>Hora Marcaje 4</th>
														<th>Hora Marcaje 5</th>
														<th>Hora Marcaje 6</th>
														<th>Hora Marcaje 7</th>
														<th>Hora Marcaje 8</th>
														<th>Hora Marcaje 9</th>
														<th>Hora Marcaje 10</th>
											        </tr>
										        </thead>
                                          </HeaderTemplate>
                                      <ItemTemplate>
										<tbody>
												<tr>
                                                    <td><asp:Label ID="lblCodigoMarcaje" runat="server" Text='<%# Eval("CODIGO_DE_MARCAJE") %>' /></td>
                                                    <td><asp:Label ID="lblNombrePersonal" runat="server" Text='<%# Eval("NOMBRE_DEL_PERSONAL") %>' /></td>
													<td><asp:Label ID="lblFechaMarcaje" runat="server" Text='<%# FormatDateTime(Eval("FECHA_DE_MARCAJE"), DateFormat.ShortDate) %>'/></td>
                                                    <td><asp:Label ID="lblHoraMarcaje1" runat="server" Text='<%# Eval("MARCA1") %>' /></td>
													<td><asp:Label ID="lblHoraMarcaje2" runat="server" Text='<%# Eval("MARCA2") %>' /></td>
													<td><asp:Label ID="lblHoraMarcaje3" runat="server" Text='<%# Eval("MARCA3") %>' /></td>
													<td><asp:Label ID="lblHoraMarcaje4" runat="server" Text='<%# Eval("MARCA4") %>' /></td>
													<td><asp:Label ID="lblHoraMarcaje5" runat="server" Text='<%# Eval("MARCA5") %>' /></td>
													<td><asp:Label ID="lblHoraMarcaje6" runat="server" Text='<%# Eval("MARCA6") %>' /></td>
													<td><asp:Label ID="lblHoraMarcaje7" runat="server" Text='<%# Eval("MARCA7") %>' /></td>
													<td><asp:Label ID="lblHoraMarcaje8" runat="server" Text='<%# Eval("MARCA8") %>' /></td>
													<td><asp:Label ID="lblHoraMarcaje9" runat="server" Text='<%# Eval("MARCA9") %>' /></td>
													<td><asp:Label ID="lblHoraMarcaje10" runat="server" Text='<%# Eval("MARCA10") %>' /></td>
												</tr>
                                        </tbody>
									  </ItemTemplate>
                                      <FooterTemplate>                                 
	
                                      </FooterTemplate>
                                      </asp:Repeater>
                                     </table>
                                    </asp:Panel>
									</div>
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
