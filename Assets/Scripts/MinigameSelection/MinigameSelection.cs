namespace MinigameSelection
{
    public enum Minigame { None, Minesweeper, FlappyBird, Tetris, Snake, DinoRun }

    public static class MinigameSelection {
        public static Minigame Selected = Minigame.None;

        public static string SceneName(Minigame game) => game switch {
            Minigame.Minesweeper => "Minesweeper",
            Minigame.FlappyBird  => "Flappy Bird",
            Minigame.Tetris      => "Tetris",
            Minigame.Snake       => "Snake",
            Minigame.DinoRun     => "DinoRun",
            _ => null
        };
    }
}