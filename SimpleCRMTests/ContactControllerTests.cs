using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleCRM.Controllers;
using SimpleCRM.Models;
using System.Collections.Generic;
using Xunit;

namespace SimpleCRM.Tests.Controllers
{
    public class ContactsControllerTests
    {
        private readonly Mock<IContactRepository> _mockContactRepository;
        private readonly Mock<IProductSalesRepository> _mockSalesRepository;
        private readonly ContactsController _controller;

        public ContactsControllerTests()
        {
            _mockContactRepository = new Mock<IContactRepository>();
            _mockSalesRepository = new Mock<IProductSalesRepository>();
            _controller = new ContactsController(_mockContactRepository.Object, _mockSalesRepository.Object);
        }

        [Fact]
        public void UpdateContact_Action_UpdatesContact()
        {
            // Arrange
            var customerName = "Lyon Souveniers";
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
            var result = _controller.UpdateContactToDatabase(updatedContact) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("ViewContact", result.ActionName);
            _mockContactRepository.Verify(repo => repo.UpdateContact(updatedContact), Times.Once);
        }

        [Fact]
        public void DeleteContact_Action_DeletesContact()
        {
            // Arrange
            var contactToDelete = new Contact { CustomerName = "Lyon Souveniers" };
            _mockContactRepository.Setup(repo => repo.DeleteContact(contactToDelete));

            // Act
            var result = _controller.DeleteContact(contactToDelete) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
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
            var result = _controller.InsertContactToDatabase(newContact) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName); 
            _mockContactRepository.Verify(repo => repo.InsertContact(newContact), Times.Once);
        }
    }
}
