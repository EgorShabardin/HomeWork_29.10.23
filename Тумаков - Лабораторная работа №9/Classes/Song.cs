namespace Тумаков___Лабораторная_работа__9
{
    /// <summary>
    /// Класс, описывающий песню.
    /// </summary>
    class Song
    {
        #region Поля
        private string songName;
        private string songAuthor;
        private Song previousSong;
        #endregion

        #region Свойства
        /// <summary>
        /// Свойство, позволяющее читать поле songName.
        /// </summary>
        public string SongName
        {
            get
            {
                return songName;
            }
        }
        /// <summary>
        /// Свойство, позволяющее читать поле songAuthor.
        /// </summary>
        public string SongAuthor
        {
            get
            {
                return songAuthor;
            }
        }
        /// <summary>
        /// Свойство, позволяющее читать поле previousSong.
        /// </summary>
        public Song PreviousSong
        {
            get
            {
                return previousSong;
            }
        }
        /// <summary>
        /// Свойство, позволяющее прочитать название песни и ее исполнителя.
        /// </summary>
        public string Title
        {
            get
            {
                return songName + " " + songAuthor;
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, сравнивающий две песни.
        /// </summary>
        /// <param name="transmittedSong"> Объект, передаваемый для сравнения. </param>
        /// <returns> Возвращает true, если песни одинаковые, иначе false. </returns>
        public override bool Equals(object transmittedSong)
        {
            Song song = transmittedSong as Song;

            if ((song != null) && (song.SongName == songName) && (song.SongAuthor == songAuthor))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Метод, переопределяющий метод GetHashCode для данного класса.
        /// </summary>
        /// <returns> Хеш-код текущего объекта. </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, создающий экземпляр класса Song.
        /// </summary>
        /// <param name="songName"> Название песни. </param>
        /// <param name="songAuthor"> Автор песни. </param>
        /// <param name="previousSong"> Пердыдущая песня. </param>
        public Song(string songName, string songAuthor, Song previousSong)
        {
            this.songName = songName;
            this.songAuthor = songAuthor;
            this.previousSong = previousSong;
        }

        /// <summary>
        /// Конструктор, создающий экземпляр класса Song.
        /// </summary>
        /// <param name="songName"> Название песни. </param>
        /// <param name="songAuthor"> Автор песни. </param>
        public Song(string songName, string songAuthor)
        {
            this.songName = songName;
            this.songAuthor = songAuthor;
            previousSong = null;
        }

        /// <summary>
        /// Конструктор, создающий экземпляр класса Song.
        /// </summary>
        public Song()
        {
            songName = "Не указано";
            songAuthor = "Не указано";
            previousSong = null;
        }
        #endregion
    }
}
