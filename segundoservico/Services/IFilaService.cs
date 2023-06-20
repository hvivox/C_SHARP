using System.Threading.Tasks;
using primeiroservico.Model;

namespace segundoservico.Services
{
    public interface IFilaService
    {
        Task IniciarConsumoFila();
        List<Usuario> ObterMensagensConcluidas();

    }
}