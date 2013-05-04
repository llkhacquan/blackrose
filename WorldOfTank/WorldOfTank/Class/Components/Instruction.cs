using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldOfTank.Class.Components
{
    class Instruction
    {
        public TypeInstruction Type;
        public float Parameter;

        public Instruction(TypeInstruction Type, float Parameter)
        {
            this.Type = Type;
            this.Parameter = Parameter;
        }
    }
}
