using ReservaMesa.Model;

namespace ReservaMesa.Interface
{
    public interface IControleReserva
    {
        void inserirReserva(Reserva reserva);
        Reserva consultarReserva(Guid guid);
        Reserva retornarReserva();
        void excluiDaLista(Guid guid);
        List<Reserva> listarReservas();

    }
}
