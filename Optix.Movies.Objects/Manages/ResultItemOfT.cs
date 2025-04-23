using Optix.Movies.Objects.Enums;

namespace Optix.Movies.Objects
{
    public class ResultItem<T> : ResultItem
    {
        public T Item { get; set; }


        public ResultItem(T item)
            : this(item, ErrorStatusType.NoError)
        {
        }

        public ResultItem(T item, ResultItem resultItem)
            : base(resultItem)
        {
            this.Item = item;
        }

        public ResultItem(T item, ErrorStatusType errorStatus)
            : this(item, errorStatus, new ResultError(string.Empty))
        {
        }

        public ResultItem(T item, ErrorStatusType errorStatus, Exception exception)
            : this(item, errorStatus, new ResultError(exception))
        {
        }

        public ResultItem(T item, ErrorStatusType errorStatus, string message)
            : this(item, errorStatus, new ResultError(message))
        {
        }

        public ResultItem(T item, string errorMessage)
            : this(item, ErrorStatusType.Error, new ResultError(errorMessage))
        {
        }

        public ResultItem(T item, Exception exception)
            : this(item, ErrorStatusType.Error, exception)
        {
        }

        public ResultItem(T item, ErrorStatusType errorStatus, ResultError resultError)
        {
            this.Item = item;
            this.ErrorStatus = errorStatus;
            this.Error = resultError;
        }

    }
}
