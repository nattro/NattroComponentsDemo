using System.Text.Json;
using NattroComponents.Features.DataEditor.Enum;

namespace NattroComponents.Features.DataEditor.Definitions
{
    public record GridCellDefinition
    {
        private const int defaultWidth = 200;

        public GridCellDefinition(JsonElement element, int columnNumber)
        {
            Visible = true;
            Required = false;
            Editable = false;
            Width = defaultWidth;
            ColumnNumber = columnNumber;
            foreach (var val in element.EnumerateObject())
            {
                var value = val.Value.ToString();
                switch (val.Name)
                {
                    case "DataType":
                        switch (value)
                        {
                            case "Date":
                                ControlType = ControlTypeEnum.Date;
                                break;
                            case "Number":
                                ControlType = ControlTypeEnum.Number;
                                break;
                            case "TextArea":
                                ControlType = ControlTypeEnum.TextArea;
                                break;
                            case "Text":
                                ControlType = ControlTypeEnum.Text;
                                break;
                            case "Boolean":
                                ControlType = ControlTypeEnum.Boolean;
                                break;
                            default:
                                throw new Exception($"Unknown data type {value}.");
                        }
                        break;
                    case "Name":
                        Name = value;
                        break;
                    case "Required":
                        Required = !string.IsNullOrWhiteSpace(value) && bool.Parse(value);
                        break;
                    case "Editable":
                        Editable = !string.IsNullOrWhiteSpace(value) && bool.Parse(value);
                        break;
                    case "Width":
                        Width = string.IsNullOrWhiteSpace(value) ? defaultWidth : int.Parse(value);
                        break;
                    case "ValidValues":
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            ValidValues = value.Split(',').ToList();
                        }

                        break;
                    case "Visible":
                        Visible = !string.IsNullOrWhiteSpace(value) && bool.Parse(value);
                        break;
                    default:
                        throw new Exception($"Unknown column definition setting: {val.Name}.");
                }
            }

            if (string.IsNullOrEmpty(this.Name))
            {
                throw new Exception("Dynamic control definition requires a 'Name'.");
            }
            OverrideControlTypes();
        }

        private void OverrideControlTypes()
        {
            if (ValidValues != null && ValidValues.Any())
            {
                ControlType = ControlTypeEnum.ComboBox;
            }
        }

        public string Name { get; set; }

        public bool Editable { get; set; }

        public bool Required { get; set; }

        public List<string>? ValidValues { get; set; }

        public ControlTypeEnum ControlType { get; set; }

        public int Width { get; set; }

        public bool Visible { get; set; }

        public int ColumnNumber { get; set; }

        public long SortTick { get; private set; }

        public DataSort DataSort { get; private set; }

        public string FilterValue { get; set; }
        
        public bool FilterChanged { get; set; }

        public void ToggleSort()
        {
            SortTick = DataSort == DataSort.Unsorted ? DateTime.Now.Ticks : SortTick;
            DataSort = DataSort == DataSort.Unsorted ? DataSort.Ascending : DataSort == DataSort.Ascending ? DataSort.Descending : DataSort.Unsorted;
        }
    }
}
