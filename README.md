## MyStudentPortal

MyStudentPortal is a Blazor application that follows the Clean Architecture principles introduced by Robert C. Martin (Uncle Bob) in 2012. Clean Architecture emphasizes the separation of concerns and the independence of different layers within a system, making the application more maintainable, testable, and scalable.

### Features

- **User Registration and Authentication**: Students can register and log in to the portal.
- **Course Management**: Students can view and enroll in available courses.
- **Assignment Submission**: Students can submit assignments for their enrolled courses.
- **Grading and Feedback**: Instructors can grade assignments and provide feedback to students.
- **Notification System**: Students and instructors receive notifications for important events, such as assignment deadlines and grading updates.

### Architecture

MyStudentPortal follows the Clean Architecture principles, which consist of the following layers:

1. **Presentation Layer (UI)**: This layer is responsible for rendering the user interface and handling user interactions. It includes Blazor components, layouts, and pages.

2. **Application Layer**: This layer contains the application's use cases and defines the application's behavior. It is independent of the UI and data access layers.

3. **Domain Layer**: This layer represents the core of the application and contains the business entities, interfaces, and rules. It is the most independent layer and does not depend on any other layer.

4. **Infrastructure Layer**: This layer is responsible for data access, external service integrations, and other implementation details. It depends on the Domain layer but is independent of the Application and Presentation layers.

### Technologies Used

- **Blazor**: A framework for building interactive client-side web UI with .NET.
- **Clean Architecture**: A software design philosophy that separates the different layers of an application, making it more maintainable, testable, and scalable.
- **Entity Framework Core**: An object-relational mapping (ORM) framework for .NET, used for data access.
- **ASP.NET Core Identity**: A membership system that adds login functionality to ASP.NET Core apps.
- **Bootstrap**: A popular CSS framework for building responsive, mobile-first websites.

### Getting Started

1. **Clone the repository**:
```bash
git clone https://github.com/BongumusaBhengu/MyStudentPortal.git

2. **Open the solution in Visual Studio or Visual Studio Code**.

3. **Set up the database connection string** in the `appsettings.json` file.

4. **Run the database migrations**:
```bash
dotnet ef database update
```

5. **Build and run the application**:
```bash
dotnet run
```

6. **Open the application in your web browser** at `https://localhost:5001`.

### Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please create a new issue or submit a pull request.
