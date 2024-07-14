using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DMApp.Clases;
using DMApp.Vistas_Modelo;

namespace DMApp.Vistas
{
    /// <summary>
    /// Interaction logic for FormularioJugadorDialog.xaml
    /// </summary>
    public partial class FormularioJugadorDialog : Window
    {
        private FormularioJugadorDialogVM vm = new FormularioJugadorDialogVM();
        public FormularioJugadorDialog()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        //Constructor para editar
        public FormularioJugadorDialog(Player jugador)
        {
            InitializeComponent();
            this.DataContext = vm;
            vm.Player = jugador;
            vm.Edit = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            vm.InsertarCliente();
            DialogResult = true;
        }
    }
}
