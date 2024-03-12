using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocios;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using Entidades;

namespace TRABAJO1
{
    public partial class CargaEjemplar : Utilidad
    {
        Nlibro VNL = new Nlibro();
        Nautor VNA = new Nautor();
        Nejemplar VNE = new Nejemplar();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                if (!Page.IsPostBack)
                {
                    GVLista.DataSource = VNL.ConsultarLibrosGV();
                    GVLista.DataBind();
                    DDLeditorial.DataSource = VNL.TraerEditoriales();
                    DDLeditorial.DataTextField = "editorial";
                    DDLeditorial.DataValueField = "id";
                    DDLeditorial.DataBind();
                }
            }
            else
            {
                MsgBox("Registrese Para Cargar un Ejemplar", "Default.aspx");

            }

        }

        protected void GVLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVLista.PageIndex = e.NewPageIndex;
            VNL.ConsultarLibrosGV();
        }
        protected void btnBus_Click(object sender, EventArgs e)
        {
            GVLista.DataSource = VNL.ConsultarLibrosGV(txtBusqueda.Text);
            GVLista.DataBind();
        }

        protected void GVLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaL = GVLista.SelectedRow;
            string isbn = filaL.Cells[1].Text;
            edityaño.Style["Visibility"] = "visible";
            

        }

        protected void btnCarga1_Click(object sender, EventArgs e)
        {

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            if(GVLista.SelectedRow != null) { 
            if(fuImagen1.PostedFile.ContentLength != 0  && fuImagen2.PostedFile.ContentLength != 0) { 
            #region IMAGEN1
                //obtener datos de la imagen 1

                int tamanio = fuImagen1.PostedFile.ContentLength;

                byte[] imagenOriginal = new byte[tamanio];

                fuImagen1.PostedFile.InputStream.Read(imagenOriginal, 0, tamanio);
                
                
                Bitmap ImagenOriginalBinaria = new Bitmap(fuImagen1.PostedFile.InputStream);

                //Crear una Imagen Thumbail
                System.Drawing.Image imtThumbnail;
                int tamanioThumbnail = 200;
                imtThumbnail = RedimencionarImagen(ImagenOriginalBinaria, tamanioThumbnail);
                byte[] bImagenThumbnail1 = new byte[tamanioThumbnail];
                ImageConverter Convertidor = new ImageConverter();

                bImagenThumbnail1 = (byte[])Convertidor.ConvertTo(imtThumbnail, typeof(byte[]));

                #endregion            
            #region IMAGEN2
            //obtener datos de la imagen 2
            if (fuImagen2.HasFile == false)
            {
                MsgBox("Por favor cargue la imagen 2");
            }
            int tamanio2 = fuImagen2.PostedFile.ContentLength;

            byte[] imagenOriginal2 = new byte[tamanio2];

            fuImagen2.PostedFile.InputStream.Read(imagenOriginal2, 0, tamanio2);

            Bitmap ImagenOriginalBinaria2 = new Bitmap(fuImagen2.PostedFile.InputStream);

            //Crear una Imagen Thumbail
            System.Drawing.Image imtThumbnail2;
            int tamanioThumbnail2 = 200;
            imtThumbnail2 = RedimencionarImagen(ImagenOriginalBinaria2, tamanioThumbnail2);
            byte[] bImagenThumbnail2 = new byte[tamanioThumbnail2];

            bImagenThumbnail2 = (byte[])Convertidor.ConvertTo(imtThumbnail2, typeof(byte[]));

            string ImagenDataURL64 = "data:image/jpeg;base64," + Convert.ToBase64String(bImagenThumbnail1);

            imgPreview.ImageUrl = "/ok.png";        

            string ImagenDataURL642 = "data:image/jpg;base64," + Convert.ToBase64String(bImagenThumbnail2);
            
            imgPreview2.ImageUrl = "/ok.png";

            #endregion            
            #region DATOS         
            GridViewRow filaL = GVLista.SelectedRow;
            //string isbn = filaL.Cells[2].Text;
            string idLibro = filaL.Cells[2].Text;
            int dniUsu = Convert.ToInt32(Session["Usuario"]);
            int idEditorial = Convert.ToInt32(DDLeditorial.SelectedValue);            
            int id = Convert.ToInt32(idLibro);
            int año = Convert.ToInt32(anio.Text);
            decimal precio = Convert.ToDecimal(Precio.Text);
            try
            {
                VNE.InsertarEjemplar2(id, dniUsu, año, idEditorial, bImagenThumbnail1, bImagenThumbnail2, precio);
                Ejemplares oEjemplar = new Ejemplares();
                oEjemplar.id_libro = id;
                VNE.SumarStockLibro(oEjemplar);
                VNE.SumarReporteGenero(oEjemplar);
                MsgBox("Su ejemplar ah sido cargado con exito, su estado esta activo por ende ya esta publicado en nuestra pagina");
            }
            catch (Exception ex)
            {

                MsgBox("HUBO UN ERROR EN LA CARGA DEL EJEMPLAR");
                MsgBox(ex.Message);
            }

                #endregion
            }
            else
            {
                MsgBox("Le Faltan Cargar Las Imagenes");
            }
            }
            else
            {
                MsgBox("Elija un libro de la lista para cargar un ejemplar");

            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }



        public System.Drawing.Image RedimencionarImagen(System.Drawing.Image ImagenOrinal, int Alto)
        {
            var Radio = (double)Alto / ImagenOrinal.Height;
            var NuevoAncho = (int)(ImagenOrinal.Width * Radio);
            var NuevoAlto = (int)(ImagenOrinal.Height * Radio);
            var NuevaImagenRedimencionada = new Bitmap(NuevoAncho, NuevoAlto);
            var g = Graphics.FromImage(NuevaImagenRedimencionada);
            g.DrawImage(ImagenOrinal, 0, 0, NuevoAncho, NuevoAlto);
            return NuevaImagenRedimencionada;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargarLibro.aspx");
        }

        static string conexionstring = "server= DESKTOP-KASPEP1\\SQLEXPRESS; database= LibrosLibres3; integrated security=true";
        SqlConnection con = new SqlConnection(conexionstring);

        protected void btnsig_Click(object sender, EventArgs e)
        {
            img1.Style["Visibility"] = "visible";
            img2.Style["Visibility"] = "visible";
        }
            

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            GVLista.DataSource = VNL.ConsultarLibrosGV(txtBusqueda.Text);
            GVLista.DataBind();
        }
    }
}