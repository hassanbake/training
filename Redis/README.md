# Connecting to redis sentinel with dot net 5.0

## Create console project in vscode

To list all kind of project we can create in dot net type the following command:

```
$ dotnet new --list

Templates                                         Short Name          Language          Tags                  
--------------------------------------------      --------------      ------------      ----------------------
Console Application                               console             [C#], F#, VB      Common/Console        
Class library                                     classlib            [C#], F#, VB      Common/Library        
Worker Service                                    worker              [C#], F#          Common/Worker/Web     
Unit Test Project                                 mstest              [C#], F#, VB      Test/MSTest           
NUnit 3 Test Project                              nunit               [C#], F#, VB      Test/NUnit            
NUnit 3 Test Item                                 nunit-test          [C#], F#, VB      Test/NUnit            
xUnit Test Project                                xunit               [C#], F#, VB      Test/xUnit            
Razor Component                                   razorcomponent      [C#]              Web/ASP.NET           
Razor Page                                        page                [C#]              Web/ASP.NET           
MVC ViewImports                                   viewimports         [C#]              Web/ASP.NET           
MVC ViewStart                                     viewstart           [C#]              Web/ASP.NET           
Blazor Server App                                 blazorserver        [C#]              Web/Blazor            
Blazor WebAssembly App                            blazorwasm          [C#]              Web/Blazor/WebAssembly
ASP.NET Core Empty                                web                 [C#], F#          Web/Empty             
ASP.NET Core Web App (Model-View-Controller)      mvc                 [C#], F#          Web/MVC               
ASP.NET Core Web App                              webapp              [C#]              Web/MVC/Razor Pages   
ASP.NET Core with Angular                         angular             [C#]              Web/MVC/SPA           
ASP.NET Core with React.js                        react               [C#]              Web/MVC/SPA           
ASP.NET Core with React.js and Redux              reactredux          [C#]              Web/MVC/SPA           
Razor Class Library                               razorclasslib       [C#]              Web/Razor/Library     
ASP.NET Core Web API                              webapi              [C#], F#          Web/WebAPI            
ASP.NET Core gRPC Service                         grpc                [C#]              Web/gRPC              
dotnet gitignore file                             gitignore                             Config                
global.json file                                  globaljson                            Config                
NuGet Config                                      nugetconfig                           Config                
Dotnet local tool manifest file                   tool-manifest                         Config                
Web Config                                        webconfig                             Config                
Solution File                                     sln                                   Solution              
Protocol Buffer File                              proto                                 Web/gRPC 
```

Now create dot net console app:

```
$ dotnet new console -n RedisSentinelClient
```
Now add **`StackExchange.Redis`** package to the project:

```
$ cd RedisSentinelClient
$ dotnet add package StackExchange.Redis --version 2.2.4
```

> You can find how to use **`StackExchange.Redis`** [here](https://stackexchange.github.io/StackExchange.Redis/).