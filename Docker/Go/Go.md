Source:
https://docs.docker.com/language/golang/

https://go.dev/
https://go.dev/dl/

---

### Build images

git clone https://github.com/docker/docker-gs-ping

go run main.go

curl http://localhost:8080/

docker build --tag docker-gs-ping .

docker image ls

docker image tag docker-gs-ping:latest docker-gs-ping:v1.0

docker image rm docker-gs-ping:v1.0

docker build -t docker-gs-ping:multistage -f Dockerfile.multistage .

---

### Run containers

docker run docker-gs-ping

curl http://localhost:8080/

docker run --publish 8080:8080 docker-gs-ping

docker run -d -p 8080:8080 docker-gs-ping

docker ps

docker run -d -p 8080:8080 --name rest-server docker-gs-ping

---

### Develop your app

docker volume create roach

docker volume list

docker network create -d bridge mynet

docker network list

docker run -d --name roach --hostname db --network mynet -p 26257:26257 -p 8080:8080 -v roach:/cockroach/cockroach-data cockroachdb/cockroach:latest-v20.1 start-single-node --insecure

docker exec -it roach ./cockroach sql --insecure
    CREATE DATABASE mydb;
    CREATE USER totoro;
    GRANT ALL ON DATABASE mydb TO totoro;



docker container list

docker compose config

docker exec -it roach ./cockroach sql --insecure