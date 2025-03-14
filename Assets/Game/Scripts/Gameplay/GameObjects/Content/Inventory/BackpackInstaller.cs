using UnityEngine;
using Zenject;

namespace Game.GameObjects.Content.Inventory
{
    public class BackpackInstaller : MonoInstaller
    {
        [SerializeField] private ItemBackpackParams[] _params;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Backpack>()
                .AsSingle()
                .WithArguments(_params)
                .NonLazy();
        }
    }
}