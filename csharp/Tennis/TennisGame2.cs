namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Point;
        private int _player2Point;
        private readonly string _player1Name;
        private readonly string _player2Name;
        private readonly string[] _points = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player1Point = 0;
            _player2Name = player2Name;
        }

        public void WonPoint(string player)
        {
            if (player == _player1Name)
                _player1Point++;
            else
                _player2Point++;
        }

        public string GetScore()
        {
            return IsADeuce() ? "Deuce" :
                Player1HasWon() ? $"Win for {_player1Name}" :
                Player2HasWon() ? $"Win for {_player2Name}" :
                Player1IsOnAdvantage() ? $"Advantage {_player1Name}" :
                Player2IsOnAdvantage() ? $"Advantage {_player2Name}" :
                IsADraw() ? _points[_player1Point] + "-All" :
                GetCurrentScore();
        }

        private bool IsADeuce() => _player1Point == _player2Point && _player1Point > 2;

        private bool Player1HasWon() =>
            _player1Point >= 4 && _player2Point >= 0 && (_player1Point - _player2Point) >= 2;

        private bool Player2HasWon() =>
            _player2Point >= 4 && _player1Point >= 0 && (_player2Point - _player1Point) >= 2;

        private bool Player1IsOnAdvantage() => _player1Point > _player2Point && _player2Point >= 3;

        private bool Player2IsOnAdvantage() => _player2Point > _player1Point && _player1Point >= 3;

        private string GetCurrentScore() => _points[_player1Point] + "-" + _points[_player2Point];

        private bool IsADraw() => _player1Point == _player2Point && _player1Point < 3;
    }
}