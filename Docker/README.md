# **Docker containers**

>[1. Ingredients](#ingredients)
>
>[2. Include](#include)

---

### **Ingredients:**

1. Python
    1.1. Flask (free): https://flask.palletsprojects.com/en/2.3.x/installation/#install-flask
    1.2. VS Code (free): https://code.visualstudio.com/download
    1.3. Git (free): https://git-scm.com/downloads
    1.4. Docker (free): https://www.docker.com/products/docker-desktop/
2. Java
    2.1. IntelliJ (free): https://www.jetbrains.com/idea/download/?section=windows
    2.2. VS Code (free): https://code.visualstudio.com/download
    2.3. Git (free): https://git-scm.com/downloads
    2.4. Docker (free): https://www.docker.com/products/docker-desktop/
3. Go
    3.1. VS Code (free): https://code.visualstudio.com/download
    3.2. Git (free): https://git-scm.com/downloads
    3.3. Docker (free): https://www.docker.com/products/docker-desktop/
4. .NET
    4.1. .NET 6 SDK (free): https://dotnet.microsoft.com/en-us/download/dotnet/6.0
    4.2. VS Code (free): https://code.visualstudio.com/download
    4.3. Git (free): https://git-scm.com/downloads
    4.4. Docker (free): https://www.docker.com/products/docker-desktop/

---

### **Chapter I: Build images**

> ...
```
dotnet new webapp -n myWebApp -o src --no-https --framework net6.0
```

> ...
```
docker build --tag dotnet-docker .
```

> ...
```
docker images
```

> ...
```
docker tag dotnet-docker:latest dotnet-docker:v1.0.0
```

> ...
```
docker rmi dotnet-docker:v1.0.0
```

#### [🔼 Back to top](#docker-containers)

---

### **Chapter II: Run containers**

> ...
```
docker run dotnet-docker
```

> ...
```
docker run --publish 5000:80 dotnet-docker
```

> ...
```
docker run -d -p 5000:80 dotnet-docker
```

> ...
```
docker ps
```

> ...
```
docker stop <containerID>
```

> ...
```
docker ps -a
```

> ...
```
docker restart <containerID>
```

> ...
```
docker ps --all
```

> ...
```
docker rm <containerID>
```

> ...
```
docker run -d -p 5000:80 --name dotnet-app dotnet-docker
```

---

### **Chapter III: Develop app**

> ...
```
docker volume create postgres-data
```

```
docker network create postgres-net
```

```
docker run --rm -d -v postgres-data:/var/lib/postgresql/data --network postgres-net --name db -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=example postgres
```

docker exec -ti db psql -U postgres
Press CTRL-D to exit the interactive terminal.


cd /path/to/dotnet-docker/src
```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

```
docker build --tag dotnet-docker .
```

```
docker ps
```

```
docker stop dotnet-app
```

```
docker run --rm -d --network postgres-net --name dotnet-app -p 5000:80 dotnet-docker
```

```
docker run --rm -d --network postgres-net --name db-admin -p 8080:8080 adminer
```

Specify the following in the login page and then click Login:

System: PostgreSQL
Server: db
Username: postgres
Password: example
Database: my_db


```
docker stop db-admin dotnet-app db
```

```
docker compose up --build
```

```
docker compose down
```

```
docker compose up --build -d
```

---

### **Chapter IV: Run your tests**

cd /path/to/dotnet-docker
```
dotnet new xunit -n myWebApp.Tests -o tests --framework net6.0
```

```
dotnet add package Testcontainers --version 2.3.0
```

```
dotnet test tests
```

---

### **Chapter IV: Configure CI/CD**












