using Customer.Application.Queries.Interfaces;
using Customer.Application.Queries.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FastServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFastServiceQueryHandler IFastServiceQueryHandler;


        public FastServiceController(IMediator mediator, IFastServiceQueryHandler iFastServiceQueryHandler)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            IFastServiceQueryHandler = iFastServiceQueryHandler ?? throw new ArgumentNullException(nameof(iFastServiceQueryHandler));
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(userLoginViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> login( LoginRequest login)
        {
            var result =  IFastServiceQueryHandler.Login(login);
            return Ok(result);
        }

        [HttpPost("register-user")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> register(RegisterUserRequest register)
        {
            var result = IFastServiceQueryHandler.RegisterUser(register);
            return Ok(result);
        }

        [HttpGet("nueva-solicitud-pedido")]
        [ProducesResponseType(typeof(nuevaSolicitudViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> nuevaSolicitudPedido()
        {
            var result = IFastServiceQueryHandler.NuevaSolicitudPedido();
            return Ok(result);
        }

        [HttpPost("aceptar-pedido")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> aceptarPedido(AceptarPedidoRequest aceptarPedido)
        {
            var result = IFastServiceQueryHandler.AceptarPedido(aceptarPedido);
            return Ok(result);
        }

        [HttpPost("cancelar-solicitud")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> cancelarSolicitud(CancelarSolicitudRequest cancelarSolicitud)
        {
            var result = IFastServiceQueryHandler.CancelarSolicitud(cancelarSolicitud);
            return Ok(result);
        }

        [HttpGet("search-product-idcliente")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> searchProductIdcliente(int id_cliente)
        {
            var result = IFastServiceQueryHandler.SearchPedidoIdcliente(id_cliente);
            return Ok(result);
        }

        [HttpGet("get-tipo-usuario")]
        [ProducesResponseType(typeof(TipoUsuarioViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> getTipoUsuario()
        {
            var result = IFastServiceQueryHandler.GetTipoUsuario();
            return Ok(result);
        }

        [HttpGet("get_by_id_usuario")]
        [ProducesResponseType(typeof(TipoUsuarioViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> get_by_id_usuario(int id_persona)
        {
            var result = IFastServiceQueryHandler.get_by_id_usuario(id_persona);
            return Ok(result);
        }

        [HttpGet("get-by-id-cliente-pedido")]
        [ProducesResponseType(typeof(TipoUsuarioViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> getByIdClientePedido(int id_persona)
        {
            var result = IFastServiceQueryHandler.getByIdPedido(id_persona);
            return Ok(result);
        }

        [HttpGet("search-product-idrepartidor")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> searchProductIdrepartidor(int id_repartidor)
        {
            var result = IFastServiceQueryHandler.SearchPedidoIdrepartidor(id_repartidor);
            return Ok(result);
        }

        [HttpGet("find-all-productos")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> FindAllProcutos(int estado)
        {
            var result = IFastServiceQueryHandler.FindAllProcutos(estado);
            return Ok(result);
        }

        [HttpPost("escoger-producto")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EscogerProcuto(PedidoRequests pedidoRequests)
        {
            IFastServiceQueryHandler.EscogerProcuto(pedidoRequests);
            return Ok(pedidoRequests);
        }

        [HttpPost("prueba")]
        [ProducesResponseType(typeof(userLoginViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> prueba(LoginRequest login)
        {
            var result = IFastServiceQueryHandler.Prueba(login);
            return Ok(result);
        }

    }
}
