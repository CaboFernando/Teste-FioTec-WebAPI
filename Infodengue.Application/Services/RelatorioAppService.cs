using Infodengue.Application.DTOs;
using Infodengue.Application.Interfaces;
using Infodengue.Domain.Entities;
using Infodengue.Domain.Interfaces;
using System.Net.Http.Json;

namespace Infodengue.Application.Services
{
    public class RelatorioAppService : IRelatorioAppService
    {
        private readonly ISolicitanteRepository _solicitanteRepo;
        private readonly IRelatorioRepository _relatorioRepo;
        private readonly HttpClient _http;

        public RelatorioAppService(
            ISolicitanteRepository solicitanteRepo,
            IRelatorioRepository relatorioRepo,
            HttpClient http)
        {
            _solicitanteRepo = solicitanteRepo;
            _relatorioRepo = relatorioRepo;
            _http = http;
        }

        public async Task<RelatorioDto> ConsultarRelatorioAsync(SolicitacaoRelatorioDto solicitacaoDto)
        {
            var solicitante = await _solicitanteRepo.GetByCPFAsync(solicitacaoDto.CPF);

            if (solicitante == null)
            {
                solicitante = new Solicitante
                {
                    Id = Guid.NewGuid(),
                    Nome = solicitacaoDto.Nome,
                    CPF = solicitacaoDto.CPF
                };

                await _solicitanteRepo.AddAsync(solicitante);
                await _solicitanteRepo.SaveChangesAsync();
            }

            var url = $"https://info.dengue.mat.br/api/{solicitacaoDto.Arbovirose}/city/{solicitacaoDto.CodigoIbge}?semana_ini={solicitacaoDto.SemanaInicio}&semana_fim={solicitacaoDto.SemanaFim}";
            var response = await _http.GetFromJsonAsync<List<dynamic>>(url);

            var dados = response?.FirstOrDefault();
            var municipio = dados?.municipio ?? "Desconhecido";
            var casos = dados?.casos ?? 0;

            var relatorio = new Relatorio
            {
                Id = Guid.NewGuid(),
                DataSolicitacao = DateTime.Now,
                Arbovirose = solicitacaoDto.Arbovirose,
                Municipio = municipio,
                CodigoIbge = solicitacaoDto.CodigoIbge,
                SemanaInicio = solicitacaoDto.SemanaInicio,
                SemanaFim = solicitacaoDto.SemanaFim,
                TotalCasos = (int)casos,
                SolicitanteId = solicitante.Id
            };

            await _relatorioRepo.AddAsync(relatorio);
            await _relatorioRepo.SaveChangesAsync();

            return new RelatorioDto
            {
                DataSolicitacao = relatorio.DataSolicitacao,
                Arbovirose = relatorio.Arbovirose,
                Municipio = relatorio.Municipio,
                CodigoIbge = relatorio.CodigoIbge,
                SemanaInicio = relatorio.SemanaInicio,
                SemanaFim = relatorio.SemanaFim,
                Solicitante = solicitante.Nome,
                TotalCasos = relatorio.TotalCasos
            };
        }

        public async Task<IEnumerable<RelatorioDto>> ListarRelatoriosAsync()
        {
            var relatorios = await _relatorioRepo.GetAllAsync();
            return relatorios.Select(r => new RelatorioDto
            {
                DataSolicitacao = r.DataSolicitacao,
                Arbovirose = r.Arbovirose,
                Municipio = r.Municipio,
                CodigoIbge = r.CodigoIbge,
                SemanaInicio = r.SemanaInicio,
                SemanaFim = r.SemanaFim,
                Solicitante = r.Solicitante?.Nome ?? "",
                TotalCasos = r.TotalCasos
            });
        }
    }
}
