using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using DMApp.Clases;
using DMApp.Servicios;

namespace DMApp.Vistas_Modelo
{
    class FormularioJugadorDialogVM: ObservableObject
    {
        //Propiedades

        private bool edit;
        public bool Edit
        {
            get { return edit; }
            set { SetProperty(ref edit, value); }
        }

        private Player player;
        public Player Player
        {
            get { return player; }
            set { SetProperty(ref player, value); }
        }

        public FormularioJugadorDialogVM()
        {
            player = new Player();
        }

        public void InsertarCliente()
        {
            if(Edit)
            {
                ServicioDatabase.EditarJugador(this.Player);
            }
            else
            {
                //Hacer comprobaciones de que esten todos los campos y añadirlo a la BBDD
                if(Player.Nombre != null && Player.Vida != null)
                {
                    ServicioDatabase.InsertarJugador(Player);
                }
                else
                {
                    //TODO Mandar mensaje de que no estan todos los campos obligatorios
                }
            }
        }
    }
}
