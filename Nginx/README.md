# NGINX

## API Gateway

**Responsibilities of API Gateway:**
* Authentication
* Request Routing
* Rate Limiter (Traffic Flow)
* Exception Handling

## API Management

**Responsibilities of API Managemnet**
* Policy Management
* Analytics & Monitoring
* Developer Documentation

## Installing [NGINX](https://www.nginx.com)

Instal nginx on ubuntu:
```
sudo apt update
sudo apt install nginx
```

Working with nginx service:
```
sudo service nginx status
sudo service nginx start
sudo service nginx stop
sudo service nginx reload
```

**You can use NGINX as:**
* Web server
* Load balancer
* Reverse proxy
* Forward proxy
* Cache manager
* ...

## Using nginx as **Webserver**
Edit nginx config file:

```
sudo nano /etc/nginx/nginx.conf
```

Clear and replace with:

```
http {
    server {
        listen 8181;
    }
}

events { }
```

Reload nginx service

```
sudo service nginx reload
```

Now you can see default nginx webserver page at http://localhost:8181.

To replace a page with default page create an *index.html* page in any folder:

```
sudo mkdir Documents/nginx
sudo nano Documents/nginx/index.html
```

Add your content:

```
<html>
    <head>
        <title>
            My customized nginx page
        </title>
    </head>
    <body>
        Hello, this a my nginx customized page
    </body>
</html>
```

Now customize *nginx.conf* *__server__* part:

```
server {
    listen 8181;
    root /home/roozbeh/Documents/nginx/;
}
```

Reload nginx service and check http://localhost:8181.
