using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Entities
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
    }
}
