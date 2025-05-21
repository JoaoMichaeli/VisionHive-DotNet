namespace Vision.Hive.DTO.Response
{
    public class FilialResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Bairro { get; set; }
        public string Cnpj { get; set; }
        public List<PatioResponse> Patios { get; set; }
       
    }
}
