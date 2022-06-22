using PM022PP0122.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio13
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (App.DBase == null)
            {

            }
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese los nombres", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese los apellidos", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtEdad.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese la edad", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese el correo", "OK");
                return;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese la direccion", "OK");
                return;
            }

            if (!ValidarCorreo(txtCorreo.Text))
            {
                await DisplayAlert("Error", "Por favor, ingrese un correo valido", "OK");
                return;
            }


            var person = new Persona
            {
                id = 0,
                nombre = txtNombres.Text,
                apellido = txtApellidos.Text,
                edad =  Convert.ToInt32(txtEdad.Text),
                correo = txtCorreo.Text,
                direccion = txtDireccion.Text
            };

            var result = await App.DBase.PersonSaveUpdate(person);


            if (result > 0)
            {
                await DisplayAlert("Alert", "Guardado Correctamente", "OK");
                txtNombres.Text = "";
                txtApellidos.Text = "";
                txtEdad.Text = "";
                txtCorreo.Text = "";
                txtDireccion.Text = "";
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
