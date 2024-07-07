using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMApp.Vistas;

namespace DMApp.Servicios
{
    internal class ServicioNavegacion
    {
        protected ServicioNavegacion() { }

        internal static bool? AbrirFormularioJugador() => new FormularioJugadorDialog().ShowDialog();
    }
}
