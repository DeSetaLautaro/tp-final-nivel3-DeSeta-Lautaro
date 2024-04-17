
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////*
/* AJUSTA EL TAMAÑO DE LAS CARTAS EN EL CATÁLOGO Y EN FAVORITOS CUANDO LAPANTALLA SE ACHICA */
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function ajustarEstilos() {

    var nombrePagina = window.location.pathname;
    if (nombrePagina.includes('Favoritos') || nombrePagina.includes('Catalogo')) {
        var anchoVentana = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;

        var carta = document.querySelectorAll('#carta');
        var cards = document.querySelectorAll('.card');
        var cardImages = document.querySelectorAll('.card img');

        if (anchoVentana <= 774) {

            carta.forEach(function (carta) {
                carta.style.width = '100%';
            });
            cards.forEach(function (card) {
                card.style.maxWidth = '30em';
                card.style.flexDirection = 'row';
            });

            cardImages.forEach(function (img) {
                img.style.maxWidth = '25%';
                img.style.margin = 'auto';
                img.style.padding = '0.5em';
                img.style.borderRadius = '0.7em';
            });
        } else {

            carta.forEach(function (carta) {
                carta.style.width = '18rem';
                carta.style.margin = '4px 6px';
            });
            cards.forEach(function (card) {
                card.style.maxWidth = '';
                card.style.flexDirection = '';
            });

            cardImages.forEach(function (img) {
                img.style.maxWidth = '';
                img.style.margin = '';
                img.style.padding = '';
                img.style.borderRadius = '';
            });
        }
    }
}
window.onload = ajustarEstilos;
window.onresize = ajustarEstilos;


//////////////////////////////////////////////////////////////////////////////////////////
/* FUNCIONES PARA MOSTRAR O QUITAR EL FILTRO AVANZADO EN 'LISTA DE PRODUCTOS' Y EN 'FAVORITOS' 
Y CORRER EL RESTO DEL HTML HACIA ABAJO*/
///////////////////////////////////////////////////////////////////////////////////////

function toggleFiltroAvanzado() {
    var menuDesplegable = document.getElementById("menuDesplegable");
    if (menuDesplegable.classList.contains("d-none")) {
        mostrarFiltroAvanzado();
        ajustarMargenGridView();
    } else {
        ocultarFiltroAvanzado();
        ajustarMargenGridView();
    }
}

function mostrarFiltroAvanzado() {

    var menuDesplegable = document.getElementById("menuDesplegable");
    menuDesplegable.classList.remove("d-none");

}

function ocultarFiltroAvanzado() {
    var menuDesplegable = document.getElementById("menuDesplegable");
    menuDesplegable.classList.add("d-none");
}
function ajustarMargenGridView() {
    var menuDesplegable = document.getElementById("menuDesplegable");
    var gridView = document.getElementById("GridView");
    if (!menuDesplegable.classList.contains("d-none")) {
        // Ajustar margen superior del GridView
        var menuHeight = menuDesplegable.offsetHeight;
        gridView.style.marginTop = menuHeight + "px";
    } else {
        // Resetear margen superior del GridView
        gridView.style.marginTop = "0";
    }
}