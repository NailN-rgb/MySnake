using Level_1;
using SecondLevel;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace SnakeNamespace
{
    //Как перебрать массив всех картинок
    //
    public partial class MainPage : Form
    {
        

        private string to4 = "C:/Users/Наиль/source/repos/Змея/Level3/bin/Debug/tonext.txt";
        private string to3 = "C:/Users/Наиль/source/repos/Змея/Level2/bin/Debug/tonext.txt";
        public MainPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader(to4);

            string str = read.ReadLine();

            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("Вы еще не открыли этот уровень", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Level3 lv3 = new Level3();
                lv3.Show();
            }
            read.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Level1 l1 = new Level1();
            l1.Show();
            
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            SecondLevel.Level2 l2 = new SecondLevel.Level2();
            l2.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader(to4);

            string str = read.ReadLine();

            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("Вы еще не открыли этот уровень", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Самый сложный уровень:", "OK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Level4 lv4 = new Level4();
                lv4.Show();
            }
            read.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }
    }
}
