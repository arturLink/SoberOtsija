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
    public partial class SoberPage : ContentPage
    {
        public SoberPage()
        {
            InitializeComponent();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Sober friend = (Sober)BindingContext;
            salvSobrad anton = new salvSobrad();
            anton.Name = friend.Name;
            anton.Age = friend.Age;
            anton.Trait1 = friend.Trait1;
            anton.Trait2 = friend.Trait2;
            anton.Trait3 = friend.Trait3;
            if (!String.IsNullOrEmpty(anton.Name))
            {
                App.Database.SaveItemSalv(anton);
            }
            this.Navigation.PopAsync();
        }
    }
}