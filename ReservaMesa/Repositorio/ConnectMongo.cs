using MongoDB.Driver;

namespace ReservaMesa.Repositorio
{
    public class ConnectMongo
    {
        public IMongoDatabase ConnectMongoDb()
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("ReservaDb");

            return database;
        }
    }
}
