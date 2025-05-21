using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Vision.Hive.DTO.Request;
using Vision.Hive.DTO.Response;
using Vision.Hive.Infrastructure.Contexts;
using Vision.Hive.Infrastructure.Persistence;

namespace Vision.Hive.Controllers
{
    [Route("api/[controller]")]
    [Tags("Patios")]
    [ApiController]
    public class PatioController : ControllerBase
    {
        private readonly VisionHiveContext _context;

        public PatioController(VisionHiveContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todos os pátios com suas motos
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PatioResponse>>> GetPatios()
        {
            var patios = await _context.Patios
                .Include(p => p.Motos)
                .ToListAsync();

            var response = patios.Select(p => new PatioResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                LimiteMotos = p.LimiteMotos,
                Motos = p.Motos.Select(m => new MotoResponse
                {
                    Id = m.Id,
                    Placa = m.Placa,
                    Chassi = m.Chassi,
                    NumeroMotor = m.NumeroMotor,
                    Prioridade = m.Prioridade.ToString()
                }).ToList()
            });

            return Ok(response);
        }

        /// <summary>
        /// Cadastra um novo pátio
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Patio>> PostPatio(PatioRequest request)
        {
            var filial = await _context.Filiais.FindAsync(request.FilialId);
            if (filial == null) return NotFound("Filial não encontrada");

            var patio = new Patio(request.Nome, request.LimiteMotos, request.FilialId);

            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatios), new { id = patio.Id }, patio);
        }

        /// <summary>
        /// Atualiza os dados de um pátio
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatio(Guid id, PatioRequest request)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null) return NotFound();

            patio.AtualizarDados(request.Nome, request.LimiteMotos);
            _context.Patios.Update(patio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Remove um pátio
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatio(Guid id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio == null) return NotFound();

            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}