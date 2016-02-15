using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibAgapea.App_Code.Modelo;

namespace LibAgapea.App_Code.Controlador
{
    public class Controlador_Inicio
    {
        private Controlador_Ficheros control = new Controlador_Ficheros();
        public Dictionary<String, List<string>> recuperarCat()
        {
            control.RutaFichero = "~/Ficheros/Libros.txt";
            control.AbrirFichero("ruta", "leer");
            Dictionary<String, List<string>> categorias = new Dictionary<string, List<string>>();
            List<string> filas = control.recuperarLineas();
            List<string> catYSub = filas.Select(f => f.Split(new char[] { ':' })[3] + ":" + f.Split(new char[] { ':' })[4]).Distinct().ToList();

            foreach (string tupla in catYSub)
            {
                string categoria = tupla.Split(new char[] { ':' })[0];

                if (!categorias.Keys.Contains(categoria))
                {
                    List<string> subcategorias = (from elemento in catYSub
                                                  where categoria == elemento.Split(new char[] { ':' })[0].ToString()
                                                  select elemento.Split(new char[] { ':' })[1]).ToList();
                    categorias.Add(categoria, subcategorias);
                }
            }
            return categorias;
        }
        public List<Libro> listaLibrosRecuperados()
        {
            List<Libro> listaLibrosRecuperados = new List<Libro>();

            control.RutaFichero = "~/ficheros/Libros.txt";
            control.AbrirFichero("ruta", "leer");

            List<string> lineasFicheroRecuperadas = control.recuperarLineas();

            for (int i = 0; i < lineasFicheroRecuperadas.Count; i++)
            {
                Libro libroRecuperado = new Libro();
                string[] argumentos = lineasFicheroRecuperadas[i].Split(new char[] { ':' });

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
                libroRecuperado.cantidad= int.Parse(argumentos[10]);

                listaLibrosRecuperados.Add(libroRecuperado);
            }

            return listaLibrosRecuperados;

        }
        public List<Libro> recuperarLibrosPorParametro(string parametro, string valor)
        {
            control.RutaFichero = "~/ficheros/Libros.txt";
            control.AbrirFichero("ruta", "leer");

            List<Libro> librosRecuperadosList = new List<Libro>();
            List<string> filas = control.recuperarLineas();

            List<string> librosDeLaCategoria = new List<string>();

            switch (parametro)
            {
                case "Categoria":
                    librosDeLaCategoria = (from unaLinea in filas
                                           let categoria = unaLinea.Split(new char[] { ':' })[3].ToString()
                                           where valor == categoria
                                           select unaLinea).ToList();
                    break;

                case "Subcategoria":
                    librosDeLaCategoria = (from unaLinea in filas
                                           let subCategoria = unaLinea.Split(new char[] { ':' })[4].ToString()
                                           where valor == subCategoria
                                           select unaLinea).ToList();
                    break;

                case "ISBN":
                    librosDeLaCategoria = (from unaLinea in filas
                                           let isbn = unaLinea.Split(new char[] { ':' })[5].ToString()
                                           where valor == isbn
                                           select unaLinea).ToList();
                    break;

                case "Titulo":
                    librosDeLaCategoria = (from unaLinea in filas
                                           let titulo = unaLinea.Split(new char[] { ':' })[0].ToString()
                                           where titulo.Contains(valor)
                                           select unaLinea).ToList();
                    break;

                case "Autor":
                    librosDeLaCategoria = (from unaLinea in filas
                                           let autor = unaLinea.Split(new char[] { ':' })[1].ToString()
                                           where autor.Contains(valor)
                                           select unaLinea).ToList();
                    break;



            }

            for (int i = 0; i < librosDeLaCategoria.Count; i++)
            {
                string[] argumentos = librosDeLaCategoria[i].Split(new char[] { ':' });

                Libro libroRecuperado = new Libro();

                libroRecuperado.titulo = argumentos[0];
                libroRecuperado.autor = argumentos[1];
                libroRecuperado.editorial = argumentos[2];
                libroRecuperado.categoria = argumentos[3];
                libroRecuperado.subcategoria = argumentos[4];
                libroRecuperado.ISBN10 = argumentos[5];
                libroRecuperado.ISBN13 = argumentos[6];
                libroRecuperado.precio = decimal.Parse(argumentos[7]);
                libroRecuperado.paginas =argumentos[8];
                libroRecuperado.resumen = argumentos[9];
                libroRecuperado.cantidad = int.Parse(argumentos[10]);
                

                librosRecuperadosList.Add(libroRecuperado);
            }


            return librosRecuperadosList;
        }
    }
}