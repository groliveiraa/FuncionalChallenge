namespace FuncionalChallenge.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; }

        public override string ToString()
        {
            return this.NomeCategoria;
        }
    }
}