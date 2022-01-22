using ShopApp.DataAccess.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EntityFramework
{
    public class EFOrderRepository : EFGenericRepository<Order, ShopContext>, IOrderRepository
    {
    }
}
