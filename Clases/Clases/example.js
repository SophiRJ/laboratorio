

class MyData {
    constructor() {
        this.name = "Javier";
        this.weather = "sunny";
    }
    printMessages = () => {
        console.log(`Hello ${this.name}`)
        console.log(`Today is ${this.weather}`)
    }
}

let myDta = new MyData();
//let secondObject = {};

//Object.assing(secondObject, myDta);
//secondObject.printMessages();
//myDta.printMessages();

//Copiar propiedades desde un objeto a otro-> assing

//usando spread operator
let secondObject = { ...myDta, weather = "cloudy" }
console.log(`myData: ${myDta.weather},secondObject: ${secondObject.weather}`);


//herencia
class Persona {
    constructor(nombre, edad) {
        this.nombre = nombre;
        this.edad = edad;
    }
    saludar() {
        console.log(`Hola soy${this.nombre}y tengo${this.edad}`)
    }
}
const persona = new Persona("Ana", 24);
persona.saludar();

class Empleado extends Persona {
    constructor(nombre,edad,puesto) {
        super(nombre, edad);
        this.puesto = puesto;
    }
    trabajar() {
        console.log(`${this.nombre} esta haciendo de ${this.puesto}`)
    }

}
const empleado = new Empleado("Luis", 29)
empleado.saludar()
empleado.trabajar()

//Capturar nombres de parametros desde objetos
const myData = {
    name: "Javier",
    location: {
        city: "Madrid",
        country:"Spain"
    },
    employment: {
        title: "Manager",
        dept:"Sales"
    }
    
}
//function printDatails(data) {
//    console.log(`Name ${data.name} , City:${data.location.city},Role:${data.emplyment.title}`)
//}
//otra forma de hacerlo mas facil y la mejor por que le estamos mandando un objeto
function printDetails({ name, location: { city }, employment: { title } }) {
    console.log(`Name${name},City:${city},Role:${title}`)
}

printDatails(myData);
