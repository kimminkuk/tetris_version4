using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using tetris.Models;

namespace tetris.ViewModels
{
    public class MainXamarinViewModels : INotifyPropertyChanged
    {
        const int TETRIS_Width  = 21;
        const int TETRIS_Height = 12;
        int[,] _block_buf = new int[4, 4];
        int[,] _memory_pan = new int[TETRIS_Width, TETRIS_Height];
        int next_block = 0;
        int block_kind = 0;
        int status_x = 0;
        int status_y = 0;
        int double_bounus = 0;

        int game_score;
        int game_line;
        int game_level;

        public bool Is_gaming { get; set; } = false;

        //public int Game_level 
        //{
        //    set 
        //    { 
        //        if( G )
        //    } 
        //}
        
        public int Game_score { get => game_score; set { game_score = value; NotifyPropertyChanged("Game_score"); } }
        public int Game_line { get => game_line; set { game_line = value; NotifyPropertyChanged("Game_line"); } }
        public int Game_level { get => game_level; set { game_level = value; NotifyPropertyChanged("Game_level"); } }

        public BindableTwoDArray<int> Block_pan { get => block_pan; set => block_pan = value; }
        public BindableTwoDArray<int> Next_pan { get => next_pan; set => next_pan = value; }

        private BindableTwoDArray<int> block_pan = new BindableTwoDArray<int>(21, 12);
        private BindableTwoDArray<int> next_pan = new BindableTwoDArray<int>(4, 4);

        Random rnd = new Random();

        public MainXamarinViewModels()
        {
            Init_game();
            
        }

        private void DrawCrash()
        {
            return;
        }

        private void Block_down()
        {
            return;
        }

        private void Init_game()
        {
            block_kind = rnd.Next(1, 7);
            next_block = rnd.Next(1, 7);
            status_x = 4;
            status_y = -3;

            DrawBufBlock(block_kind, _block_buf);
            game_level = 1;
            game_line = 0;
            game_score = 0;

            DrawPanBlock();

        }

        internal void EnterGame()
        {
            if (Is_gaming == false)
            {
                Init_game();

                Is_gaming = true;

                //DrawNext();
                //Block_down();
                //StartTimer();
            }
            else
            {
                DrawCrash();
            }
        }

        private void DrawPanBlock()
        {
            int i = 0, j = 0;
            for(i = 0; i < TETRIS_Width; i++)
            {
                for(j = 0; j < TETRIS_Height; j++)
                {
                    if ( i == 0 || j == 11 || i == 20 ) //End Side
                    {
                        block_pan[i, j]  = Constants.Block_wall;
                        _memory_pan[i, j] = Constants.Block_wall;
                    }
                    else //Normal 
                    {
                        block_pan[i, j] = Constants.Block_background;
                        _memory_pan[i, j] = Constants.Block_background;
                    }
                }
            }
            block_pan.NotifyBlockChaned("Block_pan");
        }

        private void DrawBufBlock(int block_kind, int[,] block_buf)
        {
            int i, j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    block_buf[i, j] = 0;
                }
            }

            switch (block_kind)
            {
                case 1:
                    block_buf[2, 0] = block_buf[2, 1] = block_buf[2, 2] = block_buf[2, 3] = block_kind;
                    break;
                case 2:
                    block_buf[1, 1] = block_buf[1, 2] = block_buf[2, 1] = block_buf[2, 2] = block_kind;
                    break;
                case 3:
                    block_buf[1, 1] = block_buf[2, 0] = block_buf[2, 1] = block_buf[2, 2] = block_kind;
                    break;
                case 4:
                    block_buf[1, 2] = block_buf[2, 0] = block_buf[2, 1] = block_buf[2, 2] = block_kind;
                    break;
                case 5:
                    block_buf[1, 1] = block_buf[2, 1] = block_buf[2, 2] = block_buf[2, 3] = block_kind;
                    break;
                case 6:
                    block_buf[1, 1] = block_buf[1, 2] = block_buf[2, 0] = block_buf[2, 1] = block_kind;
                    break;
                case 7:
                    block_buf[1, 0] = block_buf[1, 1] = block_buf[2, 1] = block_buf[2, 2] = block_kind;
                    break;
            }
        }

        #region notifyproperty
        public event PropertyChangedEventHandler PropertyChanged;
        //private void NotifyPropertyChanged(string propertyName)
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
