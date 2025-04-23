using Optix.Movies.Objects.Enums;

namespace Optix.Movies.Objects
{
    public class ResultDisposable<T> : ResultItem, IDisposable where T : IDisposable
    {
        public T? Item { get; set; }

        public ResultDisposable(T item)
        {
            this.Item = item;
        }

        public ResultDisposable(ErrorStatusType errorStatus)
            : base(errorStatus)
        {
        }

        public ResultDisposable(ErrorStatusType errorStatus, Exception exception)
            : base(errorStatus, exception)
        {
        }

        public void Dispose()
        {
            if (this.Item != null)
                this.Item.Dispose();
        }
    }
}
