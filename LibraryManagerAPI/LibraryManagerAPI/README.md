# 📚 Library Manager API

A RESTful API for managing a library's collection of books. Built with ASP.NET Core and Entity Framework Core.

## 🛠️ Features

- **CRUD Operations**: Create, read, update, and delete books.
- **Filter Books**: Retrieve books by genre and author.
- **Add Multiple Books**: Bulk add books.

## 🚀 Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/your-username/LibraryManagerAPI.git
    cd LibraryManagerAPI
    ```

2. Restore dependencies:
    ```sh
    dotnet restore
    ```

3. Update the connection string in `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "LibraryConnection": "server=(localdb)\\MSSQLLocalDB;database=LibraryDB"
      }
    }
    ```

4. Apply migrations:
    ```sh
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

5. Run the application:
    ```sh
    dotnet run
    ```

## 📄 API Endpoints

### Book Operations

- **Get all books**: `GET /api/library`
- **Get book by ID**: `GET /api/library/{id}`
- **Get books by genre**: `GET /api/library/genre/{genre}`
- **Get books by author**: `GET /api/library/author/{author}`
- **Add a book**: `POST /api/library`
- **Add multiple books**: `POST /api/library/multiple`
- **Update a book**: `PUT /api/library/{id}`
- **Delete a book**: `DELETE /api/library/{id}`
- **Delete all books**: `DELETE /api/library`

## 🏗️ Project Structure

```plaintext
LibraryManagerAPI
│
├── Controllers
│   └── LibraryController.cs
│
├── Data
│   └── LibraryContext.cs
│
├── Models
│   └── Book.cs
│
├── Repository
│   ├── Services
│   │   ├── ILibraryRepository.cs
│   │   └── LibraryRepository.cs
│
├── Program.cs
├── appsettings.json
└── Startup.cs
