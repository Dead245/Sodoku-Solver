﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SodokuSolver
{
    public partial class Form1 : Form
    {
        List<Button> buttonList = new List<Button>();
        List<Label> labelList = new List<Label>();

        int amountOfSlots = 81;
        Point slotOffset = new Point(31,31);
        Size slotSize = new Size(28, 28);

        ButtonInteraction buttonIntr = new ButtonInteraction();
        Validator validtr = new Validator();

        

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
            //Grid Creation
            { 
            Point buttonLoc = slotButton.Location;
            slotButton.Click += NewButton_Click;
            buttonList.Add(slotButton);

            Point labelLoc = resultLabel.Location;
            labelList.Add(resultLabel);


            int currentXOffset = slotOffset.X;
            int currentYOffset = 0;

                for (int i = 1; i < amountOfSlots; i++)
                {
                    Button newButton = new Button();
                    this.Controls.Add(newButton);
                    Label newLabel = new Label();
                    this.Controls.Add(newLabel);

                    buttonList.Add(newButton);
                    labelList.Add(newLabel);

                    if (i % 9 == 0)
                    {
                        currentYOffset += slotOffset.Y;
                        currentXOffset = 0;
                    }

                    //Button Setup
                    newButton.Size = slotSize;
                    newButton.FlatStyle = FlatStyle.Flat;
                    newButton.FlatAppearance.BorderSize = 0;
                    newButton.BackColor = Color.Transparent;
                    newButton.Location = new Point(
                        buttonLoc.X + currentXOffset, buttonLoc.Y + currentYOffset);
                    newButton.Font = slotButton.Font;
                    newButton.Click += NewButton_Click;
                    newButton.BringToFront();

                    //Label Setup
                    newLabel.Size = slotSize;
                    newLabel.Location = new Point(
                        labelLoc.X + currentXOffset, labelLoc.Y + currentYOffset);
                    newLabel.Font = resultLabel.Font;
                    newLabel.TextAlign = ContentAlignment.MiddleCenter;
                    newLabel.BringToFront();

                    currentXOffset += slotOffset.X;
                }
            }

            
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.Text = buttonIntr.IterateButtonText(button.Text);
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {   
            //Turn buttonList into list of text
            char[,] boardArray = new char[9,9];
            for (int y = 0; y < 9; y++) //column
            {
                for (int x = 0; x < 9; x++) //row
                {
                    if (buttonList[(y * 9) + x].Text != "")
                    {
                        boardArray[x, y] = buttonList[(y * 9) + x].Text.ToCharArray()[0];
                    }
                    else {
                        boardArray[x, y] = ' ';
                    }

                }
            }

            bool validBoard = validtr.validateNewBoard(boardArray);
            
            if (validBoard)
            {
                verifyButton.Text = "Validated!";
                //verifyButton.Enabled = false;
            } else {
                verifyButton.Text = "Not Valid!";
            }
        }
    }
}
