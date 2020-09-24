using System;

namespace PlacesApp.Models
{
    public sealed class LocationModel : BaseModel<Guid>
    {
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool Favorito { get; set; }
    }
}