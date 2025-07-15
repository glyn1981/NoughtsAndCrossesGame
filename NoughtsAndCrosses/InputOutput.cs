
using NoughtsAndCrosses.Interfaces;

namespace NoughtsAndCrosses
{
    public class InputOutput : IInputOutput
    {
        public void RenderOutput(string output)
        {
            Console.Write(output);
        }

        public void RenderLine(string output)
        {
            Console.WriteLine(output);
        }
        public string GatherInput(string message)
        {
            RenderOutput(message);

            return Console.ReadLine() ?? string.Empty;
        }
    }
}
