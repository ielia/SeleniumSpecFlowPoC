namespace ConstellationQAAutomation.Contexts
{
    public class PipiContext
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public virtual string? ToString() => $"PipiContext {{ X={X}, Y={Y}, Z={Z} }}";
    }
}
