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

namespace Filmtipsaren
{
    public partial class Form1 : Form
    {
        List<Movie> movieList = new List<Movie>();
        List<string> itemSaver = new List<string>();

        public Form1()
        {
            InitializeComponent();

            if (File.Exists("Filmer.txt"))
            {
                StreamReader sr = new StreamReader("Filmer.txt");
                string item;
                while ((item = sr.ReadLine()) != null)
                {
                    itemSaver.Add(item);
                }
                foreach(string row in itemSaver)
                {
                    List<string[]> vectorList = new List<string[]>();
                    string[] vector = row.Split(new string[] { "###" }, StringSplitOptions.None);
                    vectorList.Add(vector);
                    Movie movie = new Movie();

                    movie.Title = vector[0];
                    movie.Genre = vector[1];
                    movie.Year = Convert.ToInt32(vector[2]);
                    movie.Director = vector[3];

                    movieList.Add(movie);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void loadMovieList_Click(object sender, EventArgs e)
        {
            if(movieList.Count > 0)
            {
                listBox1.Items.AddRange(movieList.ToArray());
            }
            else
            {
                MessageBox.Show("Fanns inga filmer");
            }

            loadMovieList.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count ==  1)
            {
                movieList.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else//Annars..
            {
                MessageBox.Show("Du måste välja en film att visa som sedd");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Movie getMovie = RandomMovie();
            if(getMovie == null)
            {
                MessageBox.Show("Gick inte att ta fram en film tyvärr");
            }
            else
            {
                textBox1.Text = getMovie.ToString();
                button3.Enabled = false;
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movie getMovie = RandomMovie();
            if (getMovie == null)
            {
                MessageBox.Show("Gick inte att ta fram en film tyvärr");
            }
            else
            {
                textBox1.Text = getMovie.ToString();
            }
        }

        public Movie RandomMovie()
        {
            Random randomMovie = new Random();
            int movieCount = movieList.Count();
            if (movieList.Count > 0)
            {
                int iRandom = randomMovie.Next(0, movieCount);
                Movie getRandomMovie = movieList[iRandom];
                return getRandomMovie;
            }
            else
            {
                return null;
            }
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }

        public override string ToString()
        {
            return  "[" + Genre + "] " + "'" + Title + "'" +  " (" + Year + ")" + ", regisserad av " + Director;
        }
    }
}


