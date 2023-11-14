using Apteka.Backend.Model;

namespace Apteka.Backend.Repository.User
{
    public interface IEmployeServise
    {
 
        Task<StateResponse<bool>> DeletAsync(string name, bool employee);
        Task<StateResponse<bool>> UpdateAsync(int id,Employe employe);
        Task<StateResponse<IEnumerable<Admin>>> GetAllDataAsync();
        Task<StateResponse<Employe>> SignUpAsync(Employe employe );
        
    }
}
