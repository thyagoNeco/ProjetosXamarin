﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialListviewCell.Model;
using Xamarin.Forms;

namespace TutorialListviewCell.Views
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Animal> lstAnimal;

        public MainPage()
        {
            InitializeComponent();

            lstAnimal = new ObservableCollection<Animal>();

            lstAnimal.Add(new Animal { Name = "Leão", Family = "Família: Felidae", Image = "leao.png" });
            lstAnimal.Add(new Animal { Name = "Girafa", Family = "Família: Giraffidae", Image = "girafa.png" });
            lstAnimal.Add(new Animal { Name = "Golfinho", Family = "Família: Delphinidae", Image = "golfinho.png" });
            lstAnimal.Add(new Animal { Name = "Zebra", Family = "Família:	Equidae", Image = "zebra.png" });
            lstAnimal.Add(new Animal { Name = "Macaco-prego", Family = "Família: Cebidae", Image = "macaco.png" });

            lstViewAnimal.ItemsSource = lstAnimal;

            lstViewAnimal.ItemSelected += AnimalItemSelected;
        }

        private void AnimalItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Animal objAnimal;

            if (e.SelectedItem != null)
            {
                objAnimal = (Animal)e.SelectedItem;
                lstViewAnimal.SelectedItem = null;

                Navigation.PushAsync(new PageDetail(objAnimal));
            }
        }

        public void OnInfo(object sender, EventArgs e)
        {
            var objMenu = ((MenuItem)sender);
            var objAnimal = (Animal)objMenu.CommandParameter;
            DisplayAlert("Context Action", objAnimal.Name + " selecionado.", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var objMenu = ((MenuItem)sender);
            var objAnimal = (Animal)objMenu.CommandParameter;
            lstAnimal.Remove(objAnimal);
            DisplayAlert("Context Action", objAnimal.Name + " deletado.", "OK");
        }
    }
}
