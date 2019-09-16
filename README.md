# PortableResolver
Simple, Fast, Reliable, Always-Available ASP.NET Core Service Resolver

[![License](https://img.shields.io/badge/License-MIT-yellow.svg?style=flat-square)](https://github.com/azhdari/Mohmd.AspNetCore.PortableResolver/blob/master/License.txt)
[![NuGet](https://img.shields.io/badge/nuget-2.0.0_beta1-blue.svg?style=flat-square)](https://www.nuget.org/packages/Mohmd.AspNetCore.PortableResolver/2.0.0-beta1)

## Getting Started
Use these instructions to get the package and use it.

### Install
From the command prompt
```bash
dotnet add package Mohmd.AspNetCore.PortableResolver --version 2.0.0-beta1
```
or
```bash
Install-Package Mohmd.AspNetCore.PortableResolver -Version 2.0.0-beta1
```
or
```bash
paket add Mohmd.AspNetCore.PortableResolver --version 2.0.0-beta1
```
<br/>
<br/>

### Configure
Add service
```csharp
public void ConfigureServices(IServiceCollection services)
{
  // 1. Register everything here
  services.AddScoped<Service1>();
  services.AddScoped<Service2>();
  // ...

  // 2. Then initialize the Engine
  services.AddPortableResolver();
}
```
<br/>
<br/>

### Usage
Use one of methods below to resolve your desired service
```csharp
// Resolve a single registered service
EngineContext.Current.Resolve(typeof(FooService));
EngineContext.Current.Resolve<FooService>();

// Resolve a service with multiple registrations
EngineContext.Current.ResolveAll<BarService>();
```
<br/>

#### Resolving Unregistered Services
Resolve an unregistered `class` with at list one constructor defined with registered parameters
```csharp
EngineContext.Current.ResolveUnregistered(typeof(FooUnregisteredService));
EngineContext.Current.ResolveUnregistered<FooUnregisteredService>();
```
Example for resolving Unregistered `class`
```csharp
// Declaration
public class FooUnregisteredService
{
  public FooUnregisteredService(FooService fooService, BarService barService)
  {
  }
}

// Startup > ConfigureServices
services.AddScoped<FooService>();
services.AddScoped<BarService>();

// Usage
var service = EngineContext.Current.ResolveUnregistered<FooUnregisteredService>();
```