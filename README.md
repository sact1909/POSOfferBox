# POS OfferBox

This project is under construction by <a href='https://checox.com'>Steven Checo</a>

## Getting Started

These instructions will help you to work in the most effective way, please follow those instruction to know how to do it

### How to Work in this project

* You must clone the repo in your computer

```
Git clone https://github.com/sact1909/POSOfferBox.git
```

* Create a branch to work with

```
Git checkout branch -b <branch-name>
```

* Branch Name always must be like

>Feature/< owner-name >_< issue-reference >

* All branch must be related to an issue, please work a branch per issue

* When update the Database, run this command line to re-create de context

```
Scaffold-DbContext "<SQL Connection>" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
```

* After re-create the context, delete o comment <b>OnConfiguring</b> on <b>DB Context</b>, it will take the connection from <b>appsettings.json</b>

### Rules
* Read the lastest Pull Request to know what changed, update your main branch and create you branch to work with
* Never do a merge and commit to a Pull Request before write the documentation for been working for, This is good to let other knows how to continuous working
* You are free to create issue for everything you want to do in the project
* Don't work in the same branch of another developer if it not necessary
* Don't do Pull of your branch with appssecrets declared on appconstant.cs, those variables will be filled on Azure DevOps

## Built With

* [ASP.Net Core API](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1) - .Net Core, a Cross-Platform Framework
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - Database Environment

## Dependencies

* [AutoFac](https://autofaccn.readthedocs.io/en/latest) - IoC Container for .Net
* [AutoMapper](https://docs.automapper.org/en/latest/Getting-started.html) - An Object - Object Mapper

## Authors

* **Steven Checo** - *Initial work* - [sact1909](https://github.com/sact1909)