# CashRegister
C# Backend API for Cash register with SQL Lite BDD

# How to start 

Before run the CashRegister.sln and debug, we will build the SQL Lite database :

To do that, we will just open a new cmd terminal :

Cd the infrastructure folder 

exemple for me : 

```
cd C:\Users\Kynothan\Documents\Projet Perso\2019-mes programmes\CashRegister\CashRegister.Infrastructure
```

And use :

```
dotnet tool install --global dotnet-ef
```

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

```
dotnet ef database update
```

When its Done. You can close the cmd terminal. 

After that, you can build and run the solution.

If you need more information, please check the following link :
https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli

# SQL Lite

## BDD Update

For dev update, open a cmd and do :

```
cd C:\Users\Kynothan\Documents\Projet Perso\2019-mes programmes\CashRegister\CashRegister.Infrastructure
```

```
dotnet ef migrations add 2025-02-13-10-25
```

```
dotnet ef database update
```

## BDD Location

W R => %Appdata%

‪C:\Users\Kynothan\AppData\Local\cashRegister.db