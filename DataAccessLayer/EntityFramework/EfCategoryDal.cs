using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayerrr.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal:GenericRepository<Category>,ICategoryDal
    {
         
    }
}
