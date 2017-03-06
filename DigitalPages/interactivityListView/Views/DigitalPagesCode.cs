using DigitalPages.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using DigitalPages.Views;
using DigitalPages.ViewModel;

namespace DigitalPages
{
	public class DigitalPagesCode : ContentPage
	{
		public static ObservableCollection<string> items { get; set; }

        public static string personagem { get; set; }
        public DigitalPagesCode(string[] Personagens)
		{
            items = new ObservableCollection<string>();
            foreach (string s in Personagens)
            {
                items.Add(s);

            }
            
			ListView lstView = new ListView ();
			lstView.IsPullToRefreshEnabled = true;
			lstView.Refreshing += OnRefresh;
			lstView.ItemTapped += OnTap;
			lstView.ItemsSource = items;
			var temp = new DataTemplate (typeof(CustomCell));
			lstView.ItemTemplate = temp;
			Content = lstView;
		}

		async void OnTap (object sender, ItemTappedEventArgs e)
		{
            ///DisplayAlert ("Item Tapped", e.Item.ToString (), "Ok");
            ///
            try
            {
                
                var args  = new ClickPersonagemEventArgs(e.Item.ToString());
                OnClickPersonagem(args);
               
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "ok");
            }
        }
        public async void OpenDetalhe(InformacoesViewModel personagem)
        {

            await Navigation.PushAsync(new InformacoesXaml(personagem));

        }

        public event EventHandler ClickPersonagem;

        protected virtual void OnClickPersonagem(ClickPersonagemEventArgs e)
        {
            if (ClickPersonagem != null)
            {
              //  e.Personagem = personagem;
                ClickPersonagem(this, e);
            }
        }

        void OnRefresh (object sender, EventArgs e)
		{
			var list = (ListView)sender;
			//put your refreshing logic here
			var itemList = items.Reverse().ToList();
			items.Clear ();
			foreach (var s in itemList) {
				items.Add (s);
			}
			//make sure to end the refresh state
			list.IsRefreshing = false;
		}


	}

	public class textViewCell : ViewCell{
		public textViewCell()
		{
			StackLayout layout = new StackLayout ();
			layout.Padding = new Thickness (15, 0);
			Label label = new Label ();

			label.SetBinding (Label.TextProperty, ".");
			layout.Children.Add (label);

			var moreAction = new MenuItem { Text = "More" };
			moreAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			moreAction.Clicked += OnMore;

			var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
			deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			deleteAction.Clicked += OnDelete;

			this.ContextActions.Add (moreAction);
			this.ContextActions.Add (deleteAction);
			View = layout;
		}

		void OnMore (object sender, EventArgs e)
		{
			var item = (MenuItem)sender;
			//Do something here... e.g. Navigation.pushAsync(new specialPage(item.commandParameter));
			//page.DisplayAlert("More Context Action", item.CommandParameter + " more context action", 	"OK");
		}

		void OnDelete (object sender, EventArgs e)
		{
			var item = (MenuItem)sender;
            DigitalPagesCode.items.Remove (item.CommandParameter.ToString());
		}
	}
}


