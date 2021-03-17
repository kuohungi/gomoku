using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace gomoku
{
    abstract class Piece : PictureBox
    {
        private static readonly int pieceSize = 50;
        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - pieceSize / 2, y - pieceSize / 2);
            this.Size = new Size(pieceSize, pieceSize);
        }

        public abstract PieceType GetPieceType();
    }
}
