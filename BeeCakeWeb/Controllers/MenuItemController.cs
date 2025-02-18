﻿using BeeCake.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BeeCakeWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuItemController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;
    public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var menuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,CakeType");
        return Json(new { data = menuItemList });
    }
    //delete from menuItem
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);

        var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        _unitOfWork.MenuItem.Remove(objFromDb);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Deleted successfully!" });
    }
}
