let title = window.location.href.split("=")[1];
title = title.split("%20").join(" ")

let img = document.getElementById("imageDetails");
let id = document.getElementById("id");
let titulo = document.getElementById("title");
let fecha = document.getElementById("date");
let calificacion = document.getElementById("qualification");
let lista = document.getElementById("list");

axios.get('/Details' + title)
    .then(response => {
        let details = JSON.parse(JSON.stringify(response.data));
        presentar(details);
    })
    .catch(err => { console.log(err.message) })


function presentar(movie) {
    img.setAttribute("src", "../images/" + movie.imagen);
    id.textContent = " " + movie.id;
    titulo.textContent = " " + movie.titulo;
    fecha.textContent = " " + movie.fechaCreacion;
    calificacion.textContent = " " + movie.calificacion;


    for (let i = 0; i < movie.personajesPelicula.length; i++) {
        let li = document.createElement("li");
        li.textContent = " " + movie.personajesPelicula[i].personaje.nombre;

        lista.appendChild(li);
    }
}
