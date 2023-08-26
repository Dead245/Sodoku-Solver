using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SodokuSolver
{
    public partial class Form1 : Form
    {
        int amountOfSlots = 81;
        Point slotOffset = new Point(31,31);
        Size slotSize = new Size(28, 28);
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create Button Grid
            Point buttonLoc = slotButton.Location;
            int currentXOffset = slotOffset.X;
            int currentYOffset = 0;

            for (int i = 1; i < amountOfSlots; i++)
            {    
                Button newButton = new Button();
                this.Controls.Add(newButton);
                Label newLabel = new Label();
                this.Controls.Add(newLabel);

                if (i % 9 == 0) {
                    currentYOffset += slotOffset.Y;
                    currentXOffset = 0;
                }

                newButton.Size = slotSize;
                newButton.FlatStyle= FlatStyle.Flat;
                newButton.FlatAppearance.BorderSize = 0;
                newButton.BackColor = Color.Transparent;
                newButton.Location = new Point(
                    slotButton.Location.X + currentXOffset, slotButton.Location.Y + currentYOffset);
                newButton.BringToFront();

                newLabel.Size = slotSize;
                newLabel.Location = new Point(
                    resultLabel.Location.X + currentXOffset, resultLabel.Location.Y + currentYOffset);
                newLabel.BringToFront();

                currentXOffset += slotOffset.X;
            }
            
        }

    }
}
