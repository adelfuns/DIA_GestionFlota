namespace ProyectoFlota
{
    using System;
    using ProyectoFlota.UI;
    using System.Windows.Forms;
    public static class Ppal
    {
        public static void Main(string[] args)
        {
            var mainForm = new MainWindow().MainWindowView;
            Application.Run(mainForm);
        }
    }
}