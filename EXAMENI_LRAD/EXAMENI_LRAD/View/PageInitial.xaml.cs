using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXAMENI_LRAD.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInitial : ContentPage
    {
        public PageInitial()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var pagecontactos = new View.PageContactos();
            Navigation.PushAsync(pagecontactos);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListaContactos.ItemsSource = await App.DBContactos.GetListContactos();
        }

        private void ListaContactos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}