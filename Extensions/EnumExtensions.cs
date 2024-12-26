using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using MiSideRPC.Attributes;
using MiSideRPC.Enums;

namespace MiSideRPC.Extensions;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T source)
    {
        var fi = source.GetType().GetField(source.ToString()!)!;
        var attr = fi.GetCustomAttribute<DescriptionAttribute>();

        return attr?.Description ?? source.ToString();
    }

    public static string GetLargeImageKey(this CurrentRoom source)
    {
        var fi = source.GetType().GetField(source.ToString()!)!;
        var attr = fi.GetCustomAttribute<LargeKeyAttribute>();

        return attr?.Name;
    }

    public static bool CanHaveAction(this CurrentRoom source)
    {
        var fi = source.GetType().GetField(source.ToString()!)!;
        var attr = fi.GetCustomAttribute<CanHaveActionAttribute>();
        return attr is not null;
    }

    public static IEnumerable<CurrentAction> GetActions(this CurrentAction source)
    {
        return Enum.GetValues(typeof(CurrentAction)).Cast<Enum>().Where(source.HasFlag).Cast<CurrentAction>();
    }
}