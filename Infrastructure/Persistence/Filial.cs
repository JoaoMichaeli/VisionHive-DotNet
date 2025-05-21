namespace Vision.Hive.Infrastructure.Persistence
{
    public class Filial
    {
        public Guid Id {  get; private set; }
        public string Nome { get; private set; }
        public string Bairro { get; private set; }
        public string Cnpj { get; private set; }

        public List<Patio> Patios { get; private set; }

        public Filial(string nome, string bairro, string cnpj)
        {
            Validar(nome, bairro, cnpj);
            Id = Guid.NewGuid();
            Nome = nome;
            Bairro = bairro;
            Cnpj = cnpj;
            Patios = new List<Patio>();
        }

        public void AtualizarDados(string nome, string bairro, string cnpj)
        {
            Validar(nome, bairro, cnpj);
            Nome = nome;
            Bairro = bairro;
            Cnpj = cnpj;
        }

        private void Validar(string nome, string bairro, string cnpj)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("O nome da filial não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(bairro))
            {
                throw new Exception("O bairro da filial não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                throw new Exception("O CNPJ da filial não pode ser vazio.");
            }
        }
    }
}
