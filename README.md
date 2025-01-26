# dunnhumby
Technical Test Dunnhumby

ASSESSMENT OVERVIEW:
A Simple Product Management Dashboard
In this assignment, we aim to evaluate your software development skills. Please focus
on practicality and avoid over-engineering your solution.
Objective:
Develop simple RESTful APIs using C# (ASP.NET Core) to manage products and create a
React frontend to display and interact with the data.
Backend (C# ASP.NET Core):
1. REST API Design:
o Create APIs to manage products with the following functionalities:
▪ Register a new product with details such as:
▪ Category (Food, Electronics, Clothes...)
▪ Name
▪ Product Code
▪ Price
▪ SKU
▪ Stock Quantity
▪ Date Added
▪ Retrieve a list of products.

2. Database:
o For us to test your solution easily; please use an embedded database like
SQL Server Express, SQLite for local file storage. (Alternatively, you may
use other database solutions)

Frontend (React):

o DataTable: Implement a table to display the list of products with their
details.
o Graph: Create two graphs to visually represent product data. The graphs
should include:
▪ Total stock quantity per category.

▪ Total number of products added in different time periods (e.g. This
week, This Month, This Year)

o In addition to the data created with your new API, you can insert extra
mock data in advance to better demonstrate the graph’s functionality.

Deliverables:
1. Documentation:
o Provide a README file with clear and simple setup instructions, API
endpoints documentation.
o If required, please provide SQL scripts or detailed initialization steps for
setting up the database schema and inserting initial mock data.

2. (Optional) Dockerization:
o It’s a nice-to-have to containerize your application using Docker.
Provide a Docker file and instructions for building and running the
container.
