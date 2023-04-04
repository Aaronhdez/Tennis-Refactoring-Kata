namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _player2Score;
        private int _player1Score;
        private readonly string _player1Name;
        private readonly string _player2Name;
        private readonly string[] _points = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        public string GetScore()
        {
            return MatchIsStillPlaying() ? CurrentScore()
                : IsADraw() ? "Deuce"
                : ExtraTimeScore();
        }

        private bool MatchIsStillPlaying() =>
            _player1Score < 4 && _player2Score < 4 && _player1Score + _player2Score < 6;

        private string CurrentScore() =>
            IsADraw()
                ? _points[_player1Score] + "-All"
                : _points[_player1Score] + "-" + _points[_player2Score];

        private bool IsADraw() => _player1Score == _player2Score;

        private string ExtraTimeScore()
        {
            var score = _player1Score > _player2Score ? _player1Name : _player2Name;
            return MatchIsOnAdvantage()
                ? "Advantage " + score
                : "Win for " + score;
        }

        private bool MatchIsOnAdvantage() => (_player1Score - _player2Score) * (_player1Score - _player2Score) == 1;
    }
}