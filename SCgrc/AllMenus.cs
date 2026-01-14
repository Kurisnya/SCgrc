using System.Runtime.InteropServices;
using Lib.ConsoleHelper;

namespace SCgrc
{
    public class AllMenus
    {
        public ChoiceMenu MainRoot;
        public ChoiceMenu Main1;
        public ChoiceMenu Import;
        public ChoiceMenu Pesquisar;
        public ChoiceMenu Prazos;

        //1. Opções do Menu Principal
        public Settings SettingMain1= new Settings
            {
                IntroText= "|- GRC HELPER > Elementos -| ",
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

        //4. Opções do MainRoot
        public Settings SettingMainRoot= new Settings
            {
                IntroText= "|- GRC HELPER -|",
                Selection= ">",
                SelectionColor= ConsoleColor.Yellow
            };

        //5. Opções do Verificar Prazos
        public Settings SettingPrazos= new Settings
            {
                IntroText= "|- GRC HELPER > Prazos -|",
                Selection= ">",
                SelectionColor= ConsoleColor.Yellow
            };

        public AllMenus()
        {
        //VERIFICAR PRAZOS
            Prazos= new ChoiceMenu(SettingPrazos);
            Prazos.Options.Add(new MenuItem
            {
                Title = "Scannear",
                Value = "1"
            });
            Prazos.Options.Add(new MenuItem
            {
                Title = "Atualizar um Documento",
                Value = "2"
            });
            Prazos.Options.Add(new MenuItem
            {
                Title = "Voltar",
                Value = "0"
            });

        //MAINROOT
            MainRoot= new ChoiceMenu(SettingMainRoot);
            MainRoot.Options.Add(new MenuItem
            {
                Title = "Elementos",
                Value = "1"
            });
            MainRoot.Options.Add(new MenuItem
            {
                Title = "Verificar Prazo dos Documentos",
                Value = "2"
            });
            MainRoot.Options.Add(new MenuItem
            {
                Title = "Sair",
                Value = "0"
            });
        //MAIN1
        Main1= new ChoiceMenu(SettingMain1);
            Main1.Options.Add(new MenuItem
            {
                Title = "Status",
                Value = "1"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Importar da pasta",
                Value = "2"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Pesquisar",
                Value = "3"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Imprimir",
                Value = "4"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Criar elemento",
                Value = "5"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Salvar",
                Value = "6"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Limpar Dados",
                Value = "7"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Excluir elemento",
                Value = "8"
            });
            Main1.Options.Add(new MenuItem
            {
                Title = "Voltar",
                Value = "0"
            });


        //DATA - Documentos
        Import = new ChoiceMenu(SettingImport);
        //NOTA: As opções são criadas dentro do código do "Importar";

        //Pesquisar - Tipo de pesquisa
        Pesquisar= new ChoiceMenu(SettingPesquisa);
            Pesquisar.Options.Add(new MenuItem
            {
                Title = "Pesquisar por Index",
                Value = "1"
            });
            Pesquisar.Options.Add(new MenuItem
            {
                Title = "Pesquisar por Nome",
                Value = "2"
            });
            Pesquisar.Options.Add(new MenuItem
            {
                Title = "Pesquisar por Caminho",
                Value = "3"
            });
            Pesquisar.Options.Add(new MenuItem
            {
                Title = "Pesquisar por Categoria",
                Value = "4"
            });
            Pesquisar.Options.Add(new MenuItem
            {
                Title = "Pesquisar por Área",
                Value = "5"
            });
            Pesquisar.Options.Add(new MenuItem
            {
                Title = "Voltar",
                Value = "0"
            });
        }
        
    }
 
}