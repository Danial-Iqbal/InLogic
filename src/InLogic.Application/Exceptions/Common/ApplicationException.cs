namespace InLogic.Application.Exceptions.Common
{
    /// <summary>
    /// Represents an application exception
    /// </summary>
    public abstract class ApplicationException : Exception
    {
        #region Ctor

        protected ApplicationException(string message) : base(message)
        {

        }

        #endregion

    }
}
