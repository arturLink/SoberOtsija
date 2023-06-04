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
                "Ärgpükslik",
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
        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (char1.SelectedIndex == -1 || (char2.SelectedIndex == -1 || char3.SelectedIndex == -1))
            {
                await DisplayAlert("Hoiatus", "Omadused on tühi","Ok");
            }
            else 
            {
                ListView soberList = new ListView();
                soberList.ItemsSource = App.Database.GetChosenItem(char1.SelectedItem.ToString(), char2.SelectedItem.ToString(), char3.SelectedItem.ToString());
                DataTemplate dataTemplate = new DataTemplate(() =>
                {
                    ViewCell viewCell = new ViewCell();

                    StackLayout stackLayout = new StackLayout();
                    stackLayout.Orientation = StackOrientation.Horizontal;

                    Label label = new Label();
                    label.SetBinding(Label.TextProperty, "Name");
                    label.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    label.TextColor = Color.DarkRed;
                    label.FontAttributes = FontAttributes.Bold;

                    stackLayout.Children.Add(label);
                    viewCell.View = stackLayout;

                    return viewCell;
                });

                soberList.ItemTemplate = dataTemplate;

                pplFrame.Content = soberList;

                soberList.ItemSelected += SoberList_ItemSelected;
            }
        }
        private async void SoberList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Sober selectedFriend = (Sober)e.SelectedItem;
            if (selectedFriend.Trait1 == char1.SelectedIndex.ToString() || selectedFriend.Trait1 == char2.SelectedIndex.ToString() || selectedFriend.Trait1 == char3.SelectedIndex.ToString())
            {
                await DisplayAlert("Omadused", "Seda inimene sul on ainult 1 sarnane omadus - "+selectedFriend.Trait1, "Hästi");
            }
            else if (selectedFriend.Trait2 == char1.SelectedIndex.ToString() || selectedFriend.Trait2 == char2.SelectedIndex.ToString() || selectedFriend.Trait2 == char3.SelectedIndex.ToString())
            {
                await DisplayAlert("Omadused", "Seda inimene sul on ainult 1 sarnane omadus - " + selectedFriend.Trait2, "Hästi");
            }
            else if (selectedFriend.Trait3 == char1.SelectedIndex.ToString() || selectedFriend.Trait3 == char2.SelectedIndex.ToString() || selectedFriend.Trait3 == char3.SelectedIndex.ToString())
            {
                await DisplayAlert("Omadused", "Seda inimene sul on ainult 1 sarnane omadus - " + selectedFriend.Trait2, "Hästi");
            }
            SoberPage sbrPage = new SoberPage();
            sbrPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(sbrPage);
        }
    }
}
