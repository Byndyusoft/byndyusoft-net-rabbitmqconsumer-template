namespace RabbitMqConsumerTemplate.Infrastructure.OpenTelemetry;

using System.Diagnostics;
using System.Diagnostics.Metrics;

public static class ConsumerTemplateMetrics
{
    public static string Name => "Template.Consumer.Metrics";

    public static string DurationName => "duration";

    public static readonly double[] DurationBuckets = { 5, 10, 20, 30, 60, 120, 180, 240, 300, 600, 900, 3600, 7200, 14400, 28800 };

    private static readonly Meter Meter = new(Name);

    private static readonly Histogram<double> HistogramDuration = Meter
        .CreateHistogram<double>(DurationName,
                                 "seconds",
                                 "Время");

    public static void ObserveDuration(string property, TimeSpan timeSpan)
    {
        var tagList = new TagList { { "property", property } };
        HistogramDuration.Record(timeSpan.TotalSeconds, tagList);
    }
}