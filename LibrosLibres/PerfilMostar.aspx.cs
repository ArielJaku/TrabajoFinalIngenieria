using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
using System.Data;

namespace TRABAJO1
{
    public partial class PerfilMostar : Utilidad
    {
        Nusuario VNU = new Nusuario();
        Nejemplar VNE = new Nejemplar();
        NDonacion VND = new NDonacion();
        NPrestamo VNP = new NPrestamo();
        Prestamo oPrestamo = new Prestamo();
        Auditoria oAuditoria = new Auditoria();   
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { 
            if (Session["Usuario"] != null)
            {
                DataTable Datos = VNU.TraerUsuario2(Convert.ToInt32(Session["Usuario"]));
                //string DNI = Convert.ToString(Datos.Rows[0][0]);

                // lblDNI.Text = DNI;
                lblNomApe.Text = Convert.ToString(Datos.Rows[0][1]);
                //lblApe.Text = Convert.ToString(Datos.Rows[0][2]);
                lblCiud.Text = Convert.ToString(Datos.Rows[0][2]);
                lblProv.Text = Convert.ToString(Datos.Rows[0][3]);
                //lblDire.Text = Convert.ToString(Datos.Rows[0][3]);
                //lbldirNum.Text = Convert.ToString(Datos.Rows[0][4]);
                lblCorreo.Text = Convert.ToString(Datos.Rows[0][4]);
                GVlibrosc.DataSource = VNU.TraerLibrosUsuario(Convert.ToInt32(Session["Usuario"]));
                GVlibrosc.DataBind();
                CambiarEstados.Style["Visibility"] = "hidden";                    
                GridView2.DataSource = VNU.TraerAdquiridos(Convert.ToInt32(Session["Usuario"]));
                GridView2.DataBind();
            }
            else
            {
                oAuditoria.LogAccion(1111, "Intento ingresar a un perfil sin autorizacion");
                MsgBox("Inicie Sesion o Registrese para ver su Perfil", "Default.aspx");

            }
            }


        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        /*protected void GVlibrosc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambiarEstados.Style["Visibility"] = "visible";
           
        }*/

        protected void GVlibrosc_RowCommand(object sender, GridViewCommandEventArgs e)
        {                     
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GVlibrosc.Rows[index];
            var id = row.Cells[0].Text;
            Label1.Text = id;
            string est = row.Cells[3].Text;
            if( est != "vendido")
            {
                if (est != "prestado")
                {
                    CambiarEstados.Style["Visibility"] = "visible";
                    btnActivo.Style["Visibility"] = "visible";
                    btnIncativo.Style["Visibility"] = "visible";
                    btnDonado.Style["Visibility"] = "visible";
                    btnPrestado.Style["Visibility"] = "visible";
                    btnFinPrest.Style["Visibility"] = "hidden";

                }
                else
                {
                    CambiarEstados.Style["Visibility"] = "visible";
                    btnActivo.Style["Visibility"] = "hidden";
                    btnIncativo.Style["Visibility"] = "hidden";
                    btnDonado.Style["Visibility"] = "hidden";
                    btnPrestado.Style["Visibility"] = "hidden";
                    btnFinPrest.Style["Visibility"] = "visible";
                }

            }

        }
        

        protected void btnActivo_Click(object sender, EventArgs e)
        {
            Prestado.Style["Visibility"] = "hidden";
            Donacion.Style["Visibility"] = "hidden";
            Ejemplares oEjemplar = new Ejemplares();
            oEjemplar.id_libro=Convert.ToInt32(Label1.Text);
            oEjemplar.id_usuario = Convert.ToInt32(Session["Usuario"]);
            oEjemplar.estado = 1;
            VNE.ModificarEstadoEjemplar(oEjemplar);
            GVlibrosc.DataSource = VNU.TraerLibrosUsuario(Convert.ToInt32(Session["Usuario"]));
            GVlibrosc.DataBind();
            oAuditoria.LogAccion(Convert.ToInt32(Session["Usuario"]), "Cambio el estado del ejemplar a activo");
        }

        protected void btnIncativo_Click(object sender, EventArgs e)
        {
            Prestado.Style["Visibility"] = "hidden";
            Donacion.Style["Visibility"] = "hidden";
            Ejemplares oEjemplar = new Ejemplares();
            oEjemplar.id_libro = Convert.ToInt32(Label1.Text);
            oEjemplar.id_usuario = Convert.ToInt32(Session["Usuario"]);
            oEjemplar.estado = 2;
            VNE.ModificarEstadoEjemplar(oEjemplar);
            GVlibrosc.DataSource = VNU.TraerLibrosUsuario(Convert.ToInt32(Session["Usuario"]));
            GVlibrosc.DataBind();
            oAuditoria.LogAccion(Convert.ToInt32(Session["Usuario"]), "Cambio el estado del ejemplar a inactivo");

        }

        protected void btnDonado_Click(object sender, EventArgs e)
        {
            CambiarEstados.Style["Visibility"] = "hidden";
            Prestado.Style["Visibility"] = "hidden";
            Donacion.Style["Visibility"] = "visible";
            ddlUsuarios.DataSource = VNU.TraerUsuarios();
            ddlUsuarios.DataTextField = "nombre";
            ddlUsuarios.DataValueField = "dni";
            ddlUsuarios.DataBind();

        }

        protected void OkDonacion_Click(object sender, EventArgs e)
        {
            Donacion oDonacion = new Donacion();
            oDonacion.DniDonador = Convert.ToInt32(Session["Usuario"]);
            oDonacion.DNIRecibidor = Convert.ToInt32(ddlUsuarios.SelectedValue);
            oDonacion.Libro = Convert.ToInt32(Label1.Text);
            VND.GenerarDonacion(oDonacion);
            VND.SumarReporteGenero(oDonacion);
            Ejemplares oEjemplar = new Ejemplares();
            oEjemplar.id_libro = Convert.ToInt32(Label1.Text);
            oEjemplar.id_usuario = Convert.ToInt32(Session["Usuario"]);
            oEjemplar.estado = 3;
            VNE.ModificarEstadoEjemplar(oEjemplar);
            GVlibrosc.DataSource = VNU.TraerLibrosUsuario(Convert.ToInt32(Session["Usuario"]));
            GVlibrosc.DataBind();
            oAuditoria.LogAccion(Convert.ToInt32(Session["Usuario"]), "Genero una donacion");
            MsgBox("Se ah generado una donacion Correctamente");

        }

        protected void btnPrestado_Click(object sender, EventArgs e)
        {
            CambiarEstados.Style["Visibility"] = "hidden";
            Donacion.Style["Visibility"] = "hidden";
            Prestado.Style["Visibility"] = "visible";
            ddlUsuarios2.DataSource = VNU.TraerUsuarios();
            ddlUsuarios2.DataTextField = "nombre";
            ddlUsuarios2.DataValueField = "dni";
            ddlUsuarios2.DataBind();       


        }

        protected void OkPrestamo_Click(object sender, EventArgs e)
        {         
            
            if(Calendar1.SelectedDate > DateTime.Now)
            {
                
                //Prestamo oPrestamo = new Prestamo();
                oPrestamo.dniPrestador = Convert.ToInt32(Session["Usuario"]); ;
                oPrestamo.dniRecibidor = Convert.ToInt32(ddlUsuarios2.SelectedValue);
                oPrestamo.FechaPrestamo = DateTime.Now;
                oPrestamo.FechaDevolucion = Calendar1.SelectedDate;
                oPrestamo.libro = Convert.ToInt32(Label1.Text);
                //Usuario oUsuario = new Usuario();
                //oUsuario.DNI = Convert.ToInt32(ddlUsuarios2.SelectedValue);
                Usuario usu = new Usuario();
                usu = VNU.TienePrestamo(Convert.ToInt32(ddlUsuarios2.SelectedValue));

                if (usu.TienePrestamo == 0)
                {
                    usu.TienePrestamo = 1;
                    VNP.InsertarPrestamo(oPrestamo);
                    Ejemplares oEjemplar = new Ejemplares();
                    oEjemplar.id_libro = Convert.ToInt32(Label1.Text);
                    oEjemplar.id_usuario = Convert.ToInt32(Session["Usuario"]);
                    oEjemplar.estado = 4;
                    VNE.ModificarEstadoEjemplar(oEjemplar);
                    //Usuario oUsuario = new Usuario();
                    //oUsuario.DNI = Convert.ToInt32(ddlUsuarios2.SelectedValue);
                    //oUsuario.TienePrestamo = 1;
                    VNP.TienePrestamo(usu);
                    CambiarEstados.Style["Visibility"] = "hidden";
                    Prestado.Style["Visibility"] = "hidden";
                    GVlibrosc.DataSource = VNU.TraerLibrosUsuario(Convert.ToInt32(Session["Usuario"]));
                    GVlibrosc.DataBind();
                }
                else
                {
                    MsgBox("ESTE USUARIO YA TIENE UN PRESTAMO ACTUALMENTE, NO PUEDE TENER MAS DE UNO");
                }

            }
            else
            {
                MsgBox("DEBE ELEGIR UNA FECHA VALIDA");
            }
           

        }

        protected void btnFinPrest_Click(object sender, EventArgs e)
        {
            oPrestamo = new Prestamo();
            oPrestamo.dniPrestador = Convert.ToInt32(Session["Usuario"]);
            oPrestamo.libro = Convert.ToInt32(Label1.Text);
            VNP.FinalizarPrestamo(oPrestamo);
            Ejemplares oEjemplar = new Ejemplares();
            oEjemplar.id_libro = Convert.ToInt32(Label1.Text);
            oEjemplar.id_usuario = Convert.ToInt32(Session["Usuario"]);
            oEjemplar.estado = 1;
            VNE.ModificarEstadoEjemplar(oEjemplar);
            CambiarEstados.Style["Visibility"] = "hidden";
            Prestado.Style["Visibility"] = "hidden";
            GVlibrosc.DataSource = VNU.TraerLibrosUsuario(Convert.ToInt32(Session["Usuario"]));
            GVlibrosc.DataBind();
        }
    }
}