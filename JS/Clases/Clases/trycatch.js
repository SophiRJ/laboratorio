try {
    const usuario = JSON.parse('{"nombre":"Ana"}');
    console.log(usuario.nombre)
} catch (error) {
    console.error("Se produjo un error", error.message);
}

console.log("Sigo funcionando con el programa")
    
