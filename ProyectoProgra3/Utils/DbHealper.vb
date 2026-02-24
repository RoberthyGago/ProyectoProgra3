Imports System.Data.SqlClient
'varable para almacenar la cadena de conexion a la base de datos
Public Class DbHealper

    Private connectionString As String = ConfigurationManager.ConnectionStrings("ProyectoProgra3ConnectionString").ConnectionString

    'funcion para obtener la conexion a la base de datos
    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

    Public Function ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object)) As Object
        Throw New NotImplementedException()
    End Function
End Class
