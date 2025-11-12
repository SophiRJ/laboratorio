let miFactura = newObject;

//propiedades
miFactura.nombre = "Farmacia"
miFactura.direccion = "Calle Reina Victoria"
miFactura.telefono = "123456789"
miFactura.nif = "789456asd"

//Elementos
miFactura.Elementos = new JSON()
let producto1 = {
    descripcion="Lavadora",
    precio=325,
    cantidad=7
}
let producto2 = {
    descripcion="Secadora",
    precio=340,
    cantidad=25
}
let producto3 = {
    descripcion="Aspiradora",
    precio=140,
    cantidad=12
}

miFactura.Elementos[0] = producto1;
miFactura.Elementos[1] = producto2;
miFactura.Elementos[2] = producto3;

miFactura.importeTotal = 0
miFactura.tipoIva = 0.13

miFactura.formaPago = new Array()
miFactura.formaPago[0] = "Efectivo"
miFactura.formaPago[1] = "Tarjeta Bancaria"
miFactura.formaPago[2] = "Bizum"

//metodos-> utilizar la anotacion json
miFactura.calcularImporte() = {

}
miFactura.mostrarImporte() = {

}

