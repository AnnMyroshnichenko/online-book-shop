# Online Book Shop
The Online Book Shop API is a robust, scalable RESTful web application built with ASP.NET Core. It is designed to manage a bookstore’s inventory and operations. 
It provides functionality for creating, updating, retrieving, and deleting books, with support for categorizing books into multiple genres. The project adheres to 
Clean Architecture principles and implements the Command Query Responsibility Segregation (CQRS) pattern using MediatR.

## Technologies & Tools
- ASP.NET Core Web API
- SQL Server
- Entity Framework Core
- MediatR for CQRS pattern 
- AutoMapper for mapping between DTOs/Entities

## Architecture Overview

### Clean Architecture

The Online Book Shop API follows Clean Architecture principles. This approach organizes the codebase into concentric layers, ensuring that business logic is independent of frameworks, 
databases, and UI. The layers are:

- Domain Layer:

Contains the core business entities (e.g., Book, Category) and interfaces for repositories (e.g., IBookRepository, ICategoryRepository).

Defines the business rules and logic, independent of any external systems.


- Application Layer:

Implements business use cases through commands (e.g., CreateBookCommand, UpdateBookCommand) and queries (e.g., GetBookByIdQuery).

Uses MediatR to handle commands and queries, enforcing CQRS.

Contains DTOs (e.g., CategoryDto) for data transfer between the API and application layers.

Uses AutoMapper to map between DTOs, commands, and domain entities.


- Infrastructure Layer:

Implements repository interfaces and database access using Entity Framework Core.


- API Layer:

Exposes the application’s functionality through RESTful endpoints using ASP.NET Core controllers.

Receives HTTP requests, maps them to commands/queries, and returns responses.


### CQRS Pattern

The project implements Command Query Responsibility Segregation (CQRS) using MediatR, separating read and write operations to optimize performance and maintainability.

- Commands:
Represent actions that modify state (e.g., CreateBookCommand, UpdateBookCommand).
Handled by command handlers (e.g., CreateBookCommandHandler, UpdateBookCommandHandler).

- Queries:

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
dotnet ef database update --project Infrastructure
```

Run the API


## API Endpoints

GET /api/books – Retrieve all books

GET /api/books/{id} – Get details of a specific book

POST /api/books – Add a new book

DELETE /api/books/{id} – Delete a book

PATCH /api/books/{id} - Update book info


## Contributing
Contributions are welcome! Please:

- Fork the repository.

- Create a feature branch (git checkout -b feature/my-feature).

- Commit your changes (git commit -am 'Add my feature').

- Push (git push origin feature/my-feature) and open a Pull Request.


## License
This project is licensed under MIT. See LICENSE for details.
