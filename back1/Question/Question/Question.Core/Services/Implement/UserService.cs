using Microsoft.EntityFrameworkCore;
using Question.Core.Services.Interfaces;
using Question.DataLayer.Context;
using Question.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Core.Services.Implement
{
    public class UserService : IUserServices
    {
        #region Costructor Config
        private readonly DataLayerContext _context;
        public UserService(DataLayerContext context)
        {
            _context = context;
        }
        #endregion
        public async Task<List<User>> GetAllUser()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetUserById(short id)
        {
            return await _context.User.SingleOrDefaultAsync(x=> x.Id == id);
        }
    }
}
