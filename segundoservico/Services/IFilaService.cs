using System.Threading.Tasks;
using segundoservico.Model;

namespace segundoservico.Services
{
    public interface IFilaService
    {
        Task IniciarConsumoFila();
        //List<Usuario> ObterMensagensConcluidas();

    }
}