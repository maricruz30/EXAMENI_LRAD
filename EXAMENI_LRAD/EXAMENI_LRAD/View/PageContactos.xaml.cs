using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXAMENI_LRAD.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageContactos : ContentPage
    {
        public PageContactos()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    txtLatitud.Text=Convert.ToString(location.Latitude);
                    txtLongitud.Text = Convert.ToString(location.Longitude);
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            if(txtNombre.Text == null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UN NOMBRE", "OK");
                txtNombre.Focus();
            }
            if (txtNombre.Text == null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UN APELLIDO", "OK");
                txtApellidos.Focus();
            }
            else if (txtTelefono.Text== null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UN TELEFONO", "OK");
                txtTelefono.Focus();
            }
            else if (txtEdad.Text == null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UNA EDAD", "OK");
                txtEdad.Focus();
            }
            else if (txtNota.Text == null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UNA NOTA", "OK");
                txtEdad.Focus();
            }
            else if (cmbPais.SelectedItem == null)
            {
                await DisplayAlert("ALERTA", "DEBES SELECCIONAR UN PAIS", "OK");
            }
            else
            {

            var user = new Models.ContactosModel
                {
                    nombre = txtNombre.Text,
                    apellidos= txtApellidos.Text,
                    telefono = Convert.ToInt32(txtTelefono.Text),
                    edad = Convert.ToInt32(txtEdad.Text),
                    pais = cmbPais.SelectedItem.ToString(),
                    latitud = Convert.ToDecimal(txtLatitud.Text),
                    longitud = Convert.ToDecimal(txtLongitud.Text),
                    nota = txtNota.Text,
                   
                };

                if (await App.DBContactos.saveContacto(user) > 0)
                    await DisplayAlert("AVISO", "CONTACTO GUARDADO CORRECTAMENTE!", "OK");

                else
                    await DisplayAlert("AVISO", "ERROR", "OK");

                limpiar();
                var page = new View.PageResult();
                //page.BindingContext = result;
                await Navigation.PushAsync(page);
            }
            //OnAppearing();       

        }

        private void limpiar() 
        {
            txtNombre.Text = "";
;           txtApellidos.Text = "";
            txtEdad.Text = "";
            txtNota.Text = "";
            txtTelefono.Text = "";
            cmbPais.SelectedIndex = -1;

        }

        
    }
}