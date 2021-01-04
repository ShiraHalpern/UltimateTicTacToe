using System;
namespace ultimateTicTacToe
{
    public abstract class Player
    {
        private char symbol;

        public char Symbol { get => symbol; set => symbol = value; }

        public virtual void ChooseSymbol() { Console.WriteLine("Player"); }

        public virtual string ChooseOpponentType() { return ""; }

    }
}
