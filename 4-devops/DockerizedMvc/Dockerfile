FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

ENV ASPNETCORE_URLS http://*:80

# ENTRYPOINT is similar to CMD
# technically... ENTRYPOINT defaults to /bin/sh -c
#    ("run whatever we type after this as a shell command")
# and CMD is appended to ENTRYPOINT for that docker run initial command.
ENTRYPOINT ["dotnet", "out/DockerizedMvc.dll"]
