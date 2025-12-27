using Lib.ConsoleHelper;

namespace SCgrc
{
    public class AllMenus
    {
        public ChoiceMenu Main1;
        public ChoiceMenu Import;
        public ChoiceMenu Pesquisar;

        //1. Opções do Menu Principal
        public Settings SettingMain1= new Settings
            {
                IntroText= "/////-SISTEMA CENTRALIZADO DO GRC-/////",
                Selection= ">",
                SelectionColor= ConsoleColor.Blue

            };

        //2. Opções do menu de Importação
        public Settings SettingImport= new Settings
            {
                IntroText= $"Escolha o documento salvo desejado",
                Selection= ">",
                SelectionColor= ConsoleColor.Green

            };
        
        //3. Opções do menu de Pesquisa
        public Settings SettingPesquisa= new Settings
            {
                IntroText= $"Pesquisar pelo:",
                Selection= ">",
                SelectionColor= ConsoleColor.Blue

            };



        public AllMenus()
        {
        //MAIN1
        Main1= new ChoiceMenu(SettingMain1);
            Main1.Options.Add(new MenuItem
            {
                Title = "Importar da pasta",
                Value = "1"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Pesquisar",
                Value = "2"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Excluir elemento",
                Value = "3"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Criar elemento",
                Value = "4"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Salvar",
                Value = "5"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Limpar Dados",
                Value = "6"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Imprimir",
                Value = "7"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Sair",
                Value = "0"
            });


        //DATA - Documentos
        Import = new ChoiceMenu(SettingImport);
        //NOTA: As opções são criadas dentro do código do "Importar";

        //Pesquisar - Tipo de pesquisa
        Pesquisar= new ChoiceMenu(SettingPesquisa);
            Pesquisar.Options.Add(new MenuItem
            {
                Title = "Pesquisar por nome",
                Value = "1"
            });
            Pesquisar.Options.Add(new MenuItem
            {
                Title = "Pesquisar por Index",
                Value = "2"
            });
        }
        
    }
 
}