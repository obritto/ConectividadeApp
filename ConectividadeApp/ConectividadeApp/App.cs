using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ConectividadeApp
{
    public class App : Application
    {

        Label l = new Label
        {
            XAlign = TextAlignment.Center,
            Text = ""
        };

        Button btn = new Button
        {
            Text = "TESTE"
        };

        Button btn2 = new Button
        {
            Text = "LISTAR"
        };

        Entry txt = new Entry
        {
            Placeholder = "Host"
        };

        Button btn3 = new Button
        {
            Text = "Verificar Host"
        };


        public App()
        {
            btn.Clicked += Btn_Clicked;

            btn2.Clicked += Btn2_Clicked;

            btn3.Clicked += Btn3_Clicked;

            Connectivity.Plugin.CrossConnectivity.Current.ConnectivityChanged += 
                Current_ConnectivityChanged;


            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        l, btn, btn2, txt, btn3
                    }
                }
            };
        }


        private async void Btn3_Clicked(object sender, EventArgs e)
        {
            bool resposta = await Connectivity.Plugin.CrossConnectivity.Current.IsReachable(
                txt.Text, 5000);

            l.Text = resposta.ToString();
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            l.Text = "";
            foreach (var item in Connectivity.Plugin.CrossConnectivity.Current.Bandwidths)
            {
                l.Text += item.ToString() + "\n";
            }

        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.Plugin.CrossConnectivity.Current.IsConnected == true)
            {
                l.Text = "CONECTADO!";
            }
            else
            {
                l.Text = "OFF!";
            }
        }

        private void Current_ConnectivityChanged(object sender, 
            Connectivity.Plugin.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (e.IsConnected == true)
            {
                l.Text = "CONECTADO!";
            }
            else
            {
                l.Text = "OFF!";
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
