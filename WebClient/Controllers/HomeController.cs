using System.Web.Mvc;
using ThinkCraft.Application.Account;

namespace ThinkCraft.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountInteractor _accountInteractor;

        public HomeController(IAccountInteractor accountInteractor)
        {
            _accountInteractor = accountInteractor;
        }

        public ActionResult Index()
        {
            var message = _accountInteractor.Message();
            return View();
        }
    }
}