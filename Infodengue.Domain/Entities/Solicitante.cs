namespace Infodengue.Domain.Entities
{
    public class Solicitante
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string CPF { get; set; } = null!;

        public ICollection<Relatorio> Relatorios { get; set; } = new List<Relatorio>();
    }
}
