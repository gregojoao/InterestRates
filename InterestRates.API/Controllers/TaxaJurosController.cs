using Microsoft.AspNetCore.Mvc;

namespace InterestRates.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxaJurosController : ControllerBase
{
    /// <summary>
    /// Retorna a taxa de juros padrão
    /// </summary>
    /// <returns>Taxa de juros de 1% (0.01)</returns>
    [HttpGet("/taxaJuros")]
    [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
    public Task<decimal> Get() =>
        Task.FromResult(0.01m);
}