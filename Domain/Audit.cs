namespace Vision.Hive.Domain
{
    public class Audit
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Prioridade Prioridade { get; protected set; }

        protected Audit()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }

        protected void AtualizarDataModificacao()
        {
            DateModified = DateTime.Now;
        }
    }
}
