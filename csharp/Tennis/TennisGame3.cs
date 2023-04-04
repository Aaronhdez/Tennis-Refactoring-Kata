namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _player2Score;
        private int _player1Score;
        private readonly string _player1Name;
        private readonly string _player2Name;
        private readonly string[] _points = new[] { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            return MatchIsStillPlaying() ? CurrentScore() 
                : IsADraw() ? "Deuce" 
                : ExtraTimeScore();
        }

        private string ExtraTimeScore()
        {
            var score = _player1Score > _player2Score ? _player1Name : _player2Name;
            return MatchIsOnAdvantage() ? "Advantage " + score : "Win for " + score;
        }

        private string CurrentScore()
        {
            var score = _points[_player1Score];
            return IsADraw() ? score + "-All" : score + "-" + _points[_player2Score];
        }

        private bool MatchIsStillPlaying()
        {
            return _player1Score < 4 && _player2Score < 4 && _player1Score + _player2Score < 6;
        }

        private bool MatchIsOnAdvantage()
        {
            return (_player1Score - _player2Score) * (_player1Score - _player2Score) == 1;
        }

        private bool IsADraw()
        {
            return _player1Score == _player2Score;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }

    }
}

