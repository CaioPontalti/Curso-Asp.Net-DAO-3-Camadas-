namespace Model.Entity
{
    public class Categoria
    {
        private string idCategoria;
        private string nome;
        private string descricao;
        private int estado;

        public string IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Estado { get; set; }

        public Categoria()
        {
       
        }

        public Categoria(string idCategoria, string nome, string descricao)
        {
            this.idCategoria = idCategoria;
            this.nome = nome;
            this.descricao = descricao;
        }

        public Categoria(string idCategoria)
        {
            this.idCategoria = idCategoria;
            
        }
    }
}
