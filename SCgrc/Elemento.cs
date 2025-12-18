namespace SCgrc
{
    public class elemento
    {
        public int Index{get;set;}
        public elemento prox{get;set;}
        public string nome{get;set;}
        public string id{get;set;}


        //TO STRING:
        //Nome: nome         >Index: Index
        //Id: id
        public void ToString()
        {
            System.Console.WriteLine($"Nome: {nome}         >Index: {Index}\nId: {id}\n--------------------------------");
        }
    }
}