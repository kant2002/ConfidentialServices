Confidential Services for ASP.NET Core
======================================

This library provides set of helpers, which can make your sensitive information in models, and allow you separate business logic with your security requirements.

# How to use

```
dotnet package add ConfidentialServices
```

And add this line to your Program.cs
```
builder.Services.AddConfidentialServices();
```

There optional support for AutoMapper and Swashbuckle
```
builder.Services.AddConfidentialServices()
	.AddAutoMapper()
	.AddSwashbuckle();
```