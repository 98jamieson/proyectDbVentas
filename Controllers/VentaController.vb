Imports System.Web.Mvc
Imports Oracle.ManagedDataAccess.Client

Namespace Controllers
    Public Class VentaController
        Inherits Controller

        ' GET: Venta
        Function Index() As ActionResult

            'CONEXION A DB
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


        '<HttpPost>
        Function setVenta()

            Dim venta = New VentaModelo
            Dim detalle = New VentaDetalle
            detalle.subtotal = 10.0
            detalle.productoReferencia = 1
            detalle.cantidad = 10
            venta.venta = New Venta
            venta.venta.detalles = New List(Of VentaDetalle)
            venta.venta.detalles.Add(detalle)


            'Conexion
            Dim cn As String = ConfigurationManager.ConnectionStrings("proyectdb").ConnectionString
            Dim connection As New OracleConnection(cn)
            connection.Open()



            If (connection.State = ConnectionState.Open) Then
                Dim connectivity = True
            End If
            Dim oraTransaction As OracleTransaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
            'PROC

            Try

                'ENCABEZADO
                Dim cmd As New OracleCommand("PR_CREAR_FACTURA", connection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Transaction = oraTransaction

                cmd.Parameters.Add("P_CLI_NUMERO_DOCUMENTO", OracleDbType.Int32, ParameterDirection.Input).Value = 1


                Dim salida As New OracleParameter("P_ID_VENTA", OracleDbType.Int32)
                salida.Direction = ParameterDirection.Output

                cmd.Parameters.Add(salida)

                Dim pk = cmd.ExecuteNonQuery()
                Dim aux = salida.Value
                'DETALLE

                For Each det As VentaDetalle In venta.venta.detalles

                    Dim cmd2 As New OracleCommand("PR_CREAR_DET_FACTURA", connection)
                    cmd2.CommandType = CommandType.StoredProcedure
                    cmd2.Transaction = oraTransaction

                    cmd2.Parameters.Add("P_VEN_ID_VENTA", OracleDbType.Int32, ParameterDirection.Input).Value = aux
                    cmd2.Parameters.Add("P_PRO_REFERENCIA", OracleDbType.Int32, ParameterDirection.Input).Value = det.productoReferencia
                    cmd2.Parameters.Add("P_DETA_CANTIDAD", OracleDbType.Int32, ParameterDirection.Input).Value = det.cantidad
                    cmd2.Parameters.Add("P_DETA_SUBTOTAL", OracleDbType.Double, ParameterDirection.Input).Value = det.subtotal

                    cmd2.ExecuteNonQuery()
                Next

                oraTransaction.Commit()

            Catch ex As Exception
                oraTransaction.Rollback()
                Throw ex
            End Try

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


        Function setNewVentaModel()
            Dim cli As New List(Of Cliente)
            cli = searchClientes()
            Return View(cli)
        End Function

        <HttpPost>
        Function Buscar(ByVal item As String)
            Dim vals = item

            Return View()
        End Function



    End Class
End Namespace