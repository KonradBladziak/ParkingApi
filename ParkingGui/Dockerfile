### STAGE 1: Build ###
FROM node:18.15-alpine AS build
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build
### STAGE 2: Run ###
FROM nginx:1.25-alpine
COPY --from=build /usr/src/app/dist/parking-gui /usr/share/nginx/html

#ddocker run -t -d -p 4200:80 --name=gui gui