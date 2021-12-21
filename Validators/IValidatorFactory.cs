namespace validation_service.Validators
{
    public interface IValidatorFactory
    {
        IValidator? GetValidator(string validatorType);
    }
}