FROM nginx:alpine 
WORKDIR /var/www/web
COPY dist/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80