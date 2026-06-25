using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GateConsoleApp.UseCases;


public record OpenGateRequest(string deviceId);

internal class OpenGateUseCase(IGateRepository repository, ILogger<OpenGateUseCase> logger)
{
    public Task HandleAsync(OpenGateRequest request)
    {
        var gate = repository.Get(request.deviceId);

        gate.IsOpened = true;

        return Task.CompletedTask;
    }
}
