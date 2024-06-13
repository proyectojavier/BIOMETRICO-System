Imports System.Runtime.CompilerServices
Module Mensajes
    Dim vQuitarPalabras As String

    <Extension()>
    Sub MensajeError(ByVal vPage As Page, ByVal vMessage As String)
        If vMessage.Contains("'") Then
            vQuitarPalabras = vMessage.Replace("'", "")
        ElseIf vMessage.Contains("""") Then
            vQuitarPalabras = vMessage.Replace("""", "")
        Else
            vQuitarPalabras = vMessage
        End If

        vQuitarPalabras = quitarSaltosLinea(vQuitarPalabras, "")
        vPage.ClientScript.RegisterStartupScript(vPage.GetType,
                                                 "mensaje",
                                                 "<script> swal('EROOR!', '" + vQuitarPalabras + "', 'error') </script>")
    End Sub
    Private Function quitarSaltosLinea(ByVal texto As String, caracterReemplazar As String) As String
        quitarSaltosLinea = Replace(Replace(texto, Chr(10), caracterReemplazar), Chr(13), caracterReemplazar)
    End Function
    Sub MensajeExpiracion(ByVal vPage As Page)
        'vPage.ClientScript.RegisterStartupScript(vPage.GetType,
        '                                         "mensaje",
        '                                         "<script> swal({
        '                                                   icon: 'error',
        '                                                  title: '¡Error!',
        '                                                  showConfirmButton: true,
        '                                                  confirmButtonText: 'Cerrar',
        '                                                  closeOnConfirm: false
        '                                                }). then(function(result){
        '                                                  window.location = 'BIO.aspx';
        '                                                             }) </script>")
        vPage.ClientScript.RegisterStartupScript(vPage.GetType(),
                                                 "MessageBox",
                                                 "<script type='text/javascript'>
                                                         alert('Se expiro la sesión');
                                                         window.location.href = 'BIO.aspx';
                                                 </script>")
    End Sub
    Sub MensajeCierreSesion(ByVal vPage As Page)
        vPage.ClientScript.RegisterStartupScript(vPage.GetType(),
                                                 "MessageBox",
                                                 "<script type='text/javascript'>
                                                         window.location.href = 'BIO.aspx';
                                                 </script>")
    End Sub
    Sub MensajeCorrecto(ByVal vPage As Page, ByVal vMessage As String)
        vPage.ClientScript.RegisterStartupScript(vPage.GetType,
                                                 "mensaje",
                                                 "<script> swal('Correcto!', '" + vMessage + "', 'success') </script>")
    End Sub
    Sub MensajeAdvertencia(ByVal vPage As Page, ByVal vMessage As String)
        vPage.ClientScript.RegisterStartupScript(vPage.GetType,
                                                 "mensaje",
                                                 "<script> swal('Advertencia!', '" + vMessage + "', 'warning') </script>")
    End Sub

    Sub MensajeEliminacion(ByVal vPage As Page, ByVal vMessage As String, ByVal vCodigoMarcaje As String,
                           ByVal vFechaMarcaje As String, ByVal vHoraMarcajes As String)
        'vPage.ClientScript.RegisterStartupScript(vPage.GetType,
        '                                         "mensaje",
        '                                         "<script> 
        '                                            swal({
        '                                                  title: 'Sweet!',
        '                                                  text: 'Here's a custom image.'
        '                                                }); 
        '                                         </script>")
        vPage.ClientScript.RegisterStartupScript(vPage.GetType,
                                                 "mensaje",
                                                 "<script> swal({
                                                              title: 'Esta Seguro de Eliminar el Rgistro?',
                                                              text: '" + vMessage + "'!,
                                                              type: 'warning',
                                                              showCancelButton: true,
                                                              confirmButtonClass: 'btn-danger',
                                                              confirmButtonText: 'SI',
                                                              closeOnConfirm: false
                                                            }). then(function(result){
                                                                 swal('Eliminado', 'Registro eliminado', 'success');
                                                            });
                                                   </script>")


        'vPage.ClientScript.RegisterStartupScript(vPage.GetType,
        '                                         "mensaje",
        '                                         "<script> swal({
        '                                                   icon: 'error',
        '                                                  title: '¡Error!',
        '                                                  showConfirmButton: true,
        '                                                  confirmButtonText: 'Cerrar',
        '                                                  closeOnConfirm: false
        '                                                }). then(function(result){
        '                                                  window.location = 'BIO.aspx';
        '                                                             }) </script>")
    End Sub
End Module
