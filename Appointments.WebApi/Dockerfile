#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Appointments.WebApi/Appointments.WebApi.csproj", "Appointments.WebApi/"]
COPY ["Appointments.Persistence/Appointments.Persistence.csproj", "Appointments.Persistence/"]
COPY ["Appointments.Application/Appointments.Application.csproj", "Appointments.Application/"]
COPY ["Appointments.Domain/Appointments.Domain.csproj", "Appointments.Domain/"]
RUN dotnet restore "Appointments.WebApi/Appointments.WebApi.csproj"
COPY . .
WORKDIR "/src/Appointments.WebApi"
RUN dotnet build "Appointments.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Appointments.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:1001
ENTRYPOINT ["dotnet", "Appointments.WebApi.dll"]