using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using SQLite;
using SoberOtsija.Models;

namespace SoberOtsija
{
    public partial class MainPage : ContentPage
    {
        //Sober Keanu, Dwayne, Anton, Elizabeth, Corey;
        public MainPage()
        {
            //Keanu = new Sober() { Name = "Keanu Reeves", Age = "50", Trait1 = "Tark", Trait2 = "Empaatiline", Trait3 = "Naljakas" };
            //App.Database.SaveItem(Keanu);

            //Dwayne = new Sober() { Name = "Dwayne Johnson", Age = "45", Trait1 = "Rumal", Trait2 = "Julge", Trait3 = "Naljakas" };
            //App.Database.SaveItem(Dwayne);

            //Anton = new Sober() { Name = "Anton Prokhorov", Age = "18", Trait1 = "Ärgpükslik", Trait2 = "Helde", Trait3 = "Tark" };
            //App.Database.SaveItem(Anton);

            //Elizabeth = new Sober() { Name = "Queen Elizabeth", Age = "99", Trait1 = "Julge", Trait2 = "Helde", Trait3 = "Tark" };
            //App.Database.SaveItem(Elizabeth);

            //Corey = new Sober() { Name = "Corey Taylor", Age = "44", Trait1 = "Naljakas", Trait2 = "Julge", Trait3 = "Tark" };
            //App.Database.SaveItem(Corey);

            InitializeComponent();

            List<string> traitsList = new List<string>
            {
                "Tark",
                "Naljakas",
                "Tõsine",
                "Julge",
                "Argpükslik",
                "Empaatiline",
                "Helde"
            };

            foreach (string trait in traitsList)
            {
                char1.Items.Add(trait);
                char2.Items.Add(trait);
                char3.Items.Add(trait);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ListView soberList = new ListView();
            soberList.SetBinding(ListView.ItemsSourceProperty, new Binding("."));

            DataTemplate dataTemplate = new DataTemplate(() =>
            {
                ViewCell viewCell = new ViewCell();

                StackLayout stackLayout = new StackLayout();
                stackLayout.Orientation = StackOrientation.Horizontal;

                Label label = new Label();
                label.SetBinding(Label.TextProperty, "Name");
                label.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

                stackLayout.Children.Add(label);
                viewCell.View = stackLayout;

                return viewCell;
            });

            soberList.ItemTemplate = dataTemplate;

            pplFrame.Content = soberList;
        }
    }

        //protected override void OnAppearing()
        //{
        //    soberList.ItemsSource = App.Database.GetItems();
        //    base.OnAppearing();
        //}


}
