document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector("#formulario")
    if (!form) return

    const obtenerTareaNueva = () => {
        const nuevaTarea = form.querySelector("#nuevaTarea")
        if (!nuevaTarea) return
        const valor = nuevaTarea.value.trim();
        if (valor === "") {
            nuevaTarea.classList.add("is-invalid")
            let placholderOriginal = nuevaTarea.placeholder;

            nuevaTarea.placeholder = 'Agrega una tarea primero'
            nuevaTarea.value = ""

            setTimeout(() => {
                nuevaTarea.classList.remove("is-invalid")
                nuevaTarea.placeholder = placholderOriginal;

            }, 1000)
            return;
        }
        console.log(`nueva tarea ${valor}`)
        nuevaTarea.value = "";
        return valor;
        
    }
    const rellenarLista = (tarea) => {
        const lista = form.querySelector("#lista")
        const ul = lista.querySelector("ul")
        const li = document.createElement("li")
        li.className = `list-group-item d-flex justify-content-between aling-items-center`

        li.innerHTML = `<span>${tarea}</span>
            <div>
                <button class="btn btn-success btn-sm me-1" data->Completar</button>
                <button class="btn btn-primary btn-sm me-1">Editar</button>
                <button class="btn btn-danger btn-sm">Eliminar</button>
            </div>
        `;
        ul.appendChild(li)
    }

    form.querySelector("#btnAgregar").addEventListener("click", () => {
        const tarea = obtenerTareaNueva();
        if (tarea) rellenarLista(tarea);
    })
    
})