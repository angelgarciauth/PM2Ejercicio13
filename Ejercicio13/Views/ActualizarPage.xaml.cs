using PM022PP0122.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio13.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarPage : ContentPage
    {
        public ActualizarPage()
        {
            InitializeComponent();
        }

      
        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombresA.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese los nombres", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtApellidosA.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese los apellidos", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtEdadA.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese la edad", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtCorreoA.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese el correo", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtDireccionA.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese la direccion", "OK");
                return;
            }

            var idPersona = (string.IsNullOrEmpty(txtId.Text)) ? 0 : int.Parse(txtId.Text);
            var person = new Persona()
            {
                id = idPersona,
                nombre = txtNombresA.Text,
                apellido = txtApellidosA.Text,
                edad = Convert.ToInt32(txtEdadA.Text),
                correo = txtCorreoA.Text,
                direccion = txtDireccionA.Text
            };

            var result = await App.DBase.PersonSaveUpdate(person);


            if (result > 0)
            {
                await DisplayAlert("Alert", "Actualizado Correctamente", "OK");
                
            }
            else
            {
                await DisplayAlert("Alert", "Ha ocurrido un error", "OK");
            }
        }
    }
}