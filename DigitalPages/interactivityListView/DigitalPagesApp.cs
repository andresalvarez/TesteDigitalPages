using DigitalPages.ViewModel;
using System;

using Xamarin.Forms;


namespace DigitalPages
{
	public class App : Application
	{
        public InformacoesXaml informacoes;
        private DigitalPagesCode dpc;
        public App (string[] personagens)
		{

			MainPage = new NavigationPage();
            dpc = new DigitalPagesCode(personagens);
            dpc.ClickPersonagem += Dpc_ClickPersonagem;
            MainPage.Navigation.PushAsync (dpc);
		}

        private void Dpc_ClickPersonagem(object sender, EventArgs e)
        {
            Personagem = ((ClickPersonagemEventArgs)e).Personagem;
            OnClickPersonagem((ClickPersonagemEventArgs)e);
        }

        public  void OpenDetalhe(InformacoesViewModel personagem)
        {
            dpc.OpenDetalhe(personagem);
        }


        string Personagem = "";
        public InformacoesViewModel info = new InformacoesViewModel();

        public event EventHandler ClickPersonagem;

        
       

        protected virtual void OnClickPersonagem(ClickPersonagemEventArgs e)
        {
            if (ClickPersonagem != null)
            {
                e.Personagem = Personagem;
                ClickPersonagem(this, e);
            }
        }
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}

    public class ClickPersonagemEventArgs : EventArgs
    {
    
        private string text = "";

    
        public ClickPersonagemEventArgs(string Personagem)
        {
            text = Personagem;
        }

 
        public string Personagem
        {
            get { return text; }
            set { this.text = value; }
        }

    
    }
}

