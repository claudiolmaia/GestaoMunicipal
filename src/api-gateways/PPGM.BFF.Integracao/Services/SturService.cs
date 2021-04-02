using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using HiQPdf;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using PPGM.BFF.Integracao.Extensions;
using PPGM.BFF.Integracao.Models;

namespace PPGM.BFF.Integracao.Services
{
    public interface ISturService
    {
        Task<List<IptuDTO>> ObterIptuPorCpf(string cpf);
        Task<List<IptuDTO>> ObterTodos();
        Task<bool> Baixar(int id);
        Task<byte[]> GerarPDF(int id);
    }

    public class SturService : Service, ISturService
    {
        private readonly HttpClient _httpClient;

        public SturService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.SturUrl);
        }

        public async Task<List<IptuDTO>> ObterIptuPorCpf(string cpf)
        {
            var response = await _httpClient.GetAsync($"/iptu/cpf/{cpf}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<List<IptuDTO>>(response);
        }

        public async Task<List<IptuDTO>> ObterTodos()
        {
            var response = await _httpClient.GetAsync($"/iptu");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<List<IptuDTO>>(response);
        }

        public async Task<bool> Baixar(int id)
        {
            var content = ObterConteudo("");
            var response = await _httpClient.PutAsync($"/iptu/{id}", content);

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<bool>(response);
        }

        public async Task<byte[]> GerarPDF(int id)
        {
            var responseIptu = await _httpClient.GetAsync($"/iptu/{id}");

            TratarErrosResponse(responseIptu);

            var iptu =  await DeserializarObjetoResponse<IptuDTO>(responseIptu);

            var htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<html><body>");
            htmlBuilder.Append("<h1>PDF Exemplo</h1>");
            htmlBuilder.Append($"<h4>CPF: {iptu.CPF}</h4>");
            htmlBuilder.Append($"<h4>Endereço: {iptu.Logradouro}, {iptu.Numero} - {iptu.Bairro} / {iptu.UF}</h4>");
            htmlBuilder.Append($"<h4>Data Vencimento: {iptu.DataVencimento.ToString("dd/MM/yyyy")}</h4>");
            htmlBuilder.Append($"<h4>Valor: R${iptu.Valor.ToString("C", CultureInfo.CurrentCulture)}</h4>");
            htmlBuilder.Append("</body></html>");

            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();
            htmlToPdfConverter.Document.PageSize =  PdfPageSize.A4;
            htmlToPdfConverter.Document.PageOrientation = PdfPageOrientation.Portrait;
            htmlToPdfConverter.Document.Margins = new PdfMargins(5);

            //var htmlToPdf = new HiQPdf.HtmlToPdf( new NReco.PdfGenerator.HtmlToPdfConverter();
            //var pdfBytes = htmlToPdf.GeneratePdf(htmlBuilder.ToString());
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlBuilder.ToString(), "");
            return pdfBuffer;
        }
    }
}
