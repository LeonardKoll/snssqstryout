# SNS/SQS Tryout

This repository contains the result of introducing myself to AWS SNS.

## What it does & Technology

Hosts a simple website with a form to submit a message to SNS.
* Backend based on .Net Core with C# and MVC.
* Frontend is a very simple HTML+JS page using Axios & Bootstrap

## Usage

```
dotnet publish .
cd /bin/Debug/netcoreapp3.1/publish
dotnet snssqstryout.dll --arn "..." --accessKey "..." --secretKey "..."

```