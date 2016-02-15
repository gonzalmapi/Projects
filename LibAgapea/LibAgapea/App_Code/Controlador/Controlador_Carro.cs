using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibAgapea.App_Code.Modelo;

namespace LibAgapea.App_Code.Controlador
{
    public class Controlador_Carro { 
    private Controlador_Ficheros control = new Controlador_Ficheros();
    public List<string> recuperaLibros(string isbn_LibrosAComprar_String)
    {
        control.RutaFichero = "~/ficheros/Libros.txt";
        control.AbrirFichero("ruta", "leer");

        List<string> filas = control.recuperarLineas();

        List<string> librosRecuperadosFichero = new List<string>();

        List<string> isbn_List = isbn_LibrosAComprar_String.Split(new char[] { '$' }).ToList();

        foreach (string isbnLibros in isbn_List)
        {
            if (isbnLibros != "")
            {
                string libroRecup = (from unaLinea in filas.Where(linea => linea.Split(new char[] { ':' })[5] == isbnLibros) select unaLinea).SingleOrDefault();
                librosRecuperadosFichero.Add(libroRecup);
            }
        }
        return librosRecuperadosFichero;
    }


    public List<Libro> fabricaLibro(List<string> librosTransform)
    {
        List<Libro> librosRecuperados = new List<Libro>();

        foreach (string libroATransformar in librosTransform)
        {
            if (libroATransformar != null)
            {
                Libro libroRecuperado = new Libro();
                string[] argumentos = libroATransformar.Split(new char[] { ':' });

                libroRecuperado.titulo = argumentos[0];
                libroRecuperado.autor = argumentos[1];
                libroRecuperado.editorial = argumentos[2];
                libroRecuperado.categoria = argumentos[3];
                libroRecuperado.subcategoria = argumentos[4];
                libroRecuperado.ISBN10 = argumentos[5];
                libroRecuperado.ISBN13 = argumentos[6];
                libroRecuperado.precio = decimal.Parse(argumentos[7]);
                libroRecuperado.paginas = argumentos[8];
                libroRecuperado.resumen = argumentos[9];
                libroRecuperado.cantidad = int.Parse(argumentos[10]);

                librosRecuperados.Add(libroRecuperado);
            }
        }

        return librosRecuperados;

    }

    public Usuario datosUsuario(List<string> infoCookie)
    {
        string loginUsuario = infoCookie[0].ToUpper();
        Usuario user = new Usuario();
        if (loginUsuario != "ANONYMOUS")
        {
            control.RutaFichero = "~/ficheros/usuarios.txt";
            control.AbrirFichero("ruta", "leer");
            user = control.recuperaUsuario(loginUsuario);
        
        }

        return user;
    }
}
}