using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaMesa.Interface;
using ReservaMesa.Model;

namespace ReservaMesa.Controllers
{
    [Route("api/reservaFila/")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IControleReserva _controleReserva;

        public ReservaController(IControleReserva controleReserva)
        {
            _controleReserva = controleReserva;
        }

        [Route("adicionaFilaReserva")]
        [HttpPost]
        public async Task<IActionResult> filaReserva([FromBody]Reserva reserva)
        {
            _controleReserva.inserirReserva(reserva);

            return Ok("Reserva Efetuada com sucesso");
        }

        [Route("retornaFilaReserva")]
        [HttpGet]
        public async Task<IActionResult> retornaItemFila()
        {
            return Ok(_controleReserva.retornarReserva());
        }

        [Route("consultarFilaReserva")]
        [HttpPut]
        public async Task<IActionResult> consultarFilaReserva(Guid guid)
        {
            return Ok(_controleReserva.consultarReserva(guid));
        }


        [Route("deletarItemReserva")]
        [HttpDelete]
        public async Task<IActionResult> deletarItemFilaReserva(Guid guid)
        {
            _controleReserva.excluiDaLista(guid);

            return Ok("Item Removido com Sucesso");
        }

        [Route("listarReservas")]
        [HttpGet]
        public async Task<IActionResult> listarItemFilaReserva()
        {
            return Ok(_controleReserva.listarReservas());
        }


    }
}
