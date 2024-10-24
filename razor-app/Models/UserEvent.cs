namespace Razor_App.Models;
public class UserEvent
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? PictureURL { get; set; }
    public DateTime EventDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}