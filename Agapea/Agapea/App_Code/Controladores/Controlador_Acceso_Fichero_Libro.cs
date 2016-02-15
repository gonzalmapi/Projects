using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Agapea.App_Code.Modelos;

namespace Agapea.App_Code.Controladores
{
    public class Controlador_Acceso_Fichero_Libro
    {
        private string lstrPath;
        private StreamReader fich;

        #region "...definicion de METODOS..."
        public Controlador_Acceso_Fichero_Libro(string path) { lstrPath = path; }
        public List<string> RecuperaLineasFichero()
        {

            AbrirFichero(lstrPath);
            List<String> filas = (from fila in fich.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                                  where fila.Length > 0
                                  select fila).ToList();
            return filas;

            //otra forma con linq:
            //return fich.ReadToEnd().Split(new string[]{Environment.NewLine},StringSplitOptions.None).Where<String>(delegate(String linea) { return linea.Length > 0; }).ToList();                  
        }

        private void AbrirFichero(string path)
        {
            fich = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));
        }
        private void CerrarFichero()
        {
            fich.Close();
        }
        #endregion
    }
}
    
