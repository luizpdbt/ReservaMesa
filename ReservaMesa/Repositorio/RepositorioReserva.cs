using MongoDB.Bson;
using MongoDB.Driver;
using ReservaMesa.Model;
using System.Linq;

namespace ReservaMesa.Repositorio
{
    public class RepositorioReserva
    {
        private ConnectMongo mongoConnect = new ConnectMongo();
        private readonly IMongoCollection<Reserva> reservaCollection;
        private readonly IMongoDatabase database;

        public RepositorioReserva()
        {
            database = mongoConnect.ConnectMongoDb();
            reservaCollection = database.GetCollection<Reserva>("reservaRestaurante01");
        }

        public void InserirHorarioEntrada(Reserva reserva)
        {
            reservaCollection.InsertOne(reserva);
        }

        public void InserirHorarioSaida(Reserva reserva)
        {
            reservaCollection.InsertOne(reserva);
        }

        public List<Reserva> RetornReservas()
        {
            var listaReservas = reservaCollection.Find(new BsonDocument()).ToList();
            return listaReservas;
        }

    }
}
