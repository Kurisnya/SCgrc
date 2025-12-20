using Lib.ConsoleHelper;

namespace SCgrc
{
    internal class CSVReader
    {
        public Settings Settings{get;set;}
        public Settings SettingMain{get;set;}
        public ChoiceMenu Mymenu{get;set;}

        public CSVReader()
        {
            SettingMain= new Settings
            {
                IntroText= "SISTEMA CENTRALIZADO DO GRC",
                Selection= ">",
                SelectionColor= ConsoleColor.Blue
            };
            Settings = new Settings
            {
                IntroText= $"Escolha o documento salvo desejado",
                Selection= ">",
                SelectionColor= ConsoleColor.Green

            };
            Mymenu = new ChoiceMenu(Settings);
        }
        
        public void Start(lista lista)
        {
            // A pasta onde ficará os documentos importados é passada pelo "caminho" abaixo:
            string caminho = "/home/kuris/Área de trabalho/Projetos/SCgrc/SCgrc/data";
            string[] arquivos = Directory.GetFiles(caminho);
            Console.WriteLine("Arquivos encontrados");


            // Um dos arquivos importados é escolhido para ser passado como vetor, transformando
            // seus dados em dados úteis.
            int cont = 0;
            foreach (string arquivo in arquivos)
            {
                Mymenu.Options.Add(new MenuItem
                {
                    Title = $"{Path.GetFileName(arquivo)}",
                    Value = $"{cont}"
                });
                cont++;
            }
            // Index do array (dos documentos) é coletado e o Menu é lançado.

            //TÍTULO:
            //--------------------------------------
            //--Escolha o documento salvo desejado--
            //--------------------------------------
            var choice = Mymenu.ReadChoice(true);
            // Index do array se torna "cont".
            cont = int.Parse(choice.Value);
            // Finalmente, o caminho do arquivo principal é extraído.
            caminho = arquivos[cont];

            //O leitor do documento é criado.
            StreamReader reader = null;
            if (File.Exists(caminho))
            {
                //abrindo documento...
                reader = new StreamReader(File.OpenRead(caminho));

                //loop de leitura do documento...
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var valores = line.Split(',');

                    // A lista é alimentada com objetos contendo os elementos extraídos do 
                    // documento
                    elemento cliente = CriaCustomerCSV(lista, valores);
                    lista.InserirFim(cliente);
                }
                Mymenu.Options.Clear();
                reader.Close();
            }

        }
        //Função que alimenta o objeto com os elementos:
        static elemento CriaCustomerCSV(lista lista, string[] valores)
        {
            Console.Clear();

            elemento x = new elemento();

            x.Index = lista.Contar() + 1;

            x.nome = valores[1];

            x.id = valores[2];

            return x;
        }

    }

}