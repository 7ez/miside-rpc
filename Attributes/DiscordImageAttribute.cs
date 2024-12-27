using System;

namespace MiSideRPC.Attributes;

[AttributeUsage(AttributeTargets.Field)]
internal class DiscordImageAttribute : Attribute
{
    public DiscordImageAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
}