using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Agapea.App_Code.Controladores;
using Agapea.App_Code.Modelos;

namespace Agapea.App_Code.Controladores
{
    public class Controlador_Vista_Inicio
    {
        private Controlador_Acceso_Fichero_Libro controlador = new Controlador_Acceso_Fichero_Libro(HttpContext.Current.Server.MapPath("~/Ficheros/Libro.txt"));
        public Dictionary<String, Libro> RecuperarLibrosMasVendidos()
        {
            Dictionary<String, Libro> coleccionLibros = new Dictionary<String, Libro>();
            foreach (string lib in controlador.RecuperaLineasFichero())
            {
                string[] campos = lib.Split(new char[] { ':' });
                coleccionLibros.Add(campos[4], new Modelos.Libro()
                {
                    titulo = campos[0],
                    autor = campos[1],
                    editorial = campos[2],
                    paginas = campos[3],
                    isbn10 = campos[4],
                    isbn13 = campos[5],
                    precio = campos[6],
                    categoria = campos[7],
                    subcategoria = campos[8]
                });
            }
            return coleccionLibros;
     }
        public Dictionary<String, List<string>> RecuperarCatySub()
        {
            Dictionary<string, List<string>> CategoriasySubcategorias = new Dictionary<string, List<string>>();
            List<string> filas = controlador.RecuperaLineasFichero();

            /* .... recuperamos de todas las lineas del fichero la categoria:subcategoria
             * .....una consulta de este tipo:
             *
            List<string> catysubcat = (from linea in miaccesoFichero.RecuperaLineasFichero()
                      let categ = linea.Split(new char[] { ':' })[7]
                      let subcat = linea.Split(new char[] { ':' })[8]
                      select  categ + ":" + subcat).Distinct().ToList();
             *             
            */
            List<string> catysubcat = filas.Select(f => f.Split(new char[] { ':' })[7] + ":" + f.Split(new char[] { ':' })[8]).Distinct().ToList();

            foreach (string tupla in catysubcat)
            {
                string categoria = tupla.Split(new char[] { ':' })[0];
                if (!CategoriasySubcategorias.Keys.Contains(categoria))
                {
                    List<string> subcategorias = (from elemento in catysubcat
                                                  where categoria == elemento.Split(new char[] { ':' })[0].ToString()
                                                  select elemento.Split(new char[] { ':' })[1]).ToList();

                    CategoriasySubcategorias.Add(categoria, subcategorias);
                }

            }
            return CategoriasySubcategorias; //<---devuelvo algo asi: [ "Informatica", ["Programacion","Bases de Datos",...],    "Derecho",["Derecho Penal","Derecho Civil",.... ] .... ]
        }

        public Libro[] BuscarLibrosCategoria(string criterio, string valor)
        {
            Func<string, bool> Filtro;
            if (criterio == "categoria") { Filtro = delegate (string fila) { return fila.Split(new char[] { ':' })[7] == valor; }; } else { Filtro = delegate (string fila) { return fila.Split(new char[] { ':' })[8] == valor; }; };


            return controlador.RecuperaLineasFichero().Where(Filtro).Select(delegate (string linea)
            {
                string[] campos = linea.Split(new char[] { ':' });
                return new Libro()
                {
                    titulo = campos[0],
                    autor = campos[1],
                    editorial = campos[2],
                    paginas = campos[3],
                    isbn10 = campos[4],
                    isbn13 = campos[5],
                    precio = campos[6],
                    categoria = campos[7],
                    subcategoria = campos[8]
                };
            }).ToArray();
        }

    }
}