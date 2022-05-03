using Customer.Application.Queries.Interfaces;
using Customer.Application.Queries.ViewModels;
using Customer.Domain.Aggregates.ConnectionBase;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Customer.Application.Queries.Implementations
{
    public class FastServiceQueryHandler : IFastServiceQueryHandler
    {
        public readonly IConnection IConnection_;

        public FastServiceQueryHandler(IConnection iConnection) 
        {
            IConnection_ = iConnection;
        }

        public userLoginViewModel Login(LoginRequest login)
        {
            var entityUser = new userLoginViewModel();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"sp_login";

                    var p = new DynamicParameters();
                    p.Add(name: "@correo", value: login.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@clave", value: login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

                    entityUser = db.Query<userLoginViewModel>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                entityUser = null;
            }

            return entityUser;
        }

        public ResponseViewModel RegisterUser(RegisterUserRequest register)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"sp_insert_update_usuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_persona", value: 0, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@documento_identidad", value: register.documento_identidad, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@nombre", value: register.nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@apellido", value: register.apellido, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@direccion", value: register.direccion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@correo", value: register.correo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@clave", value: register.clave, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@telefono", value: register.telefono, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@tipo_usuario", value: register.tipo_usuario, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    db.Query(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    response.codigo = 200;
                    response.descripcion = "registro exitoso";
                }
            }
            catch (Exception ex)
            {
                response.codigo = 500;
                response.descripcion = "registro fallido";
            }

            return response;
        }

        public List<PedidoHistoricoPorUsuarioViewModel> SearchPedidoIdcliente(int id_cliente)
        {
            List<PedidoHistoricoPorUsuarioViewModel> response = new List<PedidoHistoricoPorUsuarioViewModel>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"sp_search_pedido_idcliente";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_cliente", value: id_cliente, dbType: DbType.Int32, direction: ParameterDirection.Input);

                   response = db.Query<PedidoHistoricoPorUsuarioViewModel>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();
                    
                }
            }
            catch (Exception ex)
            {
                response = null;
            }

            return response;
        }

        public List<TipoUsuarioViewModel> GetTipoUsuario() 
        {
            List<TipoUsuarioViewModel> list = new List<TipoUsuarioViewModel>() 
            {
                new TipoUsuarioViewModel() { id_tipo = 1, descripcion = "Cliente" },
                new TipoUsuarioViewModel() { id_tipo = 2, descripcion = "Repartidor" }
            };

            return list; 
        }


        public userLoginViewModel Prueba(LoginRequest login)
        {
            var entityUser = new userLoginViewModel();

            entityUser.nombre = "Hola 1";
            entityUser.apellido = "Hola 2";
            entityUser.id_usuario = 1;

            return entityUser;
        }


        public SqlConnection GetSqlConnection(bool open = true)
        {
            var csb = new SqlConnectionStringBuilder(IConnection_.GetConnectionString()) { };

            var conn = new SqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }

        public nuevaSolicitudViewModel NuevaSolicitudPedido()
        {
            var entityUser = new nuevaSolicitudViewModel();

            try
            {
                using (var db = GetSqlConnection())
                 {
                     const string sql = @"sp_solicitudpedido";

                    

                     entityUser = db.Query<nuevaSolicitudViewModel>(sql: sql,null, commandType: CommandType.StoredProcedure).FirstOrDefault();
                 }

              


            }
            catch (Exception ex)
            {
                entityUser = null;
            }

            return entityUser;

        }
        public ResponseViewModel AceptarPedido(AceptarPedidoRequest aceptarPedido)
        {
            ResponseViewModel response = new ResponseViewModel();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"sp_aceptarpedido";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_solicitud", aceptarPedido.id_solicitud, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@id_repartidor", aceptarPedido.id_repartidor, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    //db.Query(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    response.descripcion = Convert.ToString(db.Execute(sql: sql, param: p, commandType: CommandType.StoredProcedure)) + " parametros " + aceptarPedido.id_solicitud + " - " + aceptarPedido.id_repartidor;

                    response.codigo = 200;
                    //response.descripcion = "Se aceptó el pedido";
                }

               


            }
            catch (Exception ex)
            {
                response.codigo = 500;
                response.descripcion = "registro fallido";
            }

            return response;

        }

        public UsuarioViewModel get_by_id_usuario(int idPersona)
        {
            var entityUser = new UsuarioViewModel();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"sp_get_by_id_usuario";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_persona", value: idPersona, dbType: DbType.String, direction: ParameterDirection.Input);

                    entityUser = db.Query<UsuarioViewModel>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                entityUser = null;
            }

            return entityUser;
        }

        public PedidoHistoricoPorUsuarioViewModel getByIdPedido(int id_cliente)
        {
            PedidoHistoricoPorUsuarioViewModel response = new PedidoHistoricoPorUsuarioViewModel();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"sp_search_pedido_idcliente";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_cliente", value: id_cliente, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    response = db.Query<PedidoHistoricoPorUsuarioViewModel>(sql: sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                response = null;
            }

            return response;
        }

        public List<PedidoHistoricoPorUsuarioViewModel> SearchPedidoIdrepartidor(int id_repartidor)
        {
            List<PedidoHistoricoPorUsuarioViewModel> response = new List<PedidoHistoricoPorUsuarioViewModel>();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"sp_search_pedido_idrepartidor";

                    var p = new DynamicParameters();
                    p.Add(name: "@id_repartidor", value: id_repartidor, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    response = db.Query<PedidoHistoricoPorUsuarioViewModel>(sql: sql, param: p, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            catch (Exception ex)
            {
                response = null;
            }

            return response;
        }


    }
}
