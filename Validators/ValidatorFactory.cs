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

    internal class ValidatorFactory : IValidatorFactory
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

        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value.ToUpper(), true);
        }

        public IValidator? GetValidator(string validatorType)
        {
            return ParseEnum<ValidatorTypeEnum>(validatorType) switch
            {
                ValidatorTypeEnum.BOOLEAN => booleanValidator,
                ValidatorTypeEnum.STRING => stringValidator,
                ValidatorTypeEnum.INTEGER => integerValidator,
                ValidatorTypeEnum.ENUM => enumValidator,
                ValidatorTypeEnum.DECIMAL => decimalValidator,
                ValidatorTypeEnum.REGEX => regexValidator,
                ValidatorTypeEnum.RANGE => rangeValidator,
                ValidatorTypeEnum.CURRENCY => currencyValidator,
                _ => null
            };
        }
    }
}

