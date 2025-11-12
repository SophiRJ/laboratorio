document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector("#formulario1");
    if (!form) return;

    /*Seccion de Objetos html*/
    const inputTarea = form.querySelector("#txtTarea")
    const btnAgregar = form.querySelector("#btnAgregar")
    const listaTareas = document.querySelector("#listaTareas")
    const resultadoDiv = document.querySelector("#resultado")
    const contadorDiv = document.querySelector("#contadorTareas")


    let tareas = []


    /*Seccion funciones*/
    //Funcion para mostrar alertas
    const mostrarAlerta = (mensaje, tipo = "info") => {
        resultadoDiv.innerHTML = `
        <div class="alert alert-${tipo} alert-dismissible fade show" role="alert">
        ${mensaje}<button type="button" class="btn-close data-bs-dismiss="alert"></button></div>
        `
    } 

    //Contador de tareas
    const actualizarContador = () => {
        const total = tareas.length;
        const completadas = tareas.filter(item => item.completada).length;//.length por que map devuelve un array le decimos que cuente los items
        contadorDiv.textContent = `Total: ${total}| Completadas: ${completadas}`
    }

    //Mostrar tareas
    const mostrarTareas = () => {
        listaTareas.innerHTML = "";
        tareas.forEach((tarea, index) => {
            const li = document.createElement("li");
            li.className = "list-group-item d-flex justify-content-between aling-items-center";

            const span = document.createElement("span");
            span.textContent = tarea.titulo;

            if (tarea.completada) span.style.textDecoration = "line-through";
            li.appendChild(span)


            //botones
            const divBtns = document.createElement("div");

            //Completadas
            const btnCompletada = document.createElement("button")
            btnCompletada.className="btn btn-sm btn-success me-1"
            btnCompletada.textContent = tarea.completada ? "Desmarcar" : "Completar";
            btnCompletada.addEventListener("click", () => {
                tarea.completada = !tarea.completada;
                mostrarTareas()
                actualizarContador()
            })
            divBtns.appendChild(btnCompletada);

            //Editar
            const btnEditar = document.createElement("button")
            btnEditar.className="btn btn-sm btn-primary me-1";
            btnEditar.textContent = "Editar"
            btnEditar.addEventListener("click", () => {
                const nuevoTitulo = prompt("Editar tarea : ", tarea.titulo)
                if ((nuevoTitulo || nuevoTitulo.trim()) !== "") {
                    tarea.titulo = nuevoTitulo.trim()
                    mostrarTareas()
                }
            })
            divBtns.appendChild(btnEditar);

            //Eliminar
            const btnEliminar = document.createElement("button")
            btnEliminar.className="btn btn-sm btn-danger ";
            btnEliminar.textContent = "Eliminar"
            btnEliminar.addEventListener("click", () => {
                tareas.splice(index, 1);
                mostrarTareas()
                actualizarContador()
            })
            divBtns.appendChild(btnEliminar);

            li.appendChild(divBtns)
            listaTareas.appendChild(li)
        })
        actualizarContador()
    }

    //agregar nueva tarea
    btnAgregar.addEventListener("click", () => {
        const titulo = inputTarea.value.trim()
        if (!titulo) {
            mostrarAlerta("Por favor escribe una nueva tarea", "warning")
            return;
        };
        console.log(titulo)
        tareas.push({ titulo, completada: false });
        inputTarea.value = "";
        mostrarTareas();
        //actualizarContador();
        mostrarAlerta("Se ha añadido una nueva tarea", "success");
    })
})












//const rellenarLista = (tarea) => {
//    const lista = form.querySelector("#lista")
//    const ul = lista.querySelector("ul")
//    const li = document.createElement("li")
//    li.className = `list-group-item d-flex justify-content-between aling-items-center`

//    li.innerHTML = `<span>${tarea}</span>
//        <div>
//            <button class="btn btn-success btn-sm me-1" data->Completar</button>
//            <button class="btn btn-primary btn-sm me-1">Editar</button>
//            <button class="btn btn-danger btn-sm">Eliminar</button>
//        </div>
//    `;
//    ul.appendChild(li)
//}