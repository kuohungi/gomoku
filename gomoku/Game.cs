using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gomoku
{
    class Game
    {
        public Board board = new Board();
        public PieceType currentPlayer = PieceType.black;
        public PieceType CurrentPlayer { get { return currentPlayer; } }
        private PieceType winner = PieceType.none;
        public void removeAll()
        {
            board.RemoveAll();
            currentPlayer = PieceType.black;
            winner = PieceType.none;
        }
        public PieceType Winner { get { return winner; } }
        public bool CanBePlaced(int x, int y)
        {
            if (winner == PieceType.black || winner == PieceType.white)
                return false;
            return board.CanBePlaced(x, y);
        }
        public Piece PlaceAPiece(int x, int y)
        {
            if (winner == PieceType.black || winner == PieceType.white)
                return null;
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if(piece != null)
            {
                checkWinner();
                if (currentPlayer == PieceType.black)
                {
                    currentPlayer = PieceType.white;
                }
                else if (currentPlayer == PieceType.white)
                    currentPlayer = PieceType.black;
                return piece;
            }
            return null;
        }
        private void checkWinner()
        {
            int centerX = board.LastPlaceNode.X;
            int centerY = board.LastPlaceNode.Y;
            int horizontal = 0;
            int vertical = 0;
            int leftline = 0;
            int rightline = 0;
            for(int xDir = -1; xDir <= 1; xDir++)
            {
                for(int yDir = -1; yDir <= 1; yDir++)
                {
                    if (xDir == 0 && yDir == 0)
                        continue;
                    int count = 1;
                    while(count < 5)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;
                        if (targetX < 0 || targetX >= Board.Count || targetY < 0 || targetY >= Board.Count || board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;
                        count++;
                    }
                    if ((xDir == -1 && yDir == 0) || (xDir == 1 && yDir == 0))
                        horizontal += count;
                    else if ((xDir == 0 && yDir == -1) || (xDir == 0 && yDir == 1))
                        vertical += count;
                    else if ((xDir == 1 && yDir == -1) || (xDir == -1 && yDir == 1))
                        rightline += count;
                    else if ((xDir == -1 && yDir == -1) || (xDir == 1 && yDir == 1))
                        leftline += count;
                    if(count == 5 || horizontal ==6 || vertical == 6 || rightline == 6 || leftline == 6)
                    {
                        winner = currentPlayer;
                    }
                }
            }
        }
    }
}
