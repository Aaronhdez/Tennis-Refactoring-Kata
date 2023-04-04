namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private readonly string _player1Name;
        private string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (IsPlayer1(playerName))
                player1Score += 1;
            else
                player2Score += 1;
        }

        private bool IsPlayer1(string playerName)
        {
            return playerName == _player1Name;
        }

        public string GetScore()
        {
            return BothPlayersAreDraw() ? SetLoveScore() :
                MatchIsInAdvantagePhase() ? SetAdvantageScore() : 
                GetCurrentScore();
        }

        private bool BothPlayersAreDraw()
        {
            return player1Score == player2Score;
        }

        private string SetLoveScore()
        {
            return player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }

        private bool MatchIsInAdvantagePhase()
        {
            return player1Score >= 4 || player2Score >= 4;
        }

        private string SetAdvantageScore()
        {
            return (player1Score - player2Score) switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
        }

        private string GetCurrentScore()
        {
            return GetFormattedScoreFrom(player1Score) +"-"+GetFormattedScoreFrom(player2Score);
        }

        private static string GetFormattedScoreFrom(int playerScore)
        {
            return playerScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
        }
    }
}

