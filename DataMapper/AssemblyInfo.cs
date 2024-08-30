// <copyright file="AssemblyInfo.cs" company="Transilvania University of Brasov">
// Debu Matei
// </copyright>

// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

// This will cause log4net to look for a configuration file
// called TestApp.exe.config in the application base
// directory (i.e. the directory containing TestApp.exe)
// The config file will be watched for changes.