# Build Stage
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build

WORKDIR /src

COPY . .

RUN nuget restore EmployeeManagementSolution.sln

RUN msbuild EmployeeManagementSolution.sln /p:Configuration=Release

# Runtime Stage
FROM mcr.microsoft.com/dotnet/framework/runtime:4.8

WORKDIR /app

COPY --from=build /src/EmployeeManagmentProject/bin/Release/ .

ENTRYPOINT ["EmployeeManagmentProject.exe"]
