using System;

namespace CEVideojocs.Bloc2
{
    /// <summary>
    /// Model en memòria del jugador. Com que és estàtic, sobreviu als canvis d'escena
    /// (MainMenu -> Level -> Minesweeper -> GameOver) sense necessitat de DontDestroyOnLoad.
    /// </summary>
    public class PlayerData
    {
        public string Username;
        public string Email;

        /// <summary>Jugador identificat a la sessió (null si encara no s'ha fet login).</summary>
        public static PlayerData Current { get; set; }

        /// <summary>Puntuació acumulada de la partida actual (entre minijocs).</summary>
        public static int Score { get; private set; }

        public static void AddScore(int points) => Score += points;
        public static void ResetScore() => Score = 0;
    }

    // ----------- DTOs (Data Transfer Objects) -----------

    /// <summary>POST /api/register</summary>
    [Serializable]
    public class RegisterRequestDTO
    {
        public string username;
        public string email;
    }

    /// <summary>POST /api/scores</summary>
    [Serializable]
    public class ScoreRequestDTO
    {
        public string email;
        public int score;
    }

    /// <summary>Fila de GET /api/leaderboard</summary>
    [Serializable]
    public class LeaderboardEntryDTO
    {
        public string id;
        public string username;
        public string email;
        public int score;
    }
}
