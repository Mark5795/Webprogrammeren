using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Whatsup.Models;
using Whatsup.Repositories;

namespace Whatsup.Controllers
{
    public class ContactController : Controller
    {
        //private WhatsupContext db = new WhatsupContext();
        private IContactRepository contactRepository = new ContactRepository();

        // GET: Contact
        public ActionResult Index()
        {
            IEnumerable<Contact> AllContacts = contactRepository.GetAllContacts();
            return View(AllContacts);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactRepository.GetContact((int) id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [Authorize]
        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]

        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Mobilenumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.AddContact(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }
        [Authorize]

        [Authorize]
        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactRepository.GetContact((int)id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        [Authorize]

        [Authorize]
        // POST: Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Mobilenumber")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.EditContact(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        [Authorize]

        [Authorize]
        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactRepository.GetContact((int)id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }
        [Authorize]

        [Authorize]
        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = contactRepository.GetContact((int)id);
            return RedirectToAction("Index");
        }
        [Authorize]

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contactRepository.Dispose((bool)disposing);
            }
            base.Dispose(disposing);
        }
    }
}
