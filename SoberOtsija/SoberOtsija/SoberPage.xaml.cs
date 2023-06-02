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
    }
}