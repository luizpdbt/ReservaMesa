using MongoDB.Bson.Serialization.Attributes;

namespace ReservaMesa.Model
{
    [BsonIgnoreExtraElements]
    public class Reserva
    {
        public Guid reservaId { get; set; } = Guid.NewGuid();
        public string email { get; set; }
        public string cpf { get; set; }
        public DateTime tempoEntrada { get; set; } = DateTime.Now;
    }
}
