using BeeCake.DataAccess.Repository.IRepository;
using BeeCake.Models;
using BeeCakeWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCake.DataAccess.Repository;

public class CakeTypeRepository : Repository<CakeType>, ICakeTypeRepository
{
    private readonly ApplicationDbContext _db;
    public CakeTypeRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(CakeType obj)
    {
        var objFromDb = _db.CakeType.FirstOrDefault(u => u.Id == obj.Id);
        objFromDb.Name = obj.Name;
    }
}
