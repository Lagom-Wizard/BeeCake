using BeeCake.DataAccess.Repository.IRepository;
using BeeCake.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BeeCakeWeb.Pages.Customer.Home;

public class DetailsModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public DetailsModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public MenuItem MenuItem { get; set; }
    [Range(1, 100, ErrorMessage = "Please select between 1 and 100")]
    public int Count { get; set; }
    public void OnGet(int id)
    {
        MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,CakeType");
    }
}
