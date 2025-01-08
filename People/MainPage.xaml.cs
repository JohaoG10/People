using People.Models;
using System.Collections.Generic;

namespace People;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

   
    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        JGavilanes_StatusMessage.Text = "";

        
        if (!string.IsNullOrWhiteSpace(JGavilanes_NewPerson.Text))
        {
            App.PersonRepo.AddNewPerson(JGavilanes_NewPerson.Text);
            JGavilanes_StatusMessage.Text = App.PersonRepo.StatusMessage;
            JGavilanes_NewPerson.Text = ""; 
        }
        else
        {
            JGavilanes_StatusMessage.Text = "Por favor, ingrese un nombre válido.";
        }
    }

    
    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        JGavilanes_StatusMessage.Text = "";

        List<Person> people = App.PersonRepo.GetAllPeople();
        JGavilanes_PeopleList.ItemsSource = people;
    }

    
    public async void OnPersonTapped(object sender, ItemTappedEventArgs e)
    {
        var selectedPerson = e.Item as Person;

        if (selectedPerson != null)
        {
            bool deleteConfirmed = await DisplayAlert(
                "Confirmar eliminación",
                $"{selectedPerson.Name} acaba de eliminar un registro.",
                "Sí", "No");

            if (deleteConfirmed)
            {
                
                App.PersonRepo.DeletePerson(selectedPerson.Id);
                JGavilanes_StatusMessage.Text = $"{selectedPerson.Name} ha sido eliminado.";

                OnGetButtonClicked(sender, e);
            }
        }
    }

}

