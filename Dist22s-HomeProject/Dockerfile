# grab the sdk image, create an name for it "build"
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app
EXPOSE 80

# copy csproj and restore as distinct layers
COPY *.props .
COPY *.sln .

# copy base files

# Base
COPY Base.BLL/*.csproj ./Base.BLL/ 
COPY Base.DAL/*.csproj ./Base.DAL/ 
COPY Base.DAL.EF/*.csproj ./Base.DAL.EF/ 
COPY Base.Domain/*.csproj ./Base.Domain/ 
COPY Base.Extensions/*.csproj ./Base.Extensions/ 

# Base contracts
COPY Base.Contracts.Base/*.csproj ./Base.Contracts.Base/ 
COPY Base.Contracts.BLL/*.csproj ./Base.Contracts.BLL/ 
COPY Base.Contracts.DAL/*.csproj ./Base.Contracts.DAL/ 
COPY Base.Contracts.Domain/*.csproj ./Base.Contracts.Domain/ 

# Tests
COPY Tests.WebApp/*.csproj ./Tests.WebApp/

# App
COPY App.BLL/*.csproj ./App.BLL/
COPY App.BLL.DTO/*.csproj ./App.BLL.DTO/
COPY App.Contracts.BLL/*.csproj ./App.Contracts.BLL/
COPY App.Contracts.DAL/*.csproj ./App.Contracts.DAL/
COPY App.DAL.DTO/*.csproj ./App.DAL.DTO/
COPY App.DAL.EF/*.csproj ./App.DAL.EF/
COPY App.Domain/*.csproj ./App.Domain/
COPY App.Public/*.csproj ./App.Public/
COPY App.Public.DTO/*.csproj ./App.Public.DTO/
COPY App.Recources/*.csproj ./App.Recources/
COPY WebApp/*.csproj ./WebApp/

RUN dotnet restore

# copy everything else and build app

# Base
COPY Base.BLL/. ./Base.BLL/ 
COPY Base.DAL/. ./Base.DAL/ 
COPY Base.DAL.EF/. ./Base.DAL.EF/ 
COPY Base.Domain/. ./Base.Domain/ 
COPY Base.Extensions/. ./Base.Extensions/ 

# Base contracts
COPY Base.Contracts.Base/. ./Base.Contracts.Base/ 
COPY Base.Contracts.BLL/. ./Base.Contracts.BLL/ 
COPY Base.Contracts.DAL/. ./Base.Contracts.DAL/ 
COPY Base.Contracts.Domain/. ./Base.Contracts.Domain/ 

# Tests
COPY Tests.WebApp/. ./Tests.WebApp/

# App
COPY App.BLL/. ./App.BLL/
COPY App.BLL.DTO/. ./App.BLL.DTO/
COPY App.Contracts.BLL/. ./App.Contracts.BLL/
COPY App.Contracts.DAL/. ./App.Contracts.DAL/
COPY App.DAL.DTO/. ./App.DAL.DTO/
COPY App.DAL.EF/. ./App.DAL.EF/
COPY App.Domain/. ./App.Domain/
COPY App.Public/. ./App.Public/
COPY App.Public.DTO/. ./App.Public.DTO/
COPY App.Recources/. ./App.Recources/
COPY WebApp/. ./WebApp/

WORKDIR /app/WebApp

# compile the app with Realease option and put files into dir "out"
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
WORKDIR /app
EXPOSE 80
ENV ConnectionStrings:NpgsqlConnection="Server=dist22db.postgres.database.azure.com;Database=dist22db;Port=5432;User Id=allerk;Password=FooBar1!;Ssl Mode=Require;TrustServerCertificate=true"

# copy files from previous image (the "build")
COPY --from=build /app/WebApp/out ./

# run this command when containers starts up (not runned during image build phase)
ENTRYPOINT ["dotnet", "WebApp.dll"]