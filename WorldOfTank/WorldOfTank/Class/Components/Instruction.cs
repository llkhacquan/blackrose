using System;

namespace WorldOfTank.Class.Components
{
    [Serializable]
    public class Instruction
    {
        public TypeInstruction Type;
        public float Value;
        public Condition Condition;

        public Instruction()
        {
            Type = TypeInstruction.MoveForward;
            Value = 100;
            Condition = null;
        }
    }
}
