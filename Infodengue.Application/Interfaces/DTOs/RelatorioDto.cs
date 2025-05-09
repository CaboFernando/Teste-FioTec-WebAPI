namespace Infodengue.Application.DTOs
{
    public class RelatorioDto
    {
        public DateTime DataSolicitacao { get; set; }
        public string Arbovirose { get; set; }
        public string Municipio { get; set; }
        public string CodigoIbge { get; set; }
        public int SemanaInicio { get; set; }
        public int SemanaFim { get; set; }
        public string Solicitante { get; set; }
        public int TotalCasos { get; set; }
    }
}
