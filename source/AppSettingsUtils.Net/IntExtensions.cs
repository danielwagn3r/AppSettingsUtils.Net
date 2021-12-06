using Microsoft.Extensions.Configuration;
using System;

namespace AppSettingsUtils.Net
{
    public static class IntExtensions
    {
        /// <summary>
        ///     Gets the config value for specified key and parses it as an int.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The value in the config file as an int.</returns>
        /// <exception cref="ConfigurationErrorsException">The value is not specified or cannot be parsed as in int.</exception>
        public static int GetInt(this IConfiguration configuration, string keyName)
        {
            var str = configuration.GetString(keyName);
            int value;
            if (!int.TryParse(str, out value))
            {
                string message = $"Unable to parse app setting value for {keyName} as an int: {str}";
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
        ///     The value in the config file as an int, or <paramref name="defaultValue" /> if the config value does not exist
        ///     or is blank.
        /// </returns>
        public static int GetInt(this IConfiguration configuration, string keyName, int defaultValue)
        {
            var str = configuration[keyName];
            int value;
            if (!int.TryParse(str, out value))
                value = defaultValue;
            return value;
        }

        /// <summary>
        ///     Gets the config value for specified key and parses it as an int.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The value in the config file as an int.</returns>
        /// <exception cref="ConfigurationErrorsException">The value is not specified or cannot be parsed as in int.</exception>
    }
}