﻿using validation_service.Models;

namespace validation_service.Validators
{
    internal class IntegerValidator : IValidator
    {
        public string validate(String value, ValidationConfiguration validationConfiguration)
        {
            bool result = int.TryParse(value, out _);
            if (!result)
                return "Cannot validate value: " + value + " as a integer.";
            return "";
        }
    }
}