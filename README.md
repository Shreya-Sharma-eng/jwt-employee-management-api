# Employee Management API 🚀

A RESTful Employee Management System built using **ASP.NET Core Web API**, **Entity Framework Core**, **SQL Server**, and **JWT Authentication**.

This project demonstrates:

* JWT Authentication
* Role-Based Authorization
* CRUD Operations
* Entity Relationships
* DTO Pattern
* EF Core Migrations
* Swagger Integration

---

# 🔥 Features

## Authentication & Authorization

* User Registration
* User Login
* JWT Token Generation
* Role-Based Access Control
* Admin Protected APIs

---

## Department Management

* Create Department
* Get All Departments
* Prevent Duplicate Departments

---

## Employee Management

* Add Employee
* Update Employee
* Delete Employee
* Get Employee By Id
* Get All Employees
* Prevent Duplicate Employees

---

# 🛠️ Tech Stack

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* Swagger
* C#
* LINQ

---

# 🗂️ Project Structure

```text
EmployeeManagementAPI
│
├── Controllers
├── Models
├── DTOs
├── Data
├── Migrations
├── Properties
└── Program.cs
```

---

# 🔐 Authentication Flow

1. User registers
2. User logs in
3. JWT token generated
4. Token used in Swagger Authorize
5. Protected APIs become accessible

---

# 📌 API Endpoints

## Auth APIs

| Method | Endpoint             | Description   |
| ------ | -------------------- | ------------- |
| POST   | `/api/auth/register` | Register user |
| POST   | `/api/auth/login`    | Login user    |

---

## Department APIs

| Method | Endpoint          | Description         |
| ------ | ----------------- | ------------------- |
| POST   | `/api/department` | Add department      |
| GET    | `/api/department` | Get all departments |

---

## Employee APIs

| Method | Endpoint             | Description        |
| ------ | -------------------- | ------------------ |
| POST   | `/api/employee`      | Add employee       |
| GET    | `/api/employee`      | Get all employees  |
| GET    | `/api/employee/{id}` | Get employee by id |
| PUT    | `/api/employee/{id}` | Update employee    |
| DELETE | `/api/employee/{id}` | Delete employee    |

---

# 🧠 Concepts Implemented

* JWT Authentication
* Claims & Roles
* DTO Pattern
* Entity Relationships
* One-to-Many Relationship
* Dependency Injection
* Entity Framework Core
* Database Migrations
* Authorization Policies
* Swagger Configuration
* LINQ Queries
* Data Validation

---

# ⚙️ How to Run the Project

## Clone Repository

```bash
git clone https://github.com/Shreya-Sharma-eng/jwt-employee-management-api.git
```

---

## Navigate to Project

```bash
cd EmployeeManagementAPI
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Apply Migrations

```bash
dotnet ef database update
```

---

## Run Project

```bash
dotnet run
```

---

# 📖 Swagger URL

```text
http://localhost:xxxx/swagger
```

---

# 👩‍💻 Author

Shreya Sharma

🔗 LinkedIn:
[Shreya Sharma LinkedIn](https://linkedin.com/in/shreya-sharma0610?utm_source=chatgpt.com)

---

# ⭐ Future Improvements

* Refresh Tokens
* Repository Pattern
* Service Layer
* AutoMapper
* Pagination
* Global Exception Handling
* Docker Support
* Unit Testing
* Clean Architecture
* Azure Deployment
