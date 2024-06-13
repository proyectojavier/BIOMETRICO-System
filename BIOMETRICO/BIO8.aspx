<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Plantilla.Master" CodeBehind="BIO8.aspx.vb" Inherits="BIOMETRICO.BIO8" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TituloPagina" runat="server">
	Generar Reporte 2
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyPage" runat="server">

     <div class="main-panel">
			<div class="content">
				<div class="page-inner">
					<div class="page-header">
						<h4 class="page-title">Marcajes por Departamento</h4>
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
								<a href="#">Reportes</a>
							</li>
							<li class="separator">
								<i class="flaticon-right-arrow"></i>
							</li>
							<li class="nav-item">
								<a href="#">Marcajes por Departamento</a>
							</li>
						</ul>
					</div>
					<div class="row">

          <!-- Encabezado de los relojes -->
                       <div class="col-md-12">
							<div class="card">
								<div class="card-header">
									<h4 class="card-title">Reporte Marcajes por Departamento</h4>
									
								</div>
                                <table style="width: 60%;">
                                    <tr>
                                        <td>
                                            <div class="card-body">
                                              <label>Seleccione la Unidad de Trabajo e Ingrese las Fechas Para Generar el Reporte</label>
                                                <table style="width:100%">
                                                  <tr>
                                                    <th></th>
													 <th></th>
                                                    <th></th>
                                                    <th></th>
                                                  </tr>
                                                  <tr>
													<td>
                                                     
                                                       <asp:DropDownList ID="dplUnidad" 
                                                                         name="CodigoUnidad"
                                                                         runat="server" 
                                                                         AutoPostBack="false"  
                                                                         DataTextField="LUGAR_DE_TRABAJO" 
                                                                         DataValueField="CODIGO_UNIDAD_TRABAJO"
                                                                         placeholder="Seleccione la Unidad Trabajo" 
                                                                         required="required">
                              
                                                       </asp:DropDownList>
                                                  

													</td>
													  <td>&ensp;</td>
                                                    <td> <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" Font-Bold="True" Font-Size="Medium" required></asp:TextBox> </td>
                                                    <td><asp:TextBox ID="txtFechaFinal" runat="server" TextMode="Date" Font-Bold="True" Font-Size="Medium" required></asp:TextBox>   </td>
                                                    <td><asp:Button ID="btnGenerar" runat="server" class="btn-round btn btn-secondary disabled" Text="Generar Reporte" /></td>
                                                  </tr>
                                                    
                                                    <CR:CrystalReportViewer ID="CRVReport" runat="server" AutoDataBind="true" />

                                                </table>                                                
									       </div>
                                        </td>
                                    </tr>
                                </table>
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
