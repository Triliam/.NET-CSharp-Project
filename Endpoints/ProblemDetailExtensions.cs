using Flunt.Notifications;

namespace IWantApp.Endpoints;

public static class ProblemDetailExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemDetails(this IReadOnlyCollection<Notification> notifications)
    {
        return notifications
            .GroupBy(n => n.Key)
            .ToDictionary(g => g.Key, g => g.Select(n => n.Message).ToArray());
    }
}
