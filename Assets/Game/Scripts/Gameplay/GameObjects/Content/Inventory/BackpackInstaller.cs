using System.Linq;
using Game.Common;
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
            ItemType[] itemTypes = _params.Select(item => item.ItemType).ToArray();

            Container.Bind<ItemType[]>()
                .FromInstance(itemTypes)
                .AsCached();

            Container.BindInterfacesTo<Backpack>()
                .AsSingle()
                .WithArguments(_params)
                .NonLazy();

            Container.BindInterfacesTo<BackpackPresenter>()
                .AsSingle()
                .NonLazy();

            Container.Bind<BackpackView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}