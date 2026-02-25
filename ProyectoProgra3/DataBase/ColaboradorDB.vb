Imports System.Data.SqlClient
Imports ProyectoProgra3.Models
Imports ProyectoProgra3.Utils

Public Class ColaboradorDB
    Private db As New DbHealper()
    'creo el metodo para guardar un colaborador en la base de datos
    'logica para crear colaborador en la base de datos
    Public Function CrearColaborador(ByVal pColaborador As Models.Colaborador, ByRef errorMessage As String)

        Using db.GetConnection()
            Dim query As String = "INSERT INTO COLABORADOR (TipoDocumento, Identificacion, Nombre, Apellidos, Fecha_Nacimiento, Correo) 
            VALUES (@TipoDocumento, @Identificacion, @Nombre, @Apellidos, @FechaNacimiento, @Correo)"

            Dim parameters As New Dictionary(Of String, Object) From {
            {"@Nombre", pColaborador.Nombre},
            {"@FechaNacimiento", pColaborador.FechaNacimiento},
            {"@Correo", pColaborador.Correo},
            {"@Apellidos", pColaborador.Apellidos},
            {"@Identificacion", pColaborador.Identificacion},
            {"@TipoDocumento", pColaborador.TipoDocumento}
          }

            Return db.ExecuteNonQuery(query, parameters, errorMessage)
        End Using
        Return True
    End Function

    ' Método para eliminar un colaborador
    Public Function EliminarColaborador(ByVal id As Integer, ByRef errorMessage As String) As Boolean
        Dim query As String = "DELETE FROM COLABORADOR WHERE ID_TRABAJADOR = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", id}
        }
        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function



End Class
