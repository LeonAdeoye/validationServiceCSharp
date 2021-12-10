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
        private readonly BooleanValidator booleanValidator = new BooleanValidator();
        private readonly StringValidator stringValidator = new StringValidator();
        private readonly IntegerValidator integerValidator = new IntegerValidator();

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public IValidator? getInstance(string validatorType)
        {
            switch (ParseEnum<ValidatorTypeEnum>(validatorType))
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

