namespace SoftUniBazar.ViewModels.Ad
{
    public class AdAllViewModel
    {
        public AdAllViewModel()
        {
            this.Ads = new HashSet<AdViewModel>();
        }

        public IEnumerable<AdViewModel> Ads { get; set; }
    }
}
