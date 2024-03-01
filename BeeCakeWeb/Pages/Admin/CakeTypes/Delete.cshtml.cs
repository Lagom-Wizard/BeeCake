using BeeCake.DataAccess.Repository.IRepository;
using BeeCake.Models;
using BeeCakeWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeeCakeWeb.Pages.Admin.CakeTypes;

[BindProperties]
public class DeleteModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public CakeType CakeType { get; set; }
    public DeleteModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void OnGet(int id)
    {
        CakeType = _unitOfWork.CakeType.GetFirstOrDefault(u => u.Id == id);
    }

    public async Task<IActionResult> OnPost()
    {
        var cakeTypeFromDb = _unitOfWork.CakeType.GetFirstOrDefault(u => u.Id == CakeType.Id);
        if (cakeTypeFromDb != null)
        {
            _unitOfWork.CakeType.Remove(cakeTypeFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Cake type deleted!";
            return RedirectToPage("Index");
        }

        return Page();

    }
}
