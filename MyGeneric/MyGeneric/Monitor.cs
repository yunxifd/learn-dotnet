using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyGeneric
{
    public static class Monitor
    {
        #region 私有方法
        private static void ShowInt(int value) {
            // do nothing
        }

        private static void ShowObject(object value) {
            // do nothing
        }

        private static void Show<T>(T value) {
            // do nothing
        }
        #endregion
        public static void Show() {
            int intValue = 1;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i <= 100000000; i++) {
                ShowInt(intValue);
            }
            stopwatch.Stop();
            Console.WriteLine($"common method speed {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Restart();
            for (int i = 0; i <= 100000000; i++)
            {
                ShowObject(intValue);
            }
            stopwatch.Stop();
            Console.WriteLine($"object method speed {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            for (int i = 0; i <= 100000000; i++)
            {
                Show(intValue);
            }
            stopwatch.Stop();
            Console.WriteLine($"Generic method speed {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
