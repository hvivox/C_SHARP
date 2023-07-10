using Microsoft.AspNetCore.Mvc;
using segundoservico.Services;

namespace segundoservico.Controllers
{
    [ApiController]
    [Route("api/fila")]
    public class FilaController : ControllerBase
    {
        private readonly IFilaService _filaService;

        public FilaController(IFilaService filaService)
        {
            _filaService = filaService;
        }

        [HttpGet("iniciar-consumo")]
        public IActionResult IniciarConsumoFila()
        {
            _filaService.IniciarConsumoFila();
            //_filaService.EncerrarConexaoFila();

            return Ok("Consumo da fila iniciado com sucesso e encerradas.");
        }


    }
}