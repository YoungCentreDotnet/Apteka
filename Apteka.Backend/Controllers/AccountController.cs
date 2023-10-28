using Apteka.Backend.DataLayer;
using Apteka.Backend.Model;
using Apteka.Backend.Repository.Account;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Apteka.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
  
    public class AdminAccountService : IAdminAccountService
    {
        private readonly PharmacyDbContext _pharmacyDb;

        public AdminAccountService(PharmacyDbContext pharmacyDb)
        {
            _pharmacyDb = pharmacyDb;
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

        public async Task<StateResponse<Admin>> GetByIdAsync(Guid id)
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

        public Task<StateResponse<Admin>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StateResponse<Admin>> LogInAsync(string login, string password)
        {
            StateResponse<Admin> stateResponse = new StateResponse<Admin>();
            try
            {
                var evtityData = await _pharmacyDb.Admins.FirstOrDefaultAsync(p => p.Login == login);
                if (evtityData is null)
                {
                    stateResponse.Code = (int)StatusResponse.Not_Found;
                    stateResponse.Message = nameof(StatusResponse.Not_Found);
                    stateResponse.Data = evtityData;
                }
                if (evtityData is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = evtityData;
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


        public Task<StateResponse<bool>> LogOutAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task<StateResponse<Admin>> SignUpAsync(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}