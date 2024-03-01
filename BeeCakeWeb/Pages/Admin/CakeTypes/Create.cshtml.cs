using BeeCake.DataAccess.Repository.IRepository;
using BeeCake.Models;
using BeeCakeWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeeCakeWeb.Pages.Admin.CakeTypes;

[BindProperties]
public class CreateModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public CakeType CakeType { get; set; }
    public CreateModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CakeType.Add(CakeType);
            _unitOfWork.Save();
            TempData["success"] = "Cake Type created!";
            return RedirectToPage("Index");
        }
        return Page();

    }
}
