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

namespace Winners
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_BTN_Click(object sender, EventArgs e)
        {
            //let's create a list object to store all the names from the list of the file to be streamed from
            List<String> names_list = new List<String>();

            //now we create a stream object to open the file
            StreamReader input_file;

            //now we open the file
            input_file = File.OpenText("Lexture #18 - Names.txt");

            //now we read each line of the opened file and store into the list dynamically
            while (!input_file.EndOfStream)
            {
                names_list.Add(input_file.ReadLine());
            }

            //now we randomly select 5 people from the list above
            //we will store them inside a new list
            List<String> selected_list = new List<String>();

            //we keep generating a random number until we have successfully selected 5 people in the list
            Random rand = new Random();
            int index;
            string selected;
            bool flip_next = false;
            while (selected_list.Count != 5)
            {
                //we want a random integer between 0 and whatever the size of the list of names
                index = rand.Next(names_list.Count);
                //now we grab the name at this index
                selected = names_list[index];
                //before we put this selected name into the list of selected names, we need to check it is unique
                for (int i = 0; i < selected_list.Count; i++)
                {
                    if (String.Equals(selected, selected_list[i]))
                    {
                        //if this name is already in the list, we continue the cycle
                        flip_next = true;
                        break;
                    }
                }
                if(flip_next)
                {
                    flip_next = false;
                    continue;
                }
                //at this point the name is unique
                selected_list.Add(selected);
            }

            //now we change the respective labels' text value to the 5 selected people's names
            RandName_1_LBL.Text = selected_list[0];
            RandName_2_LBL.Text = selected_list[1];
            RandName_3_LBL.Text = selected_list[2];
            RandName_4_LBL.Text = selected_list[3];
            RandName_5_LBL.Text = selected_list[4];

            //now we create a new list for the 3 winners
            //again, we will randomly select 3 names from the list of selected names
            List<String> winners_list = new List<String>();
            flip_next = false;
            while (winners_list.Count != 3)
            {
                index = rand.Next(selected_list.Count);
                selected = selected_list[index];
                for (int i = 0; i < winners_list.Count; i++)
                {
                    if (String.Equals(selected, winners_list[i]))
                    {
                        flip_next = true;
                        break;
                    }
                }
                if (flip_next)
                {
                    flip_next = false;
                    continue;
                }
                winners_list.Add(selected);
            }

            //now we respectively change the labels for the 3 winners
            Winner_1_LBL.Text = winners_list[0];
            Winner_2_LBL.Text = winners_list[1];
            Winner_3_LBL.Text = winners_list[2];

            //now lets store the prizes in a list
            List<String> prizes = new List<String>() { "$1,000", "$500", "$250" };
            //now we create a new list to get the prizes randomly
            List<String> rand_prizes = new List<String>();
            flip_next = false;
            while (rand_prizes.Count != 3)
            {
                index = rand.Next(prizes.Count);
                selected = prizes[index];
                for (int i = 0; i < rand_prizes.Count; i++)
                {
                    if (String.Equals(selected, rand_prizes[i]))
                    {
                        flip_next = true;
                    }
                }
                if (flip_next)
                {
                    flip_next = false;
                    continue;
                }
                rand_prizes.Add(selected);
            }

            //now we respectively change the label values for the prizes
            Prize_1_LBL.Text = rand_prizes[0];
            Prize_2_LBL.Text = rand_prizes[1];
            Prize_3_LBL.Text = rand_prizes[2];
        }
    }
}
