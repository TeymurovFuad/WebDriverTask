using WebDriverTask.Utils.LogerConfiguration;

namespace WebDriverTask.Utils.Helpers
{
    public class ExceptionHelper
    {
        public static Action IgnoreActionExceptions(Action action, params Type[] exceptionTypes)
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

        public static void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.LogMessage(ex);
                throw;
            }
        }

        public static void Try(Action action, ErrorLogger logError)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.LogMessage(ex);
                throw;
            }
        }

        public static T Try<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.LogMessage(ex);
                throw;
            }
        }
    }
}
