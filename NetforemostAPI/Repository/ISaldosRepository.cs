using NetforemostAPI.DTOs;
using NetforemostAPI.Models;

namespace NetforemostAPI.Repository
{
    public interface ISaldosRepository
    {
        Task<List<Gestore>> GetGestores();
        Task<List<SaldoDTO>> GetSaldos();
    }
}
