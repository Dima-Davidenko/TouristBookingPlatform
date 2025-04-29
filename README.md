
# 🌍 Tourist Booking Platform

[![Build Status](https://github.com/Dima-Davidenko/TouristBookingPlatform/actions/workflows/deploy-api.yml/badge.svg)](https://github.com/Dima-Davidenko/TouristBookingPlatform/actions)
[![Deploy Frontend](https://github.com/Dima-Davidenko/TouristBookingPlatform/actions/workflows/deploy-frontend.yml/badge.svg)](https://github.com/Dima-Davidenko/TouristBookingPlatform/actions)

A full-stack .NET Core web application for managing and reserving tourist events.  
Built as a pet project to demonstrate backend, frontend, database, and DevOps skills for a Junior .NET Developer role.

---

## 🧭 Project Overview

This application allows:
- Visitors to browse tourist events and make reservation requests
- Admins to manage events (CRUD) via a protected dashboard

The app is **deployed live on Azure** and powered by **GitHub Actions CI/CD**.

---

## 🛠️ Technologies Used

| Layer     | Tech Stack                                      |
|-----------|--------------------------------------------------|
| Backend   | ASP.NET Core Web API (C#), Entity Framework Core |
| Frontend  | ASP.NET Core MVC, Razor Views, Bootstrap         |
| Database  | SQL Server (LocalDB for dev, Azure SQL for prod) |
| DevOps    | GitHub Actions, Azure App Services               |

---

## 💡 Features

### ✅ Public User View
- View list of upcoming tourist events (`/Events`)
- Click **Reserve** to submit name + email
- Simple inline confirmation

### 🔒 Admin Panel (`/Admin`)
- Login required: **username** `admin`, **password** `admin`
- Create / Edit / Delete events
- List events in a Bootstrap-styled table

### ✨ Developer Tools
- Retry logic for API calls
- Separate environments: `Development` vs `Production`
- Clean separation of user vs admin routes

---

## 🚀 Live Demo

| Service  | URL |
|----------|-----|
| Frontend | https://touristbooking-web.azurewebsites.net |
| Backend  | https://tourist-booking-service.azurewebsites.net/swagger |
| Admin    | https://touristbooking-web.azurewebsites.net/Admin |
| Project Info Page | https://touristbooking-web.azurewebsites.net/Project/About |

---

## 🔧 How to Run Locally

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- [SQL Server Express / LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

### Steps

```bash
git clone https://github.com/Dima-Davidenko/TouristBookingPlatform.git
cd TouristBookingPlatform

# Apply DB migrations
dotnet ef database update --project TouristBookingPlatform.API

# Run the app (both projects in Visual Studio or with dotnet run)
```

- Local API: `https://localhost:5001/api/events`
- Local Web: `https://localhost:5002/Events`

---

## ⚙️ CI/CD with GitHub Actions

- `main` branch triggers deploy for both frontend and backend
- Azure App Services used for hosting
- Secure deployment via Azure service principal login

Secrets used:
- `AZURE_CREDENTIALS` (JSON for SPN login)
- `ApiBaseUrl` configured per environment

---

## 📂 Solution Structure

```
TouristBookingPlatform/
├── TouristBookingPlatform.sln
├── TouristBookingPlatform.API/       # Web API
├── TouristBookingPlatform.Web/       # MVC frontend
├── .github/workflows/                # CI/CD pipelines
└── README.md
```

---

## 👤 Author

**Dmytro Davidenko**  
📧 dimitrdavidenko@gmail.com  
📍 Bansko, Bulgaria  
🔗 [LinkedIn](https://www.linkedin.com/in/dmytro-davidenko/)  
🔗 [GitHub](https://github.com/Dima-Davidenko/TouristBookingPlatform)

---

## 📜 License

This project is licensed under the MIT License.
