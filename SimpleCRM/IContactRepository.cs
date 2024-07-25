using System;
using System.Collections.Generic;
using SimpleCRM.Models;

namespace SimpleCRM
{
	public interface IContactRepository
	{
		IEnumerable<Contact> GetAllContacts();
		Contact GetContact(string customerName);
		void UpdateContact(Contact contact);
		void DeleteContact(Contact contact);
		void InsertContact(Contact contact);
	}
}
