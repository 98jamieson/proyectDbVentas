@Code
    ViewData("Title") = "Home Page"
End Code

<div style="position: relative; width: 100%; height: 0; padding-top: 41.6667%;
 padding-bottom: 0; box-shadow: 0 2px 8px 0 rgba(63,69,81,0.16); margin-top: 1.6em; margin-bottom: 0.9em; overflow: hidden;
 border-radius: 8px; will-change: transform; background-image: url('https://ruta-de-tu-imagen/alpes.png');">
    <iframe loading="lazy" style="position: absolute; width: 100%; height: 100%; top: 0; left: 0; border: none; padding: 0;margin: 0;"
            src="https://www.canva.com/design/DAFjO6zLLO8/view?embed" allowfullscreen="allowfullscreen" allow="fullscreen">
    </iframe>
</div>
 

<div class="row">
    <div class="col-md-4">
        <div class="card">
            <img src="~/Image/sillon.png" alt="Sofás y Sillones" class="card-img-top" width="200px">
            <div class="card-body">
                <h2 class="card-title">Sillones Marino</h2>
                <p class="card-text">Encuentra sofás y sillones cómodos y elegantes para tu sala de estar.</p>
                <a class="btn btn-primary" @Html.ActionLink("Ver más", "Index", "Cliente")</a>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="card">
            <img src="~/Image/sillonce.png" alt="Sofás y Sillones" class="card-img-top" width="200px">
            <div class="card-body">
                <h2 class="card-title">Sillones Luxury</h2>
                <p class="card-text">Descubre nuestro hermoso sofa Lexury.</p>
                <a class="btn btn-primary" href="https://tu-tienda-de-muebles.com/categoria/comedores">Ver más &raquo;</a>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="card">
            <img src="~/Image/sillonNeAm.png" alt="Sofás y Sillones" class="card-img-top" width="200px">
            <div class="card-body">
                <h2 class="card-title">Sillones Furniture</h2>
                <p class="card-text">Encuentra los juegos de sala modernos.</p>
                <a class="btn btn-primary" href="https://tu-tienda-de-muebles.com/categoria/camas">Ver más &raquo;</a>
            </div>
        </div>
    </div>
</div>
