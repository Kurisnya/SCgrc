using System.Diagnostics;
using ClosedXML.Excel;

namespace Helper;

public partial class Form1 : Form
{
    public Form1()
    {
        
        string root = AppDomain.CurrentDomain.BaseDirectory;
        string caminhoScripts = Path.Combine(root, "Scripts");
        string caminhoBash = Path.Combine(root, "GitPortable", "bin", "bash.exe");


        InitializeComponent();
    }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string root = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoBash = Path.Combine(root, "GitPortable", "bin", "bash.exe");
            string caminhoScripts = Path.Combine(root, "Scripts");
            string caminhoScript= Path.Combine(caminhoScripts, "cachorro.sh");
            ProcessStartInfo first = new ProcessStartInfo();
            //APONTA ONDE O "BASH" FICA
            first.FileName= caminhoBash;
            //                      -c "sh 'caminho do script' 'argumento'"
            first.Arguments = $"-c \"sh '{caminhoScript.Replace("\\", "/")}' 'cachorro'\"";

            first.RedirectStandardOutput= true;
            first.UseShellExecute= false;
            first.CreateNoWindow= true;


            using(Process processo = Process.Start(first))
        {
            string result= processo.StandardOutput.ReadToEnd();
            processo.WaitForExit();
            MessageBox.Show("Resposta do Bash:\n" + result);
        }

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Excel excel = new Excel();
            MessageBox.Show("Linha encontrada: " + excel.PesquisarExcel(@"C:\Users\christian.soares\iT.eam\SGPI - Lista Mestra\Controle de Documentos\Lista Mestra.xlsx", "Política da Segurança da Informação.docx"));
        }
}
