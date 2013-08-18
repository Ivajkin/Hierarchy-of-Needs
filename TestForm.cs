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

        private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();

        }

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


        private void TestForm_Load(object sender, EventArgs e)
        {

        }

    }
}
