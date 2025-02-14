using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete; // referans ekledik ki kullanabilelim Product ü

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
