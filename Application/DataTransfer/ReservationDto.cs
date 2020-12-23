using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DataTransfer
{
    public class ReservationDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Projection")]
        public int ProjectionId { get; set; }
        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Starts")]
        public DateTime ProjectionBegin { get; set; }
        [Display(Name = "Ends")]
        public DateTime ProjectionEnd { get; set; }
        [Display(Name = "Hall")]
        public int HallId { get; set; }
        [Display(Name = "Movie")]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        [Display(Name = "Seats details")]
        public IEnumerable<ReservationSeatDto> SeatsInfo { get; set; }
        public List<int> ReservationSeats { get; set; }
    }
}
