using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Biblioteca
    {
        
        List<Libro> lista;
        List<Usuario> usuarios;
        List<PrestamoL> prestamos;

        public Biblioteca()
        {

            lista = new List<Libro>();
            usuarios = new List<Usuario>();
            prestamos = new List<PrestamoL>();
        }
        public void agregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void agregarLibro(Libro libro)
        {
            lista.Add(libro);
        }

        public void prestamo(Libro libr, Usuario usua, DateTime fecha)
        {
            if (lista.Contains(libr) && usuarios.Contains(usua)) {
                if (libr.Disponible == true)
                {
                    PrestamoL p1=new PrestamoL(libr, usua, fecha);
                    libr.Disponible = false;
                    prestamos.Add(p1);
                }
                else
                {
                    Console.WriteLine("El libro no esta disponible");
                }
            }
            else
            {
                Console.WriteLine("Usuario o libro incorrecto");
            }
        }
        public void mostrarPrestamos()
        {
            if(prestamos.Count == 0) { Console.WriteLine("No hay prestamos activs"); }

            foreach (PrestamoL p in prestamos)
            {
                if (p.activo == true)
                {
                    Console.WriteLine($"Libro {p.Libro.Titulo}, Usuario: {p.Usuario.Nombre}, fechaPrestamo: {p.fechaPrestamo}");
                }
            }
        }
        public void mostrarLibros()
        {
            if (lista.Count == 0) {
                Console.WriteLine("No hay libros");
            }
            foreach(Libro libro in lista)
            {
                Console.WriteLine($"Libro: {libro.Titulo}-Autor: {libro.Autor}- Año:{libro.Año}");
            }

        }
        public void BuscarPorNombre(string nombre)
        {
            bool libroEncontrado=false;
            for(int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Titulo.ToLower() == nombre.ToLower()) {
                    libroEncontrado=true;
                    Console.WriteLine($"Libro encontrado {lista[i].Titulo}, Autor: {lista[i].Autor}, Año: {lista[i].Año}");
                }
                
            }
            if (!libroEncontrado)
            {
                Console.WriteLine("Libro no encontrado");
            }
        }
    }
}
