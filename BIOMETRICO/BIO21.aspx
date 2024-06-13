<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Plantilla.Master" CodeBehind="BIO21.aspx.vb" Inherits="BIOMETRICO.BIO21" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloPagina" runat="server">
 Marcajes del Empleado
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
								<a href="#">Personal de Marcaje</a>
							</li>
                            <li class="separator">
								<i class="flaticon-right-arrow"></i>
							</li>
                            <li class="nav-item">
								<a href="#">Ver Marcajes</a>
							</li>
						</ul>
					</div>
					<div class="row">
						<div class="col-md-12">
							<div class="card">
								<div class="card-header">
									<div class="d-flex align-items-center">
										<h4 class="card-title">Marcajes del Empleado</h4>
									</div>
                                    <p></p>
                                    <div class="d-flex align-items-center">
                                          <table style="width: 88%;">
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblTextoCodigoPersonall" runat="server" Text="Código del Personal: " 
                                                               Font-Bold="True"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCodigoPersonal" runat="server" Text="175" Font-Bold="True" 
                                                               ForeColor="Maroon" Font-Size="Medium"></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="lblTextoFechaInicio" runat="server" Text="Fecha de Inicio" Font-Bold="True" 
                                                               ForeColor="Maroon" Font-Size="Medium" ></asp:Label>
                                                </td>
                                                <td>
                                                     <asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Final" Font-Bold="True" 
                                                               ForeColor="Maroon" Font-Size="Medium"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td> <asp:Label ID="lblTextoNombrePersonal" runat="server" Text="Nombrel del Personal: " 
                                                               Font-Bold="True"></asp:Label>
                                                </td>
                                                <td><asp:Label ID="lblNombrePersonal" runat="server" Text="Francisco Javier GOnzalez Armas" 
                                                               Font-Bold="True" ForeColor="Maroon" Font-Size="Medium"></asp:Label>
                                                </td>
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
                                                        <th></th>
												        <th>Fecha Marcaje</th>
												        <th>Hora Marcaje</th>
								                        <th></th>
											        </tr>
										        </thead>
                                          </HeaderTemplate>
                                      <ItemTemplate>
										<tbody>
												<tr>
                                                    <td><asp:Label ID="lblCodigoMarcaje" runat="server" Text='<%# Eval("CODIGO_DE_MARCAJE") %>' Visible="False" /></td>
													<td><asp:Label ID="lblFechaMarcaje" runat="server" Text='<%# FormatDateTime(Eval("FECHA_DE_MARCAJE"), DateFormat.ShortDate) %>'/></td>
                                                    <td><asp:Label ID="lblHoraMarcaje" runat="server" Text='<%# Eval("HORA_DE_MARCAJE") %>' /></td>
													<td><asp:ImageButton ID="btEliminar" runat="server" ImageUrl="~/images/icons/close-icon.png"
                                                                         class="btn btn-danger btn-xs btn-round disabled" ToolTip="Eliminar Marcaje" 
                                                                         CommandArgument='<%# Convert.ToString(Eval("CODIGO_DE_MARCAJE")) + ";" +
                                                                                                                                  Convert.ToString(Eval("FECHA_DE_MARCAJE")) + ";" +
                                                                                                                                  Convert.ToString(Eval("HORA_DE_MARCAJE")) %>' OnClick="OnDelete"
                                                                         OnClientClick="return confirm('Esta seguro de eliminar el registro?');"/>
                                                    </td>
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
