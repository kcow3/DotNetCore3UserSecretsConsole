# DotNetCore3UserSecretsConsole
Simple console app demonstrating the use of user secrets in a .Net Core 3.1 Console application. 
The code is adapted from: https://www.twilio.com/blog/2018/05/user-secrets-in-a-net-core-console-app.html

Setup instructions:

The following nuget packages are required:

* <PackageReference Include="Microsoft.Extensions.Configuration.UserSecrets" Version="3.0.0" />
* <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="3.1.1" />
* <PackageReference Include="Microsoft.Extensions.Options" Version="3.1.1" />
* <PackageReference Include="Microsoft.Extensions.Options.ConfigurationExtensions" Version="3.1.1" />

Add user secrets in json form by right clicking on your project and selecting [Manage User Secrets].

For example:
{
  "Secrets:SomeUserSecret": "Value"
}

The Secrets Model can now contain Properties you want to retrieve from User secrets:

public string SomeUserSecret { get; set; }

In Program.cs you can access secrets via the ISecretService interface.
