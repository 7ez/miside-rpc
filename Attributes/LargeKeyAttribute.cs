using System;

namespace MiSideRPC.Attributes;

public class LargeKeyAttribute : Attribute
{
    public string Name { get; init; }

    public LargeKeyAttribute(string name)
    {
        Name = name;
    }
}