using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Entities
{
    public class ArtistSong
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
