namespace BioEngine.BRC.Site.ViewModels
{
    public class ShareViewModel
    {
        public string Url { get; }
        public string Title { get; }

        public ShareViewModel(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}
