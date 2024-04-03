using NattroComponents.Features.DataEditor.Enum;

namespace NattroComponents.Features.DataEditor.Definitions;

public record EditableGridInstance
{
    public string? JsonConfiguration { get; set; } = string.Empty;
    public List<List<string>> DataRows { get; set; } = new();
    public GridControlState State { get; set; } = GridControlState.Invisible;
    public GridFunctionalityEnum? GridFunctionality { get; set; } = GridFunctionalityEnum.List;
    public Func<List<string>, Task<bool>>? SaveDataCallback { get; set; } = null;
    public Func<List<string>, Task<bool>>? DeleteDataCallback { get; set; } = null;
    public Func<List<string>, List<List<string>>, bool, Task>? RowClickCallback { get; set; } = null;
    public string NoDataMessage { get; set; } = string.Empty;
}