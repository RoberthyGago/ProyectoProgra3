Imports System.Data.SqlClient
Imports ProyectoProgra3.Models
Imports ProyectoProgra3.Utils

Public Class ColaboradorDB
    Private db As New DbHealper()
    'creo el metodo para guardar un colaborador en la base de datos
    'logica para crear colaborador en la base de datos
    Public Function CrearColaborador(ByVal pColaborador As Models.Colaborador, ByRef errorMessage As String) As Boolean
        'logica para insertar un nuevo colaborador en la base de datos
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



    ' Método para actualizar un colaborador
    Public Function ActualizarCOLABORADOR(ByVal pColaborador As Models.Colaborador, ByRef errorMessage As String) As Boolean
        Dim query As String = "UPDATE COLABORADOR 
                              SET TipoDocumento = @TipoDocumento, 
                              Identificacion = @Identificacion,
                              Nombre = @Nombre, 
                              Apellidos = @Apellidos, 
                              Fecha_Nacimiento = @FechaNacimiento,
                              Correo = @Correo 
                              WHERE ID_TRABAJADOR = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", pColaborador.ID_TRABAJADOR},
            {"@Nombre", pColaborador.Nombre},
            {"@FechaNacimiento", pColaborador.FechaNacimiento},
            {"@Correo", pColaborador.Correo},
            {"@Apellidos", pColaborador.Apellidos},
            {"@Identificacion", pColaborador.Identificacion},
            {"@TipoDocumento", pColaborador.TipoDocumento}
        }
        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function

    Public Function ConsultarColaborador(id As String, ByRef errorMessage As String) As Models.Colaborador
        Dim query As String = "SELECT * FROM COLABORADOR WHERE ID_TRABAJADOR = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", id}
        }
        Dim dt As DataTable = db.ExecuteQuery(query, parameters, errorMessage)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            Dim persona As New Models.Colaborador() With {
                .Nombre = row("NOMBRE").ToString(),
                .Apellidos = row("APELLIDOS").ToString(),
                .FechaNacimiento = Convert.ToDateTime(row("FECHA_NACIMIENTO")),
                .Correo = row("CORREO").ToString(),
                .Identificacion = row("IDENTIFICACION").ToString(),
                .TipoDocumento = row("TIPODOCUMENTO").ToString()
            }
            Return persona
        End If
        Return Nothing

        Throw New NotImplementedException()
    End Function
End Class
