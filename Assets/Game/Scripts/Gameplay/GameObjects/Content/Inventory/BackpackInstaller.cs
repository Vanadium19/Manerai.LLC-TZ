using System.Linq;
using Game.Common;
using Game.GameObjects.Content.Items;
using Game.GameObjects.UI;
using UnityEngine;
using Zenject;

namespace Game.GameObjects.Content.Inventory
{
    public class BackpackInstaller : MonoInstaller
    {
        [SerializeField] private ItemBackpackParams[] _params;
        [SerializeField] private BackpackView _view;

        public override void InstallBindings()
        {
            ItemConfig[] itemTypes = _params.Select(item => item.Config).ToArray();

            //Main
            Container.Bind<ItemConfig[]>()
                .FromInstance(itemTypes)
                .AsCached();

            Container.BindInterfacesTo<Backpack>()
                .AsSingle()
                .WithArguments(_params)
                .NonLazy();

            //Presenters
            Container.BindInterfacesTo<BackpackPresenter>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<BackpackNetworkPresenter>()
                .AsSingle()
                .NonLazy();

            //View
            Container.Bind<BackpackView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}