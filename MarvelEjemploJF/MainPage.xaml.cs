using MarvelEjemploJF.Models;
using MarvelEjemploJF.Services;
using System.Collections.ObjectModel;

namespace MarvelEjemploJF;


public partial class MainPage : ContentPage
{
    public ObservableCollection<JFMarvelCharacterc> Characters { get; set; }

    public MainPage()
    {
        InitializeComponent();

        Characters = new ObservableCollection<JFMarvelCharacterc>();
        BindingContext = this;

        LoadCharacters();
    }

    private async void LoadCharacters()
    {
        var service = new JFMarvelServices();
        var characters = await service.GetCharactersAsync();
        foreach (var character in characters)
        {
            Characters.Add(character);
        }

    }
}