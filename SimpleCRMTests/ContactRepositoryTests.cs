using Moq;
using SimpleCRM.Models;
using System.Collections.Generic;
using Xunit;

namespace SimpleCRM.Tests.Repositories
{
    public class ContactRepositoryTests
    {
        private readonly Mock<IContactRepository> _mockContactRepository;

        public ContactRepositoryTests()
        {
            _mockContactRepository = new Mock<IContactRepository>();
        }

        [Fact]
        public void GetAllContacts_ReturnsAllContacts()
        {
            // Arrange
            var expectedContacts = new List<Contact>
            {
                new Contact { CustomerName = "Customer 1" },
                new Contact { CustomerName = "Customer 2" },
                new Contact { CustomerName = "Customer 3" }
            };
            _mockContactRepository.Setup(repo => repo.GetAllContacts()).Returns(expectedContacts);

            // Act
            var result = _mockContactRepository.Object.GetAllContacts();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedContacts.Count, result.Count<Contact>());
        }

        [Fact]
        public void GetContact_ReturnsContactByName()
        {
            // Arrange
            var customerName = "Customer 1";
            var expectedContact = new Contact { CustomerName = customerName };
            _mockContactRepository.Setup(repo => repo.GetContact(customerName)).Returns(expectedContact);

            // Act
            var result = _mockContactRepository.Object.GetContact(customerName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedContact.CustomerName, result.CustomerName);
        }

        [Fact]
        public void UpdateContact_Action_UpdatesContact()
        {
            // Arrange
            var customerName = "Customer 1";
            var updatedContact = new Contact
            {
                CustomerName = customerName,
                ContactFirstName = "Updated First",
                ContactLastName = "Updated Last",
                Territory = "Updated Territory",
                Country = "Updated Country",
                PostalCode = "54321",
                State = "Updated State",
                City = "Updated City",
                AddressLine1 = "Updated Address 1",
                AddressLine2 = "Updated Address 2"
            };
            _mockContactRepository.Setup(repo => repo.UpdateContact(updatedContact));

            // Act
            _mockContactRepository.Object.UpdateContact(updatedContact);

            // Assert
            _mockContactRepository.Verify(repo => repo.UpdateContact(updatedContact), Times.Once);
        }

        [Fact]
        public void DeleteContact_Action_DeletesContact()
        {
            // Arrange
            var contactToDelete = new Contact { CustomerName = "Customer 1" };
            _mockContactRepository.Setup(repo => repo.DeleteContact(contactToDelete));

            // Act
            _mockContactRepository.Object.DeleteContact(contactToDelete);

            // Assert
            _mockContactRepository.Verify(repo => repo.DeleteContact(contactToDelete), Times.Once);
        }

        [Fact]
        public void InsertContactToDatabase_Action_InsertsContact()
        {
            // Arrange
            var newContact = new Contact
            {
                CustomerName = "New Customer",
                ContactFirstName = "New First",
                ContactLastName = "New Last",
                Territory = "New Territory",
                Country = "New Country",
                PostalCode = "67890",
                State = "New State",
                City = "New City",
                AddressLine1 = "New Address 1",
                AddressLine2 = "New Address 2"
            };

            // Act
            _mockContactRepository.Object.InsertContact(newContact);

            // Assert
            _mockContactRepository.Verify(repo => repo.InsertContact(newContact), Times.Once);
        }
    }
}
