using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Com.MarvelWS;
using DigitalPages.ViewModel;

namespace DigitalPages.Droid
{
	[Activity (Label = "DigitalPages.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
        public App app;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
            ImageCircleRenderer.Init();

            var Personagens = new Com.MarvelWS.Marvel();
            app = new App(Personagens.ListaPersonagens());
            app.ClickPersonagem += App_ClickPersonagem;
            LoadApplication (app);
		}

        private void App_ClickPersonagem(object sender, EventArgs e)
        {
            var args = (ClickPersonagemEventArgs)e;
            var Personagens = new Com.MarvelWS.Marvel();

            InformacoesViewModel info = new InformacoesViewModel();

            info.Personagem = args.Personagem;
            info.Descricao = Personagens.DetalhePersonagem(info.Personagem).Descricao;
            info.Fasciculos = Personagens.ListaFasciculos();

            app.OpenDetalhe(info);
    }
    }
}

