using Refit;

namespace DemoRefit.Client.Api
{
    public class BookParameters
    {
        public bool SortAsc { get; set; } = true;
        public int Limit { get; set; } = 0;

        [Query(CollectionFormat.Multi)]
        public int[] Ids { get; set; } = [];
    }
}
