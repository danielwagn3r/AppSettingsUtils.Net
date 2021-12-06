using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettingsUtils.Net
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The value in the config file as a double.</returns>
        /// <exception cref="ConfigurationErrorsException">The value is not specified or cannot be parsed as a double.</exception>
        public static double GetDouble(this IConfiguration configuration, string keyName)
        {
            var str = configuration.GetString(keyName);
            double value;
            if (!double.TryParse(str, out value))
            {
                string message = $"Unable to parse app setting value for {keyName} as a double: {str}";
                throw new ArgumentException(message);
            }
            return value;
        }

        /// <summary>
        ///     If the value is not present or is blank,
        ///     the <paramref name="defaultValue" /> is returned.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <param name="defaultValue"></param>
        /// <returns>
        ///     The value in the config file as a double, or <paramref name="defaultValue" /> if the config value does not
        ///     exist or is blank.
        /// </returns>
        public static double GetDouble(this IConfiguration configuration, string keyName, double defaultValue)
        {
            var str = configuration[keyName];
            double value;
            if (!double.TryParse(str, out value))
                value = defaultValue;
            return value;
        }

    }
}
