
using System;
namespace ultimateTicTacToe
{
    public class PlayerFactory
    {
        public PlayerFactory()
        {
        }

        public Player CreatePlayer(string playerType)
        {
            if (playerType == "HumanPlayer")
                return new HumanPlayer();
            else if (playerType == "AIPlayer")
                return new AIPlayer();
            else return null;
        }
    }
}
