using System.Web.Mvc;
using Entities.Domain.Abstract.Entities;

namespace Entities.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReporter _reporter;

        public ReportController(IReporter reporter)
        {
            _reporter = reporter;
        }

        // GET: Report
        public ActionResult Index()
        {
            var getIdsTask = _reporter.FetchRemainsSerialNumbersAsync();
            var ids = getIdsTask.Result;
            return View(ids);
        }
    }
}