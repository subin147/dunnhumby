# .NET API Setup and Usage

This README provides step-by-step instructions to set up, run, and use the .NET API.

---

## Prerequisites

Before setting up the project, ensure you have the following installed:

1. [.NET SDK](https://dotnet.microsoft.com/download) (Version: 8.0 or higher)
2. [Visual Studio](https://visualstudio.microsoft.com/) or any IDE supporting .NET development (e.g., Rider, Visual Studio Code).

---

## Setup Instructions

### 1. Clone the Repository

Clone the project repository from GitHub:

```bash
git clone <repository-url>
cd <repository-folder>
```

### 2. Configure the Environment Variables

Create `appsettings.json` file in the root directory if it does not exist. Add your configuration variables:

#### Example: `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_user_id;Password=your_password;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```


### 3. Restore Dependencies

Navigate to the project directory and run:

```bash
dotnet restore
```


### 4. Run the Application

Start the application:

```bash
dotnet run
```

The API will typically be hosted at `https://localhost:5001` or `http://localhost:5000`.

---

## API Endpoints

Below are the available endpoints. Use tools like Postman or swagger UI to interact with them.

###  Endpoints

#### 1. `GET /products`
- Description: Fetch all products.
- Response: JSON array of products.

```json
[
  {
    "Id": 1,
    "Category": "Food",
    "Name": "Apple",
    "Code": "F001",
    "Price": 1,
    "SKU": "12345",
    "StockQuantity": 100,
    "DateAdded": "2025-01-25T12:28:49.0376369"
  },
  {
    "Id": 2,
    "Category": "Food",
    "Name": "Orange",
    "Code": "F002",
    "Price": 1,
    "SKU": "12346",
    "StockQuantity": 100,
    "DateAdded": "2025-01-25T12:28:49.0376369"
  }
]
```
#### 2. `POST /products/register`
- Description: Add a new product.
- Request Body:
```json
  {
  "categoryId": 1,
  "name": "Apple",
  "code": "F001",
  "price": 1,
  "sku": "12345",
  "stockQuantity": 10
}
```

- Response: 
 ```json
  {
  "IsSuccess": true,
  "Message": "Product 'Apple' added successfully."
}
```
---

## Testing

### 1. Run Unit Tests

To execute unit tests, use the following command:

```bash
dotnet test
```

### 2. Mock Data

If mock data is required for testing, ensure it is seeded in your `DbContext` or mock services.

---

## Deployment

For deployment, publish the application using the following command:

```bash
dotnet publish -c Release -o ./publish
```

Upload the contents of the `publish` folder to your hosting environment (e.g., Azure, AWS, IIS).

---

