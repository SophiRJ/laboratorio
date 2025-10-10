//const myfunct = function () {
//    console.log("this stament is inside the function");
//}
//console.log("this stament is outside the function");
//myFunct();
//function myFunc(name, weather) {
//    console.log(`Hello ${name}`)
//    console.log(`it is ${weather} today`)
//}
//myFunc("Maria", "sunny");
//function myfunc(name, weather = "raining",last_name) {
//    console.log(`Hello ${name}`)
//    console.log(`it is ${weather} today`)
//    console.log(`lastname is ${last_name}`)
//}

//myfunc("Javier",undefined,"Vazquez");
//function myfunc(name, weather, ...extraArgs) {//van a llegar parametros mas que yo no conozco
//    console.log(`Hello ${name}`)
//    console.log(`it is ${weather} today`)
//    for (let i = 0; i > extraArgs.length; i++) {
//        console.log(`Extra Args: ${extraArgs[i]}`);
//    }
//}
//myfunc("Jesus", "sunny", "one", "two", "three");

//funtion myFunc(name){
//    return(`Helle ${name}`)
//}
//myFunc
//function myFunc(nameFunction) {
//    return (`Hello ${nameFunction()}`),
//}
//function printName(nameFunction, printFunction) {
//    printFunction(myFunc(nameFunction))//aqui le estamos diciendo que esta parametro se va usar como funcion
//}
//printName(function () { return "Javier" }, console.log);

//Funciones Flecha
//nombre del parametro con ese parametro le decimos lo que tiene que hacer
//const myFunc = (nameFunction) => (`Hello ${nameFunction()}`)
//const printName = (nameFunction, printFunction) => printFunction(myFunc(nameFunction));
//printName(function () { return "Javier" }, console.log);
////Bool
//let firstBool = true;
//let secondBool = false;
////String
//let firstString = 'And so is this';
//let secondString = 'This is a String';

////template strings
//let weather = "sunny"
//ley message = `It is ${weather} today`;

////Numbers
//let dayInWeek = 7;
//let pi = 3.14;
//let hexValue = 0xFFF;


////Operadores de identidad y de igualdad
////Igualdad
//let firstVal = 5;
//let secondVal = "5";
//if (firsVal === secondVal) {
//    console.log("They are the same")
//} else {
//    console.log("They are NOT the same ")
//}

////Conversiones tipos
////numbers tu string
//let myData1 = (5).toString() + String(5);
//console.log(`Result ${myData1}`)

////String to number
//let firstVal = "5";
//let secondVal = "5";
////estamos contruyendo un objeto de number
//let resultado = Number(firstVal) + Number(secondVal);
//console.log(`Result ${result}`)

////MEtodos
////Number(str)
////parseInt(str)
////parseFloat(str)

//ARRAYS
//diferentes tipos
//let miArray = new Array();
//miArray[0] = 100;
//miArray[1] = "Javier";
//miArray[2] = true;

//declarar de maner literal
//let myArray1 = [100, "Javier", true];
//console.log(`Index 0: ${myArray[0]}`);

//myArray1[0] = "Tuesday";
//console.log(`Index 0: ${myArray[0]}`);

//recorrer
//for (let i = 0; i < myArray1.length; i++) {
//    console.log(`Index ${myArray1[i]}`)
//}
//foreach

/*myArray1.forEach((value, index) => console.log(`Index ${index}:${value}`));*/

//Operador e propagacion: spread operator-> para expandir un array para que su contenido lo pueda usar en otras funciones
//mediante los ... lo va a mapear y lo va a colocar pasar como parametros
//function printItems(numValue, stringValue, boolValue) {
//    console.log(`Number: ${numValue}`)
//    console.log(`String: ${stringValue}`)
//    console.log(`Boolean: ${boolValue}`)
//}

//let myArray2 = [100, "Javier", true]
//printItems(myArray2[0], myArray2[1], myArray2[2])

//printItems(...myArray2);

//Metodos de arrays
//every(test)
//let numeros = [2, 4, 6, 8, 10];
//let todosPares = numeros.every(num => num % 2 === 0);
//console.log("Todos son pares?", todosPares);


//some(test).> solo alguno uno
//let edades = [15, 17, 22, 14, 19];
//ley hayAdulto = edades.some(edad => edad >= 18) //usamos una variable de paso para que compruebe sobre esa
//console.log("Hay algun mayor de edad", hayAdulto);

//join(separator)->une con un separador
//let frutas = ["manzana", "pera", "platano", "naranja"];
//let lista = frutas.join(" ");
//console.log(lista);

////filter(test)
//let numeros = [3, 8, 12, 5, 19, 20, 7]
//let mayoresQueDiez = numeros.filter(num => num >= 10);

////find(test)-> solo extrae el priero en la busqueda en este caso 20
//let numeros1 = [4, 9, 15, 22, 90, 33];
//let mayorQueVeinte = numeros.find(num => num > 20);

//let frutas = ["manzana", "pera", "platano", "naranja"];
//let frutaLarga = frutas.find(fruta => fruta.length > 6)

////
//let nombres = ["Ana", "Luis", "Meria", "Pedro"];
//nombres.forEach(nombre => {    //hacemos una funcion
//    console.log(`Hola ${nombre}`)
//})
//Elevar al cuadradoa todoslos elementos de la funcion
//let numeros = [3, 8, 12, 5, 19, 20, 7]
//numeros.forEach(numero => {
//    console.log(`El cuadrado del numero ${numero} es ${Math.pow(numero,2)}`)
//})

////map
//let numeros = [1, 2, 3, 4, 5];
//let numerosDobles = numeros.map(num => num * 2);

//let nombres = ["Ana", "Luis", "Meria", "Pedro"];
//let saludos = nombres.map(nombre => `Hola ${nombre}`)
//array de objetos

//let alumnos = [
//    { nombre: "Juan", nota: 7 },
//    { nombre: "Lucia", nota: 9 },
//    { nombre: "Carlos", nota: 5 }
//];
//let notasMultiplicadas = alumnos.map(alumno => alumno.nota * 10);

//let products = [
//    { name: "Hat", price: 24.5, stock: 10 },
//    { name: "Kayac", price: 289.99, stock: 1 },
//    { name: "Soccer Ball", price: 10, stock: 0 },
//    { name: "Running Shoes", price: 116.50, stock: 20 },
//]


//let totalValue = products
//    .filter(item => item.stock > 0)
//    .reduce((prev, item) => prev + (item.price * item.stock, 0)
//console.log(`El total valor: $${totalValue.toFixed(2)}`)
