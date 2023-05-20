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
            <th>ID</th>
            <th>Fecha</th>
            <th>Cliente</th>
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
              
            </tr>
        Next

    </tbody>
</table>


