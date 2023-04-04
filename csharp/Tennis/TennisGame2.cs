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
            var score = "";
            if (IsADeuce()) return "Deuce";
            score = GetCurrentScore(score);
            score = GetAdvantageScore(score);
            score = GetPlayerVictoryScore(score);
            return score;
        }

        private string GetCurrentScore(string score)
        {
            if (_player1Point == _player2Point && _player1Point < 3)
            {
                score = _player1Point switch
                {
                    0 => "Love",
                    1 => "Fifteen",
                    2 => "Thirty",
                    _ => score
                };
                score += "-All";
            }

            if (_player1Point > 0 && _player2Point == 0)
            {
                _player1Result = _player1Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _player1Result
                };

                _player2Result = "Love";
                score = _player1Result + "-" + _player2Result;
            }

            if (_player2Point > 0 && _player1Point == 0)
            {
                _player2Result = _player2Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _player2Result
                };

                _player1Result = "Love";
                score = _player1Result + "-" + _player2Result;
            }

            if (_player1Point > _player2Point && _player1Point < 4)
            {
                _player1Result = _player1Point switch
                {
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _player1Result
                };
                _player2Result = _player2Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    _ => _player2Result
                };
                score = _player1Result + "-" + _player2Result;
            }

            if (_player2Point <= _player1Point || _player2Point >= 4) return score;
            _player2Result = _player2Point switch
            {
                2 => "Thirty",
                3 => "Forty",
                _ => _player2Result
            };
            _player1Result = _player1Point switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                _ => _player1Result
            };
            score = _player1Result + "-" + _player2Result;

            return score;
        }

        private string GetPlayerVictoryScore(string score)
        {
            if (_player1Point >= 4 && _player2Point >= 0 && (_player1Point - _player2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (_player2Point >= 4 && _player1Point >= 0 && (_player2Point - _player1Point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private string GetAdvantageScore(string score)
        {
            if (_player1Point > _player2Point && _player2Point >= 3)
            {
                score = "Advantage player1";
            }
            if (_player2Point > _player1Point && _player1Point >= 3)
            {
                score = "Advantage player2";
            }
            return score;
        }

        private bool IsADeuce()
        {
            return _player1Point == _player2Point && _player1Point > 2;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
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

