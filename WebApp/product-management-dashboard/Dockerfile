# Use Node.js to build the React app
FROM node:18-alpine AS build
WORKDIR /app

# Install dependencies
COPY package*.json ./
RUN npm install

# Copy the rest of the app files and build
COPY . ./
RUN npm run build

# Use a lightweight server to serve the app
FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=build /app/build .

# Expose port 3000
EXPOSE 3000
