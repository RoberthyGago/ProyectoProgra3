Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Planillas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarColaboradores()
        End If
    End Sub

    Private Sub CargarColaboradores()
        Dim cadena As String = ConfigurationManager.ConnectionStrings("ROBERTHCAConnectionString").ConnectionString

        Try
            Using cn As New SqlConnection(cadena)
                cn.Open()
                ' Usa los nombres reales de las columnas
                Dim cmd As New SqlCommand("SELECT ID_TRABAJADOR, (NOMBRE + ' ' + APELLIDOS) AS NombreCompleto FROM COLABORADOR", cn)
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                ddlColaboradores.DataSource = dt
                ddlColaboradores.DataTextField = "NombreCompleto"
                ddlColaboradores.DataValueField = "ID_TRABAJADOR"
                ddlColaboradores.DataBind()
            End Using

            ddlColaboradores.Items.Insert(0, New ListItem("-- Seleccione colaborador --", "0"))
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error al cargar colaboradores: " & ex.Message & "');", True)
        End Try
    End Sub

    Protected Sub BtnProcesarPlanilla_Click(sender As Object, e As EventArgs)
        Dim vSalarioBase As Double = 0
        Dim vExtras As Double = 0
        Dim vBruto As Double = 0
        Dim vRenta As Double = 0
        Dim vCCSS As Double = 0
        Dim vTotalDeducciones As Double = 0
        Dim vNeto As Double = 0

        ' Validación de colaborador
        If ddlColaboradores.SelectedValue = "0" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Debe seleccionar un colaborador.');", True)
            Exit Sub
        End If

        ' Salario base por categoría
        Select Case Cmbcategoria.SelectedValue
            Case "0"
                vSalarioBase = 350000
            Case "1"
                vSalarioBase = 375000
            Case "2"
                vSalarioBase = 550000
            Case Else
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Debe seleccionar una categoría.');", True)
                Exit Sub
        End Select

        ' Horas extras
        If IsNumeric(TxthorasExtras.Text) AndAlso Val(TxthorasExtras.Text) >= 0 Then
            vExtras = (vSalarioBase / 160) * 1.5 * Val(TxthorasExtras.Text)
        ElseIf TxthorasExtras.Text <> "" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Horas extras inválidas.');", True)
            Exit Sub
        End If

        ' Cálculos
        vBruto = vSalarioBase + vExtras
        vCCSS = vBruto * 0.1067

        ' Renta
        If vBruto > 750000 AndAlso vBruto <= 1000000 Then
            vRenta = (vBruto - 750000) * 0.02
        ElseIf vBruto > 1000000 AndAlso vBruto <= 2000000 Then
            vRenta = (vBruto - 1000000) * 0.03 + (1000000 - 750000) * 0.02
        ElseIf vBruto > 2000000 Then
            vRenta = (vBruto - 2000000) * 0.04 _
                   + (1000000 - 750000) * 0.02 _
                   + (2000000 - 1000000) * 0.03
        End If

        vTotalDeducciones = vCCSS + vRenta
        vNeto = vBruto - vTotalDeducciones

        ' Crear tabla para mostrar en GridView
        Dim dt As New DataTable()
        dt.Columns.Add("Concepto")
        dt.Columns.Add("Monto")

        dt.Rows.Add("Colaborador", ddlColaboradores.SelectedItem.Text)
        dt.Rows.Add("Salario Base", Format(vSalarioBase, "#,##0.00"))
        dt.Rows.Add("(+) Extras", Format(vExtras, "#,##0.00"))
        dt.Rows.Add("Salario Bruto", Format(vBruto, "#,##0.00"))
        dt.Rows.Add("(-) CCSS", Format(vCCSS, "#,##0.00"))
        dt.Rows.Add("(-) Renta", Format(vRenta, "#,##0.00"))
        dt.Rows.Add("Total Deducciones", Format(vTotalDeducciones, "#,##0.00"))
        dt.Rows.Add("Salario Neto", Format(vNeto, "#,##0.00"))

        gvDeducciones.DataSource = dt
        gvDeducciones.DataBind()

        ' Mostrar resultados en TextBox
        Txtsalario_bruto.Text = Format(vBruto, "#,##0.00")
        Txtdeducciones.Text = Format(vTotalDeducciones, "#,##0.00")
        Txtsalario_neto.Text = Format(vNeto, "#,##0.00")
        TxtPrueba.Text = Format(vExtras, "#,##0.00")
    End Sub
End Class