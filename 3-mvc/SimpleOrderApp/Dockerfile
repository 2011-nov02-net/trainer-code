# usage instructions:
# 1. docker build -t simpleorder:1.0 .
# 2. docker run -it --rm -p 8000:80 simpleorder:1.0

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build

WORKDIR /app/src

COPY SimpleOrderApp.App/*.csproj SimpleOrderApp.App/
COPY SimpleOrderApp.Data/*.csproj SimpleOrderApp.Data/
COPY SimpleOrderApp.Domain/*.csproj SimpleOrderApp.Domain/
COPY SimpleOrderApp.UnitTests/*.csproj SimpleOrderApp.UnitTests/
COPY SimpleOrderApp.WebApp/*.csproj SimpleOrderApp.WebApp/
COPY *.sln ./
RUN dotnet restore

# if the csproj file hasn't changed, we can cache up to this point
# (saves time on subsequent builds)

# copy rest of build context into /app/src
COPY . ./

# publish to /app/publish
RUN dotnet publish -o ../publish

FROM mcr.microsoft.com/dotnet/aspnet:3.1-alpine AS runtime

WORKDIR /app

# copy assemblies from build stage into this stage
COPY --from=build /app/publish ./

CMD dotnet SimpleOrderApp.WebApp.dll
