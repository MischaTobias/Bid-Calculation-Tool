# Use the official MySQL image as a base
FROM mysql:latest

# Set environment variables
ENV MYSQL_DATABASE=progi_bid_calculation
ENV MYSQL_ROOT_PASSWORD=progi2024

# Copy the SQL file to the Docker container
COPY progi_bid_calculation.sql /docker-entrypoint-initdb.d/

# Expose the MySQL port
EXPOSE 3306
