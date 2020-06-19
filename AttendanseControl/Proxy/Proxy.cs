using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Proxy
{
    public class Proxy : IOrderRepository
    {

        public OrderRepository repos;
        public void Request()
        {
            if (repos == null)
            {
                repos = new OrderRepository();
            }
        }

        void IRepository<Order>.Create(Order item)
        {
            throw new NotImplementedException();
        }

        void IRepository<Order>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> IRepository<Order>.Find(Func<Order, bool> predicate, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        Order IRepository<Order>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> IRepository<Order>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IOrderRepository.Request()
        {
            throw new NotImplementedException();
        }

        void IRepository<Order>.Update(Order item)
        {
            throw new NotImplementedException();
        }
    }

}