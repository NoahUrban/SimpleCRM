using System;
using System.Data;
using System.Diagnostics.Metrics;
using Dapper;
using SimpleCRM.Models;

namespace SimpleCRM
{
	public class ContactRepository : IContactRepository
	{
		private readonly IDbConnection _conn;


		public ContactRepository(IDbConnection conn)
		{
			_conn = conn;
		}

        public void DeleteContact(Contact contact)
        {
            _conn.Execute("DELETE FROM contacts WHERE customername = @customerName;", new { customerName = contact.CustomerName });
            _conn.Execute("DELETE FROM sales WHERE customername = @customerName;", new { customerName = contact.CustomerName });
        }

        public IEnumerable<Contact> GetAllContacts()
		{
            return _conn.Query<Contact>("SELECT * FROM contacts;");
        }

        public Contact GetContact(string customerName)
        {
            return _conn.QueryFirstOrDefault<Contact>("SELECT * FROM CONTACTS WHERE CUSTOMERNAME = @customerName", new { customerName = customerName });
        }

        public void UpdateContact(Contact updatedContact)
        {
            _conn.Execute(@"UPDATE contacts 
                    SET ContactFirstName = @ContactFirstName, 
                        ContactLastName = @ContactLastName, 
                        Territory = @Territory, 
                        Country = @Country, 
                        PostalCode = @PostalCode, 
                        State = @State, 
                        City = @City, 
                        AddressLine1 = @AddressLine1, 
                        AddressLine2 = @AddressLine2, 
                        PhoneNumber = @PhoneNumber, 
                        Email = @Email 
                    WHERE CustomerName = @CustomerName",
                            new
                            {
                                updatedContact.ContactFirstName,
                                updatedContact.ContactLastName,
                                updatedContact.Territory,
                                updatedContact.Country,
                                updatedContact.PostalCode,
                                updatedContact.State,
                                updatedContact.City,
                                updatedContact.AddressLine1,
                                updatedContact.AddressLine2,
                                updatedContact.PhoneNumber,
                                updatedContact.Email,
                                updatedContact.CustomerName
                            });
        }


        public void InsertContact(Contact newContact)
        {
            _conn.Execute(@"INSERT INTO contacts 
                    (CUSTOMERNAME, CONTACTFIRSTNAME, CONTACTLASTNAME, TERRITORY, COUNTRY, POSTALCODE, STATE, CITY, ADDRESSLINE1, ADDRESSLINE2, PHONENUMBER, EMAIL) 
                    VALUES 
                    (@CustomerName, @ContactFirstName, @ContactLastName, @Territory, @Country, @PostalCode, @State, @City, @AddressLine1, @AddressLine2, @PhoneNumber, @Email);",
                            new
                            {
                                newContact.CustomerName,
                                newContact.ContactFirstName,
                                newContact.ContactLastName,
                                newContact.Territory,
                                newContact.Country,
                                newContact.PostalCode,
                                newContact.State,
                                newContact.City,
                                newContact.AddressLine1,
                                newContact.AddressLine2,
                                newContact.PhoneNumber,
                                newContact.Email
                            });
        }

    }
}

