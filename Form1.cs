using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_is_live
{
    public partial class Form1 : Form
    {
        private Panel[,] _panel = new Panel[48, 48];
        private int[,] _panelBefor = new int[48, 48];

        public Panel panel = new Panel();
        public int frends = 0;
        const String G = "Green";
        public Form1() 
        {
            InitializeComponent();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void panel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = (Panel)sender;
            clickedPanel.BackColor = Color.Green;

            for (int x = 0; x < 36; x++)
            {
                for (int y = 0; y < 36; y++)
                {
                    if (_panel[x, y].Name == clickedPanel.Name)
                    {
                        _panel[x, y].BackColor = Color.Green;
                        _panelBefor[x, y] = 1;
                    }
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 36; x++)
            {
                for (int y = 0; y < 36; y++)
                {
                    panel.Location = new Point(16 + 20 * x, 16 + 20 * y);               //пример создания панели
                    panel.Size = new Size(16, 16);
                    panel.BackColor = Color.White;
                    panel.Click += new EventHandler(panel_Click);
                    panel.Name = x + " " + y;
                    panel.BorderStyle = BorderStyle.Fixed3D;
                    panel.ContextMenuStrip = contextMenuStrip1;
                    progressBar1.Value = progressBar1.Value + 1;

                    _panel[x, y] = panel;
                    _panelBefor[x, y] = 0;
                    this.Controls.Add(_panel[x, y]);
                    panel = new Panel();

                }
            }
             
            progressBar1.Value = 0;
            progressBar1.Enabled = false;
            progressBar1.Visible = false;
            button1.Enabled = false;
            button1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                timer1.Enabled = false;
                return;
            }
            for (int x = 0; x < 35; x++)
            {
                for (int y = 0; y < 35; y++)
                {
                    switch (y)
                    {
                        case 0:
                        {
                            if (x == 0)
                            {
                                if (_panel[x + 1, y].BackColor.Name == G)     frends++;
                                if (_panel[x + 1, y + 1].BackColor.Name == G) frends++;
                                if (_panel[x, y + 1].BackColor.Name == G)     frends++;

                                if ((frends == 3)/* | (frends == 2)*/) _panelBefor[x, y] = 1;
                                if (((frends == 3) | (frends == 2)) & (_panelBefor[x, y] == 1)) _panelBefor[x, y] = 1;
                                if ((frends != 3) & (frends != 2) & (_panel[x, y].BackColor.Name == G)) _panelBefor[x,y] = 0;
                                frends = 0;

                            }
                            else
                            {
                                if (_panel[x - 1, y].BackColor.Name == G)     frends++;
                                if (_panel[x - 1, y + 1].BackColor.Name == G) frends++;
                                if (_panel[x + 1, y].BackColor.Name == G)     frends++;
                                if (_panel[x + 1, y + 1].BackColor.Name == G) frends++;
                                if (_panel[x, y + 1].BackColor.Name == G)     frends++;

                                if ((frends == 3)/* | (frends == 2)*/) _panelBefor[x, y] = 1;
                                if (((frends == 3) | (frends == 2)) & (_panelBefor[x, y] == 1)) _panelBefor[x, y] = 1;
                                if ((frends != 3) & (frends != 2) & (_panel[x, y].BackColor.Name == G)) _panelBefor[x, y] = 0;
                                frends = 0;
                            }
                        }
                        break;

                        default:
                        {
                            if (x == 0)
                            {
                                if (_panel[x, y + 1].BackColor.Name == G) frends++;
                                if (_panel[x, y - 1].BackColor.Name == G) frends++;
                                if (_panel[x + 1, y].BackColor.Name == G) frends++;
                                if (_panel[x + 1, y + 1].BackColor.Name == G) frends++;
                                if (_panel[x + 1, y - 1].BackColor.Name == G) frends++;

                                if ((frends == 3)/* | (frends == 2)*/) _panelBefor[x, y] = 1;
                                if (((frends == 3) | (frends == 2)) & (_panelBefor[x, y] == 1)) _panelBefor[x, y] = 1;
                                if ((frends != 3) & (frends != 2) & (_panel[x, y].BackColor.Name == G)) _panelBefor[x, y] = 0;
                                frends = 0;
                            }
                            else
                            {

                                if (_panel[x, y + 1].BackColor.Name == G) frends++;
                                if (_panel[x, y - 1].BackColor.Name == G) frends++;
                                if (_panel[x + 1, y].BackColor.Name == G) frends++;
                                if (_panel[x - 1, y].BackColor.Name == G) frends++;
                                if (_panel[x + 1, y + 1].BackColor.Name == G) frends++;
                                if (_panel[x - 1, y - 1].BackColor.Name == G) frends++;
                                if (_panel[x + 1, y - 1].BackColor.Name == G) frends++;
                                if (_panel[x - 1, y + 1].BackColor.Name == G) frends++;

                                if ((frends == 3)/* | (frends == 2)*/) _panelBefor[x, y] = 1;
                                if (((frends == 3) | (frends == 2)) & (_panelBefor[x, y] == 1)) _panelBefor[x, y] = 1;
                                if ((frends != 3) & (frends != 2) & (_panel[x, y].BackColor.Name == G)) _panelBefor[x, y] = 0;
                                frends = 0;
                            }
                        }
                        break;
                    }
                }
            }

            for (int x = 0; x < 36; x++)
            {
                for (int y = 0; y < 36; y++)
                {
                    if (_panelBefor[x, y] == 1) _panel[x, y].BackColor = Color.Green; else _panel[x, y].BackColor = Color.White;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                timer1.Enabled = !timer1.Enabled;
                if (timer1.Enabled == true) label2.Text = "enable"; else label2.Text = "disable";
            }
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Enabled = false;
                for (int x = 0; x < 36; x++)
                {
                    for (int y = 0; y < 36; y++)
                    {
                        _panel[x, y].Dispose();
                        _panel[x, y] = null;
                        _panelBefor[x, y] = 0;
                    }
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                progressBar1.Value = 0;
                progressBar1.Enabled = true;
                progressBar1.Visible = true;
                button1.Enabled = true;
                button1.Visible = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value > 0) timer1.Interval = trackBar1.Value;
            label1.Text = timer1.Interval.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                timer1.Enabled = !timer1.Enabled;
                label2.Text = "enable";
            }else
            {
                timer1.Enabled = !timer1.Enabled;
                label2.Text = "disable";
            }
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label2.Text = "disable";
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                button1_Click(null, null);
            }
            else
            {
                timer1.Enabled = true;
                label2.Text = "enable";
            }
        }

        private void отчиститьПолеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == false)
            {
                for (int x = 0; x < 36; x++)
                {
                    for (int y = 0; y < 36; y++)
                    {
                        _panel[x, y].BackColor = Color.White;
                        _panelBefor[x, y] = 0;
                    }
                }
            }
        }

        private void выйтиИзИгрыToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
