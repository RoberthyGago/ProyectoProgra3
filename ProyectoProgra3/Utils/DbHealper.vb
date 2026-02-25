'esta clase se encarga de manejar la conexion a la base de datos y ejecutar consultas SQL
Imports System.Data.SqlClient

Public Class DbHealper
    'varable para almacenar la cadena de conexion a la base de datos
    Private connectionString As String = ConfigurationManager.ConnectionStrings("ROBERTHCAConnectionString").ConnectionString

    'funcion para obtener la conexion a la base de datos
    Public Function GetConnection() As SqlConnection
        Dim conn As New SqlConnection(connectionString)
        Try
            conn.Open()
        Catch ex As Exception
            conn.Dispose()
            Throw New Exception("No se pudo conectar a la base de datos: " & ex.Message)
        End Try
        Return conn
    End Function

    'metodo para ejecutar una consulta SQL que no devuelve resultados (INSERT, UPDATE, DELETE) con parametros
    Public Function ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object), ByRef errorMessage As String) As Object
        If String.IsNullOrWhiteSpace(query) Then
            Throw New ArgumentException("La consulta no puede estar vacía.")
        End If
        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each p In parameters
                        cmd.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                End If
                Try
                    cmd.ExecuteNonQuery()

                    Return True
                Catch ex As Exception
                    errorMessage = "Error al ejecutar la consulta: " & ex.Message
                    Return False
                End Try
            End Using
        End Using


    End Function

    Friend Function ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object)) As Object
        Dim errorMessage As String = ""
        Return ExecuteNonQuery(query, parameters, errorMessage)
    End Function

    Friend Function ExecuteReader(query As String, parameters As Dictionary(Of String, Object), errorMessage As String) As SqlDataReader
        Throw New NotImplementedException()
    End Function
End Class
