namespace validation_service.Validators
{
    public enum ValidatorTypeEnum
    {
        BOOLEAN,
        STRING,
        INTEGER
    }

    internal class ValidatorFactory
    {
        private readonly BooleanValidator booleanValidator = new();
        private readonly StringValidator stringValidator = new();
        private readonly IntegerValidator integerValidator = new();

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public IValidator? getInstance(string validatorType)
        {
            switch (ParseEnum<ValidatorTypeEnum>(validatorType.ToUpper()))
            {
                case ValidatorTypeEnum.BOOLEAN:
                    return booleanValidator;
                case ValidatorTypeEnum.STRING:
                    return stringValidator;
                case ValidatorTypeEnum.INTEGER:
                    return integerValidator;
                default:
                    return null;
            }
        }
    }
}

