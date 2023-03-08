using Android.App;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace EXAMENI_LRAD
{
    public partial class App : Application
    {
        static Controller.ContactosController dbcontactos;

        public static Controller.ContactosController DBContactos
        { 
            get
            {
                if (dbcontactos == null)
                {
                    var dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dbname = "Contact.db3"; //instancia sqlite
                    dbcontactos = new Controller.ContactosController(Path.Combine(dbpath, dbname));
                }

                return dbcontactos;
            }
        }

        public static object DBAlum { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.PageInitial());
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
