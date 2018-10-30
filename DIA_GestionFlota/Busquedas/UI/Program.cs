
namespace Busquedas
{

    using System.Windows.Forms;
   
    class Program
    {
        static void Main(string[] args)
        {

            var mainForm = new MainWindow().MainWindowView;
            Application.Run(mainForm);
        }
    }
}
