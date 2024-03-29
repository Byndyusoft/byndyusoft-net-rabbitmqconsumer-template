# RabbitMqConsumerTemplate

## Description

Short service description.

## Used queues

- The service is subscribed to QueueName-1
- The service sends messages to QueueName-2

## Prerequisites

Make sure you have installed all of the following prerequisites on your development machine:

- Git - [Download & Install Git](https://git-scm.com/downloads). OSX and Linux machines typically have this already installed.
- .NET Core (version 6.0 or higher) - [Download & Install .NET Core](https://dotnet.microsoft.com/download/dotnet-core/6.0).

## Configuration

### ConnectionStrings

Rabbit connection settings.

Example:

```json
{
  "ConnectionStrings": {
    "Rabbit": "host=localhost;username=guest;password=guest"
  }
}
```

### Logging

Logging settings.

Example:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
     "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

### OpenTelemetry
OpenTelemetry Exporter settings.

Example:
```json
{
  "OtlpExporterOptions": {
    "Endpoint": "http://localhost:4317"
  }
}
```

## General folder layout

### src

- RabbitMqConsumerTemplate - Consumer that handles incoming messages
- Contracts - Consumer integration contracts

### tests

- UnitTests - Unit Tests
- IntegrationTests - Consumer Integration Tests

## Consumer development lifecycle

- Implement logic in `src`
- Add or adapt unit and integration tests in `tests`
- Add or change the documentation as needed
- Open a pull request for a correct branch. Target the project's `master` branch

# Maintainers

[github.maintain@byndyusoft.com](mailto:github.maintain@byndyusoft.com)