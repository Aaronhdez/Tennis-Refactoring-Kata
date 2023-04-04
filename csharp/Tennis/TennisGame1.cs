namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (IsPlayer1(playerName))
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        private bool IsPlayer1(string playerName)
        {
            return playerName == _player1Name;
        }

        public string GetScore()
        {
            return BothPlayersAreDraw() ? GetLoveScore() :
                MatchIsInAdvantagePhase() ? GetAdvantageScore() : 
                GetCurrentScore();
        }

        private bool BothPlayersAreDraw()
        {
            return _player1Score == _player2Score;
        }

        private string GetLoveScore()
        {
            return _player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }

        private bool MatchIsInAdvantagePhase()
        {
            return _player1Score >= 4 || _player2Score >= 4;
        }

        private string GetAdvantageScore()
        {
            return (_player1Score - _player2Score) switch
            {
                1 => $"Advantage {_player1Name}",
                -1 => $"Advantage {_player2Name}",
                >= 2 => $"Win for {_player1Name}",
                _ => $"Win for {_player2Name}"
            };
        }

        private string GetCurrentScore()
        {
            return GetFormattedScoreFrom(_player1Score) +"-"+GetFormattedScoreFrom(_player2Score);
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

