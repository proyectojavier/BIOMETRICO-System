<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Plantilla.Master" CodeBehind="BIO6.aspx.vb" Inherits="BIOMETRICO.BIO6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloPagina" runat="server">
	Extraer Marcajes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPage" runat="server">

      <div class="main-panel">
			<div class="content">
				<div class="page-inner">
					<div class="page-header">
						<h4 class="page-title">Extraer Marcajes</h4>
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
								<a href="#">Consultar Datos</a>
							</li>
							<li class="separator">
								<i class="flaticon-right-arrow"></i>
							</li>
							<li class="nav-item">
								<a href="#">Extraer Dato</a>
							</li>
						</ul>
					</div>
					<div class="row">

          <!-- Encabezado de los relojes -->
                       <div class="col-md-12">
							<div class="card">
								<div class="card-header">
									<h4 class="card-title">Relojes</h4>
									
								</div>
                                <table style="width: 60%;">
                                    <tr>
                                        <td>
                                            <div class="card-body">
                                              <label>Seleccione el Reloj:</label>
                                                     <div >
                                                       <asp:DropDownList ID="dplRelojes" 
                                                                         name="CodigoReloj"
                                                                         runat="server" 
                                                                         AutoPostBack="false"  
                                                                         DataTextField="DESCRIPCION_DEL_RELOJ" 
                                                                         DataValueField="CODIGO_DE_RELOJ"
                                                                         class="form-control col-md-7 col-xs-12"
                                                                         placeholder="Seleccione el reloj" 
                                                                         required="required">
                              
                                                       </asp:DropDownList>
                                                    </div>
									       </div>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <asp:Button ID="btnConectar" runat="server" class="btn-round btn btn-success disabled" Text="Conectar" />
                                                <asp:Button ID="btnDesconectar" runat="server" class="btn-round btn btn-danger disabled" Text="Desconectar" Enabled="False" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
							</div>
						</div>
          <!-- FIN Encabezado de los relojes -->              

          <!-- Botones de Extracción de la información -->
                       <div class="col-md-12">
							<div class="card">								
                                <table style="width: 310%;">
                                    <tr>
                                        <td>
                                            <div class="card-body">
                                              
                                             </div>
									       </div>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <asp:Button ID="btnConsultarMarcaje" runat="server" class="<i class='fa fa-lock'></i> btn btn-info" Text="Consultar Marcajes" Enabled="False" />
                                                 <asp:Button ID="btnTransferirMarcaje" runat="server" class="<i class='fa fa-lock'></i> btn btn-warning" Text="Transferir Marcajes" Enabled="False" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
							</div>          
					</div>
        <!-- FIN Botones de Extracción de la información -->

        <!-- Tabla De Marcajes del Biométrico -->
						    <div class="col-md-6">
							    <div class="card">
								    <div class="card-header">
									    <div class="card-title">Consultar Marcajes del Biométrico</div>
								    </div>
								    <div class="card-body">
									    <div class="card-sub">									
										    Consultar todos los registros de marcajes del Biométrico seleccionado</div>

                                        <div class="table-responsive">  
                                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" 
                                                   Height="500px" >
                                        <table id="Tabla_Marcajes_Biometrico" class="display table table-head-bg-info mt-4" >
                                          <asp:Repeater ID="TablaMarcajesBiometrico" runat="server" >
                                              <HeaderTemplate>
										            <thead>
											            <tr>
												            <th>Código</th>
												            <th>Fecha</th>
												            <th>Hora</th>
											            </tr>
										            </thead>
                                              </HeaderTemplate>
                                          <ItemTemplate>
										    <tbody>
												    <tr>
													    <td><asp:Label ID="lblCodigoMarcaje" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CODIGO_MARCAJE") %>'/></td>
                                                        <td><asp:Label ID="lblFechaMarcaje" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FECHA_MARCAJE") %>'/></td>
													    <td><asp:Label ID="lblHoraMarcaje" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HORA_MARCAJE") %>'/></td>
												    </tr>
                                            </tbody>
									      </ItemTemplate>
                                          <FooterTemplate>                                 	
                                          </FooterTemplate>
                                          </asp:Repeater>
                                         </table>									    
                                        </asp:Panel>
										   <asp:Label ID="lblTextoTotalMarcajes" runat="server" Text="Total de Marcajes:" Font-Bold="True" Font-Size="Medium"></asp:Label>
										   <asp:Label ID="lblTotalMarcajes" runat="server" Text="" Font-Bold="True" ForeColor="#000099" Font-Size="Medium"></asp:Label>
                                        </div>
								    </div>
							    </div>       
						    </div>
        <!-- FIN Tabla De Marcajes del Biométrico -->

        <!-- Tabla De Marcajes en la Base de Datos -->
                            <div class="col-md-6">
							    <div class="card">
								    <div class="card-header">
									    <div class="card-title">Registros de Marcajes en la Base de Datos</div>
								    </div>
								    <div class="card-body">
									    <div class="card-sub">									
										     Todos los registros de marcajes trasladado a la Base de Datos del Biométrico seleccionado </div>

                                       <div class="table-responsive"> 
                                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" 
                                                   Height="500px" >
                                        <table id="Tabla_Marcajes_BD" class="display table table-head-bg-warning mt-4" >
                                          <asp:Repeater ID="TablaMarcajesBD" runat="server" >
                                              <HeaderTemplate>
										            <thead>
											            <tr>
												            <th>Código</th>
												            <th>Fecha</th>
												            <th>Hora</th>
											            </tr>
										            </thead>
                                              </HeaderTemplate>
                                          <ItemTemplate>
										    <tbody>
												    <tr>
													    <td><asp:Label ID="lblCodigoBD" runat="server" Text='<%# Eval("CODIGO_DE_MARCAJE") %>'/></td>
                                                        <td><asp:Label ID="lblFechaBD" runat="server" Text='<%# FormatDateTime(Eval("FECHA_DE_MARCAJE"), DateFormat.ShortDate) %>'/></td>
													    <td><asp:Label ID="lblHoraBD" runat="server" Text='<%# Eval("HORA_DE_MARCAJE") %>'/></td>
												    </tr>
                                            </tbody>
									      </ItemTemplate>
                                          <FooterTemplate>                                 
                                          </FooterTemplate>
                                          </asp:Repeater>
                                         </table>									    
                                        </asp:Panel>
                                           <asp:Label ID="lblTextoTotalBD" runat="server" Text="Total de Marcajes:" Font-Bold="True" Font-Size="Medium"></asp:Label>
										   <asp:Label ID="lblTotalMarcajesBD" runat="server" Text="" Font-Bold="True" ForeColor="#006600" Font-Size="Medium"></asp:Label>
                                        </div>
								    </div>
								    </div>
						    </div>
        <!-- FIN Tabla De Marcajes en la Base de Datos -->

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
