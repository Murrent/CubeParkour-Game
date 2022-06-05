[System.Serializable]
public class LevelDataClass 
{
    public float score;
    public Difficulty difficulty = Difficulty.Easy;
    public int levelID; //Index of how the level is ordered. 0 is level 1, 1 is level 2 etc.
    public string levelName; //The name of the level
    public enum Difficulty { Easy, Medium, Hard }
    public string GetDifficultyDisplayName() //Returns the difficulty as a string
    {
        switch (this.difficulty)
        {
            case Difficulty.Easy:
                return "Easy";
            case Difficulty.Medium:
                return "Medium";
            case Difficulty.Hard:
                return "Hard";
            default:
                return "None";
        }
    }
}
