Public Class AlertaManager
    Private Shared alertasActivas As New List(Of FormAlerta)()
    Private Shared ReadOnly alertasLock As New Object() ' Bloqueo para evitar concurrencia

    ' Muestra una nueva alerta sin bloquear la UI
    Public Shared Sub MostrarAlerta(mensaje As String, color As Color, Optional tipo As Integer = 3, Optional tiempo As Integer = 5)
        Dim nuevaAlerta As New FormAlerta(mensaje, color, tipo, tiempo)

        ' Asegurar ejecución en la UI
        If Application.OpenForms.Count > 0 Then
            Dim form As Form = Application.OpenForms(0)
            If form.InvokeRequired Then
                form.Invoke(New Action(Sub() MostrarAlertaInterno(nuevaAlerta)))
            Else
                MostrarAlertaInterno(nuevaAlerta)
            End If
        Else
            MostrarAlertaInterno(nuevaAlerta)
        End If
    End Sub
    ' Método interno para manejar la alerta en el hilo principal
    Private Shared Sub MostrarAlertaInterno(alerta As FormAlerta)
        SyncLock alertasLock
            alerta.StartPosition = FormStartPosition.Manual
            alerta.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - alerta.Width - 50, ObtenerPosicion())
            alertasActivas.Add(alerta)
        End SyncLock

        alerta.Show()
    End Sub
    ' Calcula la próxima posición en la pantalla
    Public Shared Function ObtenerPosicion() As Integer
        Dim pantallaAlto As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Dim alertaAlto As Integer = 70
        Dim margen As Integer = 10

        ' Calcular la posición Y de la nueva alerta
        Return pantallaAlto - ((alertaAlto + margen) * (alertasActivas.Count + 1))
    End Function

    ' Remueve la alerta de la lista y reorganiza las restantes
    Public Shared Sub RemoverAlerta(alerta As FormAlerta)
        SyncLock alertasLock
            alertasActivas.Remove(alerta)
            ReorganizarAlertas()
        End SyncLock
    End Sub

    ' Reorganiza las posiciones de las alertas activas
    Private Shared Sub ReorganizarAlertas()
        SyncLock alertasLock
            Dim alertaAlto As Integer = 70
            Dim margen As Integer = 10
            Dim pantallaAlto As Integer = Screen.PrimaryScreen.WorkingArea.Height

            For i As Integer = 0 To alertasActivas.Count - 1
                alertasActivas(i).Location = New Point(alertasActivas(i).Location.X, pantallaAlto - ((alertaAlto + margen) * (i + 1)))
            Next
        End SyncLock
    End Sub
End Class
