using SoberOtsija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoberOtsija
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalvSoberPage : ContentPage
    {
        public SalvSoberPage()
        {
            InitializeComponent();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var friend = (salvSobrad)BindingContext;
            App.Database.DeleteItemSalv(friend.Id);
            this.Navigation.PopAsync();
        }
    }
}