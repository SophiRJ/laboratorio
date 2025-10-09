//Ejercicio 1
let numeros = [23, 45, 12, 3, 100, 13, 3, 1]
console.log(`Longitud del array ${numeros.length}`)

let arrayOrdenado = numeros.sort((a, b) => a - b);
arrayOrdenado.forEach(item => {
    console.log(item)
})
let min = arrayOrdenado[0]
console.log(`El numero menor es ${min}`)
let max = arrayOrdenado[arrayOrdenado.length-1]
console.log(`El numero mayor es ${max}`)

//Dobles
numeros.map(item => console.log(item*2))

//2. Objetos y acceso a propiedades
console.log("Ejercicio 2")
class Coche {
    constructor(marca,modelo,año) {
        this.marca = marca;
        this.modelo=modelo;
        this.año = año;
        this.enMarcha=false;
    }
    mostrarMarcaModelo() {
        console.log(`Marca: ${this.marca}, modelo: ${this.modelo}`)
    }
    arrancar() {
        this.enMarcha = true;
        console.log(`El coche esta en marcha ${this.enMarcha}`)
    }
    
}
let coche1 = new Coche("AUDI", "C-11", 2003);
coche1.mostrarMarcaModelo();
coche1.arrancar();
coche1.color = "rojo";
console.log(`El color del coche ${coche1.marca} ${coche1.modelo} es ${coche1.color}`)

//3. Bucles y lógica
console.log("Ejercicio 3")
let palabras = ["sol", "luna", "estrella", "planeta", "galaxia", "universo"];

let palabras2 = palabras.filter(item => item.length > 5)
console.log(`Palabras con mas de 5 letras ${palabras2}`)

let palabrasConA = palabras.filter(item => item.includes("a"));
console.log(`Palabras que contienen 'a': ${palabrasConA.length}`);

let palabrasMayus = palabras.map(item => item.toUpperCase())
palabrasMayus.forEach(item => console.log(item))

//4.Funciones con parámetros y return
console.log("Ejercicio 3")
function calcularPromedio(array) {
    let promedio = 0;
    let suma = 0;
    array.forEach(item => {
        suma=suma+item
    })
    console.log(`Suma: ${suma}`)
    promedio = suma / array.length
    console.log(`Promedio: ${promedio}`)
}
calcularPromedio(numeros)

function esPar(numero) {
    let esPar;
    if (numero % 2 === 0) {
        esPar = true;
    } else {
        esPar = false;
    }
    return esPar;
}
console.log(`${esPar(71)} 71`)

//pares impares
let arrayPares = []
let arrayImpares= []

numeros.forEach(item => {
    if (esPar(item)) {
        arrayPares.push(item)
    } else {
        arrayImpares.push(item)
    }
})
console.log("Array Pares")
arrayPares.forEach(item => console.log(item))
console.log("Array Impares")
arrayImpares.forEach(item=>console.log(item))


//5. Funciones con Arrays
function filtrarPorLetra(array,caracter) {
    let nuevoArray = array.filter(item => item[0] === caracter);
    nuevoArray.forEach(item => console.log(item));
}
let palabras1 = ["sol", "satelite", "estrella", "planeta", "selenio", "universo"];
filtrarPorLetra(palabras1,"s")
