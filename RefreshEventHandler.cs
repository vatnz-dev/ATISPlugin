using System;

namespace ATISPlugin
{
    public class RefreshEventArgs : EventArgs
    {
        public int Number { get; }

        public RefreshEventArgs(int number)
        {
            Number = number;
        }
    }
}
