using System;


namespace Acr.Notifications
{

    public static class CrossNotifications
    {
        static INotifications current;
        public static INotifications Current
        {
            get
            {
#if BAIT
                if (current == null)
                    throw new ArgumentException("Platform implementation not found.  Did you reference the nuget package in your main project as well?");
#else
                current = current ?? new NotificationsImpl();
#endif
                return current;
            }
            set { current = value; }
        }
    }
}
