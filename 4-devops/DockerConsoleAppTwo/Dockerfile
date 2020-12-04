# a Dockerfile is a list of instructions for how to build a new image
# from a baseline of some already existing image.

# choose a base image with the dependencies for the thing you're going to copy in (source code now, not assemblies).
FROM mcr.microsoft.com/dotnet/sdk:5.0

# sets current directory for later layers
# and creates it if needed
WORKDIR /app

# copy that thing in
COPY . ./
# i can put it where i want, so i'll pick a place with
# a nice short absolute path

# # this runs during "docker build"
RUN dotnet publish -o publish

# configure it with the command it will use to start containers.
# this runs at the start of "docker run"
CMD dotnet publish/DockerConsoleAppTwo.dll


# CMD dotnet run

# how do i use this Dockerfile?
# 1. docker build -t docker-console .
# 2. docker run docker-console
