using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Tree
    {
        private string value;
        private int count;
        private Tree left;
        private Tree right;        

        public void AddValue(string enter)
        {
            if (value == null) // Если значение value равно null в данном экземпляре класса, то...
            {
                value = enter; // ...value приравнивается к enter.
                count++; // увеличиваем count на 1.
            }
            else // Если значение value не null в данном экземпляре класса, то...
            {
                if (count == 1)
                {
                    if (left == null) // Проверяем left на null и если равно, то...
                    {
                        left = new Tree(); // ...создаем новый экземпляр класса, в котором...                        
                    }
                    left.AddValue(enter); // ...придаем значению value значение enter.
                    count++;
                }

                else if (count == 2)
                {
                    if (right == null) // Проверяем right на null и если равно, то...
                    {
                        right = new Tree(); // ...создаем новый экземпляр класса, в котором...                        
                    }
                    right.AddValue(enter); // ...придаем значению value значение enter.
                    count--;
                }
            } 
        }

        public void Remove(Tree rem, string remVal, string collect)
        {
            if (rem != null)
            {
                collect += "корень - " + rem.value.ToString() + Environment.NewLine;

                if (rem.value.ToString() == remVal)
                {
                    this.left = null;
                    this.right = null;
                }

                collect += "обход левой ветви" + Environment.NewLine + rem.value.ToString() + Environment.NewLine;
                Remove(rem.left, remVal, collect);

                collect += "обход правой ветви" + Environment.NewLine + rem.value.ToString() + Environment.NewLine;
                Remove(rem.right, remVal, collect);
            }
            else
            {
                collect += "null" + Environment.NewLine;
            }

            if (this.left == null && this.right == null)
            {
                Console.WriteLine(collect);
            }
        }
    }
}