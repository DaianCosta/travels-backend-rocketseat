FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

RUN apt-get update -y && apt-get upgrade -y && \
    apt-get install -y software-properties-common && \
    apt-get install -y wget && \
    apt install -y openjdk-11-jdk && \
    dotnet tool install -g dotnet-sonarscanner

ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /app
COPY . .

CMD dotnet build-server shutdown && \
    dotnet sonarscanner begin /o:${SONAR_ORGANIZATION} \
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