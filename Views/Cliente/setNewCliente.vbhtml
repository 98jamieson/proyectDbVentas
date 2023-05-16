
@ModelType  Cliente

@Code


    ViewData("Title") = "setNewCliente"
End Code





<h2>Ingrese un Nuevo Cliente</h2>


@Using Html.BeginForm("setCliente", "Cliente")

    @<div class="">
        <div class="container">

            <div class="row">

                <div class="col-md-3">
                    <label>Primer Nombre</label>
                    @Html.TextBoxFor(Function(m) m.nombre1, New With {.class = "form-control text-danger"})
                    @Html.ValidationMessageFor(Function(m) m.nombre1, "", New With {.class = "text-danger"})

                </div>

                <div class="col-md-3">
                    <label>Segundo Nombre</label>
                    @Html.TextBoxFor(Function(m) m.nombre2, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.nombre2, "", New With {.class = "text-danger"})

                </div>
            </div>
        </div>

        <div Class="container">
            <div Class="row">

                <div class="col-md-3">

                    <label>Primer Apellido</label>
                    @Html.TextBoxFor(Function(m) m.apellido1, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.apellido1, "", New With {.class = "text-danger"})

                </div>
                <div class="col-md-3">

                    <label>Segundo Apellido</label>
                    @Html.TextBoxFor(Function(m) m.apellido2, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.apellido2, "", New With {.class = "text-danger"})

                </div>
                <div class="col-md-3">

                    <label>Apellido Casada  <span>(opcional)</span></label>
                    @Html.TextBoxFor(Function(m) m.apellidoCasada, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.apellidoCasada, "", New With {.class = "text-danger"})

                </div>
            </div>

        </div>


        <div class="container">
            <div class="row">

                <div class="col-md-3">

                    <label>Profesion</label>
                    @Html.TextBoxFor(Function(m) m.profesion, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.profesion, "", New With {.class = "text-danger"})

                </div>
                <div class="col-md-3">

                    <label>Nit</label>
                    @Html.TextBoxFor(Function(m) m.nit, New With {.class = "form-control"})
                    @Html.ValidationMessageFor(Function(m) m.nit, "", New With {.class = "text-danger"})

                </div>
            </div>
        </div>
    </div>

    @<div class="">
        <input type="submit" value="ACEPTAR" class="btn btn-success" />
    </div>

End Using
