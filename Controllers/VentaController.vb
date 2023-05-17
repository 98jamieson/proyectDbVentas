Imports System.Web.Mvc
Imports Oracle.ManagedDataAccess.Client

Namespace Controllers
    Public Class VentaController
        Inherits Controller

        ' GET: Venta
        Function Index() As ActionResult

            Dim cn As String = ConfigurationManager.ConnectionStrings("proyectdb").ConnectionString
            Dim connection As New OracleConnection(cn)
            connection.Open()

            If (connection.State = ConnectionState.Open) Then
                Dim connectivity = True
            End If

            Dim cmd As New OracleCommand("pr_get_ventas", connection)
            cmd.CommandType = CommandType.StoredProcedure

            Dim salida As New OracleParameter("resultado", OracleDbType.RefCursor)
            salida.Direction = ParameterDirection.Output
            cmd.Parameters.Add(salida)

            Dim da As New OracleDataAdapter(cmd)
            Dim tabla As New DataTable()
            da.Fill(tabla)
            Dim ventas As New List(Of Venta)
            Dim mostrartabla As DataTable = tabla
            If mostrartabla.Rows.Count > 0 Then
                For Each row As DataRow In mostrartabla.Rows
                    Dim venta As New Venta()
                    venta.documentoVenta = If(Not IsDBNull(row("CLI_NUMERO_DOCUMENTO")), row("CLI_NUMERO_DOCUMENTO").ToString(), "")
                    venta.idVenta = If(Not IsDBNull(row("VEN_ID_VENTA")), row("VEN_ID_VENTA").ToString(), "")
                    venta.fechaVenta = If(Not IsDBNull(row("VEN_FECHA")), row("VEN_FECHA").ToString(), "")
                    ventas.Add(venta)
                Next
            Else
                Response.Write("no se encontro venta")

            End If

            Return View(ventas)
        End Function


        <HttpPost>
        Function setVenta()

            Dim cli As New List(Of Cliente)

            cli = searchClientes()

            Dim cn As String = ConfigurationManager.ConnectionStrings("proyectdb").ConnectionString
            Dim connection As New OracleConnection(cn)
            connection.Open()

            If (connection.State = ConnectionState.Open) Then
                Dim connectivity = True
            End If
            'PROC
            Dim cmd As New OracleCommand("PR_SET_VENTA", connection)
            cmd.CommandType = CommandType.StoredProcedure

            'Method
            cmd.Parameters.Add("CLI_NUMERO_DOCUMENTO", OracleDbType.Int32, ParameterDirection.Input).Value = 2

            cmd.ExecuteNonQuery()
            connection.Close()

            Return Redirect("~/Venta")

        End Function


        Function setNewVenta() As ActionResult
            Dim cli As New List(Of Cliente)
            cli = searchClientes()

            Return View(cli)
        End Function



        Function searchClientes() As List(Of Cliente)

            Dim cn As String = ConfigurationManager.ConnectionStrings("proyectdb").ConnectionString
            Dim connection As New OracleConnection(cn)
            connection.Open()

            If (connection.State = ConnectionState.Open) Then
                Dim connectivity = True
            End If

            Dim cmd As New OracleCommand("pr_get_Clientes", connection)
            cmd.CommandType = CommandType.StoredProcedure

            Dim salida As New OracleParameter("resultado", OracleDbType.RefCursor)
            salida.Direction = ParameterDirection.Output

            cmd.Parameters.Add(salida)

            Dim da As New OracleDataAdapter(cmd)
            Dim tabla As New DataTable()
            da.Fill(tabla)
            Dim clientes As New List(Of Cliente)
            Dim mostrartabla As DataTable = tabla
            If mostrartabla.Rows.Count > 0 Then
                For Each row As DataRow In mostrartabla.Rows
                    Dim cli As New Cliente()
                    cli.cli_num_doc = row("CLI_NUMERO_DOCUMENTO")
                    cli.nombre1 = row("CLI_NOMBRE1")
                    cli.nombre2 = row("CLI_NOMBRE2")
                    cli.otronombre = If(Not IsDBNull(row("CLI_OTROSNOMBRES")), row("CLI_OTROSNOMBRES").ToString(), "")
                    cli.apellido1 = row("CLI_APELLIDO1").ToString()
                    cli.apellido2 = row("CLI_APELLIDO2")
                    cli.nit = row("CLI_NIT")
                    clientes.Add(cli)
                Next
            Else
                Response.Write("no se encontro el cliente")

            End If

            Return clientes

        End Function









    End Class
End Namespace