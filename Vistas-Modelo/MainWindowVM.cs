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

        //Constructores
        public MainWindowVM() 
        {
            playersList = ServicioDatabase.GetJugadores();
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
                if (playersList[i].Nombre == name)
                {
                    playersList[i].Estados.Add(newState);
                }
            }
        }

        public void RemoveState(string name, string stateToRemove)
        {
            for(int i = 0;i < playersList.Count; i++)
            {
                if(playersList[i].Nombre == name)
                {
                    playersList[i].Estados.Remove(stateToRemove);
                }
            }
        }

        public void AñadirJugador()
        {
            ServicioNavegacion.AbrirFormularioJugador();
        }
    }
}
