using DigitalPages.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace DigitalPages
{

	public partial class InformacoesXaml : ContentPage
	{
		public static ObservableCollection<string> items { get; set; }
        public static ViewModel.InformacoesViewModel tela { get; set; }
        public InformacoesXaml(InformacoesViewModel personagem)
		{
            tela = personagem;
        
            items = new ObservableCollection<string> ();
            foreach (string s in personagem.Fasciculos)
            {
                items.Add(s);
            }
            InitializeComponent ();
		}

		
		void OnRefresh (object sender, EventArgs e)
		{
			var list = (ListView)sender;
			
			var itemList = items.Reverse().ToList();
			items.Clear ();
			foreach (var s in itemList) {
				items.Add (s);
			}
			
			list.IsRefreshing = false;
		}

	
		

		
	}
}

