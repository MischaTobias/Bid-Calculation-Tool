FROM node:18-alpine AS build

WORKDIR /app

COPY package*.json ./
RUN npm install

COPY . .
RUN npm run build --omit=dev

# List the contents of the build directory for debugging
RUN ls -la /app/dist/bid-front

FROM nginx:alpine
COPY --from=build /app/dist/bid-front/browser /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
