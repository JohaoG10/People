using People.Models;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace People;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    
    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        App.PersonRepo.AddNewPerson(newPerson.Text);
        statusMessage.Text = App.PersonRepo.StatusMessage;
    }

  
    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Person> people = App.PersonRepo.GetAllPeople();
        peopleList.ItemsSource = people;

        if (people.Count == 0)
        {
            statusMessage.Text = "No se encontraron personas.";
        }
    }

   
    public async void OnPersonTapped(object sender, ItemTappedEventArgs e)
    {
        var person = e.Item as Person;
        if (person != null)
        {
            
            bool confirm = await DisplayAlert("Eliminar Registro",
                $"{person.Name} acaba de eliminar un registro.",
                "Eliminar",
                "Cancelar");

            if (confirm)
            {
                
                App.PersonRepo.DeletePerson(person.Id);

                List<Person> updatedPeople = App.PersonRepo.GetAllPeople();
                peopleList.ItemsSource = updatedPeople;
            }
        }
    }
}

