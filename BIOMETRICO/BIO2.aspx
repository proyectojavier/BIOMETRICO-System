<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Plantilla.Master" CodeBehind="BIO2.aspx.vb" Inherits="BIOMETRICO.BIO2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloPagina" runat="server">
    Personal
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
						</ul>
					</div>
					<div class="row">
						<div class="col-md-12">
							<div class="card">
								<div class="card-header">
									<div class="d-flex align-items-center">
										<h4 class="card-title">Personal de Marcaje</h4>
									</div>
                                    <p></p>
                                    <div class="d-flex align-items-center">
                                          <table style="width: 40%;">
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblTextoNombrePersonal" runat="server" Text="Nombrel del Personal: " Font-Bold="True"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
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
                                      <asp:Repeater ID="TablaDeDatos" runat="server" onitemdatabound="TablaDeDatos_ItemDataBound">
                                          <HeaderTemplate>
										        <thead>
											        <tr>
												        <th>#</th>
												        <th>Nombre</th>
												        <th>Departamento</th>
                                                        <th>Código de Marcaje</th>
                                                        <th>Personal Activo</th>
                                                        <th></th>
											        </tr>
										        </thead>
                                          </HeaderTemplate>
                                      <ItemTemplate>
										<tbody>
												<tr>
													<td><asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("CODIGO_DE_PERSONAL") %>'/></td>
                                                    <td><asp:Label ID="lblNombrUnidad" runat="server" Text='<%# Eval("NOMBRE_DEL_PERSONAL") %>' /></td>
                                                    <td><asp:Label ID="lblLugarTrabajo" runat="server" Text='<%# Eval("LUGAR_DE_TRABAJO") %>' /></td>
                                                    <td><asp:Label ID="lblCodigoMarcaje" runat="server" Text='<%# Eval("CODIGO_MARCAJE_RELOJ") %>' /></td>
                                                    <td><asp:Label ID="lblActivo" runat="server" Text='<%# Eval("PERSONAL_ACTIVO") %>' /></td>
													<td><asp:ImageButton ID="btiView" runat="server" ImageUrl="~/images/icons/File-View.png" 
                                                                         class="btn btn-info btn-xs btn-round disabled" ToolTip="Ver Marcajes" 
                                                                         CommandArgument='<%# Convert.ToString(Eval("CODIGO_DE_PERSONAL")) + ";" + Eval("NOMBRE_DEL_PERSONAL")%>' OnClick="OnConsult"/>
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
