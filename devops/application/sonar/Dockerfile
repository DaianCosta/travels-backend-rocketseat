FROM ubuntu:20.10

RUN apt-get update -y && apt-get upgrade -y && \
    apt-get install -y software-properties-common && \
    apt-get install -y wget && \
    apt install -y openjdk-11-jdk && \
    wget https://packages.microsoft.com/config/ubuntu/19.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y apt-transport-https && \
    apt-get update && \
    apt-get install -y dotnet-sdk-3.1 && \
    apt-get update && \
    apt-get install -y apt-transport-https && \
    apt-get update && \
    apt-get install -y aspnetcore-runtime-3.1 && \
    apt-get install -y dotnet-runtime-3.1 && \
    dotnet tool install -g dotnet-sonarscanner

ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /app
COPY . .

CMD dotnet build-server shutdown && \
    dotnet sonarscanner begin /o:rocket-seat \
        /d:sonar.verbose=false \
        /v:${VERSION} \
        /n:${PROJECT_NAME} \
        /k:${PROJECT_NAME} \
        /d:sonar.host.url=${SONAR_HOST} \
        /d:sonar.cs.opencover.reportsPaths=Tests/coverage.opencover.xml \
        /d:sonar.login=${SONAR_TOKEN} \
        /d:sonar.exclusions=${SONAR_EXCLUSIONS} \
        /d:sonar.sourceEncoding=UTF-8 \
        /d:sonar.branch.name=${BRANCH} \
        /d:sonar.coverage.exclusions=${SONAR_COVERAGE_EXCLUSIONS} && \
    dotnet build && \
    dotnet sonarscanner end /d:sonar.login=${SONAR_TOKEN}