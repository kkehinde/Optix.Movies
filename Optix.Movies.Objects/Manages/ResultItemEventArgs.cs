namespace Optix.Movies.Objects
{
    public class ResultItemEventArgs : EventArgs
    {
        public ResultItemEventArgs(ResultItem resultItem)
        {
            this.ResultItem = resultItem;
        }

        public ResultItem ResultItem { get; set; }
    }
}
