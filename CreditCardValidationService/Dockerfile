#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CreditCardValidationService/CreditCardValidationService.csproj", "CreditCardValidationService/"]
COPY ["CreditCardValidationService.Contracts/CreditCardValidationService.Contracts.csproj", "CreditCardValidationService.Contracts/"]
COPY ["CreditCardValidationService.Models/CreditCardValidationService.Models.csproj", "CreditCardValidationService.Models/"]
COPY ["CreditCardValidationService.Services/CreditCardValidationService.Services.csproj", "CreditCardValidationService.Services/"]
RUN dotnet restore "CreditCardValidationService/CreditCardValidationService.csproj"
COPY . .
WORKDIR "/src/CreditCardValidationService"
RUN dotnet build "CreditCardValidationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CreditCardValidationService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreditCardValidationService.dll"]