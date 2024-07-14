using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMApp.Clases;
using DMApp.Vistas;

namespace DMApp.Servicios
{
    internal class ServicioNavegacion
    {
        protected ServicioNavegacion() { }

        //Nuevo Jugador
        internal static bool? AbrirFormularioJugador() => new FormularioJugadorDialog().ShowDialog();

        //Editar Jugador
        internal static bool? AbrirFOrmularioJugador(Player p) => new FormularioJugadorDialog(p).ShowDialog();
    }
}
