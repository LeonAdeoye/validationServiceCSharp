namespace validation_service.Validators
{
    public enum ValidatorTypeEnum
    {
        BOOLEAN,
        STRING,
        INTEGER,
        DECIMAL,
        RANGE,
        ENUM,
        REGEX,
        CURRENCY
    }

    internal class ValidatorFactory
    {
        // TODO use dependency injection
        private readonly BooleanValidator booleanValidator = new();
        private readonly StringValidator stringValidator = new();
        private readonly IntegerValidator integerValidator = new();
        private readonly DecimalValidator decimalValidator = new();
        private readonly RangeValidator rangeValidator = new();
        private readonly RegexValidator regexValidator = new();
        private readonly EnumValidator enumValidator = new();
        private readonly CurrencyValidator currencyValidator = new();

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value.ToUpper(), true);
        }

        public IValidator? GetInstance(string validatorType)
        {
            switch (ParseEnum<ValidatorTypeEnum>(validatorType))
            {
                case ValidatorTypeEnum.BOOLEAN:
                    return booleanValidator;
                case ValidatorTypeEnum.STRING:
                    return stringValidator;
                case ValidatorTypeEnum.INTEGER:
                    return integerValidator;
                case ValidatorTypeEnum.ENUM:
                    return enumValidator;
                case ValidatorTypeEnum.DECIMAL:
                    return decimalValidator;
                case ValidatorTypeEnum.REGEX:
                    return regexValidator;
                case ValidatorTypeEnum.RANGE:
                    return rangeValidator;
                case ValidatorTypeEnum.CURRENCY:
                    return currencyValidator;
                default:
                    return null;
            }
        }
    }
}

