using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CLL.Identity;
using CLL.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Impl
{
    public class HistoryService : IHistoryService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;
​
        public HistoryService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }
​
        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<UserDTO> GetUsers(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Admin)
                && userType != typeof(Accountant))
            {
                throw new MethodAccessException();
            }

            var usersEntities =
                _database
                    .Users
                    .Find(z => z.UserType == 3, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<User, UserDTO>()
                    ).CreateMapper();
            var usersDto =
                mapper
                    .Map<IEnumerable<User>, List<UserDTO>>(
                        usersEntities);
            return usersDto;
        }
    }
}
}
