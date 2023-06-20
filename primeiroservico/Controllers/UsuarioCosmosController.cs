
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using primeiroservico.Model;
using primeiroservico.Repository;


namespace primeiroservico.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioCosmosController : ControllerBase
    {
        private readonly IUsuarioCosmosRepository _usuarioCosmosRepository;
        private readonly ServiceBusIntegrationRepository _serviceBusIntegrationRepository;


        public UsuarioCosmosController(IUsuarioCosmosRepository usuarioCosmosRepository, ServiceBusIntegrationRepository serviceBusIntegration)
        {
            _usuarioCosmosRepository = usuarioCosmosRepository;
            _serviceBusIntegrationRepository = serviceBusIntegration;
        }


        [HttpPost]
        public async Task<IActionResult> PostUsuario(Usuario usuario)
        {
            //ENCAMINHA INFORMAÇÃO PARA SER SALVA NO AZURE COSMOS
            await _usuarioCosmosRepository.SalvarUsuarioAsync(usuario);


            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome
            };

            string mensagem = JsonConvert.SerializeObject(usuarioDTO);

            // ENCAMINHA DADOS DO USUARIO PARA FILA
            await _serviceBusIntegrationRepository.EnviarMensagemParaFilaAsync(mensagem);
            return Ok();
        }
    }
}