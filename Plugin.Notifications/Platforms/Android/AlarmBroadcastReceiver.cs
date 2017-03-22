using System;
using Android.Content;


namespace Acr.Notifications
{
    [BroadcastReceiver(Enabled = true, Label = "Notifications Broadcast Receiver")]
    public class AlarmBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var notification = intent.ToNotification();
            var notificationId = intent.NotificationId();
            NotificationSettings.Instance.RemoveScheduledId(notificationId);

            // resend without schedule so it goes through normal mechanism
            notification.When = null;
            notification.Date = null;
            CrossNotifications.Current.Send(notification);
        }
    }
}