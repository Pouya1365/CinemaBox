using System.Reflection;

namespace CinemaBox.Presentation;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            string dllName = new AssemblyName(assemblyName: args.Name).Name + ".dll";
            string dllPath = Path.Combine(path1: AppDomain.CurrentDomain.BaseDirectory, path2: "libs", path3: dllName);
            return File.Exists(dllPath) ? Assembly.LoadFrom(dllPath) : null;
        };
        Application.Run(new Form1());
    }
}