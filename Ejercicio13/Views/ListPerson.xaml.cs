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
    public partial class ListPerson : ContentPage
    {
        Persona currentData;
        public ListPerson()
        {
            InitializeComponent();

            if (App.DBase == null)
            {

            }
        }

        protected async override void OnAppearing()
        {

            if (await App.DBase.getListPerson()!=null)
            {
                base.OnAppearing();
                ListaPersona.ItemsSource = await App.DBase.getListPerson();
            }
            else
            {
                await DisplayAlert("Advertencia", "No hay sitios agregados", "Ok");
            }


        }

        private void ListaPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentData = (e.CurrentSelection.FirstOrDefault() as Persona);
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (currentData == null)
            {
                await DisplayAlert("Advertencia", "Seleccione una persona", "Ok");
            }
            else
            {
                var persona = currentData;
                ActualizarPage page = new ActualizarPage();
                page.BindingContext = persona;
                await Navigation.PushAsync(page);
                currentData = null;
            }
            
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (currentData == null)
            {
                await DisplayAlert("Advertencia", "Seleccione una persona", "Ok");
            }
            else
            {
                bool answer = await DisplayAlert("¿Confirmacion?", "¿Esta seguro de eliminar el la persona?", "Si", "No");

                if (answer)
                {
                    await App.DBase.deletePerson(currentData);

                    ListaPersona.ItemsSource = await App.DBase.getListPerson();
                    await DisplayAlert("Confirmacion", "Persona eliminada correctamente", "Ok");
                    currentData = null;
                }

            }
        }
    }
}