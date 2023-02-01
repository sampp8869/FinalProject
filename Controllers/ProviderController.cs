using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ProviderController : Controller
    {
        public IActionResult List()
        {
            IEnumerable<TProvider> datas = null;
            FinalProjectContext db = new FinalProjectContext();
            datas = from t in db.TProviders
                    select t;
            return View(datas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TProvider p)
        {
            FinalProjectContext db = new FinalProjectContext();
            db.TProviders.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                FinalProjectContext db = new FinalProjectContext();
                TProvider delProvider = db.TProviders.FirstOrDefault(t => t.FId == id);
                if (delProvider != null)
                {
                    db.TProviders.Remove(delProvider);
                    db.SaveChangesAsync();
                }
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Edit(TProvider p)
        {
            FinalProjectContext db = new FinalProjectContext();
            TProvider x = db.TProviders.FirstOrDefault(t => t.FId == p.FId);
            if (x != null)
            {
                x.FCompanyName = p.FCompanyName;
                x.FPassword = p.FPassword;
                x.FTaxId = p.FTaxId;
                x.FFax = p.FFax;
                x.FOwnerName = p.FOwnerName;
                x.FOwnerTel = p.FOwnerTel;
                x.FOwnerMobile = p.FOwnerMobile;
                x.FOwnerEmail = p.FOwnerEmail;
                x.FOwnerName = p.FOwnerName;
                x.FContactTel = p.FContactTel;
                x.FContactMobile = p.FContactMobile;
                x.FContactEmail = p.FContactEmail;
                x.FAddress = p.FAddress;
                x.FBankName = p.FBankName;
                x.FBankDivisionName = p.FBankDivisionName;
                x.FBankAccountNumber = p.FBankAccountNumber;
                x.FBankAccountName = p.FBankAccountName;
                x.FBlackList = p.FBlackList;
                x.FRemark = p.FRemark;
                x.FCreationDate = p.FCreationDate;
                x.FLastUpdateDate = p.FLastUpdateDate;
                db.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                FinalProjectContext db = new FinalProjectContext();
                TProvider x = db.TProviders.FirstOrDefault(t => t.FId == id);
                if (x != null)
                    return View(x);
            }
            return RedirectToAction("List");
        }
    }
}
