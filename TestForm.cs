using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hierarchy_of_Needs
{
    public partial class TestForm : Form
    {
        public TestForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        MainForm parent;

        string[] variants = {   "Добиться признания и уважения",
                                "Иметь теплые отношения с людьми",
                                "Обеспечить себе будущее",
                                "Зарабатывать на жизнь",
                                "Иметь хороших собеседников",
                                "Упрочить свое положение",
                                "Развивать свои силы и способности",
                                "Обеспечить себе материальный комфорт",
                                "Повышать уровень мастерства и компетентности",
                                "Избегать неприятностей",
                                "Стремиться к новому и неизведанному",
                                "Обеспечить себе положение влияния",
                                "Покупать хорошие вещи",
                                "Заниматься делом, требующим полной отдачи",
                                "Быть понятым другими" };
        int[] score;


        private void TestForm_Load(object sender, EventArgs e)
        {
            score = new int[variants.Length];
            for (int i = 0; i < score.Length; ++i)
            {
                score[i] = 0;
            }

            Shake();
            Next();
        }


        void Next()
        {
            if (pairs.Count() == 0) Finish();
            else
            {
                button1.Text = pairs[0].Key;
                button2.Text = pairs[0].Value;
                pairs = pairs.Skip(1).ToArray();
            }
        }

        private void Finish()
        {
            Needs needs = new Needs();
            // I шкала	Материальное положение	Подсчитывается сумма по позициям 4, 8, 13
            needs.material = score[3] + score[7] + score[12];
            // II шкала	Потребность в безопасности	Подсчитывается сумма по позициям 3, 6, 10
            needs.safety = score[2] + score[5] + score[9];
            // III шкала	Потребность в межличностных связях	Подсчитывается сумма по позициям 2, 5, 15
            needs.connections = score[1] + score[4] + score[14];
            // IV шкала	Потребности в уважении со стороны	Подсчитывается сумма по позициям 1, 9, 12
            needs.respect = score[0] + score[8] + score[11];
            // V шкала	Потребность в самореализации	Подсчитывается сумма по позициям 7, 11, 14
            needs.realisation = score[6] + score[10] + score[13];

            var res = new ResultForm(parent, needs);
            res.Show();

            Close();
        }

        KeyValuePair<string, string>[] pairs;
        void Shake()
        {
            int count = 0;
            for (int i = 1; i < variants.Length; ++i) count += i;

            pairs = new KeyValuePair<string, string>[count];
            int k = 0;
            for (int i = 0; i < variants.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    pairs[k++] = new KeyValuePair<string,string>(variants[i],variants[j]);
                }
            }

            {
                Random rand = new Random();
                for (int i = 0; i < pairs.Length; i++)
                {
                    var j = rand.Next(pairs.Length-1);
                    var tmp = pairs[i];
                    pairs[i] = pairs[j];
                    pairs[j] = tmp;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Next();
            score[getIndex((Button)sender)]++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Next();
            score[getIndex((Button)sender)]++;
        }

        int getIndex(Button button)
        {
            for (int i = 0; i < variants.Length; ++i)
            {
                if (button.Text == variants[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
