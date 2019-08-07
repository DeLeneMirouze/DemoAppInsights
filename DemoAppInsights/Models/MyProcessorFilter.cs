using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;

public class MyProcessorFilter : ITelemetryProcessor
{
    private ITelemetryProcessor Next { get; set; }

    public MyProcessorFilter(ITelemetryProcessor next)
    {
        this.Next = next;
    }
    public void Process(ITelemetry item)
    {
        var request = item as RequestTelemetry;

        if (request != null &&
        request.ResponseCode.Equals("404", StringComparison.OrdinalIgnoreCase))
        {
            // l'item ne fera pas partie du flux de télémétrie
            return;
        }

        this.Next.Process(item);
    }
}
