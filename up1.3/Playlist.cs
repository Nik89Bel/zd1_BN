using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace up1._3
{
    public struct Song
    {
        public string Author;
        public string Title;
        public string Filename;
    }
    public class Playlist
    {
        private List<Song> list;
        private int currentIndex;

        public Playlist()
        {
            list = new List<Song>();
            currentIndex = 0;
        }

        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        // Добавление аудиозаписи
        public void AddSong(Song song)
        {
            // Проверка на пустые поля
            if (song.Author == " " || song.Author == "" || song.Title == " " || song.Title == "" || song.Filename == " " || song.Filename == "")
            {
                throw new ArgumentException("Все поля песни должны быть заполнены!");
            }
            else
            // Проверка на то, что такой аудиозаписи еще нет в списке
            if (list.Contains(song) || list.FindIndex(s => s.Author == song.Author && s.Title == song.Title && s.Filename == song.Filename) != -1)
            {
                throw new InvalidOperationException("Такая песня уже существует в плейлисте!");
            }
            else
                list.Add(song);
        }

        public void AddSong(string author, string title, string filename)
        {
            Song song = new Song { Author = author, Title = title, Filename = filename };
            AddSong(song);
        }

        // Переход к следующей песне
        public void NextSong()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Плейлист пуст!");
            }
            currentIndex = (currentIndex + 1) % list.Count;
        }

        // Переход к предыдущей песне
        public void PreviousSong()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Плейлист пуст!");
            }
            currentIndex = (currentIndex - 1 + list.Count) % list.Count;
        }

        // Переход по индексу
        public void GoToSong(int index)
        {
            if (index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы плейлиста!");
            }
            currentIndex = index;
        }

        // Переход к началу списка
        public void GoToStart()
        {
            if (list.Count > 0)
            {
                currentIndex = 0;
            }
        }

        // Удаление композиции по индексу
        public void RemoveSong(int index)
        {
            if (index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы плейлиста!");
            }
            list.RemoveAt(index);
            if (currentIndex >= list.Count)
            {
                currentIndex = list.Count - 1;
            }
        }

        // Удаление композиции по значению
        public void RemoveSong(Song song)
        {
            int index = list.FindIndex(s => s.Author == song.Author && s.Title == song.Title && s.Filename == song.Filename);
            if (index != -1)
            {
                list.RemoveAt(index);

                if (currentIndex >= list.Count)
                {
                    currentIndex = list.Count - 1;
                }
            }
        }

        // Очистка плейлиста
        public void ClearPlaylist()
        {
            list.Clear();
            currentIndex = 0;
        }
    }
}
