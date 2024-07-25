Simple CRM (Customer Relationship Management) System

Overview
This Simple CRM (Customer Relationship Management) system is designed to help manage customer interactions, streamline order processing, and maintain customer information effectively. It provides functionalities such as viewing pending orders and statistics, updating customer contacts, adding new customers and creating new orders.

Features
1. Dashboard
* Pending Orders: Display a list of pending orders that need attention.
* Order Statistics: Show summary statistics of pending orders.
  
2. Customer Management
* Update Contact Information: Modify customer details like name, address, and contact information.
* Add New Customers: Register new customers with their contact information.
  
3. Order Management
* Add New Orders: Enter new orders with product details, quantities, prices, and customer references.
* Update Order Status: Change the status of existing orders (e.g., from pending to completed).
  
Technologies Used
* Backend: C#, ASP.NET Core
* Database: SQL Server
* ORM: Dapper (for database interaction)
* Testing Framework: xUnit (for unit testing)
  
Setup Instructions
1. Clone the Repository:
    * bashCopy code
    * git clone https://github.com/your/repository.git	
2. cd SimpleCRM
3. Database Configuration:
    * Ensure SQL Server is installed.
    * Update connection string in appsettings.json or appsettings.Development.json.
4. Run the Application:
    * Open the solution in Visual Studio.
    * Build and run the project (F5 or Ctrl+F5).
5. Testing:
    * Unit tests are located in the SimpleCRM.Tests project.
    * Use xUnit to run tests and ensure all functionalities work as expected.
6. Usage:
    * Navigate to the application URL (default: https://localhost:5001).
    * Explore different features through the intuitive user interface.

Additional Notes
* Data Security: Ensure appropriate security measures are implemented, such as authentication and authorization, especially for production deployments.
* Scalability: Consider scalability requirements and optimize database queries and application logic accordingly.
* Feedback: We welcome your feedback and contributions to enhance this CRM system further.
  
Author
* Noah Urban- Initial development






