using System;

namespace chess
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите позицию белой ладьи");
            var whiteRookPosition = Console.ReadLine();
            Console.WriteLine("Введите позицию черного ферзя");
            var blackQueenPosition = Console.ReadLine();

            if (CheckPosition(whiteRookPosition, blackQueenPosition))
            {
                Console.WriteLine("Введите ход белой ладьи");
                var whiteRookMove = Console.ReadLine();
                if (CanRookMakeSafeMove(whiteRookPosition, whiteRookMove, blackQueenPosition))
                    Console.WriteLine("Ладья может ходить");
                else
                    Console.WriteLine("Ладья не может ходить");
            }
            else
                Console.WriteLine("Введенные позиции некорректны");

            Console.ReadKey();
        }

        static void GetCoordinates(string position, out int x, out int y)
        {
            x = (int)position[0] - 0x60;
            y = int.Parse(position[1].ToString());
        }

        static bool CanRookMakeMove(string start, string end)
        {
            if (start == end)
                return false;

            int startX, startY, endX, endY;
            GetCoordinates(start, out startX, out startY);
            GetCoordinates(end, out endX, out endY);

            return (startX == endX || startY == endY) && start !=end;
        }

        static bool CanQueenMakeMove(string start, string end)
        {
            if (start == end)
                return false;

            int startX, startY, endX, endY;
            GetCoordinates(start, out startX, out startY);
            GetCoordinates(end, out endX, out endY);

            return Math.Abs(endX - startX) <= 1 && Math.Abs(endY - startY) <= 1;
        }

        static bool CheckPosition(string whitePos, string blackPos)
        {
            return whitePos != blackPos && !CanRookMakeMove(whitePos, blackPos) && !CanQueenMakeMove(blackPos, whitePos);
        }

        static bool CanRookMakeSafeMove(string queenStartPos, string queenEndPos, string kingPos)
        {
            return CanRookMakeMove(queenStartPos, queenEndPos) && !CanQueenMakeMove(kingPos, queenEndPos);
        }
    }
}