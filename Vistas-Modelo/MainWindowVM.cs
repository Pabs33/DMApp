using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using DMApp.Clases;
using DMApp.Servicios;

namespace DMApp.Vistas_Modelo
{
    class MainWindowVM: ObservableObject
    {
        //Propiedades
        private ObservableCollection<Player> playersList;
        public ObservableCollection<Player> PlayersList 
        { 
            get { return playersList; } 
            set { SetProperty(ref playersList, value); }
        }

        private Player playerSelected;
        public Player PlayerSelected
        {
            get { return playerSelected; }
            set { SetProperty(ref playerSelected, value); }
        }

        //Constructores
        public MainWindowVM() 
        {
            playersList = ServicioDatabase.GetJugadores();
            playerSelected = new Player();
        }

        //Funciones
        public void AddPlayer(string name, int vida, List<string> estados)
        {
            playersList.Add(new Player(name, vida, estados));
        }

        public void AddState(string name, string newState)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (PlayersList[i].Nombre == name)
                {
                    PlayersList[i].Estados.Add(newState);
                }
            }
        }

        public void RemoveState(string name, string stateToRemove)
        {
            for(int i = 0;i < PlayersList.Count; i++)
            {
                if(PlayersList[i].Nombre == name)
                {
                    PlayersList[i].Estados.Remove(stateToRemove);
                }
            }
        }

        public void AñadirJugador()
        {
            ServicioNavegacion.AbrirFormularioJugador();
        }

        public void DeleteJugador()
        {
            try
            {
                ServicioDatabase.EliminarJugador(PlayerSelected);
                RecargarDataGrid();
            }
            catch(Exception ex)
            {
                //TODO Agregar control de excepciones :)
                Console.WriteLine(ex.Message);
            }
        }

        public void EditarJugador()
        {
            ServicioNavegacion.AbrirFOrmularioJugador(PlayerSelected);
        }

        public void RecargarDataGrid()
        {
            PlayersList = ServicioDatabase.GetJugadores();
        }
    }
}
