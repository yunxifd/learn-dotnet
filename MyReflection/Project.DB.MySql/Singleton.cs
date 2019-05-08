namespace Project.DB.MySql
{
    public class Singleton
    {
        private static readonly Singleton singleton = null;
        /// <summary>
        ///  私有化构造函数 使其不能在外部实例化
        /// </summary>
        private Singleton()
        {
        }

        static Singleton()
        {
            singleton = new Singleton();
        }

        public static Singleton GetInstance()
        {
            return singleton;
        }
    }
}
