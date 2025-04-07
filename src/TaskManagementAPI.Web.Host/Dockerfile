# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/TaskManagementAPI.Web.Host/TaskManagementAPI.Web.Host.csproj", "src/TaskManagementAPI.Web.Host/"]
COPY ["src/TaskManagementAPI.Web.Core/TaskManagementAPI.Web.Core.csproj", "src/TaskManagementAPI.Web.Core/"]
COPY ["src/TaskManagementAPI.Application/TaskManagementAPI.Application.csproj", "src/TaskManagementAPI.Application/"]
COPY ["src/TaskManagementAPI.Core/TaskManagementAPI.Core.csproj", "src/TaskManagementAPI.Core/"]
COPY ["src/TaskManagementAPI.EntityFrameworkCore/TaskManagementAPI.EntityFrameworkCore.csproj", "src/TaskManagementAPI.EntityFrameworkCore/"]
RUN dotnet restore "src/TaskManagementAPI.Web.Host/TaskManagementAPI.Web.Host.csproj"

COPY src/ src/
WORKDIR "/src/src/TaskManagementAPI.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 80
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "TaskManagementAPI.Web.Host.dll"]
