using System;

namespace Training.Application.Dto
{
    public class VideoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string DirectedBy { get; set; }
        public string Genre { get; set; }

        public Guid? StudioId { get; set; }
    }
}