# Property Manager

Welcome, it's good to see you here. Without any furter delay, this project is a property manager. Users can create, get and delete any property or user.

The main idea is to put in practice concepts of Hexagonal Architecture and the implementation of unit tests (using NUnit). The project was also created using importants concepts like logging (using NLog lib), caching, SOLID principles, Swagger for testing the API, and the Identity for a simple authorization layer.

The folders structure is as follows:
```
- Adapters
    - DataEf
    - IdentityAuth
    - NLog
- Consumers
    - API
- Core
    - Application
    - Domain
- Tests
    - ApplicationTests
    - DomainTests
```

It's a very simple project but very useful and the serves as the foundation for future projects. Therefore, it's doesn't stop here; new features will be added to this project in the project.