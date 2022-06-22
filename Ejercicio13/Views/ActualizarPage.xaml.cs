using PM022PP0122.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio13.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarPage : ContentPage
    {
        public ActualizarPage(bool val)
        {
            InitializeComponent();

            if (val==true)
            {
                btnActualizar.IsVisible = false;
                lblTitulo.Text = "Datos de Persona";
            }
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

            if (! ValidarCorreo(txtCorreoA.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese un correo valido", "OK");
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

        public bool ValidarCorreo(string email)
        {
            Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }
    }
}