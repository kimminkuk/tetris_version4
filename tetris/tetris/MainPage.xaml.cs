using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tetris.ViewModels;
using Xamarin.Forms;

namespace tetris
{
    public partial class MainPage : ContentPage
    {
        public static MainXamarinViewModels MX = new MainXamarinViewModels();
        public MainPage()
        {
            
            
            //Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            //{
            //    // do something every 60 seconds
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        // interact with UI elements
            //        BindingContext = new MainXamarinViewModels();
            //    });
            //    return true; // runs again, or false to stop
            //});
            //((MainXamarinViewModels)BindingContext).EnterGame();

            InitializeComponent();
            BindingContext = new MainXamarinViewModels();
            
            
            //this.BindingContext = new MainXamarinViewModels();
            //this.BindingContext = MX;

          //  this.BindingContext = MX;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            MainXamarinViewModels MV = (MainXamarinViewModels)BindingContext;
            MV.EnterGame();
            //MX.EnterGame();
            //MX.EnterGame();
            //this.BindingContext = MainPage.BindingContextProperty;
            //BindingContext = new MainXamarinViewModels();
            //((MainXamarinViewModels)BindingContext).EnterGame();
            //Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            //{
            //    // do something every 60 seconds
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        // interact with UI elements
            //        MainXamarinViewModels mm = new MainXamarinViewModels();
            //        this.BindingContext = mm;
            //    });
            //    return true; // runs again, or false to stop
            //});

            //MainXamarinViewModels mainXamarinViewModels = new MainXamarinViewModels();
            //this.BindingContext = mainXamarinViewModels;
        }

        private void Button_Clicked_LEFT(object sender, EventArgs e)
        {
            MainXamarinViewModels MV = (MainXamarinViewModels)BindingContext;
            if(MV.Is_gaming) //IF TRUE
            {
                MV.Block_left();
            }
            else
            {
                return;
            }
        }
        private void Button_Clicked_DOWN(object sender, EventArgs e)
        {
            MainXamarinViewModels MV = (MainXamarinViewModels)BindingContext;
            if (MV.Is_gaming) //IF TRUE
            {
                MV.Block_down();
            }
            else
            {
                return;
            }
        }
        private void Button_Clicked_RIGHT(object sender, EventArgs e)
        {
            MainXamarinViewModels MV = (MainXamarinViewModels)BindingContext;
            if (MV.Is_gaming) //IF TRUE
            {
                MV.Block_right();
            }
            else
            {
                return;
            }
        }
        private void Button_Clicked_ROTATE(object sender, EventArgs e)
        {
            MainXamarinViewModels MV = (MainXamarinViewModels)BindingContext;
            if (MV.Is_gaming) //IF TRUE
            {
                MV.Block_rotate();
            }
            else
            {
                return;
            }
        }
        private void Button_Clicked_DROP(object sender, EventArgs e)
        {
            MainXamarinViewModels MV = (MainXamarinViewModels)BindingContext;
            if (MV.Is_gaming) //IF TRUE
            {
                MV.Block_drop();
            }
            else
            {
                return;
            }
        }
    }
}
