﻿using Apteka.Backend.DataLayer;
using Apteka.Backend.Model;
using LinqToDB;

namespace Apteka.Backend.Repository.Account
{
    public class AdminAccountService: IAdminAccountService
    {
        private readonly PharmacyDbContext _pharmacyDb;

        public AdminAccountService(PharmacyDbContext pharmacyDb)
        {
            _pharmacyDb = pharmacyDb;
        }

        public async Task<StateResponse<bool>> DelateAsync(string login, string password)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var entityData = await _pharmacyDb.Admins.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);
                if (entityData is not null)
                {
                    _pharmacyDb.Admins.Remove(entityData);
                    await _pharmacyDb.SaveChangesAsync();
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = true;

                }
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = false;

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = false;

            }
            return stateResponse;
        }

     

        public async Task<StateResponse<Admin>> GetByIdAsync(int id)
        {
            StateResponse<Admin> stateResponse = new StateResponse<Admin>();
            try
            {
                var entityData = await _pharmacyDb.Admins.FirstOrDefaultAsync(p => p.Id == id);
                if (entityData is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entityData;

                }
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = new Admin();

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = new Admin();

            }
            return stateResponse;
        }

        

        public async Task<StateResponse<Admin>> LogInAsync(string login, string password)
        {
            StateResponse<Admin> stateResponse = new StateResponse<Admin>();
            try
            {
                var entityData = await _pharmacyDb.Admins.FirstOrDefaultAsync(p => p.Login == login && p.Password == password);
                if (entityData is not null)
                {

                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entityData;

                }
                if (entityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = new Admin();

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = new Admin();

            }
            return stateResponse;
        }



        public async Task<StateResponse<Admin>> SignUpAsync(Admin entity)
        {
            StateResponse<Admin> stateResponse = new StateResponse<Admin>();
            var res = await _pharmacyDb.Admins.FirstOrDefaultAsync(p => p.Id == entity.Id ||p.Login == entity.Login);
            try
            {


                if (res is null && entity is not null)
                {
                    await _pharmacyDb.Admins.AddAsync(entity);
                    await _pharmacyDb.SaveChangesAsync();

                    stateResponse.Code = (int)StatusResponse.Created;
                    stateResponse.Message = nameof(StatusResponse.Created);
                    stateResponse.Data = entity;

                }
                if (res is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Found;
                    stateResponse.Message = nameof(StatusResponse.Found);
                    stateResponse.Data = res;

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = new Admin();

            }
            return stateResponse;
        }

        public async Task<StateResponse<bool>> UpdateAsync(int id, Admin entity)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var update = await _pharmacyDb.Admins.FirstOrDefaultAsync(p => p.Id == id);
                if (update is not null && entity is not null)
                {
                    update.FirstName = entity.FirstName;
                    update.LastName = entity.LastName;
                    update.Login = entity.Login;
                    update.Password = entity.Password;
                    await _pharmacyDb.SaveChangesAsync();
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = true;

                }
                if (entity is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = false;
                }
            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = false;
            }
            return stateResponse;
        }

        public async Task<StateResponse<IEnumerable<Admin>>> GetAllDataAsync()
        {
            Admin admin = new Admin();
            List<Admin> admins = new List<Admin>();
            StateResponse<IEnumerable<Admin>> stateResponse = new StateResponse<IEnumerable<Admin>>();
            try
            {
                var entityData = await _pharmacyDb.Admins.ToListAsync();
                if (stateResponse is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = entityData;

                }
                if (stateResponse is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = entityData;

                }
            }
            catch
            {

                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = null;
            }
            return stateResponse;
        }
    }
}
