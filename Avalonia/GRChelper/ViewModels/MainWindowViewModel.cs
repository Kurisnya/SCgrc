namespace GRChelper.ViewModels;

using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GRChelper.Core;
using GRChelper.Views;
using Tmds.DBus.Protocol;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private lista _listaProcedimentos = new();

    [ObservableProperty]
    private lista _listaListados = new();

    [ObservableProperty]
    private CSVReader _reader = new();

    public ObservableCollection<string> ListadosNome { get; } = new();
    public ObservableCollection<string> ProcedimentosNome { get; } = new();
    public ObservableCollection<string> VencidosNome { get; } = new();
 

    public MainWindowViewModel()
    {
            Reader.Start(ListaListados,"Core/data/Listados.csv");
            elemento i= ListaListados.primeiro;

            if (i.prox != null)
            {
                do
                {
                    i=i.prox;
                    ListadosNome.Add(i.nome);

                }while(i.prox!=null);
            }




            Reader.Start(ListaProcedimentos,"Core/data/Procedimentos.csv");
            elemento j= ListaProcedimentos.primeiro;

            if (j.prox != null)
            {
                do
                {
                    j=j.prox;
                    ProcedimentosNome.Add(j.nome);

                }while(j.prox!=null);
            }


            //INSERIR DESATUALIZADOS NA COLEÇÃO
            //LISTADOS
            elemento z = ListaListados.primeiro;

            if (z.prox != null)
            {
                do
                {
                    z=z.prox;

                    if(DateTime.Today > z.revisão.AddYears(1))
                        {
                            VencidosNome.Add(z.nome);
                        }

                }while(z.prox!=null);
            }
    }

    [ObservableProperty]
    private bool _isPaneOpen = true;

    [ObservableProperty]
    private bool _home = true;
    
    [ObservableProperty]
    private bool _documentos = false;

    [ObservableProperty]
    private string _textoPrincipal = "vazio";

    [ObservableProperty]
    private bool _listaListadosView = true;

    [ObservableProperty]
    private bool _listaProcedimentosView = false;

    [ObservableProperty]
    private bool _listaVencidosView = false;

    [RelayCommand]
    private void ListaListadosSwitch()
    {
        ListaListadosView = true;

        ListaProcedimentosView = false;

        ListaVencidosView = false;
    }

    [RelayCommand]
    private void ListaProcedimentosSwitch()
    {
        ListaProcedimentosView = true;

        ListaListadosView = false;

        ListaVencidosView = false;

    }
    
    [RelayCommand]
        private void ListaVencidosSwitch()
    {
        ListaVencidosView = true;

        ListaListadosView = false;

        ListaProcedimentosView = false;
    }

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

    [RelayCommand]
    public void AtualizarVencido(string MyName)
    {

        ListaListados.Atualizar(MyName);

        VencidosNome.Remove(MyName);
    }
}