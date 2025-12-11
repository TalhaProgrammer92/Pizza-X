
---

# 🍕 Pizza X

### **A WPF (.NET 10) Desktop POS & Ordering System with EF Core and JWT Authentication**

**Pizza X** is a modern, desktop-based pizza ordering and retail management system built with **WPF (.NET 10, MVVM)** and backed by **Entity Framework Core**.
It delivers a clean, modular, and enterprise-style architecture, showcasing how professional-grade desktop applications can be designed with **layered architecture**, **JWT-based authentication**, and **robust business logic**.

This project demonstrates a blend of **POS**, **CRM**, and **Admin Management** concepts — including inventory control, menu management, ordering, and billing.

---

## 🧱 Architecture Overview

The solution follows a **clean, layered architecture** with strict separation of concerns to support scalability and maintainability.

```
PizzaX/
│
├── PizzaX.Domain           → Core models, entities, value objects
├── PizzaX.Infrastructure   → EF Core DbContext, repositories, JWT services
├── PizzaX.ApplicationCore  → Business logic, service layer, use-cases
├── PizzaX.Presentation     → WPF UI Layer (MVVM: Views, ViewModels, Commands)
│
└── PizzaX.sln
```

### 🧩 Architectural Highlights

* **MVVM** for decoupled UI and logic
* **Repository Pattern** for clean, testable data access
* **Dependency Injection** for modularity
* **JWT Authentication** used locally for secure session logic
* **SQL Server** for persistent storage and relational data modeling

---

## ⚙️ Tech Stack

| Layer          | Technology                   |
| :------------- | :--------------------------- |
| UI             | WPF (.NET 10, XAML, MVVM)    |
| Database       | SQL Server 2021              |
| ORM            | Entity Framework Core        |
| Language       | C#                           |
| Authentication | JSON Web Tokens (JWT)        |
| IDE            | Visual Studio Community 2026 |

---

## 🚀 Key Features

* **Secure Local Authentication (JWT)**
* **Pizza/Menu Management** (Add, update, delete)
* **Customer Ordering System**
* **Admin & Customer Role Separation**
* **Order Tracking & Billing**
* **Persistent Data Storage** with EF Core + SQL Server
* **Modern WPF UI** designed with XAML + MVVM best practices

---

## 💼 Real-World Use Case

Pizza X is designed as a **desktop POS-style system**, ideal for:

* Restaurant counter/desktop ordering systems
* Student or academic final projects
* Demonstrating full-stack desktop development
* Learning enterprise-style architecture in .NET
* Showcasing design patterns and layered structure in a portfolio

---

## 🧭 How to Run the Project

### 1. Clone the Repository

```bash
git clone https://github.com/TalhaProgrammer92/Pizza-X
cd PizzaX
```

### 2. Open in Visual Studio 2026

Open the `.sln` file and allow package restore to complete.

### 3. Set the Startup Project

Right-click **PizzaX.Presentation** → *Set as Startup Project*

### 4. Apply EF Core Migrations / Update Database

```bash
dotnet ef database update
```

### 5. Run the Application

Press **F5** to build and launch the Pizza X desktop application.

---

## 🔐 Authentication Model (Local JWT)

Although Pizza X is a desktop application, it employs **JWT internally** to simulate production-style authentication.

JWT is used for:

* User session handling
* Role authorization (Admin, Customer)
* Secure access to business logic routes

All token generation, validation, and role checks are handled **locally** without any external API.

---

## 🧑‍💻 Developer Notes

* Implements **Clean Architecture + MVVM** consistently
* Follows **SOLID principles** across layers
* Demonstrates how EF Core integrates with repositories and services
* Suitable as a learning project, case study, or professional portfolio entry
* Easy to extend with additional modules (payments, reports, analytics, etc.)

---

## 📄 License

This project is licensed under the **MIT License**.
See the full text in the [LICENSE](/LICENSE) file.

---

Here is the updated **Author section with clickable badges**, replacing the raw links exactly as requested.
You can paste this block directly into your refined README.

---

## 🏗️ Author

**Talha Ahmad**
.NET Developer | Software Engineer

[![GitHub Profile](https://img.shields.io/badge/GitHub-000000?style=for-the-badge\&logo=github\&logoColor=white)](https://github.com/TalhaProgrammer92)
[![LinkedIn Profile](https://img.shields.io/badge/LinkedIn-0A66C2?style=for-the-badge\&logo=linkedin\&logoColor=white)](https://www.linkedin.com/in/talha-ahmad-720171324/)

---
