using BeeCake.DataAccess.Repository.IRepository;
using BeeCake.Models;
using BeeCakeWeb.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeeCakeWeb.Pages.Admin.CakeTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<CakeType> CakeTypes { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            CakeTypes = _unitOfWork.CakeType.GetAll();
        }
    }
}