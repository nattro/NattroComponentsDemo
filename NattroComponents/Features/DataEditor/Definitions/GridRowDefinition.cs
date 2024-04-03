namespace NattroComponents.Features.DataEditor.Definitions
{
    public class GridRowDefinition
    {
        public GridRowDefinition()
        {
            ControlValues = new List<string>();
            IsInEditMode = false;
        }

        public int GridRowNumber { get; set; }

        public bool IsInEditMode { get; set; }
        public bool IsSelected { get; set; }

        public List<string> ControlValues { get; set; }
    }
}
