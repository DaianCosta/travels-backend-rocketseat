#!/bin/bash
check_sucessful(){
    if [ $? != 0 ];
    then
        echo "Error Execution"
        exit 1
    fi
}

sonar_build() {
    docker build -t ${PROJECT_NAME}-sonar:${VERSION} -f devops/application/sonar/Dockerfile .
}

sonar_execute() {

    docker run \
        --rm \
        --mount source=${VOlUME_NAME},target=/app \
        -e VERSION="${VERSION}" \
        -e PROJECT_NAME="${PROJECT_NAME}" \
        -e SONAR_ORGANIZATION="${SONAR_ORGANIZATION}" \
        -e SONAR_HOST="${SONAR_HOST}" \
        -e SONAR_TOKEN="${SONAR_TOKEN}" \
        -e SONAR_EXCLUSIONS="**/Migrations/**" \
        -e SONAR_COVERAGE_EXCLUSIONS="**/Models/**,**/Migrations/**,**/Enums/**,**/Migrations/**,**/DbContexts/**,**/Entities/**,**/devops/**,**/Program.cs,**/Startup.cs" \
        -e BRANCH=${BRANCH} \
        ${PROJECT_NAME}-sonar:${VERSION}
        check_sucessful

    docker rmi ${PROJECT_NAME}-sonar:${VERSION}
        check_sucessful
    
    docker volume rm ${VOlUME_NAME}
        check_sucessful
}

VERSION="1.0.${GITHUB_RUN_NUMBER}"
VOlUME_NAME="${PROJECT_NAME}-volume-${VERSION}"
BRANCH=`echo ${GITHUB_REF} | sed "s/refs\/heads\///g"`

sonar_build
    check_sucessful

sonar_execute
    check_sucessful