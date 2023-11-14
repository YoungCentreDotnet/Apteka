using Apteka.Backend.DataLayer;
using Apteka.Backend.Model;
using LinqToDB;

namespace Apteka.Backend.Repository.User
{
    public class EmployeServise : IEmployeServise
    {
        private readonly PharmacyDbContext _pharmacyDb;

        public EmployeServise(PharmacyDbContext pharmacyDb)
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
       public async Task<StateResponse<bool>> DeletAsync(string name, bool employee)
        {
           StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var del = await _pharmacyDb.Admins.FirstOrDefaultAsync(p => p.LastName == name);
                if (del is not null)
                {
                    _pharmacyDb.Admins.Remove(del);
                    await _pharmacyDb.SaveChangesAsync();
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = true;

                }
                if (del is null)
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

        public async Task<StateResponse<bool>> UpdateAsync(int id, Employe employe)
        {
            StateResponse<bool> stateResponse = new StateResponse<bool>();
            try
            {
                var update = await _pharmacyDb.Employes.FirstOrDefaultAsync(p => p.Id == id);
                if (update is not null && employe is not null)
                {
                    update.FirstName = employe.FirstName;
                    update.Lastname = employe.Lastname;
                    await _pharmacyDb.SaveChangesAsync();
                    stateResponse.Code = (int)StatusResponse.Success;
                    stateResponse.Message = nameof(StatusResponse.Success);
                    stateResponse.Data = true;
                }
                if (employe is null)
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

        public async Task<StateResponse<Employe>> SignUpAsync(Employe employe)
        {
            StateResponse<Employe> stateResponse = new StateResponse<Employe>();
            var res = await _pharmacyDb.Employes.FirstOrDefaultAsync(p => p.Id == employe.Id);
            try
            {


                if (res is null && employe is not null)
                {
                    await _pharmacyDb.Employes.AddAsync(employe);
                    await _pharmacyDb.SaveChangesAsync();

                    stateResponse.Code = (int)StatusResponse.Created;
                    stateResponse.Message = nameof(StatusResponse.Created);
                    stateResponse.Data = employe;

                }
                if (res is not null)
                {
                    stateResponse.Code = (int)StatusResponse.Found;
                    stateResponse.Message = nameof(StatusResponse.Found);
                    stateResponse.Data = employe;

                }

            }
            catch
            {
                stateResponse.Code = (int)StatusResponse.Server_Eror;
                stateResponse.Message = nameof(StatusResponse.Server_Eror);
                stateResponse.Data = new Employe();

            }
            return stateResponse;
        }
    }
}
