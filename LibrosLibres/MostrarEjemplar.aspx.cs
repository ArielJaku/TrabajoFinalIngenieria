using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;


namespace TRABAJO1
{
    public partial class MostrarEjemplar : Utilidad
    {
        Nejemplar VNE = new Nejemplar();
        NVenta VentaController = new NVenta();
        NEntrega EntregaController = new NEntrega();
        Nusuario USuarioController = new Nusuario();
        int dni;
        int lib;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            dni = Convert.ToInt32(Request.QueryString["valor2"]);
            lib = Convert.ToInt32(Request.QueryString["valor1"]);            
            DataTable Datos = VNE.TraerEjemplar(dni, lib);
            lblNomLib.Text = Convert.ToString(Datos.Rows[0][0]);  
            lblAutLib.Text = Convert.ToString(Datos.Rows[0][1]);
            lblEditLib.Text = Convert.ToString(Datos.Rows[0][2]);
            lblAño.Text = Convert.ToString(Datos.Rows[0][3]);
            lblCiudLib.Text = Convert.ToString(Datos.Rows[0][4]);
            string Imagen1 = Convert.ToBase64String((byte[])Datos.Rows[0][5]);
            string Imagen2 = Convert.ToBase64String((byte[])Datos.Rows[0][6]);
            string ImagenDataURL64 = "data:image/jpg;base64," + Imagen1;
            imgPreview.ImageUrl = ImagenDataURL64;
            string DataURL64 = "data:image/jpg;base64," + Imagen2;
            imgPreview2.ImageUrl = DataURL64;
        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            //ESTA FUNCION TIENE QUE SER PARA ABRIR EL DIV DE FORMULARIO DE COMPRA
            divModal1.Visible = true;


        }
        protected void btnSig_Click(object sender, EventArgs e)
        {
            //ESTA FUNCION TIENE QUE SER PARA ABRIR EL DIV DE FORMULARIO DE COMPRA
            if(txtNombre.Text == null || txtNombre.Text == "")
            {
                MsgBox("Debe ingresar un nombre");
            }else if(txtApellido.Text == null || txtApellido.Text == "")
            {
                MsgBox("Debe ingresar un apellido");
            }else if(txtDomicilio.Text == null || txtDomicilio.Text == "")
            {
                MsgBox("Debe ingresar un domicilio para envio del libro");
            }
            else
            {
                divModal1.Visible = false;
                divModal2.Visible = true;
            }


        }

        protected void btnCan_Click(object sender, EventArgs e)
        {
            //ESTA FUNCION TIENE QUE SER PARA ABRIR EL DIV DE FORMULARIO DE COMPRA

            divModal1.Visible = false;
            divModal2.Visible = false;
            divModal3.Visible = false;
        }
        protected void btnSigEnvio_Click(object sender, EventArgs e)
        {
            //ESTA FUNCION TIENE QUE SER PARA ABRIR EL DIV DE FORMULARIO DE COMPRA
            divModal2.Visible = false;
            divModal3.Visible = true;
        }
        public void enviarMail()
        {
            //ESTE CODIGO SE UTILIZA PARA ENVIAR UN CORREO AL VENDEDOR
            string CuerpoMensaje = "ACA VA EL TEXTO QUE LE QUEREMOS ENVIAR POR EJEMPLO ALGUIEN QUIERE COMPRAR SU PRODUCTO";
            ControladorCorreo Email = new ControladorCorreo();
            if (Email.EnviarCorreo2(CuerpoMensaje) == "ok")
            {
                MsgBox("El envio del correo ah sido exitoso, espere la respuesta del dueño del libro en su casilla");

            }
            else
            {
                MsgBox("El envio del correo Fallo!");

            }

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            //ESTA FUNCION TIENE QUE SER PARA ABRIR EL DIV DE FORMULARIO DE COMPRA
            if (txtTitTarg.Text == null || txtTitTarg.Text == "")
            {
                MsgBox("Debe ingresar un titular de tarjeta");
            }
            else if (txtNumTarjeta.Text == null || txtNumTarjeta.Text == "")
            {
                MsgBox("Debe ingresar un numero de tarjeta");
            }
            else if (txtCVVTarjeta.Text == null || txtCVVTarjeta.Text == "")
            {
                MsgBox("Debe ingresar un codigo de tarjeta correcto");
            }
            else
            {            //ESTA FUNCION TIENE QUE SER PARA ABRIR EL DIV DE FORMULARIO DE FINAL DE COMPRA
                Venta oVenta = new Venta();
                Usuario oUsuario = new Usuario();
                //comprador
                oUsuario.DNI = Convert.ToInt32(Session["Usuario"]);//comprador
                oVenta.dniVendedor = dni;
                oVenta.fechaVenta = DateTime.Now;
                oVenta.idLibro = lib;
                oVenta.estadoVenta = 1;
                var res = VentaController.ingresarVenta(oVenta, oUsuario);
                if (RadCadLib.Checked == true)
                {
                    //traigo el id de la venta
                    oVenta.dniComprador = oUsuario.DNI;
                    var vent = VentaController.traerVenta(oVenta);
                    //traigo la direccion del vendedor para buscar el libro
                    Usuario oUsuarioVendedor = new Usuario();
                    oUsuarioVendedor = USuarioController.DetalleUsuario(oVenta.dniVendedor);
                    //inserto la entrega
                    Entrega ent = new Entrega();
                    ent.IdVenta = vent.id;
                    ent.FechaInicio = DateTime.Now;
                    ent.DireccionEntregaInicio = oUsuarioVendedor.direccion_calle + " " + Convert.ToString(oUsuarioVendedor.direccion_numero);
                    ent.DireccionEntregaFin = txtDomicilio.Text;
                    EntregaController.EntregaNueva(ent);

                }
                if (res == 1)
                {
                    //MODIFICO EL ESTADO DEL EJEMPLAR PARA QUE NO SIGA APARECIENDO
                    Ejemplares oEJemplar = new Ejemplares();
                    oEJemplar.id_libro = lib;
                    oEJemplar.id_usuario = dni;
                    oEJemplar.estado = 5;
                    VNE.ModificarEstadoEjemplar(oEJemplar);
                }
                else
                {
                    MsgBox("Hubo un error al procesar su compra");
                }
                divModal3.Visible = false;
                divModal4.Visible = true;
            }

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}