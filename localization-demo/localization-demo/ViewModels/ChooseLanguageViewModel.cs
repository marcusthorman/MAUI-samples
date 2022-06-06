using localization_demo.Models;
using localization_demo.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace localization_demo.ViewModels;

public class ChooseLanguageViewModel
{
    public ChooseLanguageViewModel()
    {
        // instantiate ObservableCollection of Language objects
        Languages = new ObservableCollection<Language>
        {
            new Language("en-US", "English"),
            new Language("da-DK", "Danish"),
        };

        // try to load saved language
        LoadSavedLanguagePreferences();
    }


    // this property will serve as the collection which we will show in our contentpage
    public ObservableCollection<Language> Languages { get; private set; }


    // contains the current selection
    private Language _selectedLanguage;
    public Language SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            _selectedLanguage = value;
            SetLanguage();
        }
    }


    private void SetLanguage()
    {
        SaveLanguagePreferences(SelectedLanguage);

        // change locale:
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(SelectedLanguage.Identifier);
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(SelectedLanguage.Identifier);
        CultureInfo.CurrentCulture = new System.Globalization.CultureInfo(SelectedLanguage.Identifier);
        CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo(SelectedLanguage.Identifier);

        // continue
        GoToMainPage();
    }


    private void LoadSavedLanguagePreferences()
    {
        if (!Preferences.ContainsKey("locale"))
        {
            return;
        }

        var savedLocale = Preferences.Get("locale", "");
        if (string.IsNullOrEmpty(savedLocale))
        {
            return;
        }

        var correspondingLanguage = Languages.Where(x => string.Compare(x.Identifier, savedLocale) == 0);
        if (correspondingLanguage.Count() != 1)
        {
            // something went wrong here
            return;
        }

        SelectedLanguage = correspondingLanguage.First();
    }


    private void SaveLanguagePreferences(Language language)
    {
        if (language == null)
        {
            return;
        }

        // check if preferences is already set
        if (string.Compare(Preferences.Get("locale", ""), language.Identifier) == 0)
        {
            return;
        }

        Preferences.Set("locale", language.Identifier);
    }


    // //// doesn not preserve backstack
    private async void GoToMainPage() => await Shell.Current.GoToAsync($"////{nameof(MainPage)}");
}
