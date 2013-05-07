using System.Windows.Forms;
using System.Runtime.Serialization;
using System;

namespace WorldOfTank.Class.Components
{
    [Serializable]
    public class TreeNodePlus : TreeNode
    {
        public Condition Condition;

        public TreeNodePlus(string text, Condition condition)
            : base(text)
        {
            Condition = condition;
        }

        public TreeNodePlus(string text, TreeNode[] children, Condition condition)
            : base(text, children)
        {
            Condition = condition;
        }
        public TreeNodePlus()
        {

        }
        public TreeNodePlus(string text)
            : base(text)
        {
            
        }
        public TreeNodePlus(string text, TreeNode[] children)
            : base(text, children)
        {
            
        }
        public TreeNodePlus(string text, int imageIndex, int selectedImageIndex)
            : base(text, imageIndex, selectedImageIndex)
        {
            
        }
        public TreeNodePlus(string text, int imageIndex, int selectedImageIndex, TreeNode[] children)
            : base(text, imageIndex, selectedImageIndex, children)
        {
            
        }
        protected TreeNodePlus(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            
        }
         
    }
}
