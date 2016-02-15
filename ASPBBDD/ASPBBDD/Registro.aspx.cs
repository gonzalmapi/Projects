using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ASPBBDD
{
    public partial class Registro : System.Web.UI.Page
    {
        private SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        private SqlTransaction transacion;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            using (SqlCommand reg = new SqlCommand())
            {
                try
                {
                    conexion.Open();
                    transacion = conexion.BeginTransaction();
                    reg.Connection = conexion;
                    reg.CommandText = "insert into dbo.Usuario values (NIF,nombre,apellidos,direccion,localidad,provincia)";
                    reg.Parameters.Add("NIF", System.Data.SqlDbType.NChar, 10);
                    reg.Parameters["NIF"].Value = TBNIF.Text;
                    reg.Parameters.Add("nombre", System.Data.SqlDbType.VarChar, 50);
                    reg.Parameters["nombre"].Value = TBNombre.Text;
                    reg.Parameters.Add("apellidos", System.Data.SqlDbType.VarChar, 100);
                    reg.Parameters["apellidos"].Value = TBApe.Text;
                    reg.Parameters.Add("localidad", System.Data.SqlDbType.VarChar, 50);
                    reg.Parameters["localidad"].Value = TBLoc.Text;
                    reg.Parameters.Add("direccion", System.Data.SqlDbType.VarChar, 100);
                    reg.Parameters["direccion"].Value = TBDir.Text;
                    reg.Parameters.Add("provincia", System.Data.SqlDbType.VarChar, 50);
                    reg.Parameters["provincia"].Value = TBProv.Text;
                    reg.Transaction = transacion;
                    reg.ExecuteNonQuery();
                }
                catch (SqlException ex) {
                   
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            using (SqlCommand miscomandos = new SqlCommand())
            {
                try
                {
                    conexion.Open();
                    transacion = conexion.BeginTransaction();
                    miscomandos.CommandText = "Select nif from usuarios where nif=@nif";
                    miscomandos.Parameters.Add("NIF", System.Data.SqlDbType.NChar, 10);
                    miscomandos.Parameters["NIF"].Value = TBNIF.Text;
                    miscomandos.Connection = conexion;
                    miscomandos.Transaction = transacion;
                    SqlDataReader lecor = miscomandos.ExecuteReader();
                    if (lecor.HasRows)
                    {
                        lecor.Close();
                        miscomandos.CommandText = "update usuarios set nombre=@nombre,apellidos=@apellidos,localidad=@localidad,direccion=@direccion,provincia=@provincia";
                        miscomandos.Parameters.Add("nombre", System.Data.SqlDbType.VarChar, 50);
                        miscomandos.Parameters["nombre"].Value = TBNombre.Text;
                        miscomandos.Parameters.Add("apellidos", System.Data.SqlDbType.VarChar, 100);
                        miscomandos.Parameters["apellidos"].Value = TBApe.Text;
                        miscomandos.Parameters.Add("localidad", System.Data.SqlDbType.VarChar, 50);
                        miscomandos.Parameters["localidad"].Value = TBLoc.Text;
                        miscomandos.Parameters.Add("direccion", System.Data.SqlDbType.VarChar, 100);
                        miscomandos.Parameters["direccion"].Value = TBDir.Text;
                        miscomandos.Parameters.Add("provincia", System.Data.SqlDbType.VarChar, 50);
                        miscomandos.Parameters["provincia"].Value = TBProv.Text;
                        miscomandos.ExecuteNonQuery();
                    }
                    transacion.Commit();
                }
                catch (SqlException ex)
                {

                    transacion.Rollback();
                }
                finally
                {
                    this.conexion.Close();
                }
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlCommand miscomandos = new SqlCommand())
            {
                try
                {
                    conexion.Open();
                    transacion = conexion.BeginTransaction();
                    miscomandos.CommandText = "Delete from usuarios where nif=@nif";
                    miscomandos.Parameters.Add("NIF", System.Data.SqlDbType.NChar, 10);
                    miscomandos.Parameters["NIF"].Value = TBNIF.Text;
                    miscomandos.Connection = conexion;
                    miscomandos.Transaction = transacion;
                    SqlDataReader lecor = miscomandos.ExecuteReader();
                    if (lecor.HasRows)
                    {
                        lecor.Close();
                        miscomandos.ExecuteNonQuery();
                    }
                    transacion.Commit();
                }
                catch (SqlException ex)
                {

                    transacion.Rollback();
                }
                finally
                {
                    this.conexion.Close();
                }
            }
        }
    }
}