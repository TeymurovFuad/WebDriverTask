using Core.Utils.LogerConfiguration;

namespace Core.Utils.Extensions
{
    public static class ExceptionExentions
    {
        public static Action IgnoreActionExceptions(this Action action, params Type[] exceptionTypes)
        {
            try
            {
                action();
            }
            catch (Exception e) when (exceptionTypes.Contains(e.GetType()))
            {
                action();
            }
            return action;
        }

        public static void Try(this Action action)
        {
            try
            {
                action();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Try(this Action action, ErrorLogger logError)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                logError.LogMessage(ex);
            }
        }
    }
}
