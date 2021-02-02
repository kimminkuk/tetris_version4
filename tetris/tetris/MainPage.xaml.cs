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
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainXamarinViewModels();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MainXamarinViewModels MV = (MainXamarinViewModels)BindingContext;
            MV.EnterGame();
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
