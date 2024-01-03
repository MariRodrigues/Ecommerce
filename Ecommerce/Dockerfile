#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Ecommerce/Ecommerce.csproj", "Ecommerce/"]
COPY ["Ecommerce.Application/Ecommerce.Application.csproj", "Ecommerce.Application/"]
COPY ["Ecommerce.Domain/Ecommerce.Domain.csproj", "Ecommerce.Domain/"]
COPY ["Ecommerce.Infra/Ecommerce.Infra.csproj", "Ecommerce.Infra/"]
RUN dotnet restore "Ecommerce/Ecommerce.csproj"
COPY . .
WORKDIR "/src/Ecommerce"
RUN dotnet build "Ecommerce.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.dll"]