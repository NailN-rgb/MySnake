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
    public partial class Level3 : Form
    {
        public PictureBox fruit;
        
        public int fruitX, fruitY;
        private int fruitcounter = 0;


        private PictureBox[] snake = new PictureBox[500];

        private Label Score;

        private int score = 0;
        private int atX, atY;
        private int cubesize = 40;

        private string nextopen = "C:/Users/Наиль/source/repos/Змея/Level3/bin/Debug/tonext.txt";

        public Level3()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(ForTime);
            timer.Interval = 200;
            timer.Start();

            snake[0] = new PictureBox();
            snake[0].Location = new Point(120, 160);
            snake[0].Size = new Size(cubesize, cubesize);
            snake[0].BackColor = Color.Black;
            this.Controls.Add(snake[0]);

            fruit = new PictureBox();
            fruit.Size = new Size(cubesize, cubesize);
            fruit.BackColor = Color.Orange;
            FruitGen();

            Score = new Label();
            Score.Text = "Score: 0";
            Score.Location = new Point(0, 0);
            Score.BackColor = Color.Red;
            Score.Location = new Point(400, 0);
            this.Controls.Add(Score);

            this.KeyDown += new KeyEventHandler(Control);
        }

        private void Control(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    if (atX != -1)
                    {
                        atX = 1;
                        atY = 0;
                    }
                    break;
                case "Left":
                    if (atX != 1)
                    {
                        atX = -1;
                        atY = 0;
                    }
                    break;
                case "Up":
                    if (atY != 1)
                    {
                        atY = -1;
                        atX = 0;
                    }
                    break;
                case "Down":
                    if (atY != -1)
                    {
                        atY = 1;
                        atX = 0;
                    }
                    break;
                case "D":
                    if (atX != -1)
                    {
                        atX = 1;
                        atY = 0;
                    }
                    break;
                case "A":
                    if (atX != 1)
                    {
                        atX = -1;
                        atY = 0;
                    }
                    break;
                case "W":
                    if (atY != 1)
                    {
                        atY = -1;
                        atX = 0;
                    }
                    break;
                case "S":
                    if (atY != -1)
                    {
                        atY = 1;
                        atX = 0;
                    }
                    break;
            }
        }


        private void FruitGen()
        {
            switch (fruitcounter % 20)
            {
                case 1:
                    fruitX = 440;
                    fruitY = 160;
                    break;

                case 2:
                    fruitX = 160;
                    fruitY = 160;
                    break;

                case 3:
                    fruitX = 400;
                    fruitY = 80;
                    break;

                case 4:
                    fruitX = 40;
                    fruitY = 400;
                    break;

                case 5:
                    fruitX = 160;
                    fruitY = 160;
                    break;

                case 6:
                    fruitX = 80;
                    fruitY = 160;
                    break;

                case 7:
                    fruitX = 80;
                    fruitY = 520;
                    break;

                case 8:
                    fruitX = 200;
                    fruitY = 360;
                    break;

                case 9:
                    fruitX = 40;
                    fruitY = 480;
                    break;

                case 10:
                    fruitX = 120;
                    fruitY = 0;
                    break;

                case 11:
                    fruitX = 360;
                    fruitY = 280;
                    break;

                case 12:
                    fruitX = 120;
                    fruitY = 520;
                    break;

                case 13:
                    fruitX = 40;
                    fruitY = 400;
                    break;

                case 14:
                    fruitX = 320;
                    fruitY = 440;
                    break;

                case 15:
                    fruitX = 0;
                    fruitY = 320;
                    break;

                case 16:
                    fruitX = 160;
                    fruitY = 360;
                    break;

                case 17:
                    fruitX = 400;
                    fruitY = 560;
                    break;

                case 18:
                    fruitX = 240;
                    fruitY = 240;
                    break;

                case 19:
                    fruitX = 280;
                    fruitY = 400;
                    break;

                default:
                    fruitX = 400;
                    fruitY = 160;
                    break;

            }


            fruit.Location = new Point(fruitX, fruitY);

            this.Controls.Add(fruit);
        }

        private void ForTime(object NewObj, EventArgs events)
        {
            Moving();
            Eating();
            //cube1.Location = new Point(cube1.Location.X + atX * cubesize, cube1.Location.Y + atY * cubesize);
        }

        private void Moving()
        {
            for (int i = score; i >= 1; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            snake[0].Location = new Point(snake[0].Location.X + atX * 40, snake[0].Location.Y + atY * 40);
            //Eatherself();
            Borders();
            Valls();
        }

        private void Eating()
        {
            if (snake[0].Location.X == fruitX && snake[0].Location.Y == fruitY)
            {
                Score.Text = "Score: " + ++score;
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + (40 * atX), snake[score - 1].Location.Y - (40 * atY));
                snake[score].Size = new Size(cubesize, cubesize);
                snake[score].BackColor = Color.Violet;
                this.Controls.Add(snake[score]);
                fruitcounter++;
                if (score == 5)
                {
                    MessageBox.Show("Уровень пройден\nПерейдите на другой уровень или продолжите", "OK", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    atX = 0;
                    atY = 0;
                    snake[0].Location = new Point(0, 120);
                    
                    StreamReader read = new StreamReader(nextopen);
                    string check = read.ReadToEnd();
                    read.Close();

                    StreamWriter next = new StreamWriter(nextopen);


                    if (string.IsNullOrEmpty(check))
                    {
                        next.Write("1");
                        next.Close();
                    }
                    else
                    {
                        next.Close();
                    }

                }

                FruitGen();
            }
        }

        private void Eatherself()
        {
            if (score > 4)
            {
                for (int i = 0; i < score; i++)
                {
                    if (snake[0].Location == snake[i].Location)
                    {
                        for (int j = i; j <= score; j++)
                        {
                            this.Controls.Remove(snake[j]);
                        }
                        score = score - (score - i + 1);

                    }
                }
            }

        }

        private void Borders()
        {
            if (snake[0].Location.X < 0)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(480, snake[i].Location.Y);
                }
            }

            if (snake[0].Location.Y < 0)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(snake[i].Location.X, 680);
                }
            }

            if (snake[0].Location.X > 500)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(0, snake[i].Location.Y);
                }
            }

            if (snake[0].Location.Y > 720)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(snake[i].Location.X, 0);
                }
            }
        }

        private void Valls()
        {
            if (snake[0].Location == pictureBox1.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена. ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox2.Location)
            {
                atX = 0;
                atY = 0;
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                score = 0;
            }
            else if (snake[0].Location == pictureBox3.Location)
            {
                atX = 0;
                atY = 0;
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                score = 0;
            }
            else if (snake[0].Location == pictureBox4.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox6.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
               
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox7.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox9.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox10.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
               
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox12.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox13.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox14.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox16.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox17.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox19.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox20.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox21.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox23.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox24.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox26.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }

                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
            else if (snake[0].Location == pictureBox27.Location)
            {
                atX = 0;
                atY = 0;
                snake[0].Location = new Point(0, 120);
                for (int i = score; i > 0; i--)
                {
                    this.Controls.Remove(snake[i]);
                }
                
                MessageBox.Show("Игра окончена, ваш счет " + score, "OK", MessageBoxButtons.OK);
                score = 0;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
