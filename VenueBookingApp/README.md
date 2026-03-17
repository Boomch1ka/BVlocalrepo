# Venue Booking Application

## Overview
The Venue Booking Application is an ASP.NET Core MVC project that allows users to manage venues, events, and bookings. This application provides a user-friendly interface for creating, editing, viewing, and deleting venues, events, and bookings.

## Features
- **Venues Management**: Create, read, update, and delete venues.
- **Events Management**: Create, read, update, and delete events associated with venues.
- **Bookings Management**: Create, read, update, and delete bookings for events.

## Project Structure
```
VenueBookingApp
├── Controllers
│   ├── HomeController.cs
│   ├── VenuesController.cs
│   ├── EventsController.cs
│   └── BookingsController.cs
├── Data
│   ├── ApplicationDbContext.cs
│   └── SeedData.cs
├── Models
│   ├── Venue.cs
│   ├── Event.cs
│   └── Booking.cs
├── Views
│   ├── Home
│   │   └── Index.cshtml
│   ├── Venues
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   ├── Events
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   ├── Bookings
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   └── Shared
│       ├── _Layout.cshtml
│       ├── _ViewImports.cshtml
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot
│   ├── css
│   │   └── site.css
│   └── js
│       └── site.js
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── Startup.cs
├── VenueBookingApp.csproj
└── README.md
```

## Getting Started
1. Clone the repository.
2. Navigate to the project directory.
3. Run the application using the command:
   ```
   dotnet run
   ```
4. Open your web browser and go to `http://localhost:5000` to access the application.

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- Razor Views
- Bootstrap (for styling)

## Contributing
Feel free to submit issues or pull requests for improvements or bug fixes. 

## License
This project is licensed under the MIT License.