FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY SonarDemo.sln ./
COPY SonarDemo/*.csproj ./SonarDemo/
COPY Tests/*.csproj ./Tests/
RUN dotnet restore

COPY . ./


RUN dotnet tool install --global dotnet-sonarscanner

ENV PATH="${PATH}:/root/.dotnet/tools"

#start sonar scan

RUN dotnet sonarscanner begin \
/k:"MathsOperation" \
/d:sonar.token="squ_2ffdf7ee20eafbdc7655324923f6ae3d7a924fc4" \
/d:sonar.exclusions=**/Dockerfile,**/Program.cs \
/d:sonar.host.url="http://host.docker.internal:9000" \
/d:sonar.cs.opencover.reportsPaths="**/coverage.opencover.xml"

RUN dotnet build -c Release

RUN dotnet test \
/p:CollectCoverage=true \
/p:CoverletOutputFormat=opencover

#end the sonar scan
RUN dotnet sonarscanner end \
/d:sonar.token="squ_2ffdf7ee20eafbdc7655324923f6ae3d7a924fc4"

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app
COPY --from=build /app .


#ENTRYPOINT