using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using Xamarin.Forms; // fail?

using tetris.Models;

namespace tetris.ViewModels
{
    public class MainXamarinViewModels : INotifyPropertyChanged
    {
        const int TETRIS_Width = 21;
        const int TETRIS_Height = 12;
        int[,] _block_buf = new int[4, 4];
        int[,] _memory_pan = new int[21, 12];
        int next_block = 0;
        int block_kind = 0;
        int status_x = 0;
        int status_y = 0;
        int double_bounus = 0;
        double level_interval = 1000;

        int time_interval = 1000;
        int save_time = 0;

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
       // public BindableTwoDArray<int> Block_pan { get => block_pan; set { block_pan = value; block_pan.NotifyBlockChaned("Block_pan"); } }
       // public BindableTwoDArray<int> Next_pan { get => next_pan; set { next_pan = value; next_pan.NotifyBlockChaned("Block_pan"); } }

        public BindableTwoDArray<int> Next_pan { get => next_pan; set => next_pan = value; }

        private BindableTwoDArray<int> block_pan = new BindableTwoDArray<int>(21, 12);
        private BindableTwoDArray<int> next_pan = new BindableTwoDArray<int>(4, 4);

        

        Random rnd = new Random();
        System.Timers.Timer timer;
        System.Threading.Timer timer_;

        public void timer_start(TimerCallback callback, int start_, int sendtime)
        {
            timer_ = new System.Threading.Timer(callback, null, start_, sendtime);
        }
        public void timer_stop()
        {
            timer_.Dispose();
        }

        public MainXamarinViewModels()
        {
            Init_game();
            
            ////timer = new System.Timers.Timer(time_interval);
            //timer.Interval = level_interval;
            
            //timer.Start();
            //timer.Elapsed += My_Timer_Tick_;
            //
            //timer.Enabled = true;
            //timer.Elapsed += new System.Timers.ElapsedEventHandler(My_Timer_Tick);
            //Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            //TIME_Thread.Start();            
        }

        private void StartTimer()
        {
            time_interval = 1000 - ((game_level - 1) * 200);
            ////Device.StartTimer(TimeSpan.FromTicks(time_interval), () =>
            //{
            //
            //    // do something every 60 seconds
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        // interact with UI elements
            //        timer.Interval = level_interval;
            //        timer.Start();
            //    });
            //    return true; // runs again, or false to stop
            //});
            //
            //save_time = time_interval;

            timer_start(My_Timer_Tick_object, 0, time_interval);

        }

        private void StopTimer()
        {
            timer.Stop();
        }

        private void grid_color(object sender, EventArgs e)
        {
            DrawPanBlock();
        }

        private void My_Timer_Tick_(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Is_gaming)
            {
                Block_down();
            }
            else
            {
                DrawCrash();
            }
        }

        private void My_Timer_Tick()
        {
            if (Is_gaming)
            {
                Block_down();
            }
            else
            {
                DrawCrash();
            }
        }

        private void My_Timer_Tick_object(object object_)
        {
            if (Is_gaming)
            {
                Block_down();
            }
            else
            {
                DrawCrash();
            }
        }

        private void DrawCrash()
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

        public void EnterGame()
        {
            
            if (Is_gaming == false)
            {
                Init_game();

                Is_gaming = true;

                DrawNext();
                Block_down();
                StartTimer();
            }
            else
            {
                DrawCrash();
               
            }
        }

        private void DrawNext()
        {
            DrawBufBlock(next_block, next_pan);
            next_pan.NotifyBlockChaned(nameof(Block_pan));
        }

        private void DrawPanBlock()
        {
            int i = 0, j = 0;
            for(i = 0; i < TETRIS_Width; i++)
            {
                for(j = 0; j < TETRIS_Height; j++)
                {
                    if ( j == 0 || j == 11 || i == 20 ) //End Side
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
            //next_pan.NotifyBlockChaned(nameof(Block_pan));
            NotifyPropertyChanged(nameof(Block_pan));
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

        public void Block_down()
        {
            if(Check_Can_Move(Constants.MOVE_DOWN))
            {
                DrawCurrentBlock(Constants.Block_background);
                status_y++;
                DrawCurrentBlock(block_kind);
            }
            else
            {
                int i = 0;
                int j = 0;
                for (i = 0; i < 4; i++)
                {
                    for ( j = 0; j < 4; j++ )
                    {
                        if (_block_buf[i,j] != 0 && (status_x +j ) >= 0 && (status_y+i) >= 0 )
                        {
                            _memory_pan[status_y + i, status_x + j] = block_kind;
                        }
                    }
                }
                Cal_Block();
                NewBlock();
            }
        }
        public void Block_drop()
        {
            DrawCurrentBlock(Constants.Block_background);

            while (Check_Can_Move(Constants.MOVE_DOWN))
            {
                status_y++;
            }
            DrawCurrentBlock(block_kind);
            Block_down();
        }

        public void Block_left()
        {
            if (Check_Can_Move(Constants.MOVE_LEFT))
            {
                DrawCurrentBlock(Constants.Block_background);
                status_x--;
                DrawCurrentBlock(block_kind);
            }
        }

        public void Block_right()
        {
            if (Check_Can_Move(Constants.MOVE_RIGHT))
            {
                DrawCurrentBlock(Constants.Block_background);
                status_x++;
                DrawCurrentBlock(block_kind);
            }
        }

        public void Block_rotate()
        {
            int i = 0, j = 0;
            int[,] l_block = new int[4, 4];
            for(i = 0; i < 4; i++) 
            { 
                 for(j = 0; j < 4; j++)
                {
                    l_block[3-j, i] = _block_buf[i, j]; 
                }
            }
            if( Check_Crash(status_x, status_y, l_block) )
            {
                DrawCurrentBlock(Constants.Block_background);
                for(i = 0; i < 4; i++)
                {
                    for(j = 0; j <4; j++)
                    {
                        _block_buf[i, j] = l_block[i, j];
                    }
                }
                DrawCurrentBlock(block_kind);
            }
        }

        private void NewBlock()
        {
            block_kind = next_block;
            status_x = 4;
            status_y = -3;
            DrawBufBlock(block_kind, _block_buf);
            next_block = rnd.Next(1, 7);
            //if (Check_Can_Move(Constants.TETRIS_MOVE_DOWN))
            //{
            //    DrawNext();
            //    StopTimer();
            //    Block_down();
            //    StartTimer();
            //}
            //else
            //{
            //    DrawCrash();
            //}
        }

        private void Cal_Block()
        {
            int i = 0, j = 0, k = 0;
            for (i = 19; i >= 0; i--)
            {
                int line_chk = 0;
                for(j = 1; j < 11; j++)
                {
                    if (_memory_pan[i, j] != 0) line_chk++;
                }
                if (line_chk == 10) //line clear
                {
                    double_bounus = double_bounus + 10 + ((game_level - 1) * 5);
                    Game_line++;
                    Game_score = game_score + double_bounus;

                    if( (game_line % 5) ==0 )
                    {
                        Game_level++;
                    }
                    for( k = i - 1; k >= 0; k--)
                    {
                        for( j = 1; j < 11; j++)
                        {
                            _memory_pan[k + 1, j] = _memory_pan[k, j];
                        }
                    }
                    for(k = 0; k < 20; k++)
                    {
                        for(j = 1; j < 11; j++)
                        {
                            block_pan[k, j] = _memory_pan[k, j];
                        }
                    }
                    NotifyPropertyChanged(nameof(Block_pan));
                    Cal_Block(); // recursive func and Finish Line clear
                }
                if( double_bounus > 0)
                {
                    double_bounus = 0;
                }
            }
        }

        private void DrawCurrentBlock(int block_background)
        {
            int i = 0;
            int j = 0;
            for(i = 0; i < 4; i++)
            {
                for(j = 0; j < 4; j++)
                {
                    if ( ( _block_buf[i,j] != 0 ) && ( status_y+i >= 0 ) )
                    {
                        block_pan[status_y + i, status_x + j] = block_background;
                    }
                }
            }
            //next_pan.NotifyBlockChaned(nameof(Block_pan));
            NotifyPropertyChanged(nameof(Block_pan));
            //block_pan.NotifyBlockChaned(nameof(Block_pan));
        }

        private bool Check_Can_Move(int direct_)
        {
            int x = status_x;
            int y = status_y;

            switch (direct_)
            {
                case Constants.MOVE_DOWN:
                    y++;
                    break;
                case Constants.MOVE_LEFT:
                    x--;
                    break;
                case Constants.MOVE_RIGHT:
                    x++;
                    break;
            }
            if(!Check_Crash(x,y,_block_buf))
            {
                return false;
            }
            return true;
        }

        private bool Check_Crash(int x, int y, int[,] block_buf)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i < 4; i++)
            {
                for(j = 0; j < 4; j++)
                {
                    //Fail case
                    //1. x + j = 0 , x + j = 11
                    //
                    if(block_buf[i,j] != 0)
                    {
                        if ( (x + j == 0 || x + j == 11) || ( y + i >= 0 && x + j >= 0 && _memory_pan[y+i,x+j] != 0) )
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
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
