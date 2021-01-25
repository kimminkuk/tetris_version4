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
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            BindingContext = new MainXamarinViewModels(); // ?
            InitializeComponent();
            //BindingContext = new MainXamarinViewModels(); // ?
            //this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ((MainXamarinViewModels)BindingContext).EnterGame();
            
        }
    }
}
