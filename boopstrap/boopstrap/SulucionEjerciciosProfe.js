document.addEventListener("DOMContentLoaded", () => { //Hasta que no se carguen todos los arboles DOM no comienza el código
    const form = document.querySelector("#formulario1")
    if (!form) return //Si no existe el formulario se acaba el programa

    //PRIMER EJERCICIO

    const getNumeros = () => [
        Number(form.querySelector("#txtNumero1")?.value || 0),
        Number(form.querySelector("#txtNumero2")?.value || 0),
        Number(form.querySelector("#txtNumero3")?.value || 0)
    ]

    const calcularMedia = () => {
        const numeros = getNumeros()
        alert(numeros)
        if (numeros.some(isNaN)) return
        const media = numeros.reduce((a, b) => a + b, 0) / numeros.length
        form.querySelector("#txtMedia").value = media.toFixed(2)
    }
    const encontrarMayor = () => {
        const numeros = getNumeros()
        if (numeros.some(isNaN)) return
        const mayor = Math.max(...numeros)
        form.querySelector("#txtMayor").value = mayor.toFixed(2)

    }

    const encontrarMenor = () => {
        const numeros = getNumeros()
        if (numeros.some(isNaN)) return
        const menor = Math.min(...numeros)
        form.querySelector("#txtMenor").value = menor.toFixed(2)
    }

    //SEGUNDO EJERCICIO



    let aleatorio = Math.floor(Math.random() * 100) + 1
    let oportunidades = 0

    const adivinar = () => {
        const input = form.querySelector("#txtNumeroJuego")
        const resultadoDiv = form.querySelector("#resultado")
        if (!input || resultadoDiv) return

        const numero = parseInt(input.value)
        if (isNaN(numero) || numero < 1 || numero > 1) {
            resultadoDiv.innerHTML = `
            <div class="alert alert-warning alert-dismissible fade show" role="alert">
            Introduce un número válido entre 1 y 100
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            </div>
            `
            return
        }

        oportunidades++
        resultadoDiv.innerHTML = ""
        if (nuero === aleatorio) {
            resultadoDiv.innerHTML = `
            <div class="alert alert-success alert-dismissible fade show" role="alert">
            !Acertaste! El número aleatorio era: <strong>${aleatorio}</strong><br/>
            Lo lograste en <strong>${oportunidades} intentos
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>

            `
        } else if (oportunidades >= 6) {
            resultadoDiv.innerHTML = `
            <div class="alert alert-success alert-dismissible fade show" role="alert">
            Se acabaron los intentos. El número era <strong> ${aleatorio} </strong><br>
            !Intentalo otra vez!
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            `
            reiniciarJuego()
        } else if (numero > aleatorio) {
            resultadoDiv.innerHTML = `
            <div class="alert alert-success alert-dismissible fade show" role="alert">
            Demasiado alto. Te quedan <strong> ${6 - oportunidades} </strong><br>
            !Intentalo otra vez!
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            `
        } else {
            resultadoDiv.innerHTML = `
            <div class="alert alert-success alert-dismissible fade show" role="alert">
            Demasiado bajo. Te quedan <strong> ${6 - oportunidades} </strong><br>
            !Intentalo otra vez!
            <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            `
        }
        input.value = ""

    }

    const reiniciarJuego = () => {
        let aleatorio = Math.floor(Math.random() * 100) + 1
        let oportunidades = 0
    }



    //Gestion de eventos
    form.querySelector("#btnMedia")?.addEventListener("click", calcularMedia)
    form.querySelector("#btnMayor")?.addEventListener("click", encontrarMayor)
    form.querySelector("#btnMenor")?.addEventListener("click", encontrarMenor)
    form.querySelector("#btnAdivinar")?.addEventListener("click", adivinar)

})