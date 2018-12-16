namespace DIA_GestionFlota
{
	/// <summary>
    /// Ppal.
    /// </summary>
	using System.Windows.Forms;
    public static class Ppal
    {
		/// <summary>
        /// Escribe usando <see cref="Consola"/>
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
		{
			var mainForm = new MainWindow().MainWindowView;
            Application.Run(mainForm);
		}
	}
}