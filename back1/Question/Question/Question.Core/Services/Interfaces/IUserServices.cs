using Question.DataLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Question.Core.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(short id);
    }
}
