namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private readonly string _player1Name;
        private string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this._player1Name = player1Name;
            this._player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (Player1Scored(playerName))
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        private bool Player1Scored(string playerName)
        {
            return playerName == _player1Name;
        }

        public string GetScore()
        {
            var score = "";
            if (BothPlayersAreDraw())
            {
                score = SetDraw();
            }
            else if (MatchIsInAdvantagePhase())
            {
                score = SetAdvantageScore();
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    var tempScore = 0;
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }

        private bool BothPlayersAreDraw()
        {
            return m_score1 == m_score2;
        }

        private string SetDraw()
        {
            string score;
            score = m_score1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
            return score;
        }

        private bool MatchIsInAdvantagePhase()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }

        private string SetAdvantageScore()
        {
            string score;
            var minusResult = m_score1 - m_score2;
            score = minusResult switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };
            return score;
        }
    }
}

