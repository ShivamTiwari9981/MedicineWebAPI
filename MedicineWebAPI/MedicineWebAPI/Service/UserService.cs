﻿using MedicineWebAPI.Models;
using MedicineWebAPI.UnitOfWork;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MedicineWebAPI.Service
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Login(LoginModel model)
        {
            try
            {
                int err_no = 0;
                var param = new List<SqlParameter>();
                param.Add(new SqlParameter("@email", model.Email));
                param.Add(new SqlParameter("@password", model.Password));
                param.Add(new SqlParameter("@err_no", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, null, DataRowVersion.Current, err_no));                var result = Global.ExecuteStoredProcedure("sp_register_user", param, _unitOfWork.GetConnection());
                err_no = (int)param.Find(x => x.ParameterName == "@err_no")?.Value;
                return err_no;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseModel Register(UserModel model)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                string err_msg = "";
                int err_no = 0;
                var param = new List<SqlParameter>();
                param.Add(new SqlParameter("@firstName",model.FirstName));
                param.Add(new SqlParameter("@lastName", model.LastName));
                param.Add(new SqlParameter("@password", model.Password));
                param.Add(new SqlParameter("@email", model.Email));
                param.Add(new SqlParameter("@fund", 0));
                param.Add(new SqlParameter("@type", Global.UserType.User));
                param.Add(new SqlParameter("@status", Global.Status.Pending));
                param.Add(new SqlParameter("@err_no", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, null, DataRowVersion.Current, err_no));
                param.Add(new SqlParameter("@errMsg", SqlDbType.VarChar, 200, ParameterDirection.Output, true, 0, 0, null, DataRowVersion.Current, err_msg));
                var result = Global.ExecuteStoredProcedure("sp_register_user", param, _unitOfWork.GetConnection());
                err_no = (int)param.Find(x => x.ParameterName == "@err_no")?.Value;
                err_msg = param.Find(x => x.ParameterName == "@errMsg")?.Value.ToString() ?? "";
                if (err_no == 0)
                {
                    response.Status = true;
                    response.Message = err_msg;
                }
                else
                {
                    response.Status = false;
                    response.Message = err_msg;

                }
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public ResponseModel ViewUser(int userId)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                var param = new List<SqlParameter>();
                param.Add(new SqlParameter("@userId", userId));
                var result = Global.ExecuteStoredProcedure("sp_register_user", param, _unitOfWork.GetConnection());
                response.Status = true;
                response.data = result.Tables[0];
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseModel UpdateUser(UserModel model)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                string err_msg = "";
                int err_no = 0;
                var param = new List<SqlParameter>();
                param.Add(new SqlParameter("@firstName", model.FirstName));
                param.Add(new SqlParameter("@lastName", model.LastName));
                param.Add(new SqlParameter("@password", model.Password));
                param.Add(new SqlParameter("@email", model.Email));
                param.Add(new SqlParameter("@err_no", SqlDbType.Int, 4, ParameterDirection.Output, true, 0, 0, null, DataRowVersion.Current, err_no));
                param.Add(new SqlParameter("@errMsg", SqlDbType.VarChar, 200, ParameterDirection.Output, true, 0, 0, null, DataRowVersion.Current, err_msg));
                var result = Global.ExecuteStoredProcedure("sp_update_user", param, _unitOfWork.GetConnection());
                err_no = (int)param.Find(x => x.ParameterName == "@err_no")?.Value;
                err_msg = param.Find(x => x.ParameterName == "@errMsg")?.Value.ToString() ?? "";
                if (err_no == 0)
                {
                    response.Status = true;
                    response.Message = err_msg;
                }
                else
                {
                    response.Status = false;
                    response.Message = err_msg;

                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
