using Microsoft.AspNetCore.Mvc;
using Transacao.Financeira.Web.Services;

namespace Transacao.Financeira.Web.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Upload()
        {


            return View();
        }
    }
}
