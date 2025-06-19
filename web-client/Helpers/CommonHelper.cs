using System.ComponentModel;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace web_client.Helpers;

public static class CommonHelper
{
    public static DateTimeOffset GetDateTimeNullValue()
    {
        return DateTimeOffset.MinValue;
    }
    public static DateTimeOffset GetCurrent()
    {
        return DateTimeOffset.Now;
    }
    public static TimeOnly GetCurrentTime()
    {
        return TimeOnly.FromDateTime(GetCurrent().DateTime);
    }
    public static string ConvertToUnsign(this string input, bool? trim = false)
    {
        if (input?.HasValueString() != true) return input;
        if (trim == true) return input?.Trim();
        return input;
    }

    public static string GetDescription(this Enum source)
    {
        var field = source.GetType().GetField(source.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute != null ? attribute.Description : source.ToString();
    }

    public static byte[] Base64UrlDecode(this string input)
    {
        var base64 = input.Replace('-', '+').Replace('_', '/');

        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
            case 0:
                break;
            default:
                throw new FormatException("Invalid Base64Url string!");
        }

        return Convert.FromBase64String(base64);
    }

    public static string CapitalizeFirstChar(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        return char.ToUpper(input[0]) + input[1..];
    }

    public static string GetAccountName(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value ?? string.Empty;
    }

    public static Guid GetAccountId(this IHttpContextAccessor httpContextAccessor)
    {
        var source = httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? string.Empty;
        if (string.IsNullOrEmpty(source))
            return Guid.Empty;
        if (Guid.TryParse(source, out var result))
            return result;
        return Guid.Empty;
    }

    public static decimal RoundToNearestThousand(this decimal number)
    {
        return (decimal)Math.Round((double)number / 1000.0) * 1000;
    }

    public static string FormatCurrency(this decimal number)
    {
        return number.ToString("#,##0");
    }

    public static string FormatCurrency(this int number)
    {
        return number.ToString("#,##0");
    }

    public static string FormatCurrency(this double number)
    {
        return number.ToString("#,##0");
    }

    public static IEnumerable<byte> Sha256ToByte(this string source)
    {
        using var hmacSha256 = SHA256.Create();
        return hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(source));
    }

    public static byte[] Sha256ToByte(this string source, string key)
    {
        var keyByte = Encoding.UTF8.GetBytes(key);
        using var hmacSha256 = new HMACSHA256(keyByte);
        return hmacSha256.ComputeHash(Encoding.UTF8.GetBytes(source));
    }

    public static string Sha256(this string source, bool lower = true)
    {
        var format = lower ? "x2" : "X2";
        var dataBytes = source.Sha256ToByte();
        var result = "";
        foreach (var item in dataBytes) result += item.ToString(format);
        return result;
    }

    public static string Sha256(this string source, string key, bool lower = true)
    {
        var format = lower ? "x2" : "X2";
        var dataByte = source.Sha256ToByte(key);
        var result = dataByte.Aggregate("", (current, item) => current + item.ToString(format));
        return result;
    }

    public static bool HasValueGuid(this Guid? guid) => guid.HasValue && guid != Guid.Empty;
    public static bool HasValueString(this string? input) => !string.IsNullOrEmpty(input);
}
