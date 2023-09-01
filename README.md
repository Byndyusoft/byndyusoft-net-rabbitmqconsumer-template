# .NET RabbitMQ consumer service template

## What does it include?

Template includes:
- RabbitMQ package - [Byndyusoft.Messaging.RabbitMq](https://github.com/Byndyusoft/Byndyusoft.Net.RabbitMq).
- Package for masking sensitive data in logs and traces - [Byndyusoft.MaskedSerialization](https://github.com/Byndyusoft/Byndyusoft.MaskedSerialization).
- Health checks using method /healthz.
- OpenTelemetry Tracing and Metrics.

Projects:
- src
  - RabbitMqConsumerTemplate - Consumer that handles incoming messages
  - Contracts - Consumer integration contracts

- tests 
  - UnitTests - Unit Tests
  - IntegrationTests - Consumer Integration Tests

## Install
``` shell
dotnet new --install Byndyusoft.Net.RabbitMqConsumerTemplate
```

Template with bsrabbitconsumer name should appear in your project list

## Create service

```shell
dotnet new bsrabbitconsumer -o <DIRECTORY_NAME>
```

**Note:**  Service name will match to the directory name. [Here](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) you can see full list of available options.

# Maintainers
github.maintain@byndyusoft.com
