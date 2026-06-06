# BookLibrary

En fullstack-applikation för att hantera böcker och författare, byggd som en skoluppgift i kursen C# II.

## 🔗 Live Demo

Frontend deployad på GitHub Pages: [https://e-bot-rgb.github.io/BookLibrary/](https://e-bot-rgb.github.io/BookLibrary/)

## 🛠️ Teknikstack

**Backend**
- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQL Server (LocalDB)
- Clean Architecture (API, Application, Domain, Infrastructure)
- Repository pattern med generiskt repository
- Dependency Injection via interfaces

**Frontend**
- React + Vite
- Deployad via GitHub Pages

**Tester**
- xUnit
- NSubstitute för mockning

## 📁 Projektstruktur

```
BookLibrary/
├── BookLibrary.API           # Controllers, Program.cs
├── BookLibrary.Application   # Services, Interfaces
├── BookLibrary.Domain        # Modeller (Author, Book)
├── BookLibrary.Infrastructure # Repositories, DbContext, Migrations
├── BookLibrary.Tests         # Enhetstester (xUnit)
└── BookLibrary.Client        # React frontend (Vite)
```

## ✅ Funktioner

- CRUD för författare och böcker
- 1-till-många relation (Author → Books)
- 7 enhetstester
- GitHub Actions CI – bygger och kör tester vid varje commit

## 🚀 Kom igång

### Backend
1. Klona repot
2. Öppna `BookLibrary.slnx` i Visual Studio
3. Kör `Update-Database` i Package Manager Console
4. Starta projektet med F5

### Frontend
```bash
cd BookLibrary.Client
npm install
npm run dev
```
