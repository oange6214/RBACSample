namespace RBACSample.Shared.Helpers;

public static class CommonHelper
{
    public static string GenerateUniqueId()
    {
        return Guid.NewGuid().ToString();
    }

    public static string ToTitleCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var cultureInfo = Thread.CurrentThread.CurrentCulture;
        var textInfo = cultureInfo.TextInfo;
        return textInfo.ToTitleCase(input.ToLower());
    }
}