
![Logo](https://i.imgur.com/T38mIrt.png)


# Mailroom Manager

A fully-integrated solution for managing a mailroom.
## How-To Run API

- Ensure you have Microsoft SQL Express and Visual Studio 2022 installed
- Clone/Download the project.
- Open it in Visual Studio 2022.
- Open appsettings.json file within the Mailroom API project
- Configure the DefaultConnection string to match your MSSQLe server's connection string
- Open the Package Manager Console (*Views -> Other Windows -> Package Manager Console*)

Enter the Mailroom API directory:
```bash
  cd "Mailroom API"
```

Create a Database Migration:
```bash
  dotnet ef migrations add CreateInitial
```

Update the Database:
```bash
  dotnet ef database update
```

Start the API server by running the Mailroom API project without debugging, or from the project directory.

When you run the API via Visual Studio, it will automatically open Swagger UI for you. From there, you can view the API structure and schemas, as well as interact directly with the API.

Please note the API's IP address and port, as you'll need to give it to the client.

## How-To Run Client Application

- Start the client by running the Mailroom App project
   * If the application fails to connect to the API, it will throw an error. When you click OK, it will open a window to configure the API Server address. Enter in the address from the API server, including the port, and click save. Restart the application.
- When the application starts up and connects to the API, any shipments in the database will appear within the Shipments list, and a green + button will appear above the shipments "Details" box.
- You can add a shipment to get started, or select one if there's one there to get it's details.
- When a shipment is selected, it's bags will appear, and when a bag is selected, it's parels will appear.
   - When any item is selected, it's control buttons will appear in it's corresponding box above the Details box.
- Click the controls buttons to interact with your selected object by either deselecting it, deleting it, editing it, or adding a new object to the list.
- Clicking any item within a list will show its details to the left in the corresponding Details box.
## Technologies
**Server:** C# .NET Core 6 WebAPI

**Client:** C# .NET Framework 4.8 WinForms


## Features

- CRUD API for all objects
   - Get a single object or all objects (Both use GET)
   - Add/Edit/Delete all objects (POST, PUT, DELETE)
- Custom Client UI
   - Allows user-friendly control and management via the API
   - Designed for ease-of-use, ideal for store employee
- Extensive error handling
- Code is heavily commented
- Easily extensible
   - You can easily add new API methods
   - You can easily update or add new UI functionality
## Contributors

Developed by myself, Alex K. for [Helmes AS](https://www.helmes.com/) in Estonia.

