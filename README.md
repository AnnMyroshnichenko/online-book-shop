# Online Book Shop
The Online Book Shop API is a robust, scalable RESTful API built with ASP.NET Core. It is designed to manage a bookstore’s inventory and operations. 
It provides functionality for creating, updating, retrieving, and deleting books, with support for categorizing books into multiple genres. The project adheres to 
Clean Architecture principles and implements the Command Query Responsibility Segregation (CQRS) pattern using MediatR. The application implements role-based authorization 
using ASP.NET Core Identity with roles like Admin and User to control access. It also includes comprehensive unit tests to ensure the correctness and reliability of the core application logic. 
Tests are written using xUnit and Moq for mocking dependencies. 

## Technologies & Tools
- ASP.NET Core Web API
- SQL Server
- Entity Framework Core
- MediatR for CQRS pattern 
- AutoMapper for mapping between DTOs/Entities
- Serilog for logging
- xUnit and Moq for unit testing

## Architecture Overview

### Clean Architecture

The Online Book Shop API follows Clean Architecture principles. This approach organizes the codebase into concentric layers, ensuring that business logic is independent of frameworks, 
databases, and UI. The layers are:

- #### Domain Layer:

Contains the core business entities (e.g., Book, Category) and interfaces for repositories (e.g., IBookRepository, ICategoryRepository).

Defines the business rules and logic, independent of any external systems.


- #### Application Layer:

Implements business use cases through commands (e.g., CreateBookCommand, UpdateBookCommand) and queries (e.g., GetBookByIdQuery).

Uses MediatR to handle commands and queries, enforcing CQRS.

Contains DTOs (e.g., CategoryDto) for data transfer between the API and application layers.

Uses AutoMapper to map between DTOs, commands, and domain entities.


- #### Infrastructure Layer:

Implements repository interfaces and database access using Entity Framework Core.


- #### API Layer:

Exposes the application’s functionality through RESTful endpoints using ASP.NET Core controllers.

Receives HTTP requests, maps them to commands/queries, and returns responses.


### CQRS Pattern

The project implements Command Query Responsibility Segregation (CQRS) using MediatR, separating read and write operations to optimize performance and maintainability.

- #### Commands:
Represent actions that modify state (e.g., CreateBookCommand, UpdateBookCommand).
Handled by command handlers (e.g., CreateBookCommandHandler, UpdateBookCommandHandler).

- #### Queries:
Represent read operations that retrieve data without modifying state (e.g., GetBookByIdQuery, GetAllBooksQuery).
Handled by query handlers that return DTOs.


## Getting Started
Clone the repository

```
git clone https://github.com/AnnMyroshnichenko/online-book-shop.git
```

Configure your database and dependencies in appsettings.json.

Build and restore dependencies

```
dotnet restore
dotnet build
```
Apply EF migrations and seed initial data:

```
dotnet ef database update --project BookStore.Infrastructure
```

Run the API


## API Endpoints

#### Books
GET /api/books

POST /api/books

GET /api/books/{id}

DELETE /api/books/{id}

PATCH /api/books/{id}


#### Identity
POST /api/identity/register

POST /api/identity/login

POST /api/identity/refresh

GET /api/identity/confirmEmail

POST /api/identity/resendConfirmationEmail

POST /api/identity/forgotPassword

POST /api/identity/resetPassword

POST /api/identity/manage/2fa

GET /api/identity/manage/info

POST /api/identity/manage/info

PATCH /api/identity/user


## Contributing
Contributions are welcome! Please:

- Fork the repository.

- Create a feature branch (git checkout -b feature/my-feature).

- Commit your changes (git commit -am 'Add my feature').

- Push (git push origin feature/my-feature) and open a Pull Request.


## License
This project is licensed under MIT. See LICENSE for details.
