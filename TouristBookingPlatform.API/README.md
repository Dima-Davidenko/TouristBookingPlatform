# Tourist Booking Platform API

Welcome to the **Tourist Booking Platform API**!  
This project is a simple RESTful Web API built with **ASP.NET Core** and **Entity Framework Core**.  
It simulates a basic event booking system — allowing users to view, create, update, and delete tourist events.

---

## 🚀 Project Goals
- Build a clean and professional Web API using .NET technologies.
- Practice working with real database (SQL Server) through Entity Framework Core.
- Implement full CRUD operations.
- Learn API best practices (routing, HTTP methods, controllers, async/await).

---

## 🛠 Technologies Used
- **ASP.NET Core Web API (.NET 8)**
- **C#**
- **Entity Framework Core (EF Core)**
- **MS SQL Server (LocalDB)**
- **Swagger/OpenAPI** (for API testing)
- **Git** (version control)

---

## 📋 Features
- List all tourist events (GET `/api/events`)
- View details of a specific event (GET `/api/events/{id}`)
- Create a new event (POST `/api/events`)
- Update an existing event (PUT `/api/events/{id}`)
- Delete an event (DELETE `/api/events/{id}`)
- API documentation with Swagger UI.

---

## 🧩 How to Run Locally

### Prerequisites
- Visual Studio 2022 (Community Edition or higher)
- .NET 8 SDK
- SQL Server Express / LocalDB
- Git (optional)

### Steps
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/TouristBookingPlatform.git
    cd TouristBookingPlatform
    ```

2. Open the solution (`TouristBookingPlatform.sln`) in Visual Studio.

3. Set `TouristBookingPlatform.API` as the Startup Project.

4. Check the `appsettings.json` for database connection string:
    ```json
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TouristBookingDb;Trusted_Connection=True;"
    ```

5. Run Entity Framework migrations (if database does not exist):
    - Open **Package Manager Console**:
      ```bash
      Update-Database
      ```

6. Run the project:
    - Press **F5** or click **Run** button.
    - API will be available at `https://localhost:5001/swagger` (Swagger UI).

---


---

## ✨ Future Improvements (Optional)
- Add authentication and user management (ASP.NET Identity / JWT).
- Build a front-end client (ASP.NET MVC or Angular).
- Add data validation and error handling.
- Improve database seeding for testing.

---

## 📜 License
This project is licensed under the MIT License.  
Feel free to use and adapt it for learning or portfolio purposes.

---

## 📫 Contact
**Author:** Dima Davidenko  
**Email:** dimitrdavidenko@gmail.com 
**GitHub:** [Dima Davidenko](https://github.com/Dima-Davidenko)

---
