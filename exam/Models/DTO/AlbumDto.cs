using System;
using System.Collections.Generic;

namespace exam.Models.DTO
{
    public class AlbumDto
    {
        public string AlbumName { get; set; }

        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }

        public virtual ICollection<TrackDto> Tracks { get; set; }

        public virtual MusicLabel MusicLabel { get; set; }
    }
}
