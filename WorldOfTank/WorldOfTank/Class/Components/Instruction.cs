using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

        public Instruction Clone()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            return (Instruction)formatter.Deserialize(stream);
        }
    }
}
