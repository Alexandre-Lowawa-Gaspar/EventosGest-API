namespace EventosGest.API.Entites
{
    public class Evento
    {
        public Evento()
        {
            Oradores = new List<EventoOrador>();
            FoiExcluido = false;
        }
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public List<EventoOrador> Oradores { get; set; }
        public bool FoiExcluido { get; set; }
        public void Update(string titulo, string descricao, DateTime inicio, DateTime termino)
        {
            Titulo = titulo;
            Descricao = descricao;
            Inicio = inicio;
            Termino = termino;
        }
        public void Delete() 
        {
            FoiExcluido = true;
        }
    }

}
