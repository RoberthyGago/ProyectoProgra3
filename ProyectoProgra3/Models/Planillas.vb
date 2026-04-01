Namespace Models
    Public Class Planillas
        Private _nombre As String
        Private _apellidos As String

        Public Sub New()

        End Sub


        Public Sub New(nombre As String, apellidos As String)
            Me.Nombre = nombre
            Me.Apellidos = apellidos
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

        Public Function Resumen() As String
            Return $"{Nombre} {Apellidos}"
        End Function

    End Class
End Namespace