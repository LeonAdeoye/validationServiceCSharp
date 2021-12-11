﻿using validation_service.Models;

namespace validation_service.Validators
{
    internal class EmptyValidator : IValidator
    {
        public string validate(string value, ValidationConfiguration validationConfiguration)
        {
            if (!validationConfiguration.CanBeEmpty && value == "")
                return "Value cannot be empty and yet it is";
            return "";

        }
    }
}