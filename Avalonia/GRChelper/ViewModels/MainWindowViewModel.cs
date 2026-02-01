namespace GRChelper.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GRChelper.Views;

public partial class MainWindowViewModel : ObservableObject
{

    [ObservableProperty]
    private bool _isPaneOpen = true;

    [ObservableProperty]
    private bool _home = true;

    [ObservableProperty]
    private bool _documentos = false;

    [ObservableProperty]
    private string _textoPrincipal = "vazio";

    [RelayCommand]
    private void MudaTextoPrincipal()
    {
        TextoPrincipal = "HelloWorld";
    }


    
    [RelayCommand]
    private void SwitchySplitView()
    {
        IsPaneOpen = !IsPaneOpen;
    }

    [RelayCommand]
    private void SwitchyToDocumentos()
    {
        Home = !Home;
        Documentos = !Documentos;
    }
}