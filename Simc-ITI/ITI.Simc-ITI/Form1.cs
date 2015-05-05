using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITI.Simc_ITI.Money.Lib;

namespace ITI.Simc_ITI
{
    public partial class Form1 : Form
    {
        private Graphics g, screeng;
        private Timer t;
        private Bitmap bmp;
        private Map game;
        public Form1()
        {
            InitializeComponent();
            t = new Timer();
            t.Interval = 10;
            t.Tick += new EventHandler(T_loop);
            t.Start();

            game = new Map(30,25);

        }

        private void T_loop( object sender, EventArgs e )
        {
            g.DrawImage(bmp, new Point(0,0));
            screeng.Clear(Color.White);

            game.Draw(screeng);
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            bmp = new Bitmap(this.Width, this.Height);
            g = this.CreateGraphics();
            screeng = Graphics.FromImage(bmp);
        }
    }
}

