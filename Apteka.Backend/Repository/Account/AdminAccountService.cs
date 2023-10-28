using Apteka.Backend.DataLayer;
using Apteka.Backend.Model;
using LinqToDB;

namespace Apteka.Backend.Repository.Account
{

    public class AdminAccountService : IAdminAccountService
    {
        private readonly PharmacyDbContext _studyDb;

        public AdminAccountService(PharmacyDbContext studyDb)
        {
            _studyDb = studyDb;
        }

        public Task<StateResponse<IEnumerable<Admin>>> GetAllDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StateResponse<Admin>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StateResponse<Admin>> LogInAsync(string login, string password)
        {
            throw new NotImplementedException();
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