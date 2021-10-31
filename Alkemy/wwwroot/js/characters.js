const inputName = document.getElementById("input-name");
const selectMovies = document.getElementById("select-movies");
const tBody = document.getElementById("tbody");
const btnFilter = document.getElementById("btnFilter");
const age = document.getElementById("input-age");
const weight = document.getElementById("input-weight");

//=============================== CARGA DE LISTA DE PERSONAJES ==================================
axios.post('/character')
    .then(response => {
        let listCharacters = response.data;
        presentar(listCharacters);
    })
//===============================================================================================

//=============================== CARGA DE PELICULAS AL SELECT ==================================
axios.post('character/movies')
    .then(response => {
        let listMovies = response.data;
        for (let i = 0; i < listMovies.length; i++) {
            const option = document.createElement("option");
            option.value = listMovies[i].id;
            option.text = listMovies[i].titulo;

            selectMovies.appendChild(option);
        }
    })
    .catch(err => {
        console.log(err.message);
    })
//==============================================================================================


//============================ BUSCA POR NOMBRE ================================================
inputName.addEventListener("input", function () {
    console.log(inputName.value);
    $.ajax({
        url: '/character',
        type: 'GET',
        data: {
            name: inputName.value
        },
        success: function (response) {
            if (inputName.value == "") {
                window.history.pushState(inputName.value, "Vacio", "/characters");
            }
            else {
                window.history.pushState(inputName.value, "Nuevo", "/characters?name=" + inputName.value);
                presentar(response);
            }
        }
    });
});
//==============================================================================================

//============================== FILTROS DE LOS RESULTADOS =====================================
let filter;
age.addEventListener("change", function () {
    if (age.value > 0) {
        weight.disabled = true;
        selectMovies.disabled = true;
        filter = "age=" + age.value;
    }
    if (age.value <= 0) {
        weight.disabled = false;
        selectMovies.disabled = false;
    }
});
weight.addEventListener("change", function () {
    if (weight.value > 0) {
        age.disabled = true;
        selectMovies.disabled = true;
        filter = "weight=" + weight.value;
    }
    if (weight.value <= 0) {
        age.disabled = false;
        selectMovies.disabled = false;
    }
});
selectMovies.addEventListener("change", function () {
    if (selectMovies.value != "none") {
        weight.disabled = true;
        age.disabled = true;
        filter = "idMovie=" + idMovie.value;
    }
    if (selectMovies.value == "none") {
        weight.disabled = false;
        age.disabled = false;
    }
});
btnFilter.addEventListener("click", function () {
    $.ajax({
        url: '/character',
        type: 'GET',
        data: { name: inputName.value, age: age.value, weight: weight.value, idMovie: selectMovies.value },
        success: function (response) {
            if ((age.value == 0 || age.value == null) && (weight.value == 0 && weight.value != null) && (selectMovies.value == 0 || selectMovies.value == null)) {
                window.history.pushState(inputName.value, "Vacio", "/characters");
            }
            else {
                window.history.pushState(inputName.value, "Nuevo", "/characters?name=" + inputName.value + "&"+ filter);
                presentar(response);
            }
        }
    });
});
//==============================================================================================

//=========================== MOSTRAR DATOS EN LA TABLA ========================================
function presentar(characters) {
    limpiar();
    for (let i = 0; i < characters.personajes.length; i++) {
        const imageTable = document.createElement("th");
        const nameTable = document.createElement("th");
        const row = document.createElement("tr");
        const image = document.createElement("img");
        const name = document.createElement("p");

        image.src = "../images/" + characters.personajes[i].imagen;
        name.textContent = characters.personajes[i].nombre;

        imageTable.appendChild(image);
        nameTable.appendChild(name);

        row.appendChild(imageTable);
        row.appendChild(nameTable);

        tBody.appendChild(row);
    }
}
//==============================================================================================

//========================= LIMPIAR TABLA ====================================
function limpiar() {
    while (tBody.firstChild) {
        tBody.removeChild(tBody.firstChild);
    }
}
//============================================================================