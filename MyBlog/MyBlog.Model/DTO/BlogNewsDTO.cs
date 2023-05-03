namespace MyBlog.Model.DTO;

public class BlogNewsDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Time { get; set; }
    public int BrowseCount { get; set; }
    public int LikeCount { get; set; }
    public int TypeId { get; set; }
    public int WriterId { get; set; }

    public string TypeInfoName { get; set; }
    public string WriterInfoName { get; set; }
}