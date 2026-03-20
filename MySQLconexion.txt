Imports System.Data
Imports System.IO
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Public Class MySQLconexion
    Private myConexion As MySqlConnection
    Private m_ServerName As String = ""
    Private m_Port As String = ""
    Private m_DataBase As String = ""
    Private m_Usuario As String = ""
    Private m_Password As String = ""
    Private m_ConnectionLifetime As String = "" 'Connection Lifetime
    Public s_error As String

    ' Singleton para conexión única
    Private Shared _instance As MySQLconexion
    Public Shared ReadOnly Property Instance As MySQLconexion
        Get
            If _instance Is Nothing Then
                _instance = New MySQLconexion()
            End If
            Return _instance
        End Get
    End Property

    ' Conectar a la base de datos
    Public Function Connect() As MySqlConnection
        ResetConnection() ' Reinicia la conexión si está cerrada o desechada

        If LoadConfig("tsconfig.json") Then
            Dim sCadenaConexion As String = $"Database={m_DataBase};Port={m_Port};Data Source={m_ServerName};Uid={m_Usuario};Pwd={m_Password};Connection Lifetime={If(String.IsNullOrEmpty(m_ConnectionLifetime), "300", m_ConnectionLifetime)};"
            Try
                If myConexion Is Nothing Then
                    myConexion = New MySqlConnection(sCadenaConexion)
                End If

                If myConexion.State = ConnectionState.Closed Then
                    myConexion.Open()
                End If
            Catch ex As MySqlException
                s_error = $"Error de conexión: {ex.Message}"
                Debug.Print(s_error)
                Throw New Exception($"Error al conectar con la base de datos: {ex.Message}")
            End Try
        Else
            Throw New Exception("No se pudo cargar la configuración de la base de datos.")
        End If

        Return myConexion
    End Function

    ' Desconectar de la base de datos
    Public Function Disconnect() As MySqlConnection
        Try
            If myConexion IsNot Nothing AndAlso myConexion.State = ConnectionState.Open Then
                myConexion.Close()
            End If
            myConexion?.Dispose()
            myConexion = Nothing
        Catch ex As MySqlException
            LogError(ex)
            s_error = $"Error de conexión: {ex.Message}"
            Debug.Print(s_error)
            Throw New Exception($"Error al conectar con la base de datos: {ex.Message}")
        End Try
        Return myConexion
    End Function

    ' Validar estado de conexión
    Public Function IsConnected() As Boolean
        Return myConexion IsNot Nothing AndAlso myConexion.State = ConnectionState.Open
    End Function

    ' Obtener errores
    Public Function GetError() As String
        Return s_error
    End Function

    ' Método para cargar configuración desde un archivo JSON
    Private Function LoadConfig(filePath As String) As Boolean
        Try
            ' Obtener el directorio base de ejecución
            Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory

            ' Subir dos niveles para llegar a "bin"
            Dim binDirectory As String = Directory.GetParent(Directory.GetParent(baseDirectory).FullName).FullName

            ' Construir la ruta del archivo tsconfig.json
            Dim iniDirectory As String = Path.Combine(binDirectory, "Ini")

            Dim configPath As String = Path.Combine(iniDirectory, filePath)

            If File.Exists(configPath) Then
                Dim json As String = File.ReadAllText(configPath)
                Debug.Print($"Contenido del archivo JSON: {json}")
                Dim config As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)

                ' Validar que todas las claves estén presentes
                If config.ContainsKey("DB_SERVER_MY") Then m_ServerName = config("DB_SERVER_MY")
                If config.ContainsKey("DB_PORT_MY") Then m_Port = config("DB_PORT_MY")
                If config.ContainsKey("DB_NAME_MY") Then m_DataBase = config("DB_NAME_MY")
                If config.ContainsKey("DB_USER_MY") Then m_Usuario = config("DB_USER_MY")
                If config.ContainsKey("DB_PASSWORD_MY") Then m_Password = config("DB_PASSWORD_MY")
                If config.ContainsKey("Connection Lifetime") Then m_ConnectionLifetime = config("Connection Lifetime")

                Debug.Print($"Configuración cargada: Server={m_ServerName}, Port={m_Port}, Database={m_DataBase}, User={m_Usuario}")

                If String.IsNullOrEmpty(m_ServerName) OrElse String.IsNullOrEmpty(m_Port) OrElse
                   String.IsNullOrEmpty(m_DataBase) OrElse String.IsNullOrEmpty(m_Usuario) OrElse
                   String.IsNullOrEmpty(m_Password) Then
                    Throw New Exception("La configuración de la base de datos está incompleta o inválida.")
                End If
                Return True
            Else
                s_error = $"Archivo de configuración no encontrado: {filePath}"
                Debug.Print(s_error)
                Return False
            End If
        Catch ex As Exception
            s_error = $"Error al cargar configuración: {ex.Message}"
            Debug.Print(s_error)
            Return False
        End Try
    End Function

    Public Sub ResetConnection()
        If myConexion IsNot Nothing AndAlso (myConexion.State = ConnectionState.Closed OrElse myConexion.State = ConnectionState.Broken) Then
            myConexion.Dispose()
            myConexion = Nothing
        End If
    End Sub

    ' Método para ejecutar consultas
    Public Function ExecuteQuery(query As String, parameters As Dictionary(Of String, Object)) As DataTable
        Dim table As New DataTable()
        Try
            Using connection = Connect()
                If connection.State <> ConnectionState.Open Then
                    Throw New Exception("La conexión con la base de datos no está abierta.")
                End If
                Using command As New MySqlCommand(query, connection)
                    For Each param In parameters
                        command.Parameters.AddWithValue($"@{param.Key}", If(param.Value, DBNull.Value))
                    Next
                    Using reader = command.ExecuteReader()
                        table.Load(reader)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LogError(ex)
            Throw New Exception($"Error al ejecutar consulta: {ex.Message}")
        End Try
        Return table
    End Function

    ' Registrar errores
    Private Sub LogError(ex As Exception)
        s_error = ex.Message
        Debug.Print($"Error: {ex.Message}")
    End Sub
End Class
