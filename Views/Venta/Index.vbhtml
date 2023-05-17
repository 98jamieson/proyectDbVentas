@ModelType  List(Of Venta)

@Code
    ViewData("Title") = "Index"
End Code


<div href="row">
    <a href="~/Venta/setNewVenta" class="btn btn-success">Nuevo</a>
</div>
<table class="table">
    <thead>
        <tr>
            <th>Id Venta</th>
            <th>Fecha Venta</th>
            <th>No Documento</th>
        </tr>
    </thead>
    <tbody>

        @For Each item In Model
            @<tr>
                <td>
                    @item.idVenta
                </td>
                <td>
                    @item.fechaVenta
                </td>
                <td>
                    @item.documentoVenta
                </td>
                @*<td>
                    <a class="btn btn-primary" href="Cliente/selectCliente/@item.cli_num_doc">Editar</a>
                </td>
                <td>
                    <a class="btn btn-danger" href="Cliente/deleteCliente/@item.cli_num_doc">Eliminar</a>
                </td>*@
            </tr>
        Next

    </tbody>
</table>


