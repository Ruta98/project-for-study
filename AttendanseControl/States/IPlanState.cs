using System;
using System.Collections.Generic;
using System.Text;

namespace States
{
    public abstract class IPlanState
    {
        public abstract void NextStep();
        public abstract void Cancel();
    }
}
