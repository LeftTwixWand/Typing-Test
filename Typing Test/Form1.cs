using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework;
using System.Diagnostics;
using System.Threading;
using System.Windows.Input;

namespace Typing_Test
{
    public partial class Form1 : MetroForm
    {
        bool isWorking = true;
        Thread thread;
        public Form1()
        {
            InitializeComponent();
            this.StyleManager = metroStyleManager;
            thread = new Thread(Typing);
            thread.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            thread.Start();
        }

        public void Typing()
        {
            while (isWorking)
            {
                Thread.Sleep(40);
                mainTextBox.Focus();
            }
        }

        private void MetroTile1_Click(object sender, EventArgs e)
        {
            metroStyleManager.Style = (sender as MetroTile).Style;
        }

        private void MetroTileSwitch_Click(object sender, EventArgs e)
        {
            metroStyleManager.Theme = metroStyleManager.Theme == MetroThemeStyle.Light ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
        }

        private void MetroLabel10_Click(object sender, EventArgs e)
        {
            Process.Start("https://sites.google.com/view/gorbachovajv/домашня-сторінка?authuser=2");
        }

        private void MetroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            keyboardLabel.Text = metroToggle2.Checked ? "Выключить клавиатуру с подсказаками" : "Включить клавиатуру с подсказаками";
        }

        private void MainTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mainTextBox.Text != "")
            {
                if (e.KeyChar == mainTextBox.Text.First())
                {
                    mainTextBox.Text = mainTextBox.Text.Remove(0, 1);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isWorking = false;
        }

        private void MetroTabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (metroTabControl1.SelectedTab == metroTabPage1)
            {
                if (mainTextBox.Text != "")
                {
                    if (e.KeyChar == mainTextBox.Text.First())
                    {
                        mainTextBox.Text = mainTextBox.Text.Remove(0, 1);
                    }
                }
            }
        }
    }
    
}
