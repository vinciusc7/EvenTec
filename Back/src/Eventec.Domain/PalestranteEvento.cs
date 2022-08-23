using EvenTec.Domain;

namespace Eventec.Domain
{
    public class PalestranteEvento
    {
        public int PalestranteID { get; set; }
        public Palestrante palestrante { get; set; }
        public int EventoID { get; set; }
        public Evento Evento { get; set; }
    }
}