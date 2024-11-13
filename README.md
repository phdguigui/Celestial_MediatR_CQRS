# 🌌 Celestial: Mediator and CQRS

## 📂 Project Overview

**Celestial** is a project developed as part of the **Becomex** mentorship program. This project aims to apply the theoretical concepts of **Mediator** and **CQRS** in a practical application, using **MediatR** in .NET.

The project simulates an astronomical cataloging system with basic CRUD functionality to manage star registrations. The CRUD operations allow for:
- **Creation** of new star entries.
- **Query** for detailed information about registered stars.
- **Update** of existing star information.
- **Delete** entries from the catalog.

The application is set up for use via **Swagger**, making it easy to explore the system's features and demonstrate the practical application of architectural and design patterns learned.

## 🤝 Mediator Pattern

The Mediator pattern is a behavioral design pattern aimed at reducing coupling between system components by facilitating communication through a central object called the "mediator". This mediator manages interactions between objects, allowing them to communicate without knowing about each other.

### ⚙️ How It Works
Instead of components interacting directly, they send messages to the mediator, which then decides where to route the message. This improves system maintenance and flexibility, as components can be added or modified without affecting others that interact with them.

### Before
![image](https://github.com/user-attachments/assets/3c4c2a09-50b6-4cf1-ad8d-c75af6af1ed5)

### After
![image](https://github.com/user-attachments/assets/b1cad50f-84d0-4fd2-81fe-e12b6985434d)

### ✅ Advantages
- **Reduces coupling** between components.
- **Eases maintenance**, enabling the addition or modification of functionality without affecting other components.
- **Centralizes communication logic**, making it more organized.

### ⚠️ Disadvantages
- **Can cause overload** on the mediator if too many interactions are centralized through it.
- **Makes it harder to trace** the flow of calls, as all components communicate via a single point.

### 💬 Application in the Project

The project is divided into **Requests**, **Handlers**, and **Responses**, as seen in the **Commands** folder within the **Domain**.

### Requests 📩

Requests are objects that represent a request for an action or operation. They contain the necessary data to perform an operation, such as creating, updating, or deleting a resource.

```csharp
public class CreateStarCommandRequest : IRequest<CreateStarResponse>
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public double Magnitude { get; set; }

    public CreateStarCommandRequest(string name, Position position, double magnitude)
    {
        Name = name;
        Position = position;
        Magnitude = magnitude;
    }
}
```
In the class above, all necessary data for creating a new star is included. Since this is a **Request**, the class should inherit from **IRequest** of **MediatR** and set the type **CreateStarResponse**, which will be the expected response (the promise) for this request.

All request classes should have the suffix *Request* at the end of the class name.

### Handlers 🔧

Handlers are classes responsible for processing the requests made through the **Requests**. Each handler is responsible for handling a specific type of request, executing the business logic required to perform the requested operation.

```csharp
public class CreateStarCommandHandler : IRequestHandler<CreateStarCommandRequest, CreateStarResponse>
{
    private readonly IStarRepository _starRepository;

    public CreateStarCommandHandler(IStarRepository starRepository)
    {
        _starRepository = starRepository;
    }

    public async Task<CreateStarResponse> Handle(CreateStarCommandRequest request, CancellationToken cancellationToken)
    {
        var star = new Star(request.Name, request.Position, request.Magnitude);

        await _starRepository.AddStarAsync(star);

        var response = new CreateStarResponse(star.Id, star.Name, star.Position, star.Magnitude);

        return response;
    }
}
```

In the class above, the method **Handle** is implemented, which is required for every class that inherits from **IRequestHandler**. When inheriting from **IRequestHandler**, the class for the related **Request** is specified, and it is from there that the link between **Request** and **Handler** is created through **MediatR**. The second class provided is the response for this method, which must always match the expected response for the **Request** of the handler.

The **Handler** will perform all the necessary processing to return the result of the request.

All **Handler** classes should have the suffix *RequestHandler* at the end of the class name.

### Responses 📤

Responses are objects that represent the system's reply after executing a **Request**. They contain the results of the operation, which may include data, success or failure messages, or other details about what happened.

```csharp
public class CreateStarResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Position Position { get; set; }
    public double Magnitude { get; set; }

    public CreateStarResponse(int id, string name, Position position, double magnitude)
    {
        Id = id;
        Name = name;
        Position = position;
        Magnitude = magnitude;
    }
}
```

In the class above, an example of a **Response** used in the project is presented. It is important to note that no **MediatR** interface implementation is required here, as the implementation is needed only in the **Request** and **Handler** to establish the connection between them.

This class will contain the attributes with the necessary information processed in the **Handler** and expected in the **Request**.

All **Response** classes should have the suffix *Response* at the end of the class name.

---

## ⚔️ CQRS (Command Query Responsibility Segregation)

CQRS is an architectural pattern that separates read operations (queries) from write operations (commands) in a system. Instead of using the same data model and classes for both operations, CQRS suggests creating distinct models for each type of operation, allowing for the optimization and scaling of read and write operations independently.

### ⚙️ How It Works
The CQRS model divides the system into two parts:
1. **Commands**: Responsible for operations that alter the state of the system (write).
2. **Queries**: Responsible for operations that query data without altering the state (read).

This separation allows for optimization of each part individually, providing benefits such as improved performance and better scalability.

![image](https://github.com/user-attachments/assets/0d325fe6-7048-40f3-bcd1-2df785537e22)

### ✅ Advantages
- **Optimizes read and write operations** separately.
- **Facilitates scalability**, as the read and write models can be adjusted based on specific needs.
- **Improves security**, restricting data modification to the write model only.

### ⚠️ Disadvantages
- **Increases complexity** of the application, as it requires the creation and maintenance of two distinct models.
- **Data synchronization** between the read and write models can be challenging, especially in distributed systems.

### 💬 Application in the Project

The project is divided into **Commands** and **Queries**, as seen in the **Domain**.

Each folder will contain classes dedicated to database registration (commands) and data reading (queries).

In this project, both divisions access the same database without distribution, serving only as a base example of CQRS architecture. The performance benefits of CQRS are not yet visible in this case, but its organizational structure is demonstrated.

---

## 🏷️ Class Naming Convention

Given the implementation of **Mediator** and **CQRS**, each requiring an additional need for suffixes in class names, below is the naming pattern used for each class type, combining both **Mediator** and **CQRS**.

We will consider **Command** and **Query** for **CQRS** and **Request**, **RequestHandler**, and **Response** for **Mediator**.

*BaseClassName/Entity* + *CQRSMethod* + *MediatorMethod*

### Examples:

*CreateStar* + *Command* + *Request*
*GetStar* + *Query* + *RequestHandler*
*UpdateStar* + *Query* + *Response*

By following all possibilities, we have 8 possible combinations with the suffixes of **Mediator** and **CQRS**.

---

## 🔍 Difference Between Mediator and CQRS

| 📝 Aspect                        | 🤝 Mediator                                                            | ⚔️ CQRS                                                              |
|----------------------------------|----------------------------------------------------------------------|---------------------------------------------------------------------|
| **Objective**                    | Facilitate communication between components without direct coupling   | Separate read and write operations to optimize each                  |
| **Design Pattern**               | Behavioral                                                           | Architectural                                                        |
| **Centralization**               | Uses a central mediator to manage interactions                        | No centralization; separates read and write operations               |
| **Reduces Coupling**             | Yes, reduces coupling between components                             | Not applicable                                                       |
| **Scalability**                  | Can be limited by the mediator if too many interactions occur         | Increases scalability by allowing independent optimization of read and write models |
| **Additional Complexity**        | Can make the message flow more complex                               | Requires the creation and maintenance of two separate models         |
| **Use Case Example**             | Communication or integration systems between modules                  | Systems with large volumes of read and write operations              |

---

## 🔗 Why Mediator and CQRS are Commonly Used Together?

The **Mediator** pattern and the **CQRS** architecture are often used together because they complement each other in complex systems:

1. **Separation of Responsibilities**: CQRS separates read and write operations into different models, while Mediator decouples the communication between these operations and other components. Together, they provide a clearer organization of responsibilities, making the system easier to maintain and evolve.

2. **Scalability and Performance**: With CQRS, read and write operations can be scaled independently. Mediator, by centralizing communication, helps manage complexity and maintain performance by efficiently directing commands and queries to their respective handlers.

3. **Flexibility in Business Logic Handling**: Using Mediator with CQRS allows business rules to be applied at the command and query levels without directly interfering with other system components. This modular approach reduces the risk of unwanted changes.

4. **Simplicity in Event Implementation**: Mediator simplifies the sending of notifications and messages between components, making it ideal for implementing events after commands, such as scenarios where changes to application state (writes) need to trigger updates in queries (reads) asynchronously.

### Benefits of Integration

| Benefit                         | Description                                                                                                      |
|---------------------------------|------------------------------------------------------------------------------------------------------------------|
| **Reduction of Coupling**       | Mediator manages communication between the read and write operations separated by CQRS                           |
| **Easier Maintenance**          | The separation of responsibilities, combined with Mediator, makes the system more modular and easier to maintain |
| **Scalability**                 | Operations can be scaled separately, and Mediator helps organize and optimize interactions                       |
| **Reactive Events**             | Facilitates the creation of events that synchronize the read model with the write model asynchronously           |

### Developed by [Guilherme Siedschlag](https://github.com/phdguigui/) 🕶️
