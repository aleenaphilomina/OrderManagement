# Order Management API

A backend REST API built with ASP.NET Core for managing customer orders. The project demonstrates a layered architecture, Entity Framework Core, SQL Server, dependency injection, asynchronous programming, centralized exception handling, and Swagger/OpenAPI documentation.

## Technologies

* C#
* ASP.NET Core Web API
* .NET 8
* Entity Framework Core
* SQL Server
* REST API
* Swagger / OpenAPI
* Dependency Injection
* LINQ
* Async/Await
* xUnit
* Git

## Architecture

The application follows a layered architecture with clear separation of responsibilities:

```text
OrderManagementAPI
│
├── Controllers
│   └── OrdersController.cs
│
├── Domain
│   ├── Entities
│   └── Enums
│
├── Application
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── Infrastructure
│   ├── Data
│   └── Repositories
│
├── Middleware
│   └── GlobalExceptionMiddleware.cs
│
└── Program.cs
```

### Responsibilities

**Controllers**

Handle HTTP requests and responses and expose REST API endpoints.

**Application**

Contains application services, interfaces, DTOs, and business-related application logic.

**Domain**

Contains core business entities and domain concepts.

**Infrastructure**

Handles database access and Entity Framework Core implementation.

**Middleware**

Handles cross-cutting concerns such as centralized exception handling.

## Features

* Create customer orders
* Retrieve orders
* Calculate order totals
* Entity Framework Core database access
* Repository and service abstractions
* Dependency Injection
* Asynchronous database operations
* CancellationToken support
* Centralized exception handling
* Structured logging
* Swagger/OpenAPI documentation
* Unit testing

## API Endpoints

| Method | Endpoint           | Description             |
| ------ | ------------------ | ----------------------- |
| POST   | `/api/Orders`      | Create a new order      |
| GET    | `/api/Orders/{id}` | Retrieve an order by ID |

## Example Request

### Create Order

```http
POST /api/Orders
Content-Type: application/json
```

```json
{
  "customerId": 101,
  "items": [
    {
      "productId": 1,
      "quantity": 2,
      "unitPrice": 500
    },
    {
      "productId": 2,
      "quantity": 1,
      "unitPrice": 200
    }
  ]
}
```

### Example Response

```json
{
  "id": 1,
  "customerId": 101,
  "status": "Pending",
  "totalAmount": 1200
}
```

## Running the Application

### Prerequisites

* Visual Studio 2022
* .NET 8 SDK
* SQL Server or SQL Server LocalDB

### Steps

Clone the repository:

```bash
git clone https://github.com/aleenaphilomina/OrderManagementAPI.git
```

Open the solution in Visual Studio.

Configure the SQL Server connection string in:

```text
appsettings.json
```

Build the solution:

```bash
dotnet build
```

Run the application:

```bash
dotnet run
```

## Swagger

After starting the application, Swagger UI is available at:

```text
https://localhost:<port>/swagger
```

Swagger can be used to explore and test the API endpoints.

## Development Practices

The project demonstrates several practices commonly used in enterprise .NET applications:

* Separation of concerns
* Dependency Injection
* Interface-based design
* Repository and service patterns
* Async database operations
* Structured logging
* Centralized exception handling
* DTO-based API contracts
* EF Core query optimization using `AsNoTracking()`
* API documentation with OpenAPI

## Future Improvements

Potential improvements include:

* JWT authentication and authorization
* FluentValidation
* Pagination and filtering
* API versioning
* Automated integration tests
* Docker support
* CI/CD pipeline
* Redis caching
* Health checks
* Performance monitoring
* Azure deployment
