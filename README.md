# .NET RabbitMQ consumer service template

## What includes?

Template includes:
- RabbitMQ package - [Byndyusoft.Messaging.RabbitMq](https://github.com/Byndyusoft/Byndyusoft.Net.RabbitMq).
- Package for masking sensitive data in logs and traces - [Byndyusoft.MaskedSerialization](https://github.com/Byndyusoft/Byndyusoft.MaskedSerialization).
- Health checks using method /healthz.
- OpenTelemetry Tracing.

Projects:
- src
  - RabbitMqConsumerTemplate - Worker-consumer that handled incoming messages
  - Contracts - Consumer integration contracts

- tests 
  - UnitTests - Unit Tests
  - IntegrationTests - Consumer Integration Tests

## Install
``` shell
dotnet new --install Byndyusoft.Net.RabbitMqConsumerTemplate
```

Template with name bsrabbitconsumer should be appear in your projects list

## Create service

```shell
dotnet new bsrabbitconsumer -o <DIRECTORY_NAME>
```

**Note:**  Service name will be match to directory name. [Here](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) you can see full list of available options.

# Maintainers
github.maintain@byndyusoft.com
