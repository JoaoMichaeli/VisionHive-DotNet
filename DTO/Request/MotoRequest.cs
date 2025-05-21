using Vision.Hive.Domain;

namespace Vision.Hive.DTO.Request
{
    public class MotoRequest
    {
        public string? Placa { get; set; }
        public string? Chassi { get; set; }
        public string? NumeroMotor { get; set; }
        public Prioridade Prioridade { get; set; }
        public Guid PatioId { get; set; }

    }
}
