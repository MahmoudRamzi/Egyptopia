using Egyptopia.Domain.Common;

namespace Egyptopia.Domain.Entities
{
    public class TourGuide : EntityBase
    {
        //public Guid Id { get; set; }=Guid.NewGuid();
        //public string Name { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }
        public string AboutInfo { get; set; }
        public ICollection<TourGuideComment> TourGuideComments { get; set; }
        public string IdentityNumber { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<TourGuideLanguage> TourGuideLanguages { get; set; }
        
    }
}