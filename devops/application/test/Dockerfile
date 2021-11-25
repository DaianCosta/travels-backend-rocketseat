FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app

COPY . .

CMD dotnet restore && \
    dotnet build && \
    dotnet test /p:CollectCoverage=true \
        /p:CoverletOutputFormat=opencover \
        /p:ExcludeByFile=${TEST_EXCLUSIONS}