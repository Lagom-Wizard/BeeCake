using BeeCake.DataAccess.Repository.IRepository;
using BeeCake.Models;
using BeeCakeWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeeCakeWeb.Pages.Admin.CakeTypes;

[BindProperties]
public class EditModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public CakeType CakeType { get; set; }
    public EditModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void OnGet(int id)
    {
        CakeType = _unitOfWork.CakeType.GetFirstOrDefault(u => u.Id == id);
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CakeType.Update(CakeType);
            _unitOfWork.Save();
            TempData["success"] = "Cake Type edited!";
            return RedirectToPage("Index");
        }
        return Page();

    }
}

