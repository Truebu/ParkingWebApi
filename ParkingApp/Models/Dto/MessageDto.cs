namespace ParkingApp.Models.Dto
{
    public class MessageDto
    {
        public String message { get; set; }
        public bool error { get; set; }
        public double value { get; set; }

        public MessageDto(String message)
        {
            this.message = message;
        }

        public MessageDto(String message, double value)
        {
            this.message = message;
            this.value = value;
        }

        public MessageDto(string message, bool error) 
        {
            this.message = message;
            this.error = error;
        }
    }
}
