using Core.Utils.LogConfig;

namespace Core.Utils.Helpers
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
                MessageLogger.GetLogger().Error(ex.Message);
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
                MessageLogger.GetLogger().Error(ex.Message);
                throw;
            }
        }
    }
}
