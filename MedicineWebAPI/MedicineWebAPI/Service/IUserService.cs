﻿using MedicineWebAPI.Models;

namespace MedicineWebAPI.Service
{
    public interface IUserService
    {
        int Login(LoginModel model);
        ResponseModel Register(UserModel model);
        ResponseModel ViewUser(int userId);
    }
}
