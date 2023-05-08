using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Label[,] tiles;

		int NR_MAPS = 6;
		string[] map1 = { "05", "15", "09", "29", "31", "42", "67", "68", "79", "90" };
		string[] map2 = { "03", "08", "09", "13", "17", "41", "52", "67", "68", "74", "79", "84", "90" };
		string[] map3 = { "01", "07", "08", "09", "43", "44", "52", "67", "68", "90", "99" };
		string[] map4 = { "00", "03", "04", "08", "13", "18", "19", "23", "59", "50", "55", "60", "61", "71", "97", "98" };
		string[] map5 = { "03", "13", "02", "36", "23", "37", "38", "40", "47", "51", "50", "79", "85", "84", "89", "92", "93", "94", "95" };
		string[] map6 = { "02", "03", "09", "12", "36", "47", "50", "57", "66", "79", "92", "99" };

		private void start_button_Click(object sender, EventArgs e)
		{
			menu.Enabled = false;
			menu.Visible = false;

			title.Enabled = false;
			title.Visible = false;

			start_button.Enabled = false;
			start_button.Visible = false;

			quit_button.Enabled = false;
			quit_button.Visible = false;

			tiles = new Label[,]{
				{ label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 },
				{ label11, label12, label13, label14, label15, label16, label17, label18, label19, label20 },
				{ label21, label22, label23, label24, label25, label26, label27, label28, label29, label30 },
				{ label31, label32, label33, label34, label35, label36, label37, label38, label39, label40 },
				{ label41, label42, label43, label44, label45, label46, label47, label48, label49, label50 },
				{ label51, label52, label53, label54, label55, label56, label57, label58, label59, label60 },
				{ label61, label62, label63, label64, label65, label66, label67, label68, label69, label70 },
				{ label71, label72, label73, label74, label75, label76, label77, label78, label79, label80 },
				{ label81, label82, label83, label84, label85, label86, label87, label88, label89, label90 },
				{ label91, label92, label93, label94, label95, label96, label97, label98, label99, label100 },
			};

			for (int i = 0; i < 10; i++)
				for (int j = 0; j < 10; j++)
					tiles[i, j].Text = "";

			ChooseMap();
			NumberTiles();
		}

		private void quit_button_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo) == DialogResult.Yes)
				this.Close();
		}

		private void restart_button_Click(object sender, EventArgs e)
		{
			NumberTiles();
		}

		private void close_button_Click(object sender, EventArgs e)
		{
			menu.Enabled = true;
			menu.Visible = true;

			title.Text = "Minesweeper";
			title.Enabled = true;
			title.Visible = true;

			start_button.Text = "Start";
			start_button.Enabled = true;
			start_button.Visible = true;

			quit_button.Enabled = true;
			quit_button.Visible = true;
		}

		private void ChooseMap()
		{
			int map = new Random().Next(1, NR_MAPS + 1);
			switch(map)
            {
				case 1:
					AddBombs(map1);
					break;
				case 2:
					AddBombs(map2);
					break;
				case 3:
					AddBombs(map3);
					break;
				case 4:
					AddBombs(map4);
					break;
				case 5:
					AddBombs(map5);
					break;
				case 6:
					AddBombs(map6);
					break;
			}
		}

		private void AddBombs(string[] map)
        {
			for (int i = 0; i < map.Length; i++)
            {
				int x = Int32.Parse(map[i][0].ToString());
				int y = Int32.Parse(map[i][1].ToString());
				tiles[x, y].Text = "X";
            }
        }

		private void NumberTiles()
		{
			string path = @"C:\Users\TheBoss\OneDrive\Desktop\Atestate\Minesweeper\Minesweeper\Resources\smile.png";
			face.Image = Image.FromFile(path);
			face.SizeMode = PictureBoxSizeMode.StretchImage;
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					tiles[i, j].Enabled = true;
					tiles[i, j].BackColor = Color.Silver;
					tiles[i, j].ForeColor = Color.Silver;

					if (tiles[i, j].Text == "X")
						continue;

					int nr = 0;

					if (i - 1 >= 0 && j - 1 >= 0 && tiles[i - 1, j - 1].Text == "X")
						nr++;
					if (i - 1 >= 0 && tiles[i - 1, j].Text == "X")
						nr++;
					if (i - 1 >= 0 && j + 1 < 10 && tiles[i - 1, j + 1].Text == "X")
						nr++;
					if (j - 1 >= 0 && tiles[i, j - 1].Text == "X")
						nr++;
					if (j + 1 < 10 && tiles[i, j + 1].Text == "X")
						nr++;
					if (i + 1 < 10 && j - 1 >= 0 && tiles[i + 1, j - 1].Text == "X")
						nr++;
					if (i + 1 < 10 && tiles[i + 1, j].Text == "X")
						nr++;
					if (i + 1 < 10 && j + 1 < 10 && tiles[i + 1, j + 1].Text == "X")
						nr++;

					if (nr > 0)
						tiles[i, j].Text = nr.ToString();
				}
			}
		}


		private void label1_Click(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			if (me.Button == MouseButtons.Left)
			{
				for (int i = 0; i < 10; i++)
				{
					for (int j = 0; j < 10; j++)
					{
						if (tiles[i, j] == sender)
						{
							if (tiles[i, j].BackColor != Color.Red)
							{
								Fill(i, j);
								break;
							}
						}
					}
				}
			}
			else
			{
				Label l = sender as Label;
				if (l.BackColor != Color.White)
				{
					if (l.BackColor != Color.Red)
					{
						l.BackColor = Color.Red;
						l.ForeColor = Color.Red;
					}
					else
					{
						l.BackColor = Color.Silver;
						l.ForeColor = Color.Silver;
					}
				}
			}
			CheckWin();
		}

		void Fill(int i, int j)
		{
			if (tiles[i, j].BackColor != Color.White)
			{
				tiles[i, j].BackColor = Color.White;
				tiles[i, j].ForeColor = Color.Black;
				if (tiles[i, j].Text == "")
				{
					if (i + 1 < 10)
						Fill(i + 1, j);
					if (i - 1 >= 0)
						Fill(i - 1, j);
					if (j + 1 < 10)
						Fill(i, j + 1);
					if (j - 1 >= 0)
						Fill(i, j - 1);
				}
				else if (tiles[i, j].Text == "X")
				{
					tiles[i, j].ForeColor = Color.Red;
					for (int k = 0; k < 10; k++)
						for (int l = 0; l < 10; l++)
							tiles[k, l].Enabled = false;
					string path = @"C:\Users\TheBoss\OneDrive\Desktop\Atestate\Minesweeper\Minesweeper\Resources\dead.png";
					face.Image = Image.FromFile(path);
					face.SizeMode = PictureBoxSizeMode.Zoom;
				}
			}
		}

        void CheckWin()
		{
			bool win = true;
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if (tiles[i, j].BackColor == Color.Silver)
						win = false;
					else if (tiles[i, j].BackColor == Color.Red && tiles[i, j].Text != "X")
						win = false;
				}
			}
			if (win == true)
			{
				menu.Enabled = true;
				menu.Visible = true;

				title.Text = "You Win!";
				title.Enabled = true;
				title.Visible = true;

				start_button.Text = "Play Again";
				start_button.Enabled = true;
				start_button.Visible = true;

				quit_button.Enabled = true;
				quit_button.Visible = true;
			}
		}
    }
}
