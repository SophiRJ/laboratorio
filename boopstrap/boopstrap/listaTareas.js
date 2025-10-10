document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector(`#formulario1`)
    if (!form) return;

    //seccion objetos HTML
    const inputTarea = form.querySelector("#txtTarea");//objeto que define la tarea
    const btnAgregar = form.querySelector("#btnAgregar")
    const listaTareas = document.querySelector("#listaTareas")
    const resultadoDiv = document.querySelector("#resultado")
    const contadorDiv = document.querySelector("#contadorTareas")

    let tareas = []//tareas la rellenamos luego

    //Seccion de funciones
    //Funcion para mostrar alertas
    const mostrarAlertas = (mensaje, tipo = "info") => {
        resultadoDiv.innerHTML = `<div class="alert alert-${tipo} alert-dismissible fade show" role="alert">
        ${mensaje}<button type="button" class="btn-close" data-bs-dismiss="alert"></button></div>
        `
    }
    //Contador tareas
    const actualizarContador = () => {
        const total = tareas.length;
        const completadas = tareas.filter(t => t.completada).length;
        contadorDiv.textContent=`Total : ${total} | Completadas: ${completadas}`
    }

    //Mostrar tareas
    const mostrarTareas = () => {
        listaTareas.innerHTML = "";
        tareas.forEach((tarea, index) => {
            const li = document.createElement("li")
            li.className = "list-group-item d-flex justify-content-between aling-items-center"

            const span = document.createElement("span")
            span.textContent = tarea.titulo;

            if (tarea.completada) span.style.textDecoration = "line-through"
            li.appendChild(span);

            //botones
            const divBtns = document.createElement("div");//ya tengo una seccion donde va a ir no hace falta <>

            //completadas
            const btnCompletado = document.createElement("button");
            btnCompletado.className = "btn btn-sm btn-success me-1"
            btnCompletado.textContent = tarea.completada ? "Desmarcar" : "Completar";
            btnCompletado.addEventListener('click', () => {
                tarea.completada = !tarea.completada;
                mostrarTareas();
                actualizarContador();
            })
            divBtns.appendChild(btnCompletado);


            //Editar
            const btnEditar = document.createElement("button");
            btnEditar.className = "btn btn-sm btn-primary me-1";
            btnEditar.textContent = "Editar";
            btnEditar.addEventListener('click', () => {
                const nuevoTitulo = prompt("Editar tarea: ", tarea.titulo);
                if (nuevoTitulo && nuevoTitulo.trim() !== "") {
                    tarea.titulo = nuevoTitulo.trim();
                    mostrarTareas();
                }
            })
            divBtns.appendChild(btnEditar);

            //Eliminar
            const btnEliminar = document.createElement("button");
            btnEliminar.className = "btn btn-sm btn-danger";
            btnEliminar.textContent = "Eliminar";
            btnEliminar.addEventListener('click', () => {
                tareas.splice(index, 1);
                mostrarTareas();
                actualizarContador();
            })
            divBtns.appendChild(btnEliminar);

            li.appendChild(divBtns);
            listaTareas.appendChild(li);
        });
        actualizarContador()
    }

    //Agregar nueva tarea
    btnAgregar.addEventListener("click", () => {
        const titulo = inputTarea.value.trim()
        if (!titulo) {
            mostrarAlertas("Por favor, ecribe una tarea", "warning");
            return;
        }
        tareas.push({ titulo, completada: false });
        inputTarea.value = "";
        mostrarTareas();
        //actualizarContador();
        mostrarAlertas(`Tarea "${titulo}" agregada`,"success");
    })
})