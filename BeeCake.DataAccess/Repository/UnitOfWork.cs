using BeeCake.DataAccess.Repository.IRepository;
using BeeCake.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCake.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(_db);
        CakeType = new CakeTypeRepository(_db);
        MenuItem = new MenuItemRepository(_db);
    }

    public ICategoryRepository Category { get; private set; }
    public ICakeTypeRepository CakeType { get; private set; }
    public IMenuItemRepository MenuItem { get; private set; }

    public void Dispose()
    {
        _db.Dispose();
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
