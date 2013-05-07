using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using WorldOfTank.Class.Model;

namespace WorldOfTank.Class.Components
{
    /// <summary>
    /// This class handle the Conditional Options when creating brain
    /// </summary>
    [Serializable]
    public class Condition
    {
        public TypeCondition Type;
        public Comparison Comparision;
        public List<Condition> Children;

        public Condition()
        {
            Type = TypeCondition.Unique;
            Comparision = new Comparison();
            Children = new List<Condition>();
        }

        /// <summary>
        /// Return the result of Conditional with some input
        /// </summary>
        /// <param name="yourTank"></param>
        /// <param name="enemyTank"></param>
        /// <param name="enemyBullet"></param>
        /// <returns></returns>
        public bool GetResult(Tank yourTank, Tank enemyTank, Bullet enemyBullet)
        {
            if (Type == TypeCondition.And)
            {
                return Children.All(t => t.GetResult(yourTank, enemyTank, enemyBullet));
            }
            if (Type == TypeCondition.Or)
            {
                return Children.Any(t => t.GetResult(yourTank, enemyTank, enemyBullet));
            }
            return Comparision.GetResult(yourTank, enemyTank, enemyBullet);
        }

        /// <summary>
        /// This method return a string that present the condition
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            var s = string.Empty;
            if (Type == TypeCondition.Unique)
            {
                s += Comparision.Parameter.ToString();

                switch (Comparision.Operator)
                {
                    case TypeOperator.GreaterEqual:
                        s += " >= ";
                        break;
                    case TypeOperator.Greater:
                        s += " > ";
                        break;
                    case TypeOperator.Equal:
                        s += " == ";
                        break;
                    case TypeOperator.Lower:
                        s += " < ";
                        break;
                    case TypeOperator.LowerEqual:
                        s += " <= ";
                        break;
                    case TypeOperator.NotEqual:
                        s += " != ";
                        break;
                }

                s += Comparision.Value.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                s = String.Format("({0})", Children[0].Print());
                for (var i = 1; i < Children.Count; i++)
                {
                    if (Type == TypeCondition.And)
                    {
                        s += String.Format(" AND ({0})", Children[i].Print());
                    }
                    else
                    {
                        s += String.Format(" OR ({0})", Children[i].Print());
                    }
                }
            }
            return s;
        }

        /// <summary>
        /// The method return a tree presents the conditional structure of the condition
        /// </summary>
        /// <returns></returns>
        public TreeNodePlus GetTreeNode()
        {
            if (Type != TypeCondition.Unique)
            {
                var childrenNodes = new TreeNode[Children.Count];
                for (var i = 0; i < Children.Count; i++)
                {
                    childrenNodes[i] = Children[i].GetTreeNode();
                }
                if (Type == TypeCondition.And)
                {
                    return new TreeNodePlus("AND", childrenNodes, this);
                }
                if (Type == TypeCondition.Or)
                {
                    return new TreeNodePlus("OR", childrenNodes, this);
                }
            }
            return new TreeNodePlus(Print(), this);
        }
    }
}
