using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace ASPBBDD
{
    public partial class RegistroDataSet : System.Web.UI.Page
    {
        private DataSet midata = new DataSet();
        SqlDataAdapter adap;
        SqlCommandBuilder build;
        private SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
                {
                    try
                    {
                        con.Open();
                        adap = new SqlDataAdapter("select * from usuario", con);
                        build = new SqlCommandBuilder(adap);
                        adap.Fill(midata, "tabusu");

                    }
                    catch (SqlException ec)
                    {


                    }
                    finally
                    {
                        con.Close();
                        Session["midata"] = midata;
                    }

                }
            }else
            {
                midata = (DataSet)Session["midata"];
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            DataTable tablausu = midata.Tables["tabusu"];
            foreach (DataRow item in tablausu.Rows)
            {
                if ((string)item["NIF"] == this.TBNIF.Text)
                {
                    tablausu.Rows.Remove(item);
                }
            }
          //tablausu.Rows.Remove(tablausu.Rows.Cast<DataRowCollection>().Where(item=>(string)item["NIF"] == TBNIF.Text));
        
    }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            DataTable tablausu = midata.Tables["tabusu"];
            foreach  (DataRow item in tablausu.Rows)
            {
                if ((string)item["NIF"] == this.TBNIF.Text) {
                    item["nombre"] = this.TBNombre.Text;
                    item["apellidos"] = this.TBApe.Text;
                    item["direccion"] = this.TBDir.Text;
                    item["localidad"] = this.TBLoc.Text;
                    item["provincia"] = this.TBProv.Text;
                }
            }
                 }

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            DataTable tablausu = midata.Tables["tabusu"];
            tablausu.Rows.Add(new object[] { this.TBNIF.Text,this.TBNombre.Text,this.TBApe.Text,this.TBDir.Text,this.TBLoc.Text,this.TBProv.Text});
        }

        protected void BtnVlocar_Click(object sender, EventArgs e)
        {
            using (this.con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString))
            {
                try
                {
                    this.con.Open();
                    this.adap.Update(midata.Tables["tabusu"]);
                    this.midata.AcceptChanges();
                            
                }
                catch (SqlException ec)
                {
                   
                }
                finally {
                    this.con.Close();
                }
            }
        }
    }
}