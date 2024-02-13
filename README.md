# ConcertShowBooker

ConcertShowBooker is a web application for managing concert bookings. It follows a layered architecture and utilizes the Identity Framework for user authentication.

## Layers

### Infrastructure Layer

Contains infrastructure-related code such as database configurations, logging, and external services integration.

### Entities Layer

Defines the domain entities used in the application. Entities represent the core business objects and encapsulate their behavior and data.

### Repositories Layer

Provides data access and manipulation methods for interacting with the database. It abstracts away the data access logic and provides a clean API for the rest of the application to interact with the database.

### UI Layer

Implements the user interface and presentation logic. It includes Razor Pages, HTML/CSS, and JavaScript code responsible for rendering the user interface and handling user interactions.

## Identity Framework

The Identity Framework is used for user authentication and authorization. It provides features such as user registration, login, logout, and role-based access control.

## Features

- User authentication: Allows users to sign up, log in, and log out using the Identity Framework.
- Role-based access control: Admin users have additional privileges to manage users, view all bookings, and perform administrative tasks.
- Booking management: Users can view, create, update, and delete their concert bookings.
- Ticket management: Allows users to manage their tickets for booked concerts.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- Razor Pages
- Bootstrap
- HTML/CSS
- JavaScript


## Usage

- Sign up or log in to the application using your credentials.
- Once logged in, you can view upcoming concerts, book tickets, and manage your bookings.
- Admin users have additional privileges to manage users, view all bookings, and perform administrative tasks.
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
