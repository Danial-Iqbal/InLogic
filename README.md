# InLogic
InLogic Application Design from Scratch using Dotnet Core 7 WebApi and Angular 16 FrontEnd

- A Simple User Registration System.
- Allows users to register their accounts through a user-friendly interface.
- Consist of both backend API developed using .NET CORE and a frontend user interface build with angular.

[![MIT license](http://img.shields.io/badge/license-MIT-brightgreen.svg)](http://opensource.org/licenses/MIT)

## Technologies
- [ASP.NET Core 7](https://dotnet.microsoft.com/) 
- [ASP Net Core Web Api](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio)
- [Angular 16](https://angular.io/)
- [Angular CLI 16](https://cli.angular.io/)
- [3 Layer Architecture](https://www.techtarget.com/searchsoftwarequality/definition/3-tier-application)
- [Swashbuckle.AspNetCore.Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Fluent Validation](https://fluentvalidation.net/)
- [AutoMapper](https://automapper.org/)
- [Problem Details](https://learn.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-7.0)
- [Microsoft Sql Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [EntityFramwork Core](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)
- [Code First Approach](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx)
- [API KEY Authorization](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/introduction?view=aspnetcore-7.0)
- [Dependency Injection](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0)
- [XUnit](https://xunit.net/)
- [Fluent Assertions](https://fluentassertions.com/)

## Pre-requisites
1. [.Net core 7 SDK](https://www.microsoft.com/net/core#windows)
2. [Visual studio 2022](https://www.visualstudio.com/)
3. [VSCode](https://code.visualstudio.com/)
4. [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
5. [NodeJs](https://nodejs.org/en/) (Latest)
6. [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2017)
7. [XUnit](https://xunit.net/)

## Configuration

1. Clone the repo: git clone https://github.com/Danial-Iqbal/InLogic.git
2. Database Initialization (Migrations) [Automatic or Manual] 
   - Automatic Run 
       - Automatically executed on the Run of InLogic.WebApi.              
   - **OR**
   - Manual Run (optional)
       - Open Package Manager Console
       - Set Default Project InLogic.Data
          ![image](https://github.com/Danial-Iqbal/InLogic/assets/38452803/73df1335-74c9-4861-8202-3ff4479d2076)
       - Set Startup Project InLogic.WebApi
          ![image](https://github.com/Danial-Iqbal/InLogic/assets/38452803/6af91109-8e8f-4786-acd0-04de1fe55447)
       - Run Command 'update-database' on package manager console
          ![image](https://github.com/Danial-Iqbal/InLogic/assets/38452803/5cdf8354-7311-467a-a35e-65dce82dea6d)
3. Database connectionstring in launchSettings.json 
   - DefaultConnection is pointed to (LocalDB)
   - Path : InLogic.WebApi/Properties/launchSettings.json
   - `"DBProvider": "MSSQL" ,` Use `MSSQL` to connect to Microsoft SqlServer
   - `"ConnectionStrings:DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=InLogic;Trusted_Connection=True;MultipleActiveResultSets=true"
  `
4. X-API-KEY in launchSettings.json
   - Path : InLogic.WebApi/Properties/launchSettings.json
   - `"X-API-KEY":"1234"`
6. cd to folder InLogic\InLogic.Web
   - code .
   - open terminal
   - `npm install`
   - `ng serve`
7. environment.ts in InLogic\InLogic.Web
   - Path : InLogic.Web/src/environments/environment.ts
   - `X-API-KEY: 1234`
   - `apiUrl: https://localhost:7189/api/`
   - ![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/0d837417-9995-42d4-9786-0b2f0e9b417d)
8. open the InLogic.sln
   - Visual Studio 2022 IDE
      - opening the solution will restore the nuget and npm packages build the solution
      - Multiple Projects Startup `InLogic.WebApi` and `InLogic.Web`
   - Visual Studio Code
     - Open the folder `InLogic.Web`
     - Build the Solution
     - Run the Projects `InLogic.WebApi` and `InLogic.Web`
 6. Application URL's
     - `Webapi https://localhost:7189 `
     - `AngularWeb http://localhost:4200`
 7. InLogic.Tests (Unit Tests) 

## Soltion Explorer

![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/6ec2b17f-bd16-4073-bad8-2a12acba5541)
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/1bbb2938-0b58-4f2a-bf81-311e9a44c2ed)


## Launch URL's
### WebApi

* **WebApi API -> https://localhost:7189/swagger/index.html**

### Web

* **Web -> http://localhost:4200**

## WebApi

### API Documentation

#### Swagger UI
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/ea5b9a21-f50d-4e2f-9b48-98c4d25438c9)
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/7e999d24-0b86-43e4-9c99-c6eeb1984176)
#### Authorization
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/9846a1ed-60b7-4047-93a3-fa107a55e555)
#### API Endpoint and Request Body

**Screenshots**
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/b9d563e6-5f57-4825-a515-bda8d9ce0947)

**EndPoint**
```csharp
POST /api/Users/Register
```

**Request Body**
```csharp
{
  "name": "string",
  "email": "string",
  "password": "string",
  "confirmPassword": "string"
}
```
#### Response
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/e3b2e624-8415-4d17-ab47-a2eec41aa874)
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/400c99a2-845a-48be-8f87-205c4c362d10)

**200**
```csharp
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```
**400**
```csharp
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "additionalProp1": "string",
  "additionalProp2": "string",
  "additionalProp3": "string"
}
```
**500**
```csharp
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "additionalProp1": "string",
  "additionalProp2": "string",
  "additionalProp3": "string"
}
```
#### Schemas

**Screenshots**
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/fd162f0c-4da2-49c1-8d64-c7dec6c9f9d9)

**ProblemDetails**
```csharp
ProblemDetails{
type	string
nullable: true
title	string
nullable: true
status	integer($int32)
nullable: true
detail	string
nullable: true
instance	string
nullable: true
}
```
**UserRegisterRequestModel**
```csharp
UserRegisterRequestModel{
name	string
nullable: true
email	string
nullable: true
password	string
nullable: true
confirmPassword	string
nullable: true
}
```
**UserRegisterResponseModel**
```csharp
UserRegisterResponseModel{
id	string($uuid)
}
```
## Web
#### Registration
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/a88676d2-f126-4e6c-961f-6db677f75b2a)
#### 403 Forbidden
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/c23151df-2ed9-4169-b258-858396e020ed)

## Unit Testing
InLogic.Tests
![image](https://github.com/Danial-Iqbal/InLogic2/assets/38452803/4cff0d77-5214-4221-a271-ed5f1f53fc39)

## MS SQL SERVER

#### Connection
![image](https://github.com/Danial-Iqbal/InLogic/assets/38452803/6cd73f2e-5e62-4c88-b615-4183f91b9a21)

#### Structure
![image](https://github.com/Danial-Iqbal/InLogic/assets/38452803/587185b2-88cb-492a-831c-d6179317778a)

#### Result Set
![image](https://github.com/Danial-Iqbal/InLogic/assets/38452803/3260b2d2-d3f3-40b7-9bab-40ab37ba1259)


