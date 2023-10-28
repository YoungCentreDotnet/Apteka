using Apteka.Backend.Model;

namespace Apteka.Backend.Repository.Account
{
    public interface IAdminAccountService
    {
        Task<StateResponse<Admin>> SignUpAsync(Admin entity);
        Task<StateResponse<Admin>> LogInAsync(string login, string password);
        Task<StateResponse<bool>> LogOutAsync(string login, string password);
     
        Task<StateResponse<IEnumerable<Admin>>> GetAllDataAsync();
        Task<StateResponse<Admin>> GetByIdAsync(int id);
    }
}