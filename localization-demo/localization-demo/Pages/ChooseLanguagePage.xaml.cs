using localization_demo.Resources.Strings;
using localization_demo.ViewModels;

namespace localization_demo.Pages;

public partial class ChooseLanguagePage : ContentPage
{
	private readonly ChooseLanguageViewModel _viewModel;

	public ChooseLanguagePage(ChooseLanguageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}
}

