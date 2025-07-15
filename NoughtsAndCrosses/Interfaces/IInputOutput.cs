namespace NoughtsAndCrosses.Interfaces
{
    public interface IInputOutput
    {
        string GatherInput(string message);
        void RenderOutput(string output);
        void RenderLine(string output);
    }
}