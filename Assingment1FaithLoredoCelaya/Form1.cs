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

namespace Assingment1FaithLoredoCelaya
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //Empties the combo box if there was any element with in it.
            cmb.Items.Clear();

            //Fetches the number of attempts
            int size = Convert.ToInt32(tbNo.Text);

            //Initilizes how we are gonna store the data.
            string[] trials = new string[size];
            try
            {

                //Intilize a string builder to format the output
                StringBuilder str = new StringBuilder();

                //Create a new board
                Board b = new Board();

                int no = 0;

                //Random method.
                if (random.Checked == true)
                {
                    //Create and empty a file
                    File.WriteAllText(@"..\FaithLoredoNonIntelligentMethod.txt", " ");
                    for (int k = 0; k < size; k++)
                    {
                        //Create a new knight
                        Knight kng = new Knight();

                        //Process output and run the algorithm
                        str.Append("Trial " + (k + 1) + ": ");
                        str.Append(kng.randomMovement(b, Convert.ToInt32(tbX.Text), Convert.ToInt32(tbY.Text)));
                        str.Append("\n");
                        //output
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                str.Append("    " + b.BoardArray[i, j]);
                                if (b.BoardArray[i, j] < 10)
                                {
                                    str.Append("  ");
                                }
                                if (j == 7)
                                {
                                    str.Append("\n");
                                }
                            }
                        }
                        str.Append("\n");

                        //Pass output to the file and forms
                        trials[no] = str.ToString();
                        str.Clear();
                        no++;

                    }
                    //write into the file.
                    for (int i = 0; i < size; i++)
                    {
                        cmb.Items.Add(trials[i]);
                        File.AppendAllText(@"..\FaithLoredoNonIntelligentMethod.txt", trials[i]);
                        cmb.SelectedIndex = 0;
                    }
                }

                //Heuristics method
                if (smart.Checked == true)
                {
                    //Empty file and create a new one.
                    File.WriteAllText(@"..\FaithLoredoHeuristicsMethod.txt", " ");
                    for (int k = 0; k < size; k++)
                    {
                        //Create a new knight and run  
                        Knight kng = new Knight();
                        str.Append("Trial " + (k + 1) + ": ");
                        str.Append(kng.smartMovement(b, Convert.ToInt32(tbX.Text), Convert.ToInt32(tbY.Text)));
                        str.Append("\n");

                        //output
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                str.Append("    " + b.BoardArray[i, j]);
                                if (b.BoardArray[i, j] < 10)
                                {
                                    str.Append("  ");
                                }
                                if (j == 7)
                                {
                                    str.Append("\n");
                                }
                            }
                        }
                        str.Append("\n");
                        trials[no] = str.ToString();
                        str.Clear();
                        no++;
                    }
                    //Write into file. 
                    for (int i = 0; i < size; i++)
                    {
                        cmb.Items.Add(trials[i]);
                        File.AppendAllText(@"..\FaithLoredoHeuristicsMethod.txt", trials[i]);
                        cmb.SelectedIndex = 0;
                    }
                }
                
            }
            //Error handling.
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Put all into the combo box.
            output.Text = cmb.SelectedItem.ToString();
            
            //for some reason. the program  will always do one under the number we selected. Im not too sure of why. I been trying to debug
            //However I dont have enough time to quite figure it out.  Keep that in mind. 
        }
    }
}

