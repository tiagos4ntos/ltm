using SimpleInjector;

namespace LTM.WebApi.App_Start
{
    public static class Bootstrapper
    {
        private static readonly Container _container;

        static Bootstrapper()
        {
            try
            {
                _container = new Container();
            }
            catch (System.Exception)
            {                
                throw;
            }
        }

        public static Container Container { get { return _container; } }
    }
}