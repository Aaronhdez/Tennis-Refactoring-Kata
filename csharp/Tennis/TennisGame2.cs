namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Point;
        private int _player2Point;

        private string _player1Result = "";
        private string _player2Result = "";
        private string _player1Name;
        private string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player1Point = 0;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            return IsADeuce() ? "Deuce" :
                Player1HasWon() ? "Win for player1" :
                Player2HasWon() ? "Win for player2" :
                Player1IsOnAdvantage() ? "Advantage player1" :
                Player2IsOnAdvantage() ? "Advantage player2" : GetCurrentScore(string.Empty);
        }

        private string GetCurrentScore(string score)
        {
            var points = new[] { "Love", "Fifteen", "Thirty", "Forty" };

            if (_player1Point == _player2Point && _player1Point < 3)
            {
                return points[_player1Point] + "-All";
            }

            _player1Result = points[_player1Point];
            _player2Result = points[_player2Point];
            score = _player1Result + "-" + _player2Result;
            return score;
        }

        private bool Player2HasWon()
        {
            return _player2Point >= 4 && _player1Point >= 0 && (_player2Point - _player1Point) >= 2;
        }

        private bool Player1HasWon()
        {
            return _player1Point >= 4 && _player2Point >= 0 && (_player1Point - _player2Point) >= 2;
        }

        private bool Player2IsOnAdvantage()
        {
            return _player2Point > _player1Point && _player1Point >= 3;
        }

        private bool Player1IsOnAdvantage()
        {
            return _player1Point > _player2Point && _player2Point >= 3;
        }

        private bool IsADeuce()
        {
            return _player1Point == _player2Point && _player1Point > 2;
        }

        private void P1Score()
        {
            _player1Point++;
        }

        private void P2Score()
        {
            _player2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }
    }
}