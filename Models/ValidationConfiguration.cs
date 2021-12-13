namespace validation_service.Models
{
    public record ValidationConfiguration : IComparer<ValidationConfiguration>
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

        public int Compare(ValidationConfiguration? x, ValidationConfiguration? y)
        {
            if (x == null && y == null)
            return x.Id.CompareTo(y.Id);
        }

        public override string ToString()
        {
            return $"ValidationConfiguration=\nId:{Id},\nDescription:{Description},\nCanBeEmpty:{CanBeEmpty},\nType:{Type}\n";
        }
    }
}