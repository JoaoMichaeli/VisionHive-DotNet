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
    [Tags("Motos")]
    [ApiController]
    public class MotoController: ControllerBase
    {
        private readonly VisionHiveContext _context;

        public MotoController(VisionHiveContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna uma lista de motos
        /// </summary>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     GET api/moto
        /// 
        /// </remarks>
        /// <response code="200">Retorna uma lista de motos</response>
        /// <response code="500">Erro interno do servidor</response>
        /// <response code="503">Serviço indisponível</response>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        public async Task<ActionResult<IEnumerable<Moto>>> GetMotos()
        {
            return await _context.Motos.Include(x => x.Patio).ToListAsync();
        }



        /// <summary>
        /// Retorna uma moto pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MotoResponse>> GetMoto(Guid id)
        {
            var moto = await _context.Motos.Include(x => x.Patio).SingleOrDefaultAsync(x => x.Id == id);

            if (moto == null)
            {
                return NotFound();
            }

            var motoDto = new MotoResponse
            {
                Id = moto.Id,
                Placa = moto.Placa,
                Chassi = moto.Chassi,
                NumeroMotor = moto.NumeroMotor,
                Prioridade = moto.Prioridade.ToString(),
                Patio = moto.Patio.Nome
            };

            return Ok(motoDto);
        }



        /// <summary>
        /// Cadastra uma nova moto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Moto>> PostMoto(MotoRequest request)
        {
            var patio = _context.Patios.SingleOrDefault(x => x.Id == request.PatioId);

            if (patio is null)
                throw new Exception("Pátio não existe");

            var moto = new Moto(request.Placa, request.Chassi, request.NumeroMotor, request.Prioridade, request.PatioId);

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoto", new { id = moto.Id }, moto);
        }



        /// <summary>
        /// Atualiza uma moto existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoto(Guid id, MotoRequest request)
        {
            var moto = await _context.Motos.FindAsync(id);

            if (moto == null)
            {
                return NotFound();
            }

            moto.AtualizarDados(request.Placa, request.Chassi, request.NumeroMotor, request.Prioridade, request.PatioId);

            _context.Motos.Update(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        /// <summary>
        /// Remove uma moto existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoto(Guid id)
        {
            var moto = await _context.Motos.Include(x => x.Patio).SingleOrDefaultAsync(x => x.Id == id);

            if (moto == null)
            {
                return NotFound();
            }

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}