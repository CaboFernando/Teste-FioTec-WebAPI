namespace Infodengue.Domain.Entities
{
    public class Relatorio
    {
        public Guid Id { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Arbovirose { get; set; } = null!;
        public int SemanaInicio { get; set; }
        public int SemanaFim { get; set; }
        public string CodigoIbge { get; set; } = null!;
        public string Municipio { get; set; } = null!;
        
        public Guid SolicitanteId { get; set; }
        public Solicitante Solicitante { get; set; } = null!;
    }
}
