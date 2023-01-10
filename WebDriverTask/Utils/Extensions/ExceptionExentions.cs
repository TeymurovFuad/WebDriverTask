namespace WebDriverTask.Utils.Extensions
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

        public static Action Try(this Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return action;
        }
    }
}
