using BeeCake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCake.DataAccess.Repository.IRepository;
public interface ICakeTypeRepository : IRepository<CakeType>
{
    void Update(CakeType obj);
}
