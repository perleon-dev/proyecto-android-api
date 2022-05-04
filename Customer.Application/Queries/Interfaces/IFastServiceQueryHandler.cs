using Customer.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.Interfaces
{
    public interface IFastServiceQueryHandler
    {
        userLoginViewModel Login(LoginRequest login);
        ResponseViewModel RegisterUser(RegisterUserRequest register);
        List<PedidoHistoricoPorUsuarioViewModel> SearchPedidoIdcliente(int id_cliente);
        List<TipoUsuarioViewModel> GetTipoUsuario();
        userLoginViewModel Prueba(LoginRequest login);

        nuevaSolicitudViewModel NuevaSolicitudPedido();

        ResponseViewModel AceptarPedido(AceptarPedidoRequest aceptarPedido);
        UsuarioViewModel get_by_id_usuario(int idPersona);
        PedidoHistoricoPorUsuarioViewModel getByIdPedido(int id_cliente);
        List<PedidoHistoricoPorUsuarioViewModel> SearchPedidoIdrepartidor(int id_repartidor);
        ResponseViewModel CancelarSolicitud(CancelarSolicitudRequest cancelarSolicitud);


    }
}
