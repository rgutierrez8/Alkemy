const divContainer = document.getElementById("container-div");
const inputTitle = document.getElementById("input-title");
const selectGen = document.getElementById("genre");
const btnBuscar = document.getElementById("btnBuscar");
const form = document.getElementById("formSearch");
const btnAsc = document.getElementById("btnAsc");
const btnDesc = document.getElementById("btnDesc");
const order = document.getElementById("order");

const btnFilter = document.getElementById("btnFilter");
let datos = [];
let movies
let orderType = "";

start();

function start() {
    axios.get('movie')
        .then(response => {
            movies = JSON.parse(JSON.stringify(response.data));
            presentar(movies);
        })
        .catch(err => {
            console.log(err.message);
        });
}

btnFilter.addEventListener("click", function () {
    console.log(datos);
    let name = "";
    if (inputTitle.value !== "") {
        name = "name=" + inputTitle.value + "&";
    }
    $.ajax({
        url: '/movie',
        type: 'GET',
        data: {
            name: inputTitle.value, genre: selectGen.value, order: order.value, datos: datos.toString()
        },
        success: function (response) {
            if (orderType == "" && selectGen.value == "") {
                start();
                window.history.pushState(inputTitle.value, "Vacio", "/movies");
            }
            else {
                window.history.pushState(inputTitle.value, "Nuevo", "/movies?" + name + $("form").serialize());
            }
            presentar(response);
        }
    });
});

//btnAsc.addEventListener("click", function () {
//    btnAsc.classList.add("orderSelected");
//    btnDesc.classList.remove("orderSelected");
//    orderType = "asc";
//    order(orderType);
//});
//btnDesc.addEventListener("click", function () {
//    btnDesc.classList.add("orderSelected");
//    btnAsc.classList.remove("orderSelected");
//    orderType = "desc";
//    order(orderType);
//});

//function order(orderType) {
//    console.log(btnAsc.value);
//    $.ajax({
//        url: '/movie',
//        type: 'GET',
//        data: 'order=' + orderType,
//        success: function (response) {
//            if (orderType == "") {
//                start();
//                window.history.pushState(inputTitle.value, "Vacio", "/movies");
//            }
//            else {
//                window.history.pushState(inputTitle.value, "Nuevo", "/movies?order=" + orderType.toUpperCase());
//            }
//            presentar(response);
//        }
//    });
//}

inputTitle.addEventListener("input", function () {
    $.ajax({
        url: '/movie',
        type: 'GET',
        data: $('#input-title').serialize(),
        success: function (response) {
            if (inputTitle.value.length == 0) {
                start();
                window.history.pushState(inputTitle.value, "Vacio", "/movies");
            }
            else {
                window.history.pushState(inputTitle.value, "Nuevo", "/movies?name=" + inputTitle.value);
            }
            movies = response;
            presentar(response);
        }
    });
});

//selectGen.addEventListener("input", function () {
//    $.ajax({
//        url: '/movie',
//        type: 'GET',
//        data: $('#genre').serialize(),
//        success: function (response) {
//            if (selectGen.value == "none") {
//                start();
//                window.history.pushState(selectGen.value, "Vacio", "/movies");
//            }
//            else {
//                window.history.pushState(selectGen.value, "Nuevo", "/movies?genre=" + selectGen.value);
//            }
//            presentar(response);
//        }
//    });
//});






function presentar(movies) {
    limpiarDiv();
    let data = movies.peliculaSeries;

    for (let i = 0; i < data.length; i++) {
         const div = document.createElement("div");
        const a = document.createElement("a");
        const img = document.createElement("img");
        const title = document.createElement("h2");

        title.textContent = data[i].titulo;
        img.src = "../images/" + data[i].imagen;

        a.appendChild(img);
        a.appendChild(title);
        //a.setAttribute("href", "/Movies/Details");
        a.addEventListener("click", function () {
            window.location.href = "/Movies/Details?nombre=" + a.lastChild.textContent;
        });

        div.appendChild(a);
        div.classList.add("div-movie");

        divContainer.appendChild(div);
    }
}

function limpiarDiv() {
    while (divContainer.firstChild) {
        divContainer.removeChild(divContainer.firstChild);
    }
}



