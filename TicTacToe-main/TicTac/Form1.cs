using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
    public partial class Form1 : Form
    {
        public List<Shape> XO { get; set; }
        public bool isX { get; set; }
        public List<Place> Places { get; set; }
        public bool isEasy { get; set; }
        public char[] board = new char[9];
        public char first;
        public int loss { get; set; }
        public int win { get; set; }

        int max(int score, int bestScore)
        {
            if (score >= bestScore)
            {
                return score;
            }
            else
            {
                return bestScore;
            }
        }

        int min(int score, int bestScore)
        {
            if (score <= bestScore)
            {
                return score;
            }
            else
            {
                return bestScore;
            }
        }

        char checkWinner()
        {
            int empty = 0;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == ' ')
                {
                    empty++;
                }
            }
            if ((board[0] == 'X' && board[1] == 'X' && board[2] == 'X') || (board[3] == 'X' && board[4] == 'X' && board[5] == 'X') || (board[6] == 'X' && board[7] == 'X' && board[8] == 'X') || (board[0] == 'X' && board[3] == 'X' && board[6] == 'X') || (board[1] == 'X' && board[4] == 'X' && board[7] == 'X') || (board[2] == 'X' && board[5] == 'X' && board[8] == 'X') || (board[0] == 'X' && board[4] == 'X' && board[8] == 'X') || (board[2] == 'X' && board[4] == 'X' && board[6] == 'X'))
            {
                return 'X';
            }
            else if ((board[0] == '0' && board[1] == '0' && board[2] == '0') || (board[3] == '0' && board[4] == '0' && board[5] == '0') || (board[6] == '0' && board[7] == '0' && board[8] == '0') || (board[0] == '0' && board[3] == '0' && board[6] == '0') || (board[1] == '0' && board[4] == '0' && board[7] == '0') || (board[2] == '0' && board[5] == '0' && board[8] == '0') || (board[0] == '0' && board[4] == '0' && board[8] == '0') || (board[2] == '0' && board[4] == '0' && board[6] == '0'))
            {
                return '0';
            }
            else if (empty == 0)
            {
                return 't';
            }
            else
            {
                return 'N';
            }
        }

        int minimax(int depth, bool isMaximizing)
        {
            char result = checkWinner();
            if (result != 'N')
            {
                if (first == 'R')
                {
                    if (result == 'X')
                    {
                        return 10;
                    }
                    if (result == '0')
                    {
                        return -10;
                    }
                    if (result == 't')
                    {
                        return 0;
                    }
                }
                else
                {
                    if (result == 'X')
                    {
                        return -10;
                    }
                    if (result == '0')
                    {
                        return 10;
                    }
                    if (result == 't')
                    {
                        return 0;
                    }
                }
            }

            if (isMaximizing)
            {
                int bestScore = -1000000;
                for (int i = 0; i < 9; i++)
                {
                    if (board[i] == ' ')
                    {
                        if (first == 'R')
                        {
                            board[i] = 'X';
                        }
                        else
                        {
                            board[i] = '0';
                        }
                        int score = minimax(depth + 1, false);
                        board[i] = ' ';
                        bestScore = max(score, bestScore);
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = 1000000;
                for (int i = 0; i < 9; i++)
                {
                    if (board[i] == ' ')
                    {
                        if (first == 'R')
                        {
                            board[i] = '0';
                        }
                        else
                        {
                            board[i] = 'X';
                        }
                        int score = minimax(depth + 1, true);
                        board[i] = ' ';
                        bestScore = min(score, bestScore);
                    }
                }
                return bestScore;
            }
        }

        int bestMove()
        {
            int bestScore = -1000000;
            int move = 0;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == ' ')
                {
                    if (first == 'R')
                    {
                        board[i] = 'X';
                    }
                    else
                    {
                        board[i] = '0';
                    }
                    int score = minimax(0, false);
                    board[i] = ' ';
                    if (score > bestScore)
                    {
                        bestScore = score;
                        move = i;
                    }
                }
            }
            if (first == 'R')
            {
                board[move] = 'X';
            }
            else
            {
                board[move] = '0';
            }
            return move;
        }

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                board[i] = ' ';
            }
            DialogResult dialogResult = MessageBox.Show("Easy Mode", "Select Difficulty", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes)
            {
                isEasy = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                isEasy = false;
            }
            DialogResult dialogResult1 = MessageBox.Show("Would you like to go first", "Select Turn", MessageBoxButtons.YesNo);

            if (dialogResult1 == DialogResult.Yes)
            {
                first = 'C';
            }
            else if (dialogResult1 == DialogResult.No)
            {
                first = 'R';
            }
            XO =new List<Shape>();
            isX = true;
            Places = new List<Place>();
            Places.Add(new Place(new Point(100, 100)));
            Places.Add(new Place(new Point(300, 100)));
            Places.Add(new Place(new Point(500, 100)));
            Places.Add(new Place(new Point(100, 300)));
            Places.Add(new Place(new Point(300, 300)));
            Places.Add(new Place(new Point(500, 300)));
            Places.Add(new Place(new Point(100, 500)));
            Places.Add(new Place(new Point(300, 500)));
            Places.Add(new Place(new Point(500, 500)));
            win = 0;
            loss = 0;
            if (first == 'R')
            {
                if (isEasy)
                {
                    Random random = new Random();
                    int rand = random.Next(0, 9);
                    board[rand] = 'X';
                    Shape shape = new Shape(isX, Places[rand].Location);
                    Places[rand].isFree = false;
                    Places[rand].isX = true;
                    XO.Add(shape);
                    isX = !isX;
                }
                else
                {
                    int move = bestMove();
                    Shape shape = new Shape(isX, Places[move].Location);
                    Places[move].isFree = false;
                    Places[move].isX = true;
                    XO.Add(shape);
                    isX = !isX;
                }
                //Invalidate(true);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(win!=5 || loss!=5)
            {
                Pen pn = new Pen(Color.Black, 15);
                foreach (Shape s in XO)
                {
                    s.DrawShape(e.Graphics);
                }
                e.Graphics.DrawLine(pn, new Point(200, 0), new Point(200, 600));
                e.Graphics.DrawLine(pn, new Point(400, 0), new Point(400, 600));
                e.Graphics.DrawLine(pn, new Point(0, 200), new Point(600, 200));
                e.Graphics.DrawLine(pn, new Point(0, 400), new Point(600, 400));
            }else
            {
                e.Graphics.Clear(Color.White);
            }    
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(win==5 || loss==5)
            {
                finalWinner();
            }else
            {
                int selected = 0;
                if (e.Location.X > 0 && e.Location.X < 200)
                {
                    if (e.Location.Y > 0 && e.Location.Y < 200)
                    {
                        selected = 0;
                    }
                    else if (e.Location.Y > 200 && e.Location.Y < 400)
                    {
                        selected = 3;
                    }
                    else if (e.Location.Y > 400 && e.Location.Y < 600)
                    {
                        selected = 6;
                    }
                }
                else if (e.Location.X > 200 && e.Location.X < 400)
                {
                    if (e.Location.Y > 0 && e.Location.Y < 200)
                    {
                        selected = 1;
                    }
                    else if (e.Location.Y > 200 && e.Location.Y < 400)
                    {
                        selected = 4;
                    }
                    else if (e.Location.Y > 400 && e.Location.Y < 600)
                    {
                        selected = 7;
                    }
                }
                else if (e.Location.X > 400 && e.Location.X < 600)
                {
                    if (e.Location.Y > 0 && e.Location.Y < 200)
                    {
                        selected = 2;
                    }
                    else if (e.Location.Y > 200 && e.Location.Y < 400)
                    {
                        selected = 5;
                    }
                    else if (e.Location.Y > 400 && e.Location.Y < 600)
                    {
                        selected = 8;
                    }
                }
                bool check = false;
                if (Places[selected].isFree)
                {
                    check = true;
                    if (isX)
                    {
                        board[selected] = 'X';
                    }
                    else
                    {
                        board[selected] = '0';
                    }
                    Shape shape = new Shape(isX, Places[selected].Location);
                    Places[selected].isFree = false;
                    Places[selected].isX = isX;
                    XO.Add(shape);
                    isX = !isX;
                    Invalidate(true);
                }
                if (checkWinner() != 'N')
                {
                    char res = checkWinner();
                    if ((res == 'X' && first == 'C') || (res == '0' && first == 'R'))
                    {
                        MessageBox.Show("YOU WON!                     ", "Victory!", MessageBoxButtons.OK);
                        win++;
                        label4.Text = String.Format("{0}", win);
                        progressBar2.Value += 20;
                    }
                    else if ((res == '0' && first == 'C') || (res == 'X' && first == 'R'))
                    {
                        MessageBox.Show("Your opponent won!           ", "Defeat!", MessageBoxButtons.OK);
                        loss++;
                        label2.Text = String.Format("{0}", loss);
                        progressBar1.Value += 20;
                    }
                    else
                    {
                        MessageBox.Show("It's a tie!                  ", "Tie!", MessageBoxButtons.OK);
                    }
                    resetAll();
                    if (win == 5 || loss == 5)
                    {
                        finalWinner();
                    }
                }
                if (check)
                {
                    if (isEasy)
                    {
                        if (first == 'R')
                        {
                            Random random = new Random();
                            int rand;
                            while (true)
                            {
                                rand = random.Next(0, 9);
                                if (board[rand] == ' ')
                                {
                                    break;
                                }
                            }
                            board[rand] = 'X';
                            Shape shape = new Shape(isX, Places[rand].Location);
                            Places[rand].isFree = false;
                            Places[rand].isX = true;
                            XO.Add(shape);
                            isX = !isX;
                        }
                        else
                        {
                            Random random = new Random();
                            int rand;
                            while (true)
                            {
                                rand = random.Next(0, 9);
                                if (board[rand] == ' ')
                                {
                                    break;
                                }
                            }
                            board[rand] = '0';
                            Shape shape = new Shape(isX, Places[rand].Location);
                            Places[rand].isFree = false;
                            Places[rand].isX = true;
                            XO.Add(shape);
                            isX = !isX;
                        }
                    }
                    else
                    {
                        int move = bestMove();
                        Shape shape = new Shape(isX, Places[move].Location);
                        Places[move].isFree = false;
                        Places[move].isX = true;
                        XO.Add(shape);
                        isX = !isX;
                    }
                    Invalidate(true);
                    if (checkWinner() != 'N')
                    {
                        char res = checkWinner();
                        if ((res == 'X' && first == 'C') || (res == '0' && first == 'R'))
                        {
                            MessageBox.Show("YOU WON!                     ", "Victory!", MessageBoxButtons.OK);
                            win++;
                            label4.Text = String.Format("{0}", win);
                            progressBar2.Value += 20;
                        }
                        else if ((res == '0' && first == 'C') || (res == 'X' && first == 'R'))
                        {
                            MessageBox.Show("Your opponent won!           ", "Defeat!", MessageBoxButtons.OK);
                            loss++;
                            label2.Text = String.Format("{0}", loss);
                            progressBar1.Value += 20;
                        }
                        else
                        {
                            MessageBox.Show("It's a tie!                  ", "Tie!", MessageBoxButtons.OK);
                        }
                        resetAll();
                        if (win == 5 || loss == 5)
                        {
                            finalWinner();
                        }
                    }
                }
            }
        }

        private void resetAll()
        {

            XO = new List<Shape>();
            Places = new List<Place>();
            Places.Add(new Place(new Point(100, 100),true, false));
            Places.Add(new Place(new Point(300, 100),true, false));
            Places.Add(new Place(new Point(500, 100),true, false));
            Places.Add(new Place(new Point(100, 300),true, false));
            Places.Add(new Place(new Point(300, 300),true, false));
            Places.Add(new Place(new Point(500, 300),true, false));
            Places.Add(new Place(new Point(100, 500),true, false));
            Places.Add(new Place(new Point(300, 500),true, false));
            Places.Add(new Place(new Point(500, 500),true, false));
            board = new char[9];
            for (int i = 0; i < 9; i++)
            {
                board[i] = ' ';
            }
            
            Invalidate(true);
        }

        private void finalWinner()
        {
            resetAll();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            progressBar1.Visible = false;
            progressBar2.Visible = false;
            textBox1.Visible = true;
            button1.Visible = true;
            button1.Enabled = true;
            button2.Visible = true;
            button2.Enabled = true;
            if(win==5)
            {
                textBox1.Text = "GRAND VICTORY";
            }
            else
            {
                textBox1.Text = "GRAND LOSS";
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 nextForm = new Form1();
            this.Hide();
            nextForm.ShowDialog();
            this.Close();
        }
    }
}
