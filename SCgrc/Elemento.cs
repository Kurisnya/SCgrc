namespace SCgrc
{
    public class elemento
    {
        public elemento prox{get;set;}
        public int Index{get;set;}
        public string nome{get;set;}
        public string caminho{get;set;}
        public string categoria{get;set;}
        public string área{get;set;}
        public DateTime revisão;


        //TO STRING:
        //>Index: Index
        //Nome: nome         
        //Exemplo/de/caminho
        //Categoria: categoria
        public void ToString()
        {
            System.Console.WriteLine($">Index: {Index}\nNome: {nome}\n{caminho}\nCategoria: {categoria}\nÁrea: {área}\nUltima Revisão:{revisão}\n--------------------------------");
        }
    }
}