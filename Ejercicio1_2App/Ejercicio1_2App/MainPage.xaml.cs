using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio1_2App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnEnviarDatos_Clicked(object sender, EventArgs e)
        {
            try
            {
                String nombre ="", apellido="", correo="";
                Int32 edad = 0;

                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                edad = Convert.ToInt32(txtEdad.Text);
                correo = txtCorreo.Text;

                if (nombre.Length == 0)
                {
                    await DisplayAlert("Mensaje", "Debe ingresar un nombre", "Aceptar");
                } else if(apellido.Length == 0)
                {
                    await DisplayAlert("Mensaje", "Debe ingresar un apellido", "Aceptar");
                } else if(edad == 0)
                {
                    await DisplayAlert("Mensaje", "Debe ingresar la edad", "Aceptar");
                } else if(correo.Length == 0)
                {
                    await DisplayAlert("Mensaje", "Debe ingresar un correo", "Aceptar");
                }
                else
                {
                    var Person = new Models.Persona
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        Edad = edad,
                        Correo = correo
                    };

                    var openPageDatosPersona = new PageDatosPersona();
                    openPageDatosPersona.BindingContext = Person;

                    await Navigation.PushAsync(openPageDatosPersona);
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Mensaje", ex.Message, "Aceptar");
            }
        }
    }
}
