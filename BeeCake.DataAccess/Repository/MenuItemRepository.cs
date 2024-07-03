using BeeCake.DataAccess.Repository.IRepository;
using BeeCake.Models;
using BeeCake.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCake.DataAccess.Repository;

public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
{
    private readonly ApplicationDbContext _db;
    public MenuItemRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(MenuItem obj)
    {
        var objFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == obj.Id);
        objFromDb.Name = obj.Name;
        objFromDb.Description = obj.Description;
        objFromDb.Price = obj.Price;
        objFromDb.CategoryId = obj.CategoryId;
        objFromDb.CakeTypeId = obj.CakeTypeId;
        if (objFromDb.Image != null)
        {
            objFromDb.Image = obj.Image;
        }
    }
}
