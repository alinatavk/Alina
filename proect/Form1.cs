using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proect
{
    public partial class Form1 : Form
    {
        Button[,] buttons;
        List<Image> images;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillTheAraayOfButtons();

            images = new List<Image>();
            for (int i = 1; i < 9; i++)
            {
                images.Add(Image.FromFile(@"E:\\Resources\" + i + ".jpg"));
            }
            SetUpGame();
        }
        //E:\proect\Resources
        //C:\\Images\

        void SetUpGame()
        {
            Random rng = new Random();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int randomImageIndex = rng.Next(0, images.Count);
                    buttons[x, y].Image = images[randomImageIndex];
                    images.RemoveAt(randomImageIndex);

                }
            }
        }
        void FillTheAraayOfButtons()
        {
            buttons = new Button[3, 3];
            buttons[0, 0] = button1;
            buttons[1, 0] = button2;
            buttons[2, 0] = button3;
            buttons[0, 1] = button4;
            buttons[1, 1] = button5;
            buttons[2, 1] = button6;
            buttons[0, 2] = button7;
            buttons[1, 2] = button8;
            buttons[2, 2] = button9;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Image != null)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (buttons[x, y] == button)
                        {
                            CheckNeighbours(x, y);
                        }
                    }
                }
            }
            //  CheckWin();
        }
        //  void CheckWin()
        //  {
        //    if(button1.Image == images[0] && button2.Image == images[1] && button3.Image == images[2] && button4.Image == images[3] && button5.Image == images[4] && button6.Image == images[5] && button7.Image == images[6] && button8.Image == images[7] && button9.Image == images[8])
        //    {
        //        MessageBox.Show("Победа!");
        //    }

        //  }
        void CheckNeighbours(int xB, int yB)
        {
            for (int x = xB - 1; x <= xB + 1; x++)
            {
                for (int y = yB - 1; y <= yB + 1; y++)
                {
                    if (x >= 0 && x < 3 && y >= 0 && y < 3 && (xB == x || yB == y))
                    {
                        if (buttons[x, y].Image == null)
                        {
                            buttons[x, y].Image = buttons[xB, yB].Image;
                            buttons[xB, yB].Image = null;
                        }
                    }
                }
            }
        }
    }
}
