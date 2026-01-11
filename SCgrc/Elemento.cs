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


        //TO STRING:
        //Nome: nome         >Index: Index
        //Exemplo/de/caminho
        //Categoria: categoria
        public void ToString()
        {
            System.Console.WriteLine($"Nome: {nome}         >Index: {Index}\n{caminho}\nCategoria: {categoria}\nÁrea: {área}\n--------------------------------");
        }
    }
}