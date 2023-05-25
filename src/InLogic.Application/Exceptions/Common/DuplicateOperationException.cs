namespace InLogic.Application.Exceptions.Common
{
    /// <summary>
    /// Represents an duplicate operation exception
    /// </summary>
    public class DuplicateOperationException : ApplicationException
    {
        #region Fields

        /// <summary>
        /// Gets the trace identifier
        /// </summary>
        public string? TraceId { get; }

        /// <summary>
        /// Gets the title
        /// </summary>
        public string? Title { get; }

        /// <summary>
        /// Gets the detail
        /// </summary>
        public string? Detail { get; }

        /// <summary>
        /// Gets the instance
        /// </summary>
        public string? Instance { get; }

        #endregion

        #region Ctor

        public DuplicateOperationException(string? traceId, string? title, string? detail, string? instance)
    : base($"Duplicate Operation \"{detail}\" performed on \"{title}\"({instance}).")
        {
            TraceId = traceId;
            Title = title;
            Detail = detail;
            Instance = instance;
        }

        #endregion

    }
}
