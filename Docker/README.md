# Docker

## Installing [Docker](https://www.docker.com)

To install docker on ubuntu:

```
sudo apt update
sudo apt install apt-transport-https ca-certificates curl gnupg-agent software-properties-common
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -

sudo apt-key fingerprint 0EBFCD88
sudo add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable"

sudo apt update
sudo apt install docker-ce docker-ce-cli containerd.io
```

To install docker on other operatig systems pleas goto https://www.docker.com/get-started

To check if Docker has installed corectly:

```
sudo docker run hello-world
```

And you sould see the folowing output:

```
Hello from Docker!
This message shows that your installation appears to be working correctly.

To generate this message, Docker took the following steps:
 1. The Docker client contacted the Docker daemon.
 2. The Docker daemon pulled the "hello-world" image from the Docker Hub.
    (amd64)
 3. The Docker daemon created a new container from that image which runs the
    executable that produces the output you are currently reading.
 4. The Docker daemon streamed that output to the Docker client, which sent it
    to your terminal.

To try something more ambitious, you can run an Ubuntu container with:
 $ docker run -it ubuntu bash

Share images, automate workflows, and more with a free Docker ID:
 https://hub.docker.com/

For more examples and ideas, visit:
 https://docs.docker.com/get-started/
```

## Check Version
* [`docker version`](https://docs.docker.com/engine/reference/commandline/version/) shows which version of docker you have running.

Get the server version:

```
docker version --format '{{.Server.Version}}'
```

You can also dump raw JSON data:

```
docker version --format '{{json .}}'
```
## Registry & Repository

* **[`docker login`](https://docs.docker.com/engine/reference/commandline/login/) to login to a registry.**
* **[`docker logout`](https://docs.docker.com/engine/reference/commandline/logout/) to logout from a registry.**
* **[`docker pull`](https://docs.docker.com/engine/reference/commandline/pull/) pulls an image from registry to local machine.**
* **[`docker push`](https://docs.docker.com/engine/reference/commandline/push/) pushes an image to the registry from local machine.**
* [`docker search`](https://docs.docker.com/engine/reference/commandline/search/) *searches registry for image.*

```
sudo docker pull <images_name>:<image_tag(optional)>
sudo docker pull redis
sudo docker pull redis:latest
```

## Images
 Images are templates for docker containers. You can use folowing commands to check and control *__docker images__* lifecycle:

* **[`docker images`](https://docs.docker.com/engine/reference/commandline/images/) shows all images.**
* **[`docker rmi`](https://docs.docker.com/engine/reference/commandline/rmi/) removes an image.**
* **[`docker tag`](https://docs.docker.com/engine/reference/commandline/tag/) tags an image to a name (local or registry).**
* [`docker import`](https://docs.docker.com/engine/reference/commandline/import/) *creates an image from a tarball.*
* [`docker build`](https://docs.docker.com/engine/reference/commandline/build/) *creates image from Dockerfile.*
* [`docker commit`](https://docs.docker.com/engine/reference/commandline/commit/) *creates image from a container, pausing it temporarily if it is running.*
* [`docker load`](https://docs.docker.com/engine/reference/commandline/load/) *loads an image from a tar archive as STDIN, including images and tags (as of 0.7).*
* [`docker save`](https://docs.docker.com/engine/reference/commandline/save/) *saves an image to a tar archive stream to STDOUT with all parent layers, tags & versions (as of 0.7).*
* [`docker history`](https://docs.docker.com/engine/reference/commandline/history/) *shows history of image.*

```
sudo docker images
sudo docker rmi <image_id>
```

## Containers

Containers are basic isolated Docker process. Containers are to Virtual Machines as threads are to processes.

* **[`docker ps`](https://docs.docker.com/engine/reference/commandline/ps/) shows running containers.**
* **[`docker run`](https://docs.docker.com/engine/reference/commandline/run/) creates and starts a container in one operation.**
* **[`docker rm`](https://docs.docker.com/engine/reference/commandline/rm/) deletes a container.**
* **[`docker update`](https://docs.docker.com/engine/reference/commandline/update/) updates a container's resource limits.**
* **[`docker start`](https://docs.docker.com/engine/reference/commandline/start/) starts a container so it is running.**
* **[`docker stop`](https://docs.docker.com/engine/reference/commandline/stop/) stops a running container.**
* **[`docker restart`](https://docs.docker.com/engine/reference/commandline/restart/) stops and starts a container.**
* [`docker create`](https://docs.docker.com/engine/reference/commandline/create/) *creates a container but does not start it.*
* [`docker rename`](https://docs.docker.com/engine/reference/commandline/rename/) *allows the container to be renamed.*
* [`docker pause`](https://docs.docker.com/engine/reference/commandline/pause/) *pauses a running container, "freezing" it in place.*
* [`docker unpause`](https://docs.docker.com/engine/reference/commandline/unpause/) *will unpause a running container.*
* [`docker wait`](https://docs.docker.com/engine/reference/commandline/wait/) *blocks until running container stops.*
* [`docker kill`](https://docs.docker.com/engine/reference/commandline/kill/) *sends a SIGKILL to a running container.*

```
sudo docker run <image_name>:<image_tag(optional)>
sudo docker run redis
```

> Use *`-d`* to run container in detached mode(run container in background).
> Use *`--name`* to specify your customized name to container.
> If you want a transient container, *`docker run --rm`* will remove the container after it stops.
> *`docker ps -a`* shows running and stopped containers.

```
sudo docker ps
sudo docker ps -a

sudo docker run -d redis
sudo docker run --rm --name myRedis redis
sudo docker run --name myRedis -d redis
```
## Debugging Containers

* **[`docker logs`](https://docs.docker.com/engine/reference/commandline/logs/) gets logs from container. (You can use a custom log driver, but logs is only available for json-file and journald in 1.10).**
* **[`docker exec`](https://docs.docker.com/engine/reference/commandline/exec/) to execute a command in container.**
* **[`docker attach`](https://docs.docker.com/engine/reference/commandline/attach/) will connect to a running container.**
* [`docker inspect`](https://docs.docker.com/engine/reference/commandline/inspect/) *looks at all the info on a container (including IP address).*
* [`docker events`](https://docs.docker.com/engine/reference/commandline/events/) *gets events from container.*
* [`docker port`](https://docs.docker.com/engine/reference/commandline/port/) *shows public facing port of container.*
* [`docker top`](https://docs.docker.com/engine/reference/commandline/top/) *shows running processes in container.*
* [`docker stats`](https://docs.docker.com/engine/reference/commandline/stats/) *shows containers' resource usage statistics.*
* [`docker diff`](https://docs.docker.com/engine/reference/commandline/diff/) *shows changed files in the container's FS.*
* [`docker cp`](https://docs.docker.com/engine/reference/commandline/cp/) *copies files or folders between a container and the local filesystem.*
* [`docker export`](https://docs.docker.com/engine/reference/commandline/export/) *turns container filesystem into tarball archive stream to STDOUT.*

To see a container log:

```
sudo docker logs <container_id>
```

To enter a running container, attach a new shell process to a running container, use one of the following commands:

```
sudo docker exec -it <container_id> /bin/bash
sudo docker exec -it <container_id> sh
sudo docker attach <container_id>
```