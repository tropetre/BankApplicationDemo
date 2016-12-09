using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTestBankWebApplicationWithoutUsers.Controllers
{
    using DataAccess;
    using Models;
    using Models.AccountStates;

    public class AccountsController : Controller
    {
        private BankContext db = new BankContext();

        // GET: Accounts
        public async Task<ActionResult> Index()
        {
            return View(await db.Accounts.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View(new Account());
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,State,Balance,Owner_Id")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,State,Balance,Owner_Id")] Account account)
        {
            //account.Owner = await db.People.FindAsync(account.Owner_Id);
            //ModelState.Clear();
            //ValidateModel(account);
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Account account = await db.Accounts.FindAsync(id);
            db.Accounts.Remove(account);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Accounts/Freeze/5
        public async Task<ActionResult> Freeze(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = await db.Accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Freeze/5
        [HttpPost, ActionName("Freeze")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FreezeConfirmed(int id)
        {
            Account account = await db.Accounts.FindAsync(id);
            account.Freeze();
            db.Entry(account).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Accounts/Transaction
        public ActionResult Transaction()
        {
            TransactionViewModel transaction = new TransactionViewModel();
            transaction.Accounts = db.Accounts.Include(p => p.Owner);

            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Transaction([Bind(Include = "From_Id,To_Id,Amount")] TransactionViewModel transaction)
        {
            if (ModelState.IsValid)
            {
                var payor = await db.Accounts.FindAsync(transaction.From_Id);
                if (payor == null)
                    new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                var payee = await db.Accounts.FindAsync(transaction.To_Id);
                if (payor == null)
                    new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                payor.TransferTo(payee, transaction.Amount);

                // Transactions are not persisted? Both models tracked by Entity Framework.
                // Setting EntityState as Modified does not help.

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }
    }
}
