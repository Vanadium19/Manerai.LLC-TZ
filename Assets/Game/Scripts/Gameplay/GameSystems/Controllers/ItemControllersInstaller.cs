using UnityEngine;
using Zenject;

namespace Game.GameSystems.Controllers
{
    public class ItemControllersInstaller : MonoInstaller
    {
        [SerializeField] private ItemDragAndDropController _itemDragAndDropController;

        public override void InstallBindings()
        {
            Container.Bind<ItemDragAndDropController>()
                .FromInstance(_itemDragAndDropController)
                .AsSingle();
        }
    }
}