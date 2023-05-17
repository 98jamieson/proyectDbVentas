Imports System.Web.Mvc
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports System.Data
Imports Oracle.ManagedDataAccess.Client

Namespace Controllers
    Public Class ProductoController
        Inherits Controller

        ' GET: Producto
        Function Index() As ActionResult


            Dim cn As String = ConfigurationManager.ConnectionStrings("proyectdb").ConnectionString
            Dim connection As New OracleConnection(cn)
            connection.Open()

            If (connection.State = ConnectionState.Open) Then
                Dim connectivity = True
            End If

            Dim cmd As New OracleCommand("pr_get_Productos", connection)
            cmd.CommandType = CommandType.StoredProcedure

            Dim salida As New OracleParameter("resultado", OracleDbType.RefCursor)
            salida.Direction = ParameterDirection.Output

            cmd.Parameters.Add(salida)

            Dim da As New OracleDataAdapter(cmd)
            Dim tabla As New DataTable()
            da.Fill(tabla)
            Dim productos As New List(Of Producto)
            Dim mostrartabla As DataTable = tabla
            If mostrartabla.Rows.Count > 0 Then
                For Each row As DataRow In mostrartabla.Rows
                    Dim cli As New Producto()
                    cli.pro_referencia = row("PRO_REFERENCIA")
                    cli.pro_nombre = row("PRO_NOMBRE")
                    cli.pro_tipo = row("PRO_TIPO")
                    cli.pro_alto = row("PRO_ALTO")
                    cli.pro_ancho = row("PRO_ANCHO")
                    cli.pro_profundidad = row("PRO_PROFUNDIDAD")
                    cli.pro_peso = row("PRO_PESO")
                    'cli.pro_foto_producto = row("CLI_NUMERO_DOCUMENTO")

                    productos.Add(cli)
                Next
            Else
                Response.Write("no se encontro ningun producto")
            End If


            Return View(productos)
        End Function

        ' GET: Producto/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Producto/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Producto/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Producto/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Producto/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Producto/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Producto/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace