//const myFunc = function () {
//    console.log("This stament is inside the function");
//}
//console.log("this stament is outside the function");
//myFunc()

//function myFunc(name, weather="raining", last_name) {
//    console.log(`Hello ${name}`)
//    console.log(`It is ${weather} today`)
//    console.log(`lastname is ${last_name}`)
//}
//myFunc("Maria", undefined, "Vazquez");

//function myFunc(name, weather, ...extraArgs) {
//    console.log(`Hello ${name}`)
//    console.log(`It is ${weather} today`)
//    for (let i = 0; i < extraArgs.length; i++) {
//        console.log(`Extra args: ${extraArgs[i]}`)
//    }
//}
//myFunc("Juan", "Jesus", "one", "two", "three");

//function myFunc(name) {
//    return(`Hello ${name}`)
//}
//console.log(myFunc("Sofia"))

//function myFunc(nameFunction){
//    return(`Hello ${nameFunction()}`)
//}
//function printName(nameFunction, printFunction) {
//    printFunction(myFunc(nameFunction))//
//}
//printName(function () { return "Javier" }, console.log);

//const myFunc = (nameFunction) => (`Hello ${nameFunction()}`);
//const printName = (nameFunction, printFunction) => printFunction(myFunc(nameFunction));
//printName(function () {return "Sofia"} , console.log)

//let myString = (5).toString() + String(5); //55
//console.log(`Result ${myString}`)

//let myArray = new Array();
//myArray[0] = 100
//myArray[1] = "Sofia"
//myArray[2] = 3.14

/*let myArray1 = [100, "Juan", 3.14]*/
//for (let i = 0; i < myArray1.length; i++) {
//    console.log(`Posicion ${i + 1} : ${myArray1[i]}`)
//}

/*myArray1.forEach((value, index) => console.log(`Index ${index}:${value}`));*/

//let numeros = [2, 4, 6, 8, 10]
//let todosPares = numeros.every(num => num % 2 == 0)
//console.log(`Todos pares? ${todosPares}`)

//let myArray1 = [13, 32, 4, 12, 5]
//let adultos = myArray1.some(dato => dato > 18);
//console.log(`Hay adulto? ${adultos}`)

//let numeros = [2, 4, 6, 8, 10,11,14]
//let filtro = numeros.filter(numero => numero >= 10)
//filtro.forEach((value, index)=>console.log(`Indice ${index+1}, valor: ${value}`))

//let nombres = ["Ana", "Luis", "Maria", "Pedro"];
//nombres.forEach(nombre => {
//    console.log(`Hola ${nombre}`)
//})

//Si no pongo llaves tambien funciona
//let numeros = [2, 4, 6, 8, 10, 11, 14]
//numeros.forEach(num => console.log(Math.pow(num,2)))

//let numeros = [2, 4, 6, 8, 10, 11, 14]
//let numerosDobles = numeros.map(numero => numero * 2)

//let nombres = ["Ana", "Luis", "Maria", "Pedro"];
//let saludos = nombres.map(nombre => `Hola ${nombre}`)
//saludos.forEach(indice => { console.log(indice) })


//let alumnos = [
//    { nombre: "Juan", nota: 7 },//objeto del tipo alumnos con dos atributos
//    { nombre: "Maria", nota: 4 },
//    { nombre: "Sara", nota: 9 }
//]
//map devuelve un nuevo array con el resultado de llmar a la funcion callback
//let nota = alumnos.map(alumno => alumno.nota * 10)
//nota.forEach(indice => {console.log(indice) })


const suma = [4, 6, 8, 2].reduce(function (a, b) { return a + b });
console.log(suma)
//se pued hacer de las dos formas
const suma1 = [4, 6, 8, 2].reduce((a, b) => a + b);
console.log(`Suma ${suma1}`)

let products = [
    { name: "Hat", price: 24.5, stock: 10 },
    { name: "Kayak", price: 289.99, stock: 1 },
    { name: "Soccer Ball", price: 10, stock: 0 },
    { name: "Running Shoes", price: 116.50, stock: 20 }
];
let totalValue = products
    .filter(item =>  item.stock > 0 )
    .reduce((prev, item) => prev + (item.price * item.stock), 0)

console.log(`El valor total es $${totalValue.toFixed(2)}`)

