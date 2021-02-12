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

* **[`docker login`](https://docs.docker.com/engine/reference/commandline/login/)** to login to a registry.
* **[`docker logout`](https://docs.docker.com/engine/reference/commandline/logout/)** to logout from a registry.
* **[`docker pull`](https://docs.docker.com/engine/reference/commandline/pull/)** pulls an image from registry to local machine.
* **[`docker push`](https://docs.docker.com/engine/reference/commandline/push/)** pushes an image to the registry from local machine.
* *[`docker search`](https://docs.docker.com/engine/reference/commandline/search/)* searches registry for image.

```
sudo docker pull <images_name>:<image_tag(optional)>
sudo docker pull redis
sudo docker pull redis:latest
```

## Images
 Images are templates for docker containers. You can use folowing commands to check and control *__docker images__* lifecycle:

* **[`docker images`](https://docs.docker.com/engine/reference/commandline/images/)** shows all images.
* **[`docker rmi`](https://docs.docker.com/engine/reference/commandline/rmi/)** removes an image.
* **[`docker tag`](https://docs.docker.com/engine/reference/commandline/tag/)** tags an image to a name (local or registry).
* *[`docker import`](https://docs.docker.com/engine/reference/commandline/import/)* creates an image from a tarball.
* *[`docker build`](https://docs.docker.com/engine/reference/commandline/build/)* creates image from Dockerfile.
* *[`docker commit`](https://docs.docker.com/engine/reference/commandline/commit/)* creates image from a container, pausing it temporarily if it is running.
* *[`docker load`](https://docs.docker.com/engine/reference/commandline/load/)* loads an image from a tar archive as STDIN, including images and tags (as of 0.7).
* *[`docker save`](https://docs.docker.com/engine/reference/commandline/save/)* saves an image to a tar archive stream to STDOUT with all parent layers, tags & versions (as of 0.7).
* *[`docker history`](https://docs.docker.com/engine/reference/commandline/history/)* shows history of image.

```
sudo docker images
sudo docker rmi <image_id>
```

## Containers

Containers are basic isolated Docker process. Containers are to Virtual Machines as threads are to processes.

* **[`docker ps`](https://docs.docker.com/engine/reference/commandline/ps/)** shows running containers.
* **[`docker run`](https://docs.docker.com/engine/reference/commandline/run/)** creates and starts a container in one operation.
* **[`docker rm`](https://docs.docker.com/engine/reference/commandline/rm/)** deletes a container.
* **[`docker update`](https://docs.docker.com/engine/reference/commandline/update/)** updates a container's resource limits.
* **[`docker start`](https://docs.docker.com/engine/reference/commandline/start/)** starts a container so it is running.
* **[`docker stop`](https://docs.docker.com/engine/reference/commandline/stop/)** stops a running container.
* **[`docker restart`](https://docs.docker.com/engine/reference/commandline/restart/)** stops and starts a container.
* *[`docker create`](https://docs.docker.com/engine/reference/commandline/create/)* creates a container but does not start it.
* *[`docker rename`](https://docs.docker.com/engine/reference/commandline/rename/)* allows the container to be renamed.
* *[`docker pause`](https://docs.docker.com/engine/reference/commandline/pause/)* pauses a running container, "freezing" it in place.
* *[`docker unpause`](https://docs.docker.com/engine/reference/commandline/unpause/)* will unpause a running container.
* *[`docker wait`](https://docs.docker.com/engine/reference/commandline/wait/)* blocks until running container stops.
* *[`docker kill`](https://docs.docker.com/engine/reference/commandline/kill/)* sends a SIGKILL to a running container.

```
sudo docker run <image_name>:<image_tag(optional)>
sudo docker run redis
```

> *`docker ps -a`* shows running and stopped containers.

```
sudo docker ps
sudo docker ps -a
```

> Use *`-d`* to run container in detached mode(run container in background).
> Use *`--name`* to specify your customized name to container.
> If you want a transient container, *`docker run --rm`* will remove the container after it stops.

```
sudo docker run -d redis
sudo docker run --rm --name myRedis redis
sudo docker run --name myRedis -d redis
```
> Use *`--restart`*  flag to control whether your containers start automaticly when they exit, or when Docker restarts.
> To configure the restart policy for a container, use the *`--restart`*  flag when using the *`docker run`* command. The value of the *`--restart`*  flag can be any of the following:

Flag | Description
-----|-------------
no | Do not automatically restart the container. (the default)
on-failure | Restart the container if it exits due to an error, which manifests as a non-zero exit code.
always | Always restart the container if it stops. If it is manually stopped, it is restarted only when Docker daemon restarts or the container itself is manually restarted. 
unless-stopped | Similar to *always*, except that when the container is stopped (manually or otherwise), it is not restarted even after Docker daemon restarts.

> You can use *`docker update`* to update restart behaviour of one or some of the containers:

```
sudo docker run -d --restart unless-stopped redis

sudo docker update --restart unless-stopped redis
sudo docker update --restart unless-stopped $(docker ps -q)
```

## Debugging Containers

* **[`docker logs`](https://docs.docker.com/engine/reference/commandline/logs/)** gets logs from container. (You can use a custom log driver, but logs is only available for json-file and journald in 1.10).
* **[`docker exec`](https://docs.docker.com/engine/reference/commandline/exec/)** to execute a command in container.
* **[`docker attach`](https://docs.docker.com/engine/reference/commandline/attach/)** will connect to a running container.
* *[`docker inspect`](https://docs.docker.com/engine/reference/commandline/inspect/)* looks at all the info on a container (including IP address).
* *[`docker events`](https://docs.docker.com/engine/reference/commandline/events/)* gets events from container.
* *[`docker port`](https://docs.docker.com/engine/reference/commandline/port/)* shows public facing port of container.
* *[`docker top`](https://docs.docker.com/engine/reference/commandline/top/)* shows running processes in container.
* *[`docker stats`](https://docs.docker.com/engine/reference/commandline/stats/)* shows containers' resource usage statistics.
* *[`docker diff`](https://docs.docker.com/engine/reference/commandline/diff/)* shows changed files in the container's FS.
* *[`docker cp`](https://docs.docker.com/engine/reference/commandline/cp/)* copies files or folders between a container and the local filesystem.
* *[`docker export`](https://docs.docker.com/engine/reference/commandline/export/)* turns container filesystem into tarball archive stream to STDOUT.

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

## Docker Network

* **[`docker network ls`](https://docs.docker.com/engine/reference/commandline/network_ls/)** List networks
* **[`docker network inspect`](https://docs.docker.com/engine/reference/commandline/network_inspect/)** NAME Display detailed information on one or more networks.
* **[`docker network create`](https://docs.docker.com/engine/reference/commandline/network_create/)** NAME Create a new network (default type: bridge).
* **[`docker network rm`](https://docs.docker.com/engine/reference/commandline/network_rm/)** NAME Remove one or more networks by name or identifier. No containers can be connected to the network when deleting it.
* **[`docker prune`](https://docs.docker.com/engine/reference/commandline/network_prune/)** remove all unused networks
* *[`docker network connect`](https://docs.docker.com/engine/reference/commandline/network_connect/)* NETWORK CONTAINER Connect a container to a network
* *[`docker network disconnect`](https://docs.docker.com/engine/reference/commandline/network_disconnect/)* NETWORK CONTAINER Disconnect a container from a network

By default there are 3 types of networks included in a docker host:
1. host
2. none
3. bridge

You can see all these networks by executing:

```
sudo docker network ls
```
You can connect to a docker container, out of docker host with an assigned docker **host** network by using *`-p`* when running a container.
In the following example we can connect to myRedis container through port 6000:

```
sudo docker run --name myRedis -d -p 6000:6379 redis
```

There is a default bridge network in docker host. Any container in a docker host has an IP address in default bridge network that can connect to other containers through. You can find container assigned IP address by *incpect*ing the default bridge network. Create two alpine container named alpine1 and alpine 2 and inspect bridge network:

```
sudo docker run -itd --name=alpine1 alpine
sudo docker run -itd --name=alpine2 alpine

sudo docker network inspect <bridge_network_id>

sudo docker attach alpine1
```
You can *attach* each these alpine container and ping other one through bridge network by *IP address* but not its *name*.
To ping other containers by ints names you need to create a bridge network yourself and assign it to containers by using *`--network`*:

```
sudo docker network create --driver=bridge my-network
sudo docker network ls

sudo docker rm -f $(sudo docker ps -aq)
sudo docker run -itd --name=alpine1 --network=my-network alpine
sudo docker run -itd --name=alpine2 --network=my-network alpine
sudo docker network inspect my-network

sudo docker attach alpine1
```

## Docker Volume

Docker volumes are [free-floating filesystems](https://docs.docker.com/storage/volumes/). They don't have to be connected to a particular container.

* **[docker volume ls](https://docs.docker.com/engine/reference/commandline/volume_ls/)** List all the volumes known to Docker. 
* **[docker volume inspect](https://docs.docker.com/engine/reference/commandline/volume_inspect/)** Returns information about a volume.
* **[docker volume create](https://docs.docker.com/engine/reference/commandline/volume_create/)** Creates a new volume that containers can consume and store data in.
* **[docker volume rm](https://docs.docker.com/engine/reference/commandline/volume_rm/)** Remove one or more volumes. You cannot remove a volume that is in use by a container.
* **[docker volume prune](https://docs.docker.com/engine/reference/commandline/volume_prune/)** Remove all unused local volumes. Unused local volumes are those which are not referenced by any containers

> For example you can assign a volume to *SQL Server* container data & log files by using *`-v`* :

```
sudo docker volume create sqlvolume
sudo docker volume ls

sudo docker run --name mssql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=myStrongPassword' -p 1433:1433 -v sqlvolume:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2019-CU8-ubuntu-16.04
```
> or assign redis container *redis.conf* file to a specified operating system path to configure it later more easily:

```
sudo mkdir /etc/redis

sudo docker run -d -v /etc/redis:/usr/local/etc/redis -p 6379:6379 --name myredis redis redis-server /usr/local/etc/redis/redis.conf
```

> Here we have an example of runing *Seq* monitoring system in a docker container:

```
sudo mkdir /etc/seq
sudo mkdir /etc/seq/data

sudo docker run --name seq -d -v /etc/seq/data:/data --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:5341 -p 80:80 datalust/seq:latest
```

## Private Docker Registry

You can create a local private docker registry as follows:

```
sudo docker run -d -p 5000:5000 --restart always --name registry registry
```

or

```
sudo mkdir /mnt/registry

sudo docker run -d -p 5000:5000 --restart=always --name registry -v /mnt/registry:/var/lib/registry registry:2
```

Now you can push any images to your local registry:

```
sudo docker pull ubuntu
sudo docker tag ubuntu localhost:5000/ubuntu
sudo docker push localhost:5000/ubuntu
```

> To push an image to a remote registry from a client, edit your *`/etc/docker/daemon.json`* file(Create the file if it dosent exist).
> In windows and mac you must change *`insecure-registries`* part in docker desktop settings.

```
{
  "insecure-registries" : ["<my_registry_address>:5000"]
}
```

> You can see your pushed images from client:

```
sudo curl -X GET http://<my_registry_address>:5000/v2/_catalog
```

## Docker File


## Docker Compose