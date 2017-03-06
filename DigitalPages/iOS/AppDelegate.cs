using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using ImageCircle.Forms.Plugin.iOS;
using DigitalPages.ViewModel;

namespace DigitalPages.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
        public DigitalPages.App apps;
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

            ImageCircleRenderer.Init();
            string[] teste = { "" };


            var Personagens = new MarvelBindingIOS.MarvelWS();
            apps = new DigitalPages.App(Personagens.ListaPersonagens());
            apps.ClickPersonagem += App_ClickPersonagem;

            LoadApplication (apps);

			return base.FinishedLaunching (app, options);
		}

        private void App_ClickPersonagem(object sender, EventArgs e)
        {
            var args = (ClickPersonagemEventArgs)e;
            var Personagens = new MarvelBindingIOS.MarvelWS();

            InformacoesViewModel info = new InformacoesViewModel();

            info.Personagem = args.Personagem;
            info.Descricao = Personagens.DetalhePersonagem(info.Personagem).Descricao;
            info.Fasciculos = Personagens.ListaFasciculos();

            apps.OpenDetalhe(info);
        }
    }
}

