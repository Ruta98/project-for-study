using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    interface IHistoryService
    {
        public interface IStreetService
        {
            IEnumerable<UserDTO> GetUsers(int page);
        }
    }
}
