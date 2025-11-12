let elObjeto = new Object();
let laCadena = new String();

//propiedad
elObjeto.id = "10";
elObjeto.nombre = "Objeto de prueba";

//metodo asociado a una funcion
elObjeto.muestraId = function () {
    alert(`El ID del objeto es ${this.id}`)
}
elObjeto.muestraNombre = function () {
    alert(this.nombre)
}

let Application = new Object()
Application.Modulos = new Array();//modulos es una tributo de applicac
Application.Modulos[0] = new Object();
Application.Modulos[0].titulo = "Lector RSS";


let inicial new Object();
inicial.estado = 1
inicial.publica = 0;
inicial.nombre = "Modulo RSS";
inicial.datos = new Object();

Application.Modulos[0].objetoInicial = inicial;

let modulo = {
    titulo: "Lector RSS",
    objetoInicial: {
        estado: 1,
        publico: 0,
        nombre: "Modulo RSS",
        datos: {}
    }
//Enviar datos
let myObjeto ={ name: "Jhon", age: 31, city: "new York" }
var myJson = JSON.stringify(myObjeto);
    //location propiedades del objeto window redirreciona a la direccion
    window.location = "demo_json.aspx?x=" + myJson;

    //Recibir datos
    let myObj= JSON.parse(myjson);

    //addEventListener
    //elemento.addEventListener(evento,funcion,opciones)
    const boton = document.querySelector("#miboton");
    boton.addEventListener("click", () => {
        alert("Hiciste un click en el boton");
    })

    boton.addEventListener("mouseover", () => {
        boton.style.backgroundcolor = "lightblue";
    })

    const elemento = document.querySelector(selector);
    //selector: "#id",".clase","div"

    const boton = document.querySelector(".btn");//para la primera clase btn
    const parrafos = document.querySelectorAll("p");//para todos los parrafos
    const enlace = document.querySelector("div.miseleccion a.enlace");