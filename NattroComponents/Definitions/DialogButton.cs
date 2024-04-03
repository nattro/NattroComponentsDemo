namespace NattroComponents.Definitions;

public record DialogButton
{
    public Func<Task>? Callback;
    public string ButtonText { get; set; } = "unknown";
    public bool IsPrimary { get; set; } = false;
}