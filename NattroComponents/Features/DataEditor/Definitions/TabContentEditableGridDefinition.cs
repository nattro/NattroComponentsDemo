using NattroComponents.Features.DataEditor.Enum;

namespace NattroComponents.Features.DataEditor.Definitions
{
    public record TabContentEditableGridDefinition
    {
        public string JsonStringConfiguration { get; set; } = string.Empty;
        public Func<Task<List<List<string>>>>? LoadDataCallback { get; set; } = null;
        public Func<List<string>, Task<bool>>? SaveDataCallback { get; set; } = null;
        public Func<List<string>, Task<bool>>? DeleteDataCallback { get; set; } = null;
        public Func<List<string>, List<List<string>>, bool, Task>? RowClickCallback { get; set; } = null;
        public Func<Task>? InvokeDataRefresh { get; set; } = null;
        public GridFunctionalityEnum? GridFunctionality { get; set; } = GridFunctionalityEnum.List;
        public string StyleClass { get; private set; } = string.Empty;
        public string NoDataMessage { get; set; } = string.Empty;
    }
}
