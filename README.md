
# Tourist Booking Platform

This is a **full-stack .NET solution** that allows users to view and manage tourist events.  
The solution consists of:

- ✅ **Backend**: RESTful API with ASP.NET Core + EF Core
- ✅ **Frontend**: ASP.NET Core MVC application
- ✅ **Database**: SQL Server (EF Core code-first)

---

## 📦 Solution Structure

```
TouristBookingPlatform/
├── TouristBookingPlatform.sln           # Solution file
├── TouristBookingPlatform.API/          # Backend Web API
├── TouristBookingPlatform.Web/          # Frontend MVC App
├── .github/workflows/                   # GitHub Actions (CI/CD)
└── README.md                            # This file
```

---

## 🔧 Technologies Used

| Layer     | Tech Stack                                      |
|-----------|--------------------------------------------------|
| Backend   | ASP.NET Core Web API (.NET 8), C#               |
| Frontend  | ASP.NET Core MVC (.NET 8), Razor Views          |
| Database  | SQL Server Express (LocalDB), EF Core ORM       |
| DevOps    | GitHub Actions, Azure App Services              |

---

## 🎯 Features

### ✅ Backend API (`TouristBookingPlatform.API`)
- RESTful API for managing tourist events
- Built with ASP.NET Core + Entity Framework Core
- Swagger UI for testing endpoints
- Full CRUD operations:
  - `GET /api/events`
  - `POST /api/events`
  - `PUT /api/events/{id}`
  - `DELETE /api/events/{id}`

### ✅ Frontend Web App (`TouristBookingPlatform.Web`)
- MVC pattern with Razor Pages
- Bootstrap-styled UI
- Event list and creation form
- Calls backend API via HttpClient

### ✅ Database
- Code-first EF Core migrations
- SQL Server Express (LocalDB for development)
- `AppDbContext` with `Events` table
- Connection string defined in `appsettings.json`

---

## 🚀 How to Run Locally

### Prerequisites
- Visual Studio 2022+
- .NET 8 SDK
- SQL Server Express / LocalDB
- Git

### 1. Clone the repository
```bash
git clone https://github.com/yourusername/TouristBookingPlatform.git
cd TouristBookingPlatform
```

### 2. Open the solution
- Open `TouristBookingPlatform.sln` in Visual Studio
- Set **multiple startup projects**: API + Web

### 3. Apply database migrations
- Open **Package Manager Console** in Visual Studio
```bash
Update-Database
```

### 4. Run the solution
- Press **F5**
- API will be at: `https://localhost:5001/api/events`
- Web app will be at: `https://localhost:5002/Events`

---

## 🌐 Azure Deployment

| Layer    | Azure App Service              | URL |
|----------|--------------------------------|-----|
| API      | `touristbooking-api`           | [API Swagger](https://touristbooking-api.azurewebsites.net/swagger) |
| Frontend | `touristbooking-web`           | [Frontend Site](https://touristbooking-web.azurewebsites.net/Events) |

### CI/CD via GitHub Actions

- On push to `main`, API and Web projects are built and deployed via:
  - `.github/workflows/deploy-api.yml`
  - `.github/workflows/deploy-web.yml`

Secrets used:
- `AZURE_WEBAPP_PUBLISH_PROFILE` (for API)
- `AZURE_WEBAPP_WEB_PUBLISH_PROFILE` (for frontend)

---

## 📸 Screenshots (Optional)
_Add UI screenshots or Swagger UI preview here._

---

## 🧩 Future Improvements

- Add Update/Delete UI in frontend
- Add authentication (ASP.NET Identity or JWT)
- Add input validation and model annotations
- Switch to Angular/React frontend (optional)

---

## 📜 License
This project is licensed under the MIT License.

---

## 👤 Author

**Your Name**  
GitHub: [@yourusername](https://github.com/yourusername)  
Email: your.email@example.com
