namespace AikoWebNewsApp;

static class Program
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
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) =>
        {
            MessageBox.Show("La app ha controlado un error inesperado: " + e.Exception.Message, "Aiko Web News App", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };
        Application.Run(new Form1());
    }    
}
