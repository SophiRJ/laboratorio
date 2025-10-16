document.addEventListener("DOMContentLoaded", () => {
    const recetas = [
        { "id": 1, "nombre": "Callos", "categoria": "Comida", "dificultad": "Fácil", "tiempo": 20 },
        { "id": 2, "nombre": "Salmorejo", "categoria": "Bebida/Sopa fría", "dificultad": "Fácil", "tiempo": 15 },
        { "id": 3, "nombre": "Milanesa de Pollo", "categoria": "Comida", "dificultad": "Media", "tiempo": 50 },
        { "id": 4, "nombre": "Tarta de queso", "categoria": "Postre", "dificultad": "Media", "tiempo": 30 },
        { "id": 5, "nombre": "Salsa Pesto", "categoria": "Salsa", "dificultad": "Fácil", "tiempo": 10 },
        { "id": 6, "nombre": "Pizza Margarita", "categoria": "Comida", "dificultad": "Media", "tiempo": 45 },
        { "id": 7, "nombre": "Arroz con Leche", "categoria": "Postre", "dificultad": "Fácil", "tiempo": 15 },
        { "id": 8, "nombre": "Filete de Pescado", "categoria": "Pescado", "dificultad": "Difícil", "tiempo": 60 },
        { "id": 9, "nombre": "Hummus Clásico", "categoria": "Aperitivo", "dificultad": "Fácil", "tiempo": 5 },
        { "id": 10, "nombre": "Lasagna Bolognesa", "categoria": "Comida", "dificultad": "Difícil", "tiempo": 90 },
        { "id": 11, "nombre": "Mousse de Chocolate", "categoria": "Postre", "dificultad": "Media", "tiempo": 25 },
        { "id": 12, "nombre": "Burritos de Pollo", "categoria": "Comida", "dificultad": "Media", "tiempo": 35 }
    ];


    const contenedorRecetas = document.querySelector("#listaRecetas")
    const alertasDiv = document.querySelector("#alertas")
    const inputTxt = document.querySelector("#filtroNombre")

    const modal = new bootstrap.Modal(document.querySelector("#modalReceta"))
    

    const [modalNombre, modalCategoria, modalDificultad, modalTiempo] =
        ["#modalNombre", "#modalCategoria", "#modalDificultad", "#modalTiempo"].map(selector => document.querySelector(selector));

    const mostrarRecetas = (array) => {
        if (!contenedorRecetas) return
        contenedorRecetas.innerHTML = array.map(({ id, nombre, categoria }) =>
            `
            <div class="col-md-3">
                <div class="card shadow-lg border-0 h-100 text-center hover-card"
                data-id="${id}" style="cursor:pointer;">
                    <div class="card-body">
                        <h5 class="card-title text-primary fw-bold">${nombre}</h5> 
                        <p class="card-text text-muted">${categoria}</p> 
                    </div> 
                </div> 
            </div>
            `
        ).join("");
        document.querySelectorAll(".card[data-id]").forEach(card => {
            card.addEventListener("click", e =>
                verReceta(Number(card.dataset.id))
            );
        });
    };

    const verReceta = id => {
        const receta = recetas.find(rect => rect.id === id)
        if (!receta) return;
        const { nombre, categoria, dificultad, tiempo } = receta
        modalNombre.textContent = nombre
        modalCategoria.textContent = categoria
        modalDificultad.textContent = dificultad
        modalTiempo.textContent = tiempo

        modal.show()
    }
    mostrarRecetas(recetas);

    const mostrarAlerta = (mensaje, tipo = "success") => {
        alertasDiv.innerHTML = `<div class="alert alert-${tipo} alert-dismissible fade show" role="alert">
        ${mensaje}<button type="button" class="btn-close" data-bs-dismiss="alert"></button></div>
        `
    }

    inputTxt.addEventListener("input", () => {
        const txt = inputTxt.value.trim().toLowerCase()

        const arrayClonado = [...recetas]
        const arrayFiltrado = arrayClonado.filter(item => item.nombre.toLowerCase().includes(txt))

        if (arrayFiltrado.length === 0) {
            mostrarAlerta("No se encontraron recetas", "danger")
            contenedorRecetas.innerHTML = ""
        } else {
            mostrarRecetas(arrayFiltrado)
            alertasDiv.innerHTML = ""
        }  
    })   
})