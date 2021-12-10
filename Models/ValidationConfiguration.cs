namespace validation_service.Models
{
    public class ValidationConfiguration
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

        public string? ValidValues
        {
            get;
            set;
        }

        public string? ValidRange
        {
            get;
            set;
        }

    }
}