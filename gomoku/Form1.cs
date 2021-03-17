using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gomoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Game game = new Game();
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);

            if (piece != null)
            {
                this.Controls.Add(piece);
                if(game.Winner == PieceType.black)
                {
                    MessageBox.Show("黑色獲勝");
                }
                else if (game.Winner == PieceType.white)
                {
                    MessageBox.Show("白色獲勝");
                }
            }

            if (game.CurrentPlayer == PieceType.black)
                pictureBox1.Image = Properties.Resources.black;
            else if (game.CurrentPlayer == PieceType.white)
                pictureBox1.Image = Properties.Resources.white;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i <= 8; ++i)
                for(int j = 0; j <= 8; ++j)
                    this.Controls.Remove(game.board.pieces[i, j]);
            game.removeAll();
            pictureBox1.Image = Properties.Resources.black;
        }
    }
}
