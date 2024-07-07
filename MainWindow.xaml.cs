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
    MainWindowVM mainWindowVM;
    public MainWindow()
    {
        InitializeComponent();
        ServicioDatabase.ConnectDatabase();
        mainWindowVM = new MainWindowVM();
        DataContext = mainWindowVM;
    }

    private void AddButton_Click(Object sender, RoutedEventArgs e)
    {
        mainWindowVM.AñadirJugador();
    }
}