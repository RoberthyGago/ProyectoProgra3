Imports System.Data.SqlClient

Public Class ColaboradorDB
    Private db As New DbHealper()
    'creo el metodo para guardar un colaborador en la base de datos
    'logica para crear persona en la base de datos
    Public Function CrearColaborador(ByVal pColaborador As Models.Colaborador)

        Using db.GetConnection()
            Dim query As String = "INSERT INTO Colaborador (TipoDocumento, Identificacion, Nombre, Apellidos, FechaNacimiento, Correo) 
            VALUES (@TipoDocumento, @Identificacion, @Nombre, @Apellidos, @FechaNacimiento, @Correo)"

            Dim parameters As New Dictionary(Of String, Object) From {
            {"@Nombre", pColaborador.Nombre},
            {"@FechaNacimiento", pColaborador.FechaNacimiento},
            {"@Correo", pColaborador.Correo},
            {"@Apellidos", pColaborador.Apellidos},
            {"@identificacion", pColaborador.Identificacion},
            {"@TipoDocumento", pColaborador.TipoDocumento}
          }

            Dim resultado = db.ExecuteNonQuery(query, parameters)
        End Using
        Return True
    End Function
End Class
