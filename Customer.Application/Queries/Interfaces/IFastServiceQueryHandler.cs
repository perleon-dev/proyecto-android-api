﻿using Customer.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Application.Queries.Interfaces
{
    public interface IFastServiceQueryHandler
    {
        userLoginViewModel Login(LoginRequest login);
        ResponseViewModel RegisterUser(RegisterUserRequest register);
        userLoginViewModel Prueba(LoginRequest login);
    }
}
