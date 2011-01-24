using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
   sealed class Class1
    {

        public static long method1(string str)
        {
            str = str.ToUpper();
            long l = 0;
            for (int i = 0; i < str.Length; i++)
            {
                l += str[i] * str[i];
            }
            l = l * l * l % (long)Math.Pow(2.0, 32.0);
            l -= (long)Math.Pow(2.0, 32.0);
            if (l < (long)(-Math.Pow(2.0, 32.0) / 2.0))
            {
                l += (long)Math.Pow(2.0, 32.0);
            }
            l = Math.Abs(l - l % 2103) + 5879;
            return l;
        }

        public static long method2(string str)
        {
            long l = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                l += (int)Math.Floor(Math.Sqrt(Math.Abs(Math.Pow((double)str[i], 3.0) % 2.147483648E9)));
            }
            l = l * l * l % (long)Math.Pow(2.0, 32.0);
            l -= (long)Math.Pow(2.0, 32.0);
            if (l < (long)(-Math.Pow(2.0, 32.0) / 2.0))
            {
                l += (long)Math.Pow(2.0, 32.0);
            }
            l = Math.Abs(l - l % 2203);
            return l;
        }

        public bool method3(string str, int num)
        {
            if ((long)num == method1(str) || (long)num == method2(str) || (long)num == method2(str.ToUpper()) || (long)num == method2(str.ToLower()))
            {
                return num == 0 == false;
            }
            return false;
        }

        public bool method3(string str1, string str2)
        {
            bool flag;

            try
            {
                flag = method3(str1, Int32.Parse(str2));
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }
    }

   public static class ExtendedPermissions
   {
       public static string[] Permissions = {
            // Publishing Permissions
            "publish_stream",
            "create_event",
            "rsvp_event",
            "sms",
            "offline_access",
            // User Permissions
            "user_about_me",
            "user_activities",
            "user_birthday",
            "user_education_history",
            "user_events",
            "user_groups",
            "user_hometown",
            "user_interests",
            "user_likes",
            "user_location",
            "user_notes",
            "user_online_presence",
            "user_photo_video_tags",
            "user_photos",
            "user_relationships",
            "user_relationship_details",
            "user_religion_politics",
            "user_status",
            "user_videos",
            "user_website",
            "user_work_history",
            "email",
            "read_friendlists",
            "read_insights",
            "read_mailbox",
            "read_requests",
            "read_stream",
            "xmpp_login",
            "ads_management",
            "user_checkins",
            // Friends Permissions
            "friends_about_me",
            "friends_activities",
            "friends_birthday",
            "friends_education_history",
            "friends_events",
            "friends_groups",
            "friends_hometown",
            "friends_interests",
            "friends_likes",
            "friends_location",
            "friends_notes",
            "friends_online_presence",
            "friends_photo_video_tags",
            "friends_photos",
            "friends_relationships",
            "friends_relationship_details",
            "friends_religion_politics",
            "friends_status",
            "friends_videos",
            "friends_website",
            "friends_work_history",
            "friends_checkins",
            // Page Permissions
            "manage_pages",
        };


   }

}
