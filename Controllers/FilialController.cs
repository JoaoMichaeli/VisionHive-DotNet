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
    [Tags("Filiais")]
    [ApiController]
    public class FilialController: ControllerBase
    {
        private readonly VisionHiveContext _context;
        public FilialController(VisionHiveContext context)
        {
            _context = context;
        }

        /// <summary>
        ///Lista todas as filiais com seus páios
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FilialResponse>>> GetFiliais()
        {
            var filiais = await _context.Filiais
                .Include(f => f.Patios)
                .ToListAsync();

            var response = filiais.Select(f => new FilialResponse
            {
                Id = f.Id,
                Nome = f.Nome,
                Bairro = f.Bairro,
                Cnpj = f.Cnpj,
                Patios = f.Patios.Select(p => new PatioResponse
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    LimiteMotos = p.LimiteMotos
                }).ToList()
            });

            return Ok(response);
        }
        /// <summary>
        /// Cadastra uma nova filial
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Filial>> PostFilial(FilialRequest request)
        {
            var filial = new Filial(request.Nome, request.Bairro, request.Cnpj);

            _context.Filiais.Add(filial);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFiliais), new { id = filial.Id }, filial);
        }

        /// <summary>
        /// Atualiza dados de uma filial
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilial(Guid id, FilialRequest request)
        {
            var filial = await _context.Filiais.FindAsync(id);
            if (filial == null) return NotFound();

            filial.AtualizarDados(request.Nome, request.Bairro, request.Cnpj);

            _context.Filiais.Update(filial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Remove uma filial
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilial(Guid id)
        {
            var filial = await _context.Filiais.FindAsync(id);
            if (filial == null) return NotFound();

            _context.Filiais.Remove(filial);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}