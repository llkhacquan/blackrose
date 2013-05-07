using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WorldOfTank.Class.Components
{
    /// <summary>
    /// Instruction is a class that stores Instruction of Tank
    /// </summary>
    [Serializable]
    public class Instruction
    {
        public TypeInstruction Type;
        public float Value;
        public bool Interruptible;
        public Condition Condition;

        /// <summary>
        /// Default Instruction
        /// </summary>
        public Instruction()
        {
            Type = TypeInstruction.MoveForward;
            Value = 100;
            Condition = null;
            Interruptible = false;
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
