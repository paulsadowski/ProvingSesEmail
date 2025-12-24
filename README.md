# ProvingSesEmail
This project is to test the Email for Amazon SES

12/24/2025

We have successfully sent an email from Visual Studio 2026 through the AWS SES.

The following are the two nuget packages that were required for functionality
    PackageReference Include="AWSSDK.Extensions.NETCore.Setup" Version="4.0.3.17"
    PackageReference Include="AWSSDK.SimpleEmail" Version="4.0.2.8"

The way this is written is to output to a console window. Thus this is a console application.

Enviroment setting need to be in place as well.
Needed to update a credential file. The credential file is found in the following directory: c:\users\<User Name>\.aws

The Key is found in the Iam under users.