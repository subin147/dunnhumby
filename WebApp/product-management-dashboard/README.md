# Product Management Dashboard

This guide will help you set up the Product Management Dashboard React application.

## Prerequisites

Ensure you have the following installed on your system:

1. **Node.js** (version 18 or later)
   - Download and install from [Node.js Official Website](https://nodejs.org/).
2. **npm** (Node Package Manager, comes with Node.js).
3. **Git** (for version control and cloning the repository).
   - Download and install from [Git Official Website](https://git-scm.com/).

---

## Setup Steps

1. **Clone the Repository**

   Open a terminal and run:
   ```bash
   git clone <repository-url>
   cd product-management-dashboard
   ```

2. **Install Dependencies**

   Run the following command to install all required npm packages:
   ```bash
   npm install
   ```

3. **Environment Variables**

   Create a `.env` file in the root of the project and configure the required variables:
   ```env
   REACT_APP_API_URL=http://localhost:5000/api
   REACT_APP_ENV=development
   ```
   Replace `http://localhost:5000/api` with the actual API URL if different.

4. **Start the Application**

   Run the application in development mode:
   ```bash
   npm start
   ```

   The application will start at [http://localhost:3000](http://localhost:3000).

5. **Build for Production**

   To create a production build, run:
   ```bash
   npm run build
   ```
   The optimized production build will be available in the `build` directory.

6. **Run Tests**

   To execute tests, run:
   ```bash
   npm test
   ```

---


## Libraries Used

- **React**: Frontend library.
- **Material-UI**: UI framework.
---


