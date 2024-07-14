using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DMApp.Clases
{
    public class Player: ObservableObject, INotifyPropertyChanged
    {

        //Propiedades
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        private int vida;
        public int Vida
        {
            get { return vida; }
            set { SetProperty(ref vida, value); }
        }

        private List<string> estados;
        public List<string> Estados
        {
            get { return estados; }
            set { SetProperty(ref estados, value); }
        }

        private string estadosString;
        public string EstadosString
        {
            get { return estadosString; }
            set { SetProperty(ref estadosString, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyRaised(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        //Constructores
        public Player(string nombre, int vida, List<string> estados)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.estados = estados;
            EstadosToString();
        }

        public Player(string nombre, int vida, string estadosString)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.estadosString = estadosString;
            this.estados = new List<string>();
            EstadosStringToList();
        }

        public Player() 
        {
            this.Estados = new List<string>();
            this.EstadosString = "";
        }

        //Funciones
        public void AddState(string newState)
        {
            this.estados.Add(newState);
        }

        public void EstadosToString()
        {
            string estadosEnString = "";
            for (int i = 0; i < this.estados.Count; i++)
            {
                if(i == this.estados.Count - 1)
                {
                    estadosEnString += estados[i];
                }
                else
                {
                    estadosEnString += estados[i] + ",";
                }
            }
            this.estadosString = estadosEnString;
        }

        public void EstadosStringToList()
        {
            string[] listaEstados = EstadosString.Split(',');
            for(int i = 0; i < listaEstados.Length; i++)
            {
                Estados.Add(listaEstados[i]);
            }
        }
    }
}
