//dos posibles soluciones: resuelta o rechazada
//manejar esos atributos que defino
const promesa = new Promise((resolve, reject) => {
    const exito = true;
    if (exito) {
        resolve("Operacion exitosa")
    } else {
        reject("Hubo un error")
    }
})
//si todo a ido bien llamo a la promesa THEN entonces
promesa.then(resultado => console.log(resultado))
    .catch(error => console.log(error));//si no a ido bien -> catch
//resolve() → devuelve el valor cuando la promesa se cumple.
//reject() → devuelve el error cuando algo falla.
//.then() y .catch() se usan para manejar las respuestas.

function obtenerRecetas()  {
    return new Promise((resolve) => {
        console.log("Cargando recetas....")
        setTimeout(() => {
            //Cuando consiga devolverme info de las ecetas las paso al resolve
            resolve(["Tortilla","Gazpacho","Croquetas"])
        },2000)//tarda 2 segundos
    })
}
//funcion que devuelve setTimeOut array
obtenerRecetas().then(recetas => console.log("Recetas cargadas ", recetas))
    .catch(() => console.log("Error con las recetas"))



                            //Await Async
function obtenerRecetas() {
    return new Promise((resolve) => {
        console.log("Cargando recetas....")
        setTimeout(() => {
            //Cuando consiga devolverme info de las ecetas las paso al resolve
            resolve(["Tortilla", "Gazpacho", "Croquetas"])
        }, 2000)//tarda 2 segundos
    })
}

//async marca la función como asíncrona → siempre devuelve una Promesa.
//await detiene temporalmente la ejecución hasta que la Promesa se resuelva.
//El resto del programa sigue corriendo sin bloquear el hilo principal.
async function mostrarRecetas() {
    console.log("Cargando recetas...")
    const recetas = await obtenerRecetas()// Espera a que la promesa se resuelva
    console.log("Recetas cargadas:",recetas)
}
mostrarRecetas()