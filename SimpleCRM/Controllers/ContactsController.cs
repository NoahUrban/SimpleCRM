using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Models;

namespace SimpleCRM.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _repo;
        private readonly IProductSalesRepository _salesRepo;

        public ContactsController(IContactRepository repo, IProductSalesRepository salesRepo)
        {
            _repo = repo;
            _salesRepo = salesRepo;
        }

        public IActionResult Index(string searchForm)
        {
            var contacts = _repo.GetAllContacts();

            if (!string.IsNullOrEmpty(searchForm))
            {
                contacts = contacts.Where(x => x.CustomerName.Contains(searchForm)).ToList();
            }

            return View(contacts.OrderBy(x => x.CustomerName));
        }

        public IActionResult ViewContact(string customerName)
        {
            var contact = _repo.GetContact(customerName);
            return View(contact);
        }

        public IActionResult UpdateContact(string customerName)
        {
            var contact = _repo.GetContact(customerName);
            return View(contact);
        }

        public IActionResult UpdateContactToDatabase(Contact contact)
        {
            _repo.UpdateContact(contact);

            return RedirectToAction("ViewContact", new {  customerName = contact.CustomerName });
        }

        public IActionResult DeleteContact(Contact contact)
        {
            _repo.DeleteContact(contact);

            return RedirectToAction("Index");
        }

        public IActionResult InsertContact()
        {
            return View();
        }

        public IActionResult InsertContactToDatabase(Contact contact)
        {
            _repo.InsertContact(contact);
            return RedirectToAction("Index");
        }
    }
}

