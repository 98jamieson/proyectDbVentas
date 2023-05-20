
@Modeltype List(Of Cliente)
@Code
    ViewData("Title") = "setNewVenta"
    Dim inputValue As String = ""

End Code


<h2 id="titulo">Registrar Venta</h2>

@Using (Html.BeginForm("YourAction", "YourController"))




End Using




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
            <input type="text" class="form-control" id="lblcodigo" aria-label="Sizing example input" placeholder="codigo" haria-describedby="inputGroup-sizing-sm">
        </div>
    </div>














    <div class="col-md-2">

        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control" placeholder="cantidad">
        </div>
    </div>

    <div class="col-md-2">

        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control" placeholder="descripcion" disabled>
        </div>
    </div>
    <div class="col-md-2">

        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control" placeholder="precio" disabled>
        </div>
    </div>
    <div class="col-md-2">
        <div class="input-group input-group-sm mb-3">
            <input type="text" class="form-control" placeholder="subtotal" disabled>
        </div>
    </div>

    
    <div>
        <h1 id="resultado"></h1>
    </div>
</div>

<script>

    $(document).ready(function () {

        //$('#titulo').html('nuevo texto desde jquery');

        $('#lblcodigo').on("keyup", function (e) {
            let cod = $(this).val();
            console.log(cod)
            }
        )



    });

</script>




