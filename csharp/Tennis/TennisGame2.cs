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
        private string[] _points = new[] { "Love", "Fifteen", "Thirty", "Forty" };

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
                Player2IsOnAdvantage() ? "Advantage player2" : 
                IsADraw() ? _points[_player1Point] + "-All" :
                GetCurrentScore();
        }

        private string GetCurrentScore()
        {
            _player1Result = _points[_player1Point];
            _player2Result = _points[_player2Point];
            return _player1Result + "-" + _player2Result;
        }

        private bool IsADraw()
        {
            return _player1Point == _player2Point && _player1Point < 3;
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