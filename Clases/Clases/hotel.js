const reserva = {
    hotel: { nombre: "Plaza", direccion: "Av Badajoz 7", telefono: "456789123" },
    cliente: { nombre: "", Apellidos: "", telefono: "" },
    habitacion: { tipo: "", precioNoche: 0, numeroNoches: 0 },
    extras: [],
    total: 0,

    calculartotal: function () {
        let totalExtras = this.extras.reduce((acumulador, extra) => acumulador + extra.precio, 0);
        let subtotal = this.habitacion.numeroNoches * this.habitacion.precioNoche;
        this.total = totalExtras + subtotal;
    },

    mostrarDetalles: function () {
        const form = document.getElementById("formReserva");
        form.addEventListener("submit", (e) => {   
            e.preventDefault();

            this.cliente.nombre = document.getElementById("nombre").value;
            this.cliente.Apellidos = document.getElementById("apellidos").value;
            this.cliente.telefono = document.getElementById("telefono").value;

            this.habitacion.tipo = document.getElementById("tipoHabitacion").selectedOptions[0].text;
            this.habitacion.precioNoche = parseFloat(document.getElementById("tipoHabitacion").value);
            this.habitacion.numeroNoches = parseInt(document.getElementById("noches").value);

            this.extras = [];
            document.querySelectorAll(".extra").forEach(checkbox => {
                if (checkbox.checked) {
                    this.extras.push({
                        descripcion: checkbox.dataset.descripcion,
                        precio: parseFloat(checkbox.value)
                    });
                }
            });


            this.calculartotal()

            
            const contenedor = document.getElementById("contenedor");
            contenedor.innerHTML = "<h1>Reserva</h1>";

            contenedor.innerHTML += `<p><b>Hotel:</b> ${this.hotel.nombre}</p>`;
            contenedor.innerHTML += `<p><b>Dirección:</b> ${this.hotel.direccion}</p>`;
            contenedor.innerHTML += `<p><b>Teléfono:</b> ${this.hotel.telefono}</p>`;

            contenedor.innerHTML += "<h2>Datos Cliente</h2>";
            contenedor.innerHTML += `<p><b>Nombre:</b> ${this.cliente.nombre} ${this.cliente.Apellidos}</p>`;
            contenedor.innerHTML += `<p><b>Teléfono:</b> ${this.cliente.telefono}</p>`;

            contenedor.innerHTML += "<h2>Detalles Reserva</h2>";
            contenedor.innerHTML += `<p><b>Habitación:</b> ${this.habitacion.tipo}</p>`;
            contenedor.innerHTML += `<p><b>Precio por Noche:</b> ${this.habitacion.precioNoche} €</p>`;
            contenedor.innerHTML += `<p><b>Número de Noches:</b> ${this.habitacion.numeroNoches}</p>`;

            contenedor.innerHTML += "<h3>Extras</h3>";
            if (this.extras.length === 0) {
                contenedor.innerHTML += "<p>No hay extras seleccionados</p>";
            } else {
                this.extras.forEach(extra => {
                    contenedor.innerHTML += `<p><b>Concepto:</b> ${extra.descripcion}, ${extra.precio} €</p>`;
                });
            }

            contenedor.innerHTML += `<h2>Importe Total: ${this.total} €</h2>`;
        });
    }
}

reserva.calculartotal()
reserva.mostrarDetalles();
