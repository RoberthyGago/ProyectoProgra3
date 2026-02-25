'usamos models para definir las clases que representan a los colaboradores y  no de error de referencia circular entre las clases
'se encapsulan campos privados con propiedades públicas para acceder a ellos
'metodos get y set para cada propiedad para modificar y acceder a los valores de las propiedades
Namespace Models
    Public Class Colaborador

        Private _nombre As String
        Private _apellidos As String
        Private _tipoDocumento As String
        Private _identificacion As String
        Private _fechaNacimiento As Date
        Private _correo As String
        Private _ID_TRABAJADOR As Integer

        Public Sub New()
            Me.Nombre = "sin nombre"
        End Sub

        Public Sub New(nombre As String, apellidos As String)
            Me.Nombre = nombre
            Me.Apellidos = apellidos
        End Sub

        Public Sub New(nombre As String, apellidos As String, tipoDocumento As String, identificacion As String, fechaNacimiento As Date, correo As String)
            Me.Nombre = nombre
            Me.Apellidos = apellidos
            Me.TipoDocumento = tipoDocumento
            Me.Identificacion = identificacion
            Me.FechaNacimiento = fechaNacimiento
            Me.Correo = correo
        End Sub




        Public Property Nombre As String
            Get
                Return _nombre
            End Get
            Set(value As String)
                _nombre = value
            End Set
        End Property

        Public Property Apellidos As String
            Get
                Return _apellidos
            End Get
            Set(value As String)
                _apellidos = value
            End Set
        End Property

        Public Property TipoDocumento As String
            Get
                Return _tipoDocumento
            End Get
            Set(value As String)
                _tipoDocumento = value
            End Set
        End Property

        Public Property Identificacion As String
            Get
                Return _identificacion
            End Get
            Set(value As String)
                _identificacion = value
            End Set
        End Property

        Public Property FechaNacimiento As Date
            Get
                Return _fechaNacimiento
            End Get
            Set(value As Date)
                _fechaNacimiento = value
            End Set
        End Property

        Public Property Correo As String
            Get
                Return _correo
            End Get
            Set(value As String)
                _correo = value
            End Set
        End Property

        Public Function Resumen() As String
            Return $"Nombre: {Nombre} {Apellidos} - {Correo}"

        End Function

    End Class
End Namespace
