using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalPages.ViewModel
{
    public class InformacoesViewModel : INotifyPropertyChanged
    {
        string _personagem;
        string _descricao;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Personagem
        {
            get
            {


                return _personagem;
            }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Personagem"));
                }

                _personagem = value;
            }

        }
        public string Descricao
        {
            get
            {


                return _descricao;
            }
            set
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Descricao"));
                }

                _descricao = value;
            }
        }

        public string Img
        {
            get
            {
                return _personagem.Replace(" ","") + ".jpg";
            }

        }

        public string[] Fasciculos { get; set; }
    }
        
}
