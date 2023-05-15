namespace ParkingApp.Models.Dto
{
    public class MessageDto
    {
        private String message { get; set; }
        private double value { get; set; }

        public MessageDto(String message)
        {
            this.message = message;
        }

        public MessageDto(String message, double value)
        {
            this.message = message;
            this.value = value;
        }
    }
}
