using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DMApp.Servicios;
using DMApp.Vistas_Modelo;

namespace DMApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    //Falla al llamar al MainWIndowVM porque ahi se hace un Get Y la base de datos todavía no esta instanciada ya que se instancia en el Constructor
    //TODO Solucionar
    MainWindowVM mainWindowVM;
    public MainWindow()
    {
        InitializeComponent();
        ServicioDatabase.ConnectDatabase();
        mainWindowVM = new MainWindowVM();
        DataContext = mainWindowVM;
    }
}