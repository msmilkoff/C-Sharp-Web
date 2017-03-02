namespace SimpleMVC.App.Data
{
    public class DataSingleton
    {
        private static SharpStoreContext instance;

        public static SharpStoreContext Context
        {
            get
            {
                if (instance == null)
                {
                    instance = new SharpStoreContext();
                }

                return instance;
            }
        }
    }
}
