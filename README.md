# 📚 Library Management API

Simple REST API built with ASP.NET Core to simulate a small library system.

---

## ✅ What You Need Installed

- .NET SDK 8.0 or higher  
  Download: https://dotnet.microsoft.com/en-us/download

To check if it’s installed:

```bash
dotnet --version
```
If a version number appears, you're ready.

📥 Clone the Repository
```bash
git clone https://github.com/your-username/library-management-api.git
```
Go to the project folder:
```bash
cd library-management-api
```
🚀 Run the Project
Restore dependencies:
```bash
dotnet restore
```
Run the API:
```bash
dotnet run
```
You should see something like:
```bash
Now listening on: https://localhost:5001
Application started.
```
🌐 How to Test
Open your browser and go to:
```bash
https://localhost:{port}/swagger
```
Replace {port} with the port shown in your terminal.

Swagger will open and allow you to test the API.

🧪 Test in This Order

- POST /api/users → Create a user

- POST /api/books → Create a book

- POST /api/books/{id}/borrow/{userId} → Borrow

- GET /api/books → Check status

- POST /api/books/{id}/return → Return

📝 Example JSON
```bash
Create User:

{
  "name": "Lucas"
}
Create Book:

{
  "title": "Clean Code",
  "author": "Robert C. Martin"
}
```
