using System.Threading.Tasks;
using ASP.NET_vNext_2015_03.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;

namespace ASP.NET_vNext_2015_03.Controllers
{
    public class BareController
    {
        private readonly IBooksRepository _repo;

        public BareController(IBooksRepository repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return new ViewResult();
        }

        public async Task<IActionResult> Books()
        {
            return new ViewResult()
            {
               ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
               {
                   Model = await _repo.GetBooks()
               }
            };
        }
    }
}