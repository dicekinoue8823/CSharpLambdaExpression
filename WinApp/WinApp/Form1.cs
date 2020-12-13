using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string[] GetValue1(string[] values, Predicate<string> predicate)
        {
            var result = new List<string>();
            foreach (var val in values)
            {
                if (predicate(val))
                {
                    result.Add(val);
                }
            }

            return result.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var values = new string[] { "A", "BB", "CCC", "DDDD", "EEEEE" };
            //匿名メソッド
            var result = GetValue1(
                values,
                delegate (string value)
                {
                    return value.Length == 3;
                }
                );
            Console.WriteLine("匿名メソッド：" + string.Join(",", result));

            //ラムダ式 パターン１
            var result2 = GetValue1(
                values,
                (value) =>
                {
                    return value.Length == 3;
                }
                );
            //ラムダ式 パターン２
            var result3 = GetValue1(
              values,
              value =>
              {
                  return value.Length == 3;
              }
              );

            //ラムダ式 パターン３
            var result4 = GetValue1(values, value => value.Length == 3);
            var result5 = GetValue1(values, value => value.Length > 3);

            Console.WriteLine("ラムダ式：" + string.Join(",", result4));
        }
    }
}
