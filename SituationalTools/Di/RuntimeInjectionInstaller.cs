using Zenject;

namespace DenZ.DevelopmentTools.Di
{
    public class RuntimeInjectionInstaller<T> : InstallerBase
    {
        private T _value;

        public RuntimeInjectionInstaller(T value)
        {
            _value = value;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_value);
        }
    }
}