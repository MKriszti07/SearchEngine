namespace SearchEngine.Core.Application.Models
{
    public class SearchRequestModel
    {
        public string Text { get; set; } = string.Empty;
        public string SearchType { get; set; } = string.Empty;
    }
}
