namespace Helper;
using System;
using ClosedXML.Excel;

public class Excel
{
    string colunaAlvo = "3"; // Coluna onde será feita a pesquisa
    public int PesquisarExcel(string caminhoExcel, string valorProcurado)
    {
        using (var workbook = new XLWorkbook(caminhoExcel))
        {
            var worksheet = workbook.Worksheet(1); // Acessa a primeira planilha
            var calula = worksheet.Column(colunaAlvo).CellsUsed(c =>c.GetString() == valorProcurado).FirstOrDefault();

            if (calula != null)
            {
                return calula.Address.RowNumber; // Retorna o número da linha onde o valor foi encontrado
            }
            else
            {
                return -1; // Retorna -1 se o valor não for encontrado
            }
            
        }
        
    }
}