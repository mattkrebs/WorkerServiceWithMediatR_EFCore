FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TestWorkerWithMediatR/TestWorkerWithMediatR.csproj", "TestWorkerWithMediatR/"]
RUN dotnet restore "TestWorkerWithMediatR/TestWorkerWithMediatR.csproj"
COPY . .
WORKDIR "/src/TestWorkerWithMediatR"
RUN dotnet build "TestWorkerWithMediatR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestWorkerWithMediatR.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWorkerWithMediatR.dll"]