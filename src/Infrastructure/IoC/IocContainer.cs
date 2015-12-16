
namespace Sediment.Infrastructure
{
    public class IocContainer: IIocContainer
    {
        // 这么搞是为了实现灵活替换IoC框架

        private static IIocContainer _instance;

        private IocContainer()
        {
        }

        public static void Build(IIocContainer container)
        {
            _instance = container;
        }

        public static IIocContainer Instance()
        {
            return _instance;
        }
    }
}
