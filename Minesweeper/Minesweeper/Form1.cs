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
			map[0] = label1;
			map[1] = label2;
			map[2] = label3;
			map[3] = label4;
			map[4] = label5;
			map[5] = label6;
			map[6] = label7;
			map[7] = label8;
			map[8] = label9;
			map[9] = label10;
			map[10] = label11;
			map[11] = label12;
			map[12] = label13;
			map[13] = label14;
			map[14] = label15;
			map[15] = label16;
			map[16] = label17;
			map[17] = label18;
			map[18] = label19;
			map[19] = label20;
			map[20] = label21;
			map[21] = label22;
			map[22] = label23;
			map[23] = label24;
			map[24] = label25;
			map[25] = label26;
			map[26] = label27;
			map[27] = label28;
			map[28] = label29;
			map[29] = label30;
			map[30] = label31;
			map[31] = label32;
			map[32] = label33;
			map[33] = label34;
			map[34] = label35;
			map[35] = label36;
			map[36] = label37;
			map[37] = label38;
			map[38] = label39;
			map[39] = label40;
			map[40] = label41;
			map[41] = label42;
			map[42] = label43;
			map[43] = label44;
			map[44] = label45;
			map[45] = label46;
			map[46] = label47;
			map[47] = label48;
			map[48] = label49;
			map[49] = label50;
			map[50] = label51;
			map[51] = label52;
			map[52] = label53;
			map[53] = label54;
			map[54] = label55;
			map[55] = label56;
			map[56] = label57;
			map[57] = label58;
			map[58] = label59;
			map[59] = label60;
			map[60] = label61;
			map[61] = label62;
			map[62] = label63;
			map[63] = label64;
			map[64] = label65;
			map[65] = label66;
			map[66] = label67;
			map[67] = label68;
			map[68] = label69;
			map[69] = label70;
			map[70] = label71;
			map[71] = label72;
			map[72] = label73;
			map[73] = label74;
			map[74] = label75;
			map[75] = label76;
			map[76] = label77;
			map[77] = label78;
			map[78] = label79;
			map[79] = label80;
			map[80] = label81;
			map[81] = label82;
			map[82] = label83;
			map[83] = label84;
			map[84] = label85;
			map[85] = label86;
			map[86] = label87;
			map[87] = label88;
			map[88] = label89;
			map[89] = label90;
			map[90] = label91;
			map[91] = label92;
			map[92] = label93;
			map[93] = label94;
			map[94] = label95;
			map[95] = label96;
			map[96] = label97;
			map[97] = label98;
			map[98] = label99;
			map[99] = label100;
		}

		Label[] map = new Label[100];

		private void Fill(Label label)
        {
			label.BackColor = Color.White;
			label.ForeColor = Color.Black;
			if (label.Text == "")
			{
				int i;
				for (i = 0; i < 100; i++)
					if (map[i] == label)
						break;
				if (i - 10 >= 0 && map[i - 10].BackColor == Color.Silver)
					Fill(map[i - 10]);
				if (i + 10 < 100 && map[i + 10].BackColor == Color.Silver)
					Fill(map[i + 10]);
				if (i + 1 < 100 && map[i + 1].BackColor == Color.Silver)
					Fill(map[i + 1]);
				if (i - 1 >= 0 && map[i - 1].BackColor == Color.Silver)
					Fill(map[i - 1]);
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{
			Label label = sender as Label;
			if (label.BackColor == Color.Silver)
            {
				if (label.Text == "")
					Fill(label);
				else if (label.Text == "X")
				{
					label.BackColor = Color.White;
					label.ForeColor = Color.Red;
					MessageBox.Show("You Lose!");
					this.Close();
				}
				else
				{
					label.ForeColor = Color.Black;
					label.BackColor = Color.White;
				}
            }
		}
	}
}
