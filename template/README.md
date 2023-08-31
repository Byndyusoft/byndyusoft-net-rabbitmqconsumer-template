# RabbitMqConsumerTemplate

## Description

Short service description.

## Listened queues

- QueueName-1
- QueueName-2

## Prerequisites

Make sure you have installed all of the following prerequisites on your development machine:

- Git - [Download & Install Git](https://git-scm.com/downloads). OSX and Linux machines typically have this already
  installed.
- .NET Core (version 6.0 or
  higher) - [Download & Install .NET Core](https://dotnet.microsoft.com/download/dotnet-core/6.0).

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

### Jaeger

Jaeger settings.

Example:

```json
{
  "Jaeger": {
    "AgentHost": "localhost",
    "AgentPort": 6831
  }
}
```

## General folders layout

### src

- RabbitMqConsumerTemplate - Worker-consumer that handled incoming messages
- Contracts - Consumer integration contracts

### tests

- UnitTests - Unit Tests
- IntegrationTests - Consumer Integration Tests

## Consumer development lifecycle

- Implement logic in `src`
- Add or adapt unit and integration tests (prefer before and simultaneously with coding) in 'tests
- Add or change the documentation as needed
- Open pull request in the correct branch. Target the project's `master` branch

# Maintainers

[github.maintain@byndyusoft.com](mailto:github.maintain@byndyusoft.com)