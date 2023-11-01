namespace CvMaker.Web.Models
{
    public class CvListViewModel

    {
        public CvListViewModel()
        {
            CvItems = new List<CvItemModel>();
        }
        public List<CvItemModel> CvItems { get; set; }
    }  
}