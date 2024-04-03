using NattroComponents.Definitions;
using NattroComponents.Features.DataEditor.Enum;

namespace NattroComponents.Features.DataEditor.Definitions;
public record TabDefinition
{
    private Boolean _isActive = false;
    public string Text { get; set; } = string.Empty;

    public List<TabContentEditableGridDefinition> TabContentDefinitions = new();

    public ControlAlignment Alignment { get; set; } = ControlAlignment.Horizontal;

    public List<DialogButton>? FooterButtons = null;

    public string TabStyleClass { get; private set; } = string.Empty;

    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            TabStyleClass = IsActive ? "active" : "";
        }
    }
}
