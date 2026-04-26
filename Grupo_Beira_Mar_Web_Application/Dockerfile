# =========================
# BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o csproj e restaura dependências
COPY ["Grupo_Beira_Mar_Web_Application.csproj", "./"]
RUN dotnet restore

# Copia o restante do código
COPY . .
RUN dotnet publish -c Release -o /app/publish

# =========================
# RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia apenas o resultado publicado
COPY --from=build /app/publish .

# Configuração de porta
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Grupo_Beira_Mar_Web_Application.dll"]