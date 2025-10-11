document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector("#formulario1")
    if (!form) return;
    const resultadoDiv = form.querySelector("#resultado");
    const carrito = [];
    const productosDisponibles = [
        {
            id: "cantidadCamiseta", nombre: "Camiseta", precio: 10},
        {id: "cantidadPantalon", nombre: "Pantalon", precio: 20},
        { id: "cantidadZapatos", nombre: "Zapatos", precio: 35 },
         { id: "cantidadGorra", nombre: "Gorra", precio: 8 },
          {  id: "cantidadBolso", nombre: "Bolso", precio: 25
        }
    ]

    //funcion auxiliar para mostrar las alertas bootstrap
    const mostrarAlerta = (mensaje, tipo = "info") => {
        resultadoDiv.innerHTML = `
            <div class="alert alert-${tipo} alert-dismissible fade show" role="alert">
            ${mensaje}<button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            </div>
        `
    }

    //Agregar productos
    const agregar_carrito = () => {
        console.log("hola")
        let agregado = false
        
        productosDisponibles.forEach(prod => {
            const cantidad = parseInt(form.querySelector(`#${prod.id}`)?.value)
            if (!isNaN(cantidad) && cantidad > 0) {
                agregado = true;
                const existente = carrito.find(item => item.nombre === prod.nombre)
                if (existente) {
                    existente.cantidad += cantidad
                } else {
                    carrito.push({ ...prod, cantidad })/*Al prod le agrego la cantidad*/
                }
            }
        })
        if (!agregado) {
            console.log(agregado)
            mostrarAlerta("Introduce al menos una cantidad mayor que cero", "warning");

        } else {           
            //Calculamos el numero total de productos en el carro
            const totalProductos = carrito.reduce((sum, item) => sum + item.cantidad, 0)
            mostrarAlerta(`Productos agregados al carito correctamente.
            Total de articulos en el carrito <strong>${totalProductos}</strong>`, "success");

        }
        //Reiniciar el formulario
        productosDisponibles.forEach(prod => {
            form.querySelector(`#${prod.id}`).value = 0;
        })
    }


    const mostrar_carrito = () => {
        if (carrito.legth === 0) {
            mostrarAlerta("El carro esta vacio", "warning")
            return;
        }
        let html = `<h5 class="mb-3">Resumen del carrito: </h5><ul class="list-group mb-3">`;
        let total = 0;

        carrito.forEach(item => {
            const subtotal = item.precio * item.cantidad;
            total += subtotal;
           /* d-flex contenedor de algo que sera flexible*/
            html += `<li class="list-group-item d-flex justify-content-between aling-items-center">
            ${item.nombre} - ${item.cantidad}
            <span>$${subtotal.toFixed(2)}</span>
            </li>`
        })
        const iva = total * 0.21;
        const totalFinal = total + iva;
        html += `</ul> 
        <div><strong>Subtotal: </strong>$${total.toFixed(2)}</div>
        <div><strong>IVA (21%);</strong>$${iva.toFixed(2)}</div>
        <div class="mb-2"><strong>Total final;</strong>$${totalFinal.toFixed(2)}</div>
        `

        resultadoDiv.innerHTML = `
        <div class="alert alert-primary alert-dismissible fade show" role="alert">
        ${html}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button></div>
        `
    }

    //Vaciar el carro
    const vaciar_carrito = () => {
        carrito.length = 0
        mostrarAlerta("Carrito vaciado del todo", "danger");
    }

    //Asociar eventos con botones
    form.querySelector("#btnAgregar")?.addEventListener('click', agregar_carrito)
    form.querySelector("#btnMostrar")?.addEventListener('click', mostrar_carrito)
    form.querySelector("#btnVaciar")?.addEventListener('click', vaciar_carrito)
})

