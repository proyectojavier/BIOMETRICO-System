<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Plantilla.Master" CodeBehind="BIO5.aspx.vb" Inherits="BIOMETRICO.BIO5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloPagina" runat="server">
 Biométricos
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
						</ul>
					</div>
					<div class="row">
						<div class="col-md-12">

                            <!-- Modal -->		

                                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
	                                <div class="modal-dialog" role="document">
		                                <div class="modal-content">
			                                <div class="modal-header">
				                                <h5 class="modal-title" id="exampleModalLabel">Crea Registro</h5>
				                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
					                                <span aria-hidden="true">&times;</span>
				                                </button>
			                                </div>
			                                <div class="modal-body">
				                               <div class="col-md-6 col-lg-8 ">
											        <div class="form-group">
												        <asp:Label ID="lblDescripcion" runat="server" Text="Ubicación del Reloj" Font-Bold="True"></asp:Label><p></p>
                                                        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" placeholder="Ubicación del Reloj" required MaxLength="50"></asp:TextBox>
											        </div>
                                                    <div class="form-group">
												        <asp:Label ID="lblIp" runat="server" Text="IP del Reloj" Font-Bold="True"></asp:Label><p></p>
                                                        <asp:TextBox ID="txtIP" runat="server" class="form-control" placeholder="IP del Reloj" required MaxLength="50"></asp:TextBox>
											        </div>
                                                    
                                                    <div class="form-group">
												        <asp:Label ID="Label5" runat="server" Text="Tipo del Reloj" Font-Bold="True"></asp:Label><p></p>
                                                              <div >
                                                               <asp:DropDownList ID="dplRelojes" 
                                                                                 name="CodigoReloj"
                                                                                 runat="server" 
                                                                                 AutoPostBack="false"  
                                                                                 DataTextField="DESCRIPCION_DEL_TIPO" 
                                                                                 DataValueField="CODIGO_DE_TIPO"
                                                                                 class="form-control col-md-7 col-xs-12"
                                                                                 placeholder="Seleccione el reloj" 
                                                                                 required="required">
                              
                                                               </asp:DropDownList>
                                                            </div>
											        </div>
                                                    <div class="form-group">
												         <asp:Label ID="Label4" runat="server" Text="Reloj en Uso" Font-Bold="True"></asp:Label><p></p>
                                                         <p>
                                                             <asp:RadioButton id="Radio1" GroupName="RegularMenu"
                                                                              Text="SI" runat="server" Checked="True" />
                                                        </p>
                                                      
                                                             <asp:RadioButton id="Radio2" GroupName="RegularMenu"
                                                                             Text ="NO" runat="server"/>
 
                                                      
											         </div>
										        </div>
			                                </div>
			                                <div class="modal-footer">
                                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="btn btn-success"/>
			                                </div>
		                                </div>
	                                </div>
                                </div>
                                    
                            <!-- End Modal -->

							<div class="card">
								<div class="card-header">
									<div class="d-flex align-items-left align-items-md-center flex-column flex-md-row">
							        <div>
								      <h4 class="card-title">Biométricos</h4>
							        </div>
							        <div class="ml-md-auto py-2 py-md-0">
								        <button type="button" class="btn btn-primary btn-round ml-auto" 
                                                data-toggle="modal" data-target="#exampleModal">
	                                            Crear Registro
                                        </button>
							        </div>
						        </div>
								</div>
								<div class="card-body">							
									<div class="table-responsive">  
                                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" 
                                               Height="500px" >
                                    <table class="table table-bordered table-bordered-bd-succfess table-head-bg-success table-hover" >
                                      <asp:Repeater ID="TablaDeDatos" runat="server" >
                                          <HeaderTemplate>
										        <thead>
											        <tr>
												        <th>#</th>
												        <th>Descripción</th>
												        <th>IP del Reloj</th>
                                                        <th>Reloj en Uso</th>
                                                        <th></th>
											        </tr>
										        </thead>
                                          </HeaderTemplate>
                                      <ItemTemplate>
										<tbody>
												<tr>
													<td><asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("CODIGO_DE_RELOJ") %>'/></td>
                                                    <td><asp:Label ID="lblNombrUnidad" runat="server" Text='<%# Eval("DESCRIPCION_DEL_RELOJ") %>' /></td>
                                                    <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("IP_DEL_RELOJ") %>' /></td>
                                                    <td><asp:Label ID="Label2" runat="server" Text='<%# Eval("RELOJ_EN_USO") %>' /></td>
													<td><asp:ImageButton ID="btiView" runat="server" ImageUrl="~/images/icons/File-View.png" 
                                                                         class="btn btn-info btn-xs btn-round disabled" ToolTip="Consultar" 
                                                                         CommandArgument='<%# Eval("CODIGO_DE_RELOJ") %>' OnClick="OnConsult"/>
                                                        <asp:ImageButton ID="btiEdit" runat="server" ImageUrl="~/images/icons/edit-icon.png" 
                                                                         class="btn btn-warning btn-xs btn-round disabled" ToolTip="Modificar" 
                                                                         CommandArgument='<%# Eval("CODIGO_DE_RELOJ") %>' OnClick="OnUpdate"/>
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
