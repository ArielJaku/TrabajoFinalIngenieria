using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using System.Data;
using System.IO;

namespace TRABAJO1
{
    public partial class CargarLibro : Utilidad
    {
        Nlibro VNL = new Nlibro();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                if (!Page.IsPostBack)
                {

                    DDLautores.DataSource = VNL.TraerAutores();
                    DDLautores.DataTextField = "apellido";
                    DDLautores.DataValueField = "id";
                    DDLautores.DataBind();
                    //DDLeditorial.DataSource = VNL.TraerEditoriales();
                    //DDLeditorial.DataTextField = "editorial";
                    //DDLeditorial.DataValueField = "id";
                    //DDLeditorial.DataBind();
                }

            }
            else
            {
                MsgBox("Registrese Para Cargar un Libro", "Default.aspx");

            }

           

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            int dniUsu = Convert.ToInt32(Session["Usuario"]);
            int idAutor = Convert.ToInt32(DDLautores.SelectedValue);
            try
            {
                if(VNL.Insertarlibro(Convert.ToInt32(txtISBN.Text), txtNombre.Text, idAutor) != 0)
                {
                    MsgBox("El libro se a cargado con exito");
                }

            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString());
                
            } 
        }

        /*protected void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            Byte[] Archivo = null;
            string nombreArchivo = string.Empty;
            string extensionArchivo = string.Empty;

            if (fuArchivo.HasFile == true)
            {
                nombreArchivo = Path.GetFileNameWithoutExtension(fuArchivo.FileName);
                extensionArchivo = Path.GetExtension(fuArchivo.FileName);
            }
        }*/

        /*

         hay una forma mas corta de hacerlo, les dejo el código
        protected void btnCargarImagen_Click(object sender, EventArgs e)
        {

        string nombreArchivo=string.Empty;

        string destino = @”~/Noticias/”;//poner la ruta donde quieres que quede el archivo
        if (fuimagen.HasFile)
        {   
        string carpetaDestino = Server.MapPath(destino);

        nombreArchivo = System.IO.Path.GetFileName(fuimagen.PostedFile.FileName);

        string SaveLocation = carpetaDestino + nombreArchivo;

        //guardamos el archivo
         fuimagen.PostedFile.SaveAs(SaveLocation);
}
}

         * 
         * 
         * 
         * 
         * */
    }
}