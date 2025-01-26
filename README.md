# Product Management Dashboard

This repository contains a full-stack product management application with:

1. A **React frontend** for the user interface.
2. A **.NET 8 backend** for API endpoints and business logic.

The app is containerized using Docker, and you can run both the frontend and backend services together with Docker Compose.

---

## **Prerequisites**

Before you begin, make sure you have the following installed:

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/install/)

---

## **Getting Started**

### **Clone the Repository**
```bash
git clone https://github.com/subin147/dunnhumby.git
cd dunnhumby
```

---

## **Running the Application**

1. **Build the Docker Images**
   ```
   docker-compose build
   ```

2. **Start the Services**
   ```
   docker-compose up
   ```

3. **Access the Application:**
   - **React Frontend:** Open [http://localhost:3000](http://localhost:3000) in your browser.
   - **.NET Backend API:** Access [http://localhost:5000](http://localhost:5000) for API endpoints.

---

## **Stopping the Application**

To stop the application, run:
```
docker-compose down
```

This will stop and remove the containers.

---

## **Environment Variables**

### Backend (`.NET API`)
The backend service uses the `ASPNETCORE_ENVIRONMENT` variable, set to `Development` by default in the `docker-compose.yml`.

### Frontend (`React App`)
Environment variables for the frontend can be set in a `.env` file located in the `WebApp/product-management-dashboard` directory.

---

### Ports in Use
If the ports (3000 or 5000) are already in use, update the `docker-compose.yml` file to use different ports.

---
