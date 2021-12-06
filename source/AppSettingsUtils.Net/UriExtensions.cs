using Microsoft.Extensions.Configuration;
using System;

namespace AppSettingsUtils.Net
{
    public static class UriExtensions
    {
        /// <summary>
        ///     Gets the configuration value for the specified key.  If the value is not present or is blank,
        ///     an exception is thrown.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <exception cref="ConfigurationErrorsException">The value is not specified, or is blank.</exception>
        /// <returns>The value in the config file.</returns>
        public static Uri GetUri(this IConfiguration configuration, string keyName)
        {
            var str = configuration[keyName];
            if ((str == null) || (str.Trim().Length == 0))
                throw new ArgumentException($"No application setting available for key: {keyName}");
            var uri = new Uri(str);
            return uri;
        }

        /// <summary>
        ///     Gets the configuration value for the specified key.  If the value is not present or is blank,
        ///     the <paramref name="defaultValue" /> is returned.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <param name="defaultValue"></param>
        /// <returns>
        ///     The value in the config file, or <paramref name="defaultValue" /> if the config value does not exist or is
        ///     blank.
        /// </returns>
        public static Uri GetUri(this IConfiguration configuration, string keyName, string defaultValue)
        {
            var str = configuration[keyName];
            if ((str == null) || (str.Trim().Length == 0))
                str = defaultValue;
            var uri = new Uri(str);
            return uri;
        }
    }
}