# Sending Email In C# Using Fluent Email

Sending transactional emails in C# is a fairly common practice. Instead of struggling to get the code right, especially with the built-in emailing system being deprecated in .NET 5, you can use FluentEmail to quickly and securely send emails using C#. In this project, we are going to see how to send emails, use email templates, and how to easily test our email delivery system without using a production email server.

## Create project ResponseService


## Create projects

### Add Nuget Packages in EmailDemo
```
Install-Package FluentEmail.Smtp
Install-Package FluentEmail.Razor
```

<img src="/pictures/received_mail.png" title="received mail"  width="600">
