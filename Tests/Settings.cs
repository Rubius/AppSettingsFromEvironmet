namespace Tests
{
    public class Settings
    {
        public Level1 A { get; set; }
    }

    public class Level1
    {
        public Level2 B { get; set; }
        public Level2 C { get; set; }
    }

    public class Level2
    {
        public string D { get; set; }
        public string E { get; set; }
    }
}
