
@Modeltype  List(Of Cliente)
@Code
    ViewData("Title") = "setNewVenta"
End Code

<h2>Registrar Venta</h2>

<div>
    <div class="form-group">
        <div class="row">
            <h3>Cliente: </h3>
            <div class="dropdown">
                <div class="">
                    @Html.DropDownList("Cliente", New SelectList(Model, "cli_num_doc", "nombre1"), New With {.htmlAttributes = New With {.class = "dropdown-menu"}})
                </div>
            </div>
        </div>
    </div>
</div>


<div class="row">
    <div class="col-md-2">

        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control" aria-label="Sizing example input" placeholder="codigo" haria-describedby="inputGroup-sizing-sm">
        </div>
    </div>
    <div class="col-md-2">

        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control"  placeholder="cantidad" >
        </div>
    </div>

    <div class="col-md-2">

        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control"  placeholder="descripcion" disabled>
        </div>
    </div>
    <div class="col-md-2">

        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control"  placeholder="precio" disabled >
        </div>
    </div>
    <div class="col-md-2">
        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control"placeholder="subtotal" disabled >
        </div>
    </div>
</div>








@*@For Each item In Model
        @<tr>
            <td>
                @item.cli_num_doc
            </td>
        </tr>
        @<tr>
            <td>
                @item.nombre1
            </td>
        </tr>

    Next*@
