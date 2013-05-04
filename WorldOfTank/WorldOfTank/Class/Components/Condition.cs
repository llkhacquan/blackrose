using System;
using System.Collections.Generic;
using System.Linq;
using WorldOfTank.Class.Model;

namespace WorldOfTank.Class.Components
{
    [Serializable]
    public class Condition
    {
        public TypeCondition Type;
        public Comparision Comparision;
        public List<Condition> Children;

        public Condition()
        {
            Type = TypeCondition.Unique;
            Comparision = new Comparision();
            Children = new List<Condition>();
        }

        public bool GetResult(Tank yourTank, Tank enemyTank, Bullet enemyBullet)
        {
            if (Type == TypeCondition.And)
                return Children.All(t => t.GetResult(yourTank, enemyTank, enemyBullet));

            if (Type == TypeCondition.Or)
                return Children.Any(t => t.GetResult(yourTank, enemyTank, enemyBullet));

            return Comparision.GetResult(yourTank, enemyTank, enemyBullet);
        }

        public string Print()
        {
            string s = "";
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

                s += Comparision.Value.ToString();
            }
            else
            {
                s = "(" + Children[0].Print() + ")";
                for (int i = 1; i < Children.Count; i++)
                    if (Type == TypeCondition.And)
                        s += " AND (" + Children[i].Print() + ")";
                    else
                        s += " OR (" + Children[i].Print() + ")";
            }
            return s;
        }

        public TreeNodePlus GetTreeNode()
        {
            if (Type != TypeCondition.Unique)
            {
                TreeNodePlus[] childrenNodes = new TreeNodePlus[Children.Count];
                for (int i = 0; i < Children.Count; i++)
                    childrenNodes[i] = Children[i].GetTreeNode();
                if (Type == TypeCondition.And) return new TreeNodePlus("AND", childrenNodes, this);
                if (Type == TypeCondition.Or) return new TreeNodePlus("OR", childrenNodes, this);
            }
            return new TreeNodePlus(Print(), this);
        }
    }

    public enum TypeCondition
    {
        Unique,
        And,
        Or,
    }
}
