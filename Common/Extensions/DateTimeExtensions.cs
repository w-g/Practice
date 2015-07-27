using System;
using System.Globalization;

namespace Sediment.Common
{
    /// <summary>
    /// 日期的扩展
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 获取指定日所在周
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime dateTime)
        {
            GregorianCalendar calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);

            return calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        /// <summary>
        /// 获取星期几
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string GetDayofWeek(this DateTime dateTime)
        {
            string dayofweek = string.Empty;

            dayofweek = string.Format("星期{0}", DateTimeExtensions.GetWeekString(dateTime));

            return dayofweek;
        }

        /// <summary>
        /// 将当前 DateTime 对象的值转换为其等效的友好时间字符串表示形式
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFriendlyDateString(this DateTime dateTime)
        {
            string friendlyDate = string.Empty;

            //校准时间
            dateTime = dateTime.ToLocalTime();
            DateTime now = DateTime.Now;

            TimeSpan span = dateTime - now;
            if (Math.Abs(span.Days) <= 30)
            {
                int week_span = dateTime.GetWeekOfYear() - now.GetWeekOfYear();
                int day_span = (dateTime.Date - now.Date).Days;

                //上下三十天内
                if (span.Days == 0)
                {
                    //当天
                    if (span.Minutes == 0)
                    {
                        friendlyDate = "现在";
                    }
                    else if (Math.Abs(span.Hours) >= 1)
                    {
                        //当天的前后一小时之外
                        if (span.Hours > 0)
                        {
                            friendlyDate = string.Format("{0}小时后", Math.Abs(span.Hours));
                        }
                        else
                        {
                            friendlyDate = string.Format("{0}小时前", Math.Abs(span.Hours));
                        }
                    }
                    else
                    {
                        //一小时之内
                        if (span.Minutes > 0)
                        {
                            friendlyDate = string.Format("{0}分钟后", Math.Abs(span.Minutes));
                        }
                        else
                        {
                            friendlyDate = string.Format("{0}分钟前", Math.Abs(span.Minutes));
                        }
                    }
                }
                else if (span.Days > 0)
                {
                    //后三十天内
                    if (dateTime.Year == now.Year)
                    {
                        //同一年
                        if (week_span == 1)
                        {
                            friendlyDate = string.Format("下周{0}", DateTimeExtensions.GetWeekString(dateTime));
                        }
                        else
                        {
                            //n天后
                            friendlyDate = string.Format("{0}天后", Math.Abs(day_span));
                        }
                    }
                    else
                    {
                        //n天后
                        friendlyDate = string.Format("{0}天后", Math.Abs(day_span));
                    }
                }
                else
                {
                    //前三十天内
                    if (dateTime.Year == now.Year)
                    {
                        //同一年
                        if (week_span == -1)
                        {
                            friendlyDate = string.Format("上周{0}", DateTimeExtensions.GetWeekString(dateTime));
                        }
                        else
                        {
                            friendlyDate = string.Format("{0}天前", Math.Abs(day_span));
                        }
                    }
                    else
                    {
                        friendlyDate = string.Format("{0}天前", Math.Abs(day_span));
                    }
                }
            }
            else
            {
                if (dateTime.Year != now.Year)
                {
                    friendlyDate = dateTime.ToString("yyyy年MM月dd日");
                }
                else
                {
                    friendlyDate = dateTime.ToString("MM月dd日");
                }
            }

            return friendlyDate;
        }

        /// <summary>
        /// 获得星期描述
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static string GetWeekString(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "一";

                case DayOfWeek.Tuesday:
                    return "二";

                case DayOfWeek.Wednesday:
                    return "三";

                case DayOfWeek.Thursday:
                    return "四";

                case DayOfWeek.Friday:
                    return "五";

                case DayOfWeek.Saturday:
                    return "六";

                case DayOfWeek.Sunday:
                    return "日";

                default:
                    return string.Empty;
            }
        }
    }
}
