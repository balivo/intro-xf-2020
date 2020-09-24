using System;

namespace PlacesApp.Models
{
    public abstract class BaseModel<TKey>
    {
        public TKey Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}