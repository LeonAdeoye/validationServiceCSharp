namespace validation_service.Models
{
    public record ValidationConfiguration //: Comparer<ValidationConfiguration>
    {
        public int Id
        {
            get;
            set;
        }
        public bool CanBeEmpty
        {
            get;
            set;
        }

        public string? StringFormat
        {
            get;
            set;
        }

        public string? Description
        {
            get;
            set;
        }

        public string? Type
        {
            get;
            set;
        }

        public string? Enumerations
        {
            get;
            set;
        }

        public string[]? ValidRange
        {
            get;
            set;
        }

        public string? RegexValue
        {
            get;
            set;
        }

        public string[]? NestedMatches
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format("ValidationConfiguration={\nId:{0},\nDescription:{1},\nCanBeEmpty:{2},\nType:{3}\n}", Id, Description, CanBeEmpty, Type);
        }
    }
}