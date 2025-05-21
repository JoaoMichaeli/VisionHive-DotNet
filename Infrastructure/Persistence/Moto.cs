
using Vision.Hive.Domain;

namespace Vision.Hive.Infrastructure.Persistence
{
    public class Moto: Audit
    {
        public Guid Id { get; private set; }
        public string? Placa { get; private set; }

        public string? Chassi { get; private set; }

        public string? NumeroMotor { get; private set; }

       public Prioridade Prioridade { get; private set; }

             
        public Guid PatioId { get; private set; }
        public Patio Patio { get; private set; }


        public Moto(string? placa, string? chassi, string? numeroMotor, Prioridade prioridade, Guid patioId)
        {
            Validar(placa, chassi, numeroMotor);

            Id = Guid.NewGuid();
            Placa = placa;
            Chassi = chassi;
            NumeroMotor = numeroMotor;
            Prioridade = prioridade;
            PatioId = patioId;

        }

        public void AtualizarDados(string? placa, string? chassi, string? numeroMotor, Prioridade prioridade, Guid patioId)
        {
            Validar(placa, chassi, numeroMotor);

            Placa = placa;
            Chassi = chassi;
            NumeroMotor = numeroMotor;
            Prioridade = prioridade;
            PatioId = patioId;

        }

        private void Validar(string? placa, string? chassi, string? numeroMotor)
        {
            if(string.IsNullOrWhiteSpace(placa) && string.IsNullOrWhiteSpace(chassi) && string.IsNullOrWhiteSpace(numeroMotor))
            {
                throw new Exception("É necessário informar pelo menos a placa, o chassi ou o número do motor.");
            }
        }
        
    }
}
