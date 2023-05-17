@ModelType  List(Of Producto)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Mantenimiento de productos</h2>

<div href="row">
    <a href="~/Producto/setNewProducto" class="btn btn-success">Nuevo Producto</a>
</div>
<table class="table">
    <thead>
        <tr>
            <th>Referencia</th>
            <th>Nombre</th>
            <th>Tipo</th>
            <th>Ancho</th>
            <th>Alto</th>
            <th>Profundidad</th>
            <th>Peso</th>
            @*<th>Imagen</th>*@
            <th>Editar</th>
            <th>Eliminar</th>
        </tr>
    </thead>
    <tbody>

        @For Each item In Model
            @<tr>

                <td>
                    @item.pro_referencia
                </td>
                <td>
                    @item.pro_nombre
                </td>
                <td>
                    @item.pro_tipo

                </td>
                <td>
                    @item.pro_alto
                </td>
                <td>
                    @item.pro_ancho
                </td>
                <td>
                    @item.pro_profundidad
                </td>

                <td>
                    @item.pro_peso
                </td>
                @*<td>
                        @item.pro_foto_producto
                    </td>*@
                <td>
                    <a class="btn btn-primary" href="Producto/selectCliente/@item.pro_referencia">Editar</a>
                </td>
                <td>
                    <a class="btn btn-danger" href="Producto/deleteCliente/@item.pro_referencia">Eliminar</a>
                </td>
            </tr>
        Next

    </tbody>
</table>
