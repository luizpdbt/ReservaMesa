using ReservaMesa.Interface;
using ReservaMesa.Repositorio;
using System.Collections;
namespace ReservaMesa.Model
{

    public class ControleReserva: IControleReserva
    {
        private Queue<Reserva> listaReservas = new Queue<Reserva>();
        private RepositorioReserva repositorioReserva = new RepositorioReserva();

        public Reserva consultarReserva(Guid guid)
        {
            return listaReservas.SingleOrDefault(x => x.reservaId.Equals(guid));
        }

        public void excluiDaLista(Guid guid)
        {
            var item = listaReservas.ToList().Where(x => x.reservaId == guid).SingleOrDefault();
            listaReservas.ToList().Remove(item);
        }

        public void inserirReserva(Reserva reserva)
        {
            repositorioReserva.InserirHorarioEntrada(reserva);
            listaReservas.Enqueue(reserva);
        }

        public List<Reserva> listarReservas()
        {
            return repositorioReserva.RetornReservas();
        }

        public Reserva retornarReserva()
        {
            var reservaDequeue = listaReservas.Dequeue();
            repositorioReserva.InserirHorarioSaida(reservaDequeue);
            return reservaDequeue;
        }
    }
}
