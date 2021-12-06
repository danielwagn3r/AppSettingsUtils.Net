using Microsoft.Extensions.Configuration;
using System;

namespace AppSettingsUtils.Net
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The value in the config file as a TimeSpan.</returns>
        /// <exception cref="ConfigurationErrorsException">The value is not specified or cannot be parsed as a double.</exception>
        public static TimeSpan GetMilliseconds(this IConfiguration configuration, string keyName)
        {
            return TimeSpan.FromMilliseconds(configuration.GetDouble(keyName));
        }

        /// <summary>
        ///     If the value is not present or is blank, the <paramref name="defaultMillis" /> is returned.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <param name="defaultMillis"></param>
        /// <returns>
        ///     The value in the config file as a TimeSpan, or <paramref name="defaultMillis" /> if the config value does not
        ///     exist or is blank.
        /// </returns>
        public static TimeSpan GetMilliseconds(this IConfiguration configuration, string keyName, double defaultMillis)
        {
            return TimeSpan.FromMilliseconds(configuration.GetDouble(keyName, defaultMillis));
        }

        /// <summary>
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The value in the config file as a TimeSpan.</returns>
        /// <exception cref="ConfigurationErrorsException">The value is not specified or cannot be parsed as a double.</exception>
        public static TimeSpan GetSeconds(this IConfiguration configuration, string keyName)
        {
            return TimeSpan.FromSeconds(configuration.GetDouble(keyName));
        }

        /// <summary>
        ///     If the value is not present or is blank,
        ///     the <paramref name="defaultSeconds" /> is returned.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <param name="defaultSeconds"></param>
        /// <returns>
        ///     The value in the config file as a TimeSpan, or <paramref name="defaultSeconds" /> if the config value does not
        ///     exist or is blank.
        /// </returns>
        public static TimeSpan GetSeconds(this IConfiguration configuration, string keyName, double defaultSeconds)
        {
            return TimeSpan.FromSeconds(configuration.GetDouble(keyName, defaultSeconds));
        }

        /// <summary>
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The value in the config file as a TimeSpan.</returns>
        /// <exception cref="ConfigurationErrorsException">The value is not specified or cannot be parsed as a double.</exception>
        public static TimeSpan GetMinutes(this IConfiguration configuration, string keyName)
        {
            return TimeSpan.FromMinutes(configuration.GetDouble(keyName));
        }

        /// <summary>
        ///     If the value is not present or is blank,
        ///     the <paramref name="defaultMinutes" /> is returned.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <param name="defaultMinutes"></param>
        /// <returns>
        ///     The value in the config file as a TimeSpan, or <paramref name="defaultMinutes" /> if the config value does not
        ///     exist or is blank.
        /// </returns>
        public static TimeSpan GetMinutes(this IConfiguration configuration, string keyName, double defaultMinutes)
        {
            return TimeSpan.FromMinutes(configuration.GetDouble(keyName, defaultMinutes));
        }

        /// <summary>
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The value in the config file as a TimeSpan.</returns>
        /// <exception cref="ConfigurationErrorsException">The value is not specified or cannot be parsed as a double.</exception>
        public static TimeSpan GetDays(this IConfiguration configuration, string keyName)
        {
            return TimeSpan.FromDays(configuration.GetDouble(keyName));
        }

        /// <summary>
        ///     If the value is not present or is blank,
        ///     the <paramref name="defaultDays" /> is returned.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <param name="defaultDays"></param>
        /// <returns>
        ///     The value in the config file as a TimeSpan, or <paramref name="defaultDays" /> if the config value does not
        ///     exist or is blank.
        /// </returns>
        public static TimeSpan GetDays(this IConfiguration configuration, string keyName, double defaultDays)
        {
            return TimeSpan.FromDays(configuration.GetDouble(keyName, defaultDays));
        }
    }
}