Imports System.Data.SqlClient

Public Class BIO1
    Inherits System.Web.UI.Page
    Dim _con As New clsConexion
    Dim _query As New clsQuerys

    Dim DatTabla As New DataTable
    Dim Adapter As New SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If IsNothing(Session.Item("uValor").ToString) Then
                    Mensajes.MensajeExpiracion(Me.Page)
                Else
                    'TOTAL DE EMPLEADO DE MARCAJE'
                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT COUNT(*) AS TOTAL_EMPLEADOS_MARCAJE FROM VBIO_PERFIL_PERSONAL
                                                    WHERE PERSONAL_ACTIVO = 'SI'
                                                    AND CODIGO_DE_PERSONAL > 0
                                                    AND  CODIGO_DE_PERSONAL < 8888", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblTotalEmpleados.Text = FormatNumber(drfila("TOTAL_EMPLEADOS_MARCAJE").ToString.Trim, 0)
                    Next

                    'TOTAL MARCAJES DEL DIA'
                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT COUNT(*) AS MARCAJES_DEL_DIA FROM VBIO_MARCAJES_EMPLEADOS
                                                    WHERE FECHA_DE_MARCAJE = CONVERT(DATE,GETDATE(),105)", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblTotalMarcajesDia.Text = drfila("MARCAJES_DEL_DIA").ToString.Trim
                    Next

                    'TOTAL MARCAJES'
                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT COUNT(*) AS TOTAL_MARCAJES FROM VBIO_MARCAJES_EMPLEADOS
                                                    WHERE CODIGO_DE_RELOJ < 3
                                                    AND CODIGO_DE_MARCAJE > 0", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblTotalMarcajes.Text = drfila("TOTAL_MARCAJES").ToString.Trim
                    Next

                    'TOTAL DE BIOMETRICOS EN USO'
                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT COUNT(*) AS CANTIDAD_BIOMETRICOS FROM BIOMETRICOS_DE_MARCAJE
                                                  WHERE RELOJ_EN_USO = 'SI'", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblBiometricos.Text = drfila("CANTIDAD_BIOMETRICOS").ToString.Trim
                    Next

                    '-----------------------------------------------------------------------------------------'
                    '-----------------------------------------------------------------------------------------'
                    'TOTAL PERSONAL 011'
                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT COUNT(*) TIPO_PERSONAL FROM VBIO_PERFIL_PERSONAL
                                                  WHERE CODIGO_TIPO_PERSONAL = '011'
                                                  AND PERSONAL_ACTIVO = 'SI'
                                                  AND CODIGO_DE_PERSONAL > 0
                                                  AND  CODIGO_DE_PERSONAL < 8888", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblPersonal011.Text = drfila("TIPO_PERSONAL").ToString.Trim
                    Next

                    'TOTAL PERSONAL 021'
                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT COUNT(*) TIPO_PERSONAL FROM VBIO_PERFIL_PERSONAL
                                                  WHERE CODIGO_TIPO_PERSONAL = '021'
                                                  AND PERSONAL_ACTIVO = 'SI'
                                                  AND CODIGO_DE_PERSONAL > 0
                                                  AND  CODIGO_DE_PERSONAL < 8888", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblPersonal021.Text = drfila("TIPO_PERSONAL").ToString.Trim
                    Next

                    'TOTAL PERSONAL 022'
                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT COUNT(*) TIPO_PERSONAL FROM VBIO_PERFIL_PERSONAL
                                                  WHERE CODIGO_TIPO_PERSONAL = '022'
                                                  AND PERSONAL_ACTIVO = 'SI'
                                                  AND CODIGO_DE_PERSONAL > 0
                                                  AND  CODIGO_DE_PERSONAL < 8888", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblPersonal022.Text = drfila("TIPO_PERSONAL").ToString.Trim
                    Next

                    'TOTAL PERSONAL 031'
                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT COUNT(*) TIPO_PERSONAL FROM VBIO_PERFIL_PERSONAL
                                                  WHERE CODIGO_TIPO_PERSONAL = '031'
                                                  AND PERSONAL_ACTIVO = 'SI'
                                                  AND CODIGO_DE_PERSONAL > 0
                                                  AND  CODIGO_DE_PERSONAL < 8888", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblPersonal031.Text = drfila("TIPO_PERSONAL").ToString.Trim
                    Next

                    'TOTAL PERSONAL 035'
                    DatTabla = New DataTable
                    Adapter = New SqlDataAdapter("SELECT COUNT(*) TIPO_PERSONAL FROM VBIO_PERFIL_PERSONAL
                                                  WHERE CODIGO_TIPO_PERSONAL = '035'
                                                  AND PERSONAL_ACTIVO = 'SI'
                                                  AND CODIGO_DE_PERSONAL > 0
                                                  AND  CODIGO_DE_PERSONAL < 8888", _con.sqlConec)
                    Adapter.Fill(DatTabla)
                    For Each drfila As DataRow In DatTabla.Rows
                        lblPersonal035.Text = drfila("TIPO_PERSONAL").ToString.Trim
                    Next
                End If
            End If
        Catch ex As Exception
            If Err.Number = 91 Then 'Cuando la variable del inicio de sesión es NULL'
                Mensajes.MensajeExpiracion(Me.Page)
            Else
                Mensajes.MensajeError(Me.Page, ex.Message)
            End If
        End Try
    End Sub
End Class