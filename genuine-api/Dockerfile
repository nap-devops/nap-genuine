ARG version
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /source

# copy csproj and restore as distinct layers
COPY ./* ./genuine-api/

RUN dotnet restore genuine-api/genuine-api.csproj
RUN dotnet publish genuine-api/genuine-api.csproj -c release -o /app --no-restore -p:PackageVersion=${version}

##### final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

RUN apt-get -y update
RUN apt-get -y install curl

WORKDIR /app
COPY --from=build /app .
COPY run.bash /app
RUN ls -lrt

EXPOSE 8080

ENTRYPOINT ["./run.bash"]