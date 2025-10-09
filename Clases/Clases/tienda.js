const carrito = {
    cliente: { nombre: "", telefono: "" },
    productos: [],
    total: 0,
    agregarProducto: function () {
        document.querySelector("#btnAgregar").addEventListener('click', () => {
            this.productos.nombre = document.querySelector("#select").option.value
        })
    }
}