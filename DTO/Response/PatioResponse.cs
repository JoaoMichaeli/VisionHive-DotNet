namespace Vision.Hive.DTO.Response
{
    public class PatioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public int LimiteMotos { get; set; }
        public List<MotoResponse> Motos { get; set; }
        
    }
}
