using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace up1._3
{
    public partial class Form1 : Form
    {
        private Playlist playlist;
        public Form1()
        {
            InitializeComponent();
            playlist = new Playlist();
        }
        // Добавление аудиозаписи
        private void AddSong(object sender, EventArgs e)
        {
            try
            {
                string author = textBox1.Text;
                string title = textBox2.Text;
                string filename = textBox3.Text;
                playlist.AddSong(author, title, filename);
                UpdateCurrentSong();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Переход к следующей аудиозаписи
        private void NextSong(object sender, EventArgs e)
        {
            try
            {
                playlist.NextSong();
                UpdateCurrentSong();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Переход к прошлой аудиозаписи
        private void PreviousSong(object sender, EventArgs e)
        {
            try
            {
                playlist.PreviousSong();
                UpdateCurrentSong();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Переход к аудиозаписи по индексу
        private void GoToSong(object sender, EventArgs e)
        {
            if (int.TryParse(numericUpDown1.Value.ToString(), out int index))
            {
                try
                {
                    playlist.GoToSong(index - 1);
                    UpdateCurrentSong();
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректный индекс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Переход к первой аудиозаписи
        private void GoToStart(object sender, EventArgs e)
        {
            playlist.GoToStart();
            UpdateCurrentSong();
        }
        // Удаление аудиозаписи из списка по индексу
        private void RemoveSong(object sender, EventArgs e)
        {
            if (int.TryParse(numericUpDown2.Value.ToString(), out int index))
            {
                try
                {
                    playlist.RemoveSong(index - 1);
                    UpdateCurrentSong();
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректный индекс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Очистка всего списка 
        private void ClearPlaylist(object sender, EventArgs e)
        {
            playlist.ClearPlaylist();
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        // Обновление списка
        private void UpdateCurrentSong()
        {
            try
            {
                Song currentSong = playlist.CurrentSong();
                textBox4.Text = currentSong.Author;
                textBox5.Text = currentSong.Title;
                textBox6.Text = currentSong.Filename;
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
