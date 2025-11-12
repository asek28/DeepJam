using UnityEngine;

public class Scrap
{
    public string Name { get; }
    public int Value { get; }

    public Scrap(string name, int value)
    {
        Name = string.IsNullOrWhiteSpace(name) ? "Unknown Scrap" : name;
        Value = Mathf.Max(0, value);
    }
}
