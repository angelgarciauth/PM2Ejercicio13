using Ejercicio13.Views;
using PM022PP0122.Controller;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio13
{
    public partial class App : Application
    {
        static DataBase db;

        public static DataBase DBase
        {
            get
            {
                if (db == null)
                {
                    String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Persona.db3");
                    db = new DataBase(FolderPath);
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListPerson()) ;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
