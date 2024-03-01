using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCake.DataAccess.Repository.IRepository;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Category { get; }
    ICakeTypeRepository CakeType { get; }
    IMenuItemRepository MenuItem { get; }
    void Save();
}
