#!/bin/bash
check_sucessful(){
  if [ $? != 0 ];
  then
    echo "Error Execution"
    exit 1
  fi
}

test_volume(){
    docker volume create ${VOlUME_NAME}
}

test_build() {
    docker build -t ${PROJECT_NAME}-test:${VERSION} -f devops/application/test/Dockerfile .
}

test_execute() {
    docker run --rm \
        --mount source=${VOlUME_NAME},target=/app \
        -e TEST_EXCLUSIONS="**/Models/%2c**/Migrations/%2c**/Enums/%2c**/Migrations/%2c**/DbContexts/%2c**/Entities/%2c/devops/%2c**/Program.cs%2c**/Startup.cs" \
        ${PROJECT_NAME}-test:${VERSION}
        check_sucessful

    docker rmi ${PROJECT_NAME}-test:${VERSION}
        check_sucessful        
}

VERSION="1.0.${GITHUB_RUN_NUMBER}"
VOlUME_NAME="${PROJECT_NAME}-volume-${VERSION}"

test_volume
    check_sucessful

test_build
    check_sucessful

test_execute
    check_sucessful
