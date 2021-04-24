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
    public partial class Level4 : Form
    {
        public PictureBox fruit;

        public int fruitX, fruitY;
        private int fruitcounter = 0;


        private PictureBox[] snake = new PictureBox[500];

        private Label Score;

        private int score = 0;
        private int atX, atY;
        private int cubesize = 40;

        

        public Level4()
        {
            InitializeComponent();

            timer.Tick += new EventHandler(ForTime);
            timer.Interval = 100;
            timer.Start();

            snake[0] = new PictureBox();
            snake[0].Location = new Point(200, 480);
            snake[0].Size = new Size(cubesize, cubesize);
            snake[0].BackColor = Color.Red;
            this.Controls.Add(snake[0]);

            fruit = new PictureBox();
            fruit.Size = new Size(cubesize, cubesize);
            fruit.BackColor = Color.Orange;
            FruitGen();

            Score = new Label();
            Score.Text = "Score: 0";
            Score.Location = new Point(0, 0);
            Score.BackColor = Color.White;
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
                    fruitX = 160;
                    fruitY = 160;
                    break;

                case 2:
                    fruitX = 160;
                    fruitY = 480;
                    break;

                case 3:
                    fruitX = 400;
                    fruitY = 80;
                    break;

                case 4:
                    fruitX = 40;
                    fruitY = 440;
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
                    fruitX = 160;
                    fruitY = 0;
                    break;

                case 11:
                    fruitX = 360;
                    fruitY = 360;
                    break;

                case 12:
                    fruitX = 40;
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
                    fruitY = 320;
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
                if (score == 30)
                {
                    MessageBox.Show("Игра пройдена\nПоздравляем!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    atX = 0;
                    atY = 0;
                    snake[0].Location = new Point(0, 120);
                    score = 0;
        


                   

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
                    snake[i].Location = new Point(520, snake[i].Location.Y);
                }
            }

            if (snake[0].Location.Y < 0)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(snake[i].Location.X, 760);
                }
            }

            if (snake[0].Location.X > 520)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(0, snake[i].Location.Y);
                }
            }

            if (snake[0].Location.Y > 760)
            {
                for (int i = 0; i <= score; i++)
                {
                    snake[i].Location = new Point(snake[i].Location.X, 0);
                }
            }
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {

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
            else if (snake[0].Location == pictureBox15.Location)
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
            else if (snake[0].Location == pictureBox18.Location)
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
            else if (snake[0].Location == pictureBox22.Location)
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
            else if (snake[0].Location == pictureBox25.Location)
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
            else if (snake[0].Location == pictureBox28.Location)
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
            else if (snake[0].Location == pictureBox29.Location)
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
            else if (snake[0].Location == pictureBox30.Location)
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
            else if (snake[0].Location == pictureBox31.Location)
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
            else if (snake[0].Location == pictureBox32.Location)
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
            else if (snake[0].Location == pictureBox33.Location)
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
            else if (snake[0].Location == pictureBox34.Location)
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
            else if (snake[0].Location == pictureBox35.Location)
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
            else if (snake[0].Location == pictureBox36.Location)
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
            else if (snake[0].Location == pictureBox37.Location)
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
            else if (snake[0].Location == pictureBox38.Location)
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
            else if (snake[0].Location == pictureBox39.Location)
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
            else if (snake[0].Location == pictureBox40.Location)
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
            else if (snake[0].Location == pictureBox41.Location)
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
            else if (snake[0].Location == pictureBox42.Location)
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
            else if (snake[0].Location == pictureBox43.Location)
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
            else if (snake[0].Location == pictureBox44.Location)
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
            else if (snake[0].Location == pictureBox45.Location)
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
            else if (snake[0].Location == pictureBox46.Location)
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
            else if (snake[0].Location == pictureBox47.Location)
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
            else if (snake[0].Location == pictureBox48.Location)
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
            else if (snake[0].Location == pictureBox49.Location)
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
            else if (snake[0].Location == pictureBox50.Location)
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
            else if (snake[0].Location == pictureBox51.Location)
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
            else if (snake[0].Location == pictureBox52.Location)
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
            else if (snake[0].Location == pictureBox53.Location)
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
            else if (snake[0].Location == pictureBox54.Location)
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
            else if (snake[0].Location == pictureBox55.Location)
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
            else if (snake[0].Location == pictureBox56.Location)
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

        private void Level4_Load(object sender, EventArgs e)
        {

        }
    }
}
