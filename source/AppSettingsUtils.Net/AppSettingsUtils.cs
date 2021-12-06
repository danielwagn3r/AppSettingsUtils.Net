using Microsoft.Extensions.Configuration;
using System;
using System.Drawing;
using System.IO;

namespace AppSettingsUtils.Net
{
    /// <summary>
    ///     Utility class for reading values from <tt>App.config</tt> and <tt>Web.config</tt> files.  Methods of this
    ///     class support reading values of various types.  Overloads of these methods support case where value is
    ///     mandatory or optional.  For optional keys use overloads which accept default values.
    /// </summary>
    /// <remarks>
    ///     Taken from https://drewnoakes.com/code/util/app-settings-util/
    /// </remarks>
    public static class UtilExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The CSV value in the config file, split into its components and returned as a string array.</returns>
        public static string[] GetCsv(this IConfiguration configuration, string keyName)
        {
            var str = configuration.GetString(keyName);
            return str.Split(',');
        }

        /// <summary>
        ///     Gets the path string associated with the specified key, and ensures that the path exists.
        ///     If the path does not exist, a <see cref="ConfigurationErrorsException" /> is thrown.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The path specified in the config file, with a guarantee that it exists on the disk.</returns>
        /// <exception cref="ConfigurationErrorsException">The key is not present in appSettings, or the path does not exist.</exception>
        public static string GetExistingFilePath(this IConfiguration configuration, string keyName)
        {
            var path = configuration.GetString(keyName);
            if (!File.Exists(path))
                throw new FileNotFoundException(
                          $"Configuration key '{keyName}' holds a non-existant file path: {path}");
            return path;
        }

        /// <summary>
        ///     If the value is not present or is blank or it is not a valid color name, the <paramref name="defaultValue" /> is
        ///     returned.
        /// </summary>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <param name="defaultValue"></param>
        /// <returns>
        ///     The value in the config file as a Color, or <paramref name="defaultValue" /> if the config value does not
        ///     exist or is blank, or it's not valid Color name.
        /// </returns>
        public static Color GetColor(this IConfiguration configuration, string keyName, Color defaultValue)
        {
            var str = configuration[keyName];

            var color = defaultValue;
            if (str != null)
            {
                color = Color.FromName(str);
                if (color.ToArgb() == 0)
                    return defaultValue;
            }

            return color;
        }

        /// <summary>
        ///     Gets the enum value from the config document having the specified key.  The enum value is compared in a
        ///     case-insensitive fashion.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>The parsed enum value.</returns>
        /// <exception cref="ConfigurationErrorsException">The key was not present</exception>
        /// <exception cref="ConfigurationErrorsException">
        ///     The config value could not be parsed as a value of enum
        ///     <typeparamref name="T" />
        /// </exception>
        public static T GetEnum<T>(this IConfiguration configuration, string keyName)
        {
            var value = configuration.GetString(keyName);
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (ArgumentException ex)
            {
                string message =
                    $"Configuration key '{keyName}' has value '{value}' that could not be parsed as a member of the {typeof(T).Name} enum type.";
                throw new ArgumentException(message, ex);
            }
        }

        /// <summary>
        ///     Gets a connection string from the connectionStrings node in config.  Note that this method reads
        ///     from the <tt>configuration</tt> section, not the <tt>appSettings</tt> one.
        /// </summary>
        /// <remarks>
        ///     Config sections for connection strings look like this:
        ///     <code>
        /// &lt;configuration&gt;
        ///     &lt;connectionStrings&gt;
        ///         &lt;add name="NAV" connectionString="Data Source=SERVER;Initial Catalog=DATABASE;User ID=USER;Password=PASSWORD"/&gt;
        ///     &lt;/connectionStrings&gt;
        /// &lt;/configuration&gt;
        /// </code>
        /// </remarks>
        /// <param name="keyName">The name of the key, as specified in application config.</param>
        /// <returns>A connection string from the config file.</returns>
        /// <exception cref="ConfigurationErrorsException">
        ///     No connection string section was found or no entry present with
        ///     specified key.
        /// </exception>
        public static string GetConnectionString(this IConfiguration configuration, string keyName)
        {
            /*
            <configuration>
                <connectionStrings>
                    <add name="NAV" connectionString="Data Source=SERVER;Initial Catalog=DATABASE;User ID=USER;Password=PASSWORD"/>
                </connectionStrings>
            </configuration>
            */

            var connStr = configuration.GetConnectionString(keyName);
            if (connStr == null)
                throw new ArgumentException($"No connection string found for key: {keyName}");
            return connStr;
        }

        public static bool ConnectionStringExists(this IConfiguration configuration, string keyName)
        {
            return configuration.GetConnectionString(keyName) != null;
        }
    }
}