https://docs.docker.com/get-docker/

https://git-scm.com/downloads

https://www.python.org/downloads/


docker init:

Welcome to the Docker Init CLI!

This utility will walk you through creating the following files with sensible defaults for your project:
  - .dockerignore
  - Dockerfile
  - compose.yaml

Let's get started!

? What application platform does your project use? Python
? What version of Python do you want to use? 3.11.4
? What port do you want your app to listen on? 5000
? What is the command to run your app? python3 -m flask run --host=0.0.0.0

---

docker images

docker tag python-docker:latest python-docker:v1.0.0

---

### **Chapter II: Run containers**

docker run python-docker

docker run --publish 8000:5000 python-docker

curl localhost:8000

docker run -d -p 8000:5000 python-docker

> **List containers:**
```
docker ps
```

docker stop wonderful_kalam

docker ps -a

docker ps --all

docker stop wonderful_kalam

docker run -d -p 8000:5000 --name rest-server python-docker

---

### **Chapter III: Develop your app**

docker volume create db-data

docker network create postgresnet

docker run --rm -d --mount type=volume,src=db-data,target=/var/lib/postgresql/data -p 5432:5432 --network postgresnet --name db -e POSTGRES_PASSWORD=mysecretpassword -e POSTGRES_DB=example postgres

docker exec -it db psql -U postgres

psql (15.3 (Debian 15.3-1.pgdg110+1))
Type "help" for help.

postgres=#

git clone https://github.com/docker/python-docker-dev



docker init
Welcome to the Docker Init CLI!

This utility will walk you through creating the following files with sensible defaults for your project:
  - .dockerignore
  - Dockerfile
  - compose.yaml

Let's get started!

? What application platform does your project use? Python
? What version of Python do you want to use? 3.11.4
? What port do you want your app to listen on? 5000
? What is the command to run your app? python3 -m flask run --host=0.0.0.0



docker build -t python-docker-dev .

docker run --rm -d --network postgresnet --name rest-server -p 8000:5000 -e POSTGRES_PASSWORD=mysecretpassword python-docker-dev


curl http://localhost:8000/initdb

curl http://localhost:8000/widgets