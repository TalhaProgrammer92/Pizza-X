
---

# **Pizza X — Architecture Documentation**

This document provides a detailed explanation of the architectural design of **Pizza X**, including its layered structure, design principles, data flow, and example folder patterns.
The goal is to present a transparent and maintainable structure that aligns with modern **Clean Architecture** and **MVVM (Model–View–ViewModel)** practices for WPF applications.

---

# **1. Overview**

Pizza X is organized using a **multi-layered clean architecture**, separating the system into vertical slices that isolate UI, business logic, data access, and domain entities.
This results in:

* Maintainable and testable code
* Low coupling between layers
* High cohesion within each layer
* Clear boundaries between application responsibility areas

The root structure:

```
PizzaX/
│
├── PizzaX.Domain
├── PizzaX.Infrastructure
├── PizzaX.ApplicationCore
├── PizzaX.Presentation
│
└── PizzaX.sln
```

Each layer has a single responsibility and communicates only through well-defined abstractions.

---

# **2. Architectural Principles**

### **2.1 Separation of Concerns**

Each layer contains only the logic it is responsible for.
The UI never interacts directly with the database; the database never knows about the UI.

### **2.2 Dependency Inversion**

Higher layers depend on *interfaces*, not concrete implementations.
For example:

* ApplicationCore defines **repository interfaces**
* Infrastructure provides the **concrete EF Core implementations**

### **2.3 Testability**

Because business rules depend only on interfaces, unit tests can mock repositories and services.
UI logic is testable through ViewModels.

### **2.4 MVVM Pattern (Presentation Layer)**

MVVM ensures:

* No code-behind business logic
* Reusable UI components
* A clean separation between presentation and state management

### **2.5 Repository Pattern (Infrastructure Layer)**

Separates database logic from business logic, preventing EF Core from leaking into upper layers.

---

# **3. Layer-by-Layer Explanation**

---

# **3.1 Domain Layer – Core Logic**

**Project:** `PizzaX.Domain`
**Purpose:** Represents the **heart of the application**.

This layer contains:

* Entity classes
* Value objects
* Domain models
* Domain exceptions
* Core validation logic

It should contain **zero external dependencies** except .NET primitives.

### Example Folder Structure

```
PizzaX.Domain/
│
├── Entities/
│   ├── Pizza.cs
│   ├── Order.cs
│   └── User.cs
│
├── ValueObjects/
│   ├── Email.cs
│   └── Money.cs
│
├── Enums/
│   └── UserRole.cs
│
└── Exceptions/
    └── DomainException.cs
```

### Responsibilities

* Define what a pizza, order, or user *is*
* Ensure domain rules (e.g., “Price cannot be negative”)
* Represent the business vocabulary

---

# **3.2 ApplicationCore Layer – Business Logic**

**Project:** `PizzaX.ApplicationCore`
**Purpose:** Implements core **application use-cases** and interfaces.

This layer acts as the **intermediate layer** between Presentation and Infrastructure.

### Contains:

* Service interfaces
* Use-case implementations
* Repository interfaces
* DTOs (Data Transfer Objects)
* Interfaces for authentication, ordering, inventory, etc.

### Example Folder Structure

```
PizzaX.ApplicationCore/
│
├── Interfaces/
│   ├── IPizzaService.cs
│   ├── IOrderService.cs
│   ├── IUserService.cs
│   └── IJwtProvider.cs
│
├── Services/
│   ├── PizzaService.cs
│   ├── OrderService.cs
│   └── UserService.cs
│
├── DTOs/
│   ├── PizzaDTO.cs
│   ├── OrderDTO.cs
│   └── UserDTO.cs
│
└── Validators/
    └── OrderValidator.cs
```

### Responsibilities

* Define interfaces for accessing data (repositories)
* Implement business workflows (use-cases)
* Map domain entities ↔ DTOs
* Handle business rules that require external data

---

# **3.3 Infrastructure Layer – Data & External Services**

**Project:** `PizzaX.Infrastructure`
**Purpose:** Contains **everything that interacts with the outside world**, such as:

* Entity Framework Core
* Repositories
* DbContext
* JWT services
* Authentication logic
* SQL Server connection

### Example Folder Structure

```
PizzaX.Infrastructure/
│
├── Data/
│   ├── PizzaXDbContext.cs
│   └── Configurations/
│       ├── PizzaConfiguration.cs
│       └── OrderConfiguration.cs
│
├── Repositories/
│   ├── PizzaRepository.cs
│   ├── OrderRepository.cs
│   └── UserRepository.cs
│
├── Authentication/
│   ├── JwtProvider.cs
│   └── TokenValidator.cs
│
└── Mappings/
    └── DtoMapper.cs
```

### Responsibilities

* Implement repository interfaces
* Handle EF Core configurations
* Manage migrations and database schema
* Provide JWT token generation & validation
* Provide access to external resources

Presentation never interacts with EF Core.
It only communicates with **ApplicationCore → Infrastructure** via abstractions.

---

# **3.4 Presentation Layer – WPF UI (MVVM)**

**Project:** `PizzaX.Presentation`
**Purpose:** Provides the user interface and visual experience.

Built using:

* WPF
* XAML
* MVVM (Model–View–ViewModel)

### Example Folder Structure

```
PizzaX.Presentation/
│
├── Views/
│   ├── LoginView.xaml
│   ├── DashboardView.xaml
│   └── PizzaManagementView.xaml
│
├── ViewModels/
│   ├── LoginViewModel.cs
│   ├── DashboardViewModel.cs
│   └── PizzaManagementViewModel.cs
│
├── Commands/
│   └── RelayCommand.cs
│
├── Models/
│   └── UI-specific models
│
└── Resources/
    └── Styles.xaml
```

### Responsibilities

* Display data to the user
* Send user actions to ViewModels
* Bind UI elements to ViewModel commands
* Contain *no* business logic

The Presentation layer communicates **only with ApplicationCore**.

---

# **4. Dependency Flow**

```
Presentation  →  ApplicationCore  →  Domain
                     ↓
               Infrastructure
```

* Presentation depends on ApplicationCore interfaces
* ApplicationCore depends on Domain entities and repository interfaces
* Infrastructure implements those interfaces
* Domain depends on nothing (core of the system)

This forms a stable, layered system with controlled access.

---

# **5. Data Flow Example**

### Example: User logs into the system

1. UI calls: `LoginViewModel.LoginCommand`
2. ViewModel calls: `IUserService.ValidateCredentials()`
3. UserService (ApplicationCore) calls: `IUserRepository.GetUserByEmail()`
4. Infrastructure returns the entity via EF Core
5. ApplicationCore generates JWT via `IJwtProvider`
6. ViewModel receives token and updates the UI state

No layer breaks its boundaries.

---

# **6. Example Use-Case Walkthrough**

### Adding a Pizza

**Step 1:** UI enters pizza details → ViewModel → `IPizzaService.AddPizza()`
**Step 2:** PizzaService validates data → maps DTO to entity
**Step 3:** Repository saves entity to SQL Server
**Step 4:** Response is returned to the UI

---

# **7. Why This Architecture Works**

* Eliminates tightly-coupled code
* Encourages unit testing
* Supports future expansion (e.g., reporting module, payment system, analytics)
* Easier onboarding for new developers
* Aligns with enterprise .NET application standards

---

# **8. Future Enhancements**

* Domain-driven events
* CQRS (Command Query Responsibility Segregation)
* Automated unit tests in Presentation & ApplicationCore
* Modular plugin system for adding new UI screens
* Advanced reporting using SQL views or LINQ projections

---

# **9. Conclusion**

This architecture allows Pizza X to operate with a clean, structured, and scalable foundation.
Each layer has a well-defined purpose, making the project maintainable and extensible for long-term evolution.

---
