using Lib.ConsoleHelper;

namespace SCgrc
{
    public class CSVReader
    {
        public AllMenus menu;

        public CSVReader(AllMenus allMenus)
        {
            menu=allMenus;
        }

        
        public void Start(lista lista)
        {
            // A pasta onde ficará os documentos importados é passada pelo "caminho" abaixo:
            string caminho = "data";
            string[] arquivos = Directory.GetFiles(caminho);
            Console.WriteLine("Arquivos encontrados");

            // Um dos arquivos importados é escolhido para ser passado como vetor, transformando
            // seus dados em dados úteis.
            int cont = 0;
            foreach (string arquivo in arquivos)
            {
                menu.Import.Options.Add(new MenuItem
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
            var choice = menu.Import.ReadChoice(true);
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
                menu.Import.Options.Clear();
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

            x.caminho = valores[2];

            x.categoria= valores[3];

            x.área= valores[4];

            int Ano= int.Parse(valores[5]);
            int Mês= int.Parse(valores[6]);
            int Dia= int.Parse(valores[7]);
            x.revisão= new DateTime(Ano,Mês,Dia);

            return x;
        }

    }

}