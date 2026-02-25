# 📚 Library Management API

A simple REST API built with ASP.NET Core to simulate a small library system.

This project was created to practice backend development using C# and .NET, focusing on clean code, organization, and proper separation of responsibilities.

It’s intentionally simple, but structured in a way that reflects how real backend applications are designed.

---

## 🚀 Overview

This API allows you to:

- Create books
- Create users
- Borrow books
- Return books
- Persist data using JSON files
- Automatically clear data when the application stops

There is no database involved. Data is stored in JSON files during runtime and reset when the session ends.

---

## 🧠 Project Goals

The purpose of this project was to:

- Practice building REST APIs with ASP.NET Core  
- Apply clean code principles  
- Separate business logic from controllers  
- Implement proper validation  
- Simulate real backend rules without unnecessary complexity  

Instead of building something large and overcomplicated, the focus here is clarity and structure.

---

## 🏗 Architecture

The project is organized into logical layers:

- **Controllers** → Handle HTTP requests and responses  
- **Services** → Contain business rules and core logic  
- **Validators** → Handle validation rules  
- **Domain** → Entities and interfaces  
- **Infrastructure** → JSON persistence  

Each layer has a clear responsibility:

- Controllers do not contain business logic  
- Services do not handle HTTP concerns  
- Entities manage their own state  

---

## 📦 Features

### 📘 Books
- Add a new book  
- List all books  
- Borrow a book  
- Return a book  
- Prevent borrowing an already borrowed book  
- Prevent borrowing if there are no users  
- Prevent returning a book that is not borrowed  

### 👤 Users
- Add a new user  
- List users  
- Validate user existence before borrowing  

### 💾 Persistence
- Data is saved in `/Data` as JSON files  
- Files are automatically cleared when the application stops  

---

## ⚙️ Tech Stack

- C#
- .NET
- ASP.NET Core Web API
- System.Text.Json
- Swagger (OpenAPI)

---
## ▶️ How to Run the Project

### ✅ Prerequisites

Before running the project, make sure you have installed:

- [.NET SDK 8.0 or higher](https://dotnet.microsoft.com/en-us/download)
- (Optional) Visual Studio 2022 or later

To check if .NET is installed, run:

```bash
dotnet --version
