using Zenject;

namespace Weapons.Bullets
{
    public class BulletInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IBulletController>()
                .FromComponentInParents()
                .WhenInjectedInto<IBulletPresenter>();
        }
    }
}
