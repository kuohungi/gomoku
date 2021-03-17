using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gomoku
{
    class Board
    {
        public static readonly int Count = 9;
        private static readonly Point noMatch = new Point (-1, -1);
        private Point lastPlaceNode = noMatch;
        public Point LastPlaceNode { get { return lastPlaceNode; } }
        private static readonly int offset = 75;
        private static readonly int radius = 10;
        private static readonly int distance = 75;
        public Piece[,] pieces = new Piece[Count, Count];
        public void RemoveAll()
        {
            Point lastPlaceNode = noMatch;
            for (int i = 0; i <= 8; i++)
                for (int j = 0; j <= 8; j++)
                    pieces[i, j] = null;
        }
        public PieceType GetPieceType(int nodeX, int nodeY)
        {
            if (pieces[nodeX, nodeY] == null)
                return PieceType.none;
            else
                return pieces[nodeX, nodeY].GetPieceType();
        }
        public bool CanBePlaced(int x, int y)
        {
            Point node = fideTheClosetNode(x, y);
            if (node == noMatch)
                return false;
            if (pieces[node.X, node.Y] != null)
                return false;
            return
                true;
        }
        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            Point node = fideTheClosetNode(x, y);
            if (node == noMatch)
                return null;
            if (pieces[node.X, node.Y] != null)
                return null;
            Point formPos = converToFormPosition(node);
            if (type == PieceType.black)
                pieces[node.X, node.Y] = new BlackPiece(formPos.X, formPos.Y);
            else if(type == PieceType.white)
                pieces[node.X, node.Y] = new WhitePiece(formPos.X, formPos.Y);
            lastPlaceNode = node;
            return pieces[node.X, node.Y];
        }
        private Point converToFormPosition(Point node)
        {
            Point formPosition = new Point();
            formPosition.X = node.X * distance + offset;
            formPosition.Y = node.Y * distance + offset;
            return formPosition;
        }
        private Point fideTheClosetNode(int x, int y)
        {
            int nodeX = fideTheClosetNode(x);
            if (nodeX == -1 || nodeX >= Count)
                return noMatch;
            int nodeY = fideTheClosetNode(y);
            if (nodeY == -1 || nodeY >= Count)
                return noMatch;
            return new Point(nodeX, nodeY);
        }
        private int fideTheClosetNode(int pos)
        {
            if (pos < offset - radius)
                return -1;
            pos -= offset;
            int quotient = pos / distance;
            int remainder = pos % distance;
            if (remainder <= radius)
                return quotient;
            else if (remainder >= distance - radius)
                return quotient + 1;
            else
                return -1;
        }
    }
}
