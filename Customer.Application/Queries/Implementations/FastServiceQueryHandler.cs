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
    }
}
