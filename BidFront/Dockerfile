# Stage 1: Build the Angular app
FROM node:current-alpine3.20 AS build

# Set working directory
WORKDIR /app

# Copy the package.json and package-lock.json files
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application files
COPY . .

# Build the Angular app
RUN npm run build

# Stage 2: Serve the Angular app using NGINX
FROM nginx:alpine

# Copy the build output from Stage 1
COPY --from=build /app/dist/bid-front /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start NGINX
CMD ["nginx", "-g", "daemon off;"]
