using Lib.ConsoleHelper;

namespace SCgrc
{
    public class AllMenus
    {
        //Menu principal
        public ChoiceMenu Main1;
        public ChoiceMenu Import;
        public Settings SettingMain1= new Settings
            {
                IntroText= "SISTEMA CENTRALIZADO DO GRC",
                Selection= ">",
                SelectionColor= ConsoleColor.Blue
            };
        public Settings SettingImport= new Settings
            {
                IntroText= $"Escolha o documento salvo desejado",
                Selection= ">",
                SelectionColor= ConsoleColor.Green

            };



        public AllMenus()
        {
        //MAIN1
        Main1= new ChoiceMenu(SettingMain1);
            Main1.Options.Add(new MenuItem
            {
                Title = "Criar Elemento",
                Value = "1"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Imprimir Todos",
                Value = "2"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Excluir elemento",
                Value = "3"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Importar da pasta",
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
                Title = "Sair",
                Value = "0"
            });


        //DATA - Documentos
        Import = new ChoiceMenu(SettingImport);
        //NOTA: As opções são criadas dentro do código do "Importar";
        }
        
    }
 
}