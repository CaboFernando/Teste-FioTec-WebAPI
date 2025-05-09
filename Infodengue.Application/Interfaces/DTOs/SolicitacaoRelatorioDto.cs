namespace Infodengue.Application.DTOs
{
    public class SolicitacaoRelatorioDto
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Arbovirose { get; set; } = "dengue";
        public string CodigoIbge { get; set; } = string.Empty;
        public int SemanaInicio { get; set; }
        public int SemanaFim { get; set; }
    }
}
