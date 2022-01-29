using System;
using System.Windows.Forms;

namespace FlappyBirdWindowsForm
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void gameTimerEvent(object sender, EventArgs e)
        {
            //bird keep going down
            flappyBird.Top += gravity;
            // move
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = score.ToString();

            //keep producing pipe
            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if (score > 5)
            {
                pipeSpeed = 15;
            }

            if (flappyBird.Top < -25)
            {
                endgame();
            }

            //end game
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds)
                )
            {
                endgame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
            {
                gravity = -15;
            }
        }
        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Down)
            {
                gravity = 15;
            }
        }

        private void endgame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over!!!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
