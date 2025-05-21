namespace Vision.Hive.Infrastructure.Persistence
{
    public class Patio
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public int LimiteMotos { get; private set; } = 100; // limite de 100 motos por patio 

        // relacionamento com filial
        public Guid FilialId { get; private set; }
        public Filial Filial { get; private set; }

        public List<Moto> Motos { get; private set; }


        
        public Patio(string nome, int limiteMotos, Guid filialId)
        {
            Validar(nome, limiteMotos);
            Id = Guid.NewGuid();
            Nome = nome;
            LimiteMotos = limiteMotos;
            FilialId = filialId;
            Motos = new List<Moto>();
        }

        public void AtualizarDados(string nome, int limiteMotos)
        {
            Validar(nome, limiteMotos);
            Nome = nome;
            LimiteMotos = limiteMotos;
        }

        public bool PodeAdicionarMoto()
        {
            return Motos.Count < LimiteMotos;
        }

        private void Validar(string nome, int limiteMotos)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("O nome do pátio não pode ser vazio.");

            if (limiteMotos <= 0)
                throw new Exception("O limite de motos deve ser maior que zero.");
        }
    }
}
    
