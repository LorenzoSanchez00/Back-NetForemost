using Microsoft.EntityFrameworkCore;
using NetforemostAPI.DTOs;
using NetforemostAPI.Models;
using NetforemostAPI.Models.Data;

namespace NetforemostAPI.Repository
{
    public class SaldosRepository : ISaldosRepository
    {
        private readonly NetforemostDbContext _context;
        public SaldosRepository(NetforemostDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Gestore>> GetGestores()
        {
            return await _context.Gestores.ToListAsync();

        }

        public async Task<List<SaldoDTO>> GetSaldos()
        {
            var saldos = await _context.Saldos
                .FromSqlRaw("EXEC p_AsignarSaldos")
                .ToListAsync();

            var gestorIds = saldos.Select(s => s.GestorId).Distinct().ToList();
            var gestores = await _context.Gestores
                .Where(g => gestorIds.Contains(g.GestorId))
                .ToListAsync();

            // Une saldos y gestores
            var result = saldos
                .GroupJoin(gestores,
                    saldo => saldo.GestorId,
                    gestor => gestor.GestorId,
                    (saldo, gestorGroup) => new
                    {
                        Saldo = saldo,
                        GestorGroup = gestorGroup
                    })
                .SelectMany(g => g.GestorGroup.DefaultIfEmpty(),
                    (g, gestor) => new SaldoDTO
                    {
                        GestorId = g.Saldo.GestorId ?? 0,
                        Nombre = gestor != null ? gestor.Nombre : "Desconocido",
                        Saldo = (int)g.Saldo.Saldo!
                    })
                .ToList();

            return result;
        }



    }
}
