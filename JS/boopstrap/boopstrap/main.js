const usuarios = [
    { id: 1, nombre: "Ana López", email: "ana@example.com", ciudad: "Madrid", edad: 28 },
    { id: 2, nombre: "Carlos Pérez", email: "carlos@example.com", ciudad: "Barcelona", edad: 34 },
    { id: 3, nombre: "Laura Gómez", email: "laura@example.com", ciudad: "Sevilla", edad: 25 },
    { id: 4, nombre: "David Ruiz", email: "david@example.com", ciudad: "Valencia", edad: 42 },
];

const contenedor = document.querySelector("#listaUsuarios")
const modal = new bootstrap.Modal(document.querySelector("#modalUsuario"))//para que js lo reconozca 
const [modalNombre, modalEmail, modalCiudad, modalEdad] = [
    "#modalNombre", "#modalEmail", "#modalCiudad", "#modalEdad"
].map(selector => document.querySelector(selector));
const mostrarUsuarios = () => {
    contenedor.innerHTML = usuarios.map(({ id, nombre, ciudad }) =>
    `
        <div class="col-md-3"> 
            <div class="card-shadow-sm h-100 text-center"> 
                <div class="card-body"> 
                    <h5 class="card-title">${nombre}</h5> 
                    <p class="card-text text-muted">${ciudad}</p> 
                    <button class="btn btn-outline-primary btn-sm" data-id="${id}"> 
                    Ver Perfil</button> 
                </div> 
            </div> 
        </div> 
        `
    ).join("");// para separar en lineas individuales

    //asociar el evento cliick a los botones
    document.querySelectorAll("[data-id]").forEach(btn => {
        //e.target -> devuelve el objeto(boton que cree arriba) que me esta levantando el evento
        //de todos sus datas coge el id
        btn.addEventListener('click', e => verUsuario(Number(e.target.dataset.id)))
    })
} 
//funcion para mostrar datos del usuario en la modal
const verUsuario = id => {
    const usuario = usuarios.find(u => u.id === id);
    if (!usuario) return;
    const { nombre, email, ciudad, edad } = usuario
    modalNombre.textContent = nombre;
    modalEmail.textContent = email;
    modalCiudad.textContent = ciudad;
    modalEdad.textContent = edad;

    //para que aparezca el popup debo decirle al modal que se muestre
    modal.show()
}
//arrancar la app
document.addEventListener("DOMContentLoaded", mostrarUsuarios);