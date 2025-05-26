
https://docs.docker.com/language/java/

### **Chapter I: Build images**

docker build --tag java-docker .

docker images

docker tag java-docker:latest java-docker:v1.0.0

docker rmi java-docker:v1.0.0

---

### **Chapter II: Run containers**

docker run java-docker

curl --request GET \
--url http://localhost:8080/actuator/health \
--header 'content-type: application/json'
curl: (7) Failed to connect to localhost port 8080: Connection refused


docker run --publish 8080:8080 java-docker

curl --request GET \
--url http://localhost:8080/actuator/health \
--header 'content-type: application/json'
{"status":"UP"}


docker run -d -p 8080:8080 java-docker

docker ps

docker stop trusting_beaver

docker ps

docker ps -a

docker ps --all

docker run --rm -d -p 8080:8080 --name springboot-server java-docker