using System.Windows.Forms;

namespace WorldOfTank.Class.Components
{
    public class TreeNodePlus : TreeNode
    {
        public Condition Condition;

        public TreeNodePlus(string text, Condition condition)
            : base(text)
        {
            Condition = condition;
        }

        public TreeNodePlus(string text, TreeNodePlus[] children, Condition condition)
            : base(text, children)
        {
            Condition = condition;
        }
    }
}
