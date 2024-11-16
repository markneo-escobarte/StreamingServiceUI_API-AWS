namespace StreamingServiceAPI.Models
{
    public class S3ObjectDTO
    {
        public string? Name { get; set; }
        public string? PresignedUrl { get; set; }
    }
}
