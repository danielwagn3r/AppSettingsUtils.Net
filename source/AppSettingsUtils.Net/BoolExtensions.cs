using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettingsUtils.Net
{
    public static class BoolExtensions
    {
        /// <summary>
        ///     Gets the config value for specified in <paramref name="keyName" /> and parses it as bool.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The value in the config file as a bool.</returns>
        /// <exception cref="ConfigurationErrorsException">The value is not specified or cannot be parsed as a bool.</exception>
        public static bool GetBool(this IConfiguration configuration, string keyName)
        {
            var str = configuration.GetString(keyName);
            bool result;
            if (!bool.TryParse(str, out result))
            {
                string message = $"Unable to parse app setting value for {keyName} as a bool: {str}";
                throw new ArgumentException(message);
            }
            return result;
        }

        /// <summary>
        ///     If the value is not present or is blank, the <paramref name="defaultValue" /> is returned.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <param name="defaultValue"></param>
        /// <returns>
        ///     The value in the config file as a bool, or <paramref name="defaultValue" /> if the config value does not exist
        ///     or is blank.
        /// </returns>
        public static bool GetBool(this IConfiguration configuration, string keyName, bool defaultValue)
        {
            var str = configuration[keyName];
            bool result;
            if (bool.TryParse(str, out result))
                return result;
            return defaultValue;
        }

        /// <summary>
        ///     Tries to read the key from the config file.  If the value is not specified, false is returned.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <param name="value">
        ///     The value as specified in the config file.  This value will be false if no key value exists in
        ///     config.
        /// </param>
        /// <returns>True if the key exists, otherwise false.</returns>
        public static bool TryGetBool(this IConfiguration configuration, string keyName, out bool value)
        {
            var str = configuration[keyName];
            return bool.TryParse(str, out value);
        }

    }
}
