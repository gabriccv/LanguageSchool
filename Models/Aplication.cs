using SR39_2021_pop2022_2.Services;
using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SR39_2021_pop2022_2.Models
{
    class Aplication
    {
        public ObservableCollection<Address> Addresses { get; set; }

        //singleton pattern; Jedan objekat klase Aplikacija postoji u celom programu. Svi delovi programa koriste ovaj objekat
        private static Aplication instance = new Aplication();

        public static Aplication Instance
        {
            get
            {
                return instance;
            }
        }

        private Aplication()
        {
            Addresses = new ObservableCollection<Address>();
            
        }
      

    }
}
