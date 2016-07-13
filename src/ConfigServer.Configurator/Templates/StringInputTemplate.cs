﻿using ConfigServer.Core;
using System.Text;

namespace ConfigServer.Configurator.Templates
{
    internal static class StringInputTemplate
    {
        public static string Build(object value, ConfigurationPropertyModel definition)
        {
            return $"<input type=\"text\" name=\"{definition.ConfigurationPropertyName}\" value=\"{value}\" {BuildValidationElement(definition)}>";
        }

        private static string BuildValidationElement(ConfigurationPropertyModel definition)
        {
            var builder = new StringBuilder();
            if (definition.ValidationRules.MaxLength.HasValue)
                builder.Append($"maxlength=\"{definition.ValidationRules.MaxLength}\" ");
            if (!string.IsNullOrWhiteSpace(definition.ValidationRules.Pattern))
                builder.Append($"pattern=\"{definition.ValidationRules.Pattern}\" ");
            return builder.ToString();
        }
    }
}