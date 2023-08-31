namespace EventosGest.API.Entites
{
    public class EventoOrador
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string TituloEvento { get; set;}
        public string DescricaoEvento {  get; set;}
        public string PerfilLinkedIn {  get; set;}
        public Guid EventoId { get; set; }
    }
}