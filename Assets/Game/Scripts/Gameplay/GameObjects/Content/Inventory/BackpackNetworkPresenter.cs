using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.App;
using Zenject;

namespace Game.GameObjects.Content.Inventory
{
    public class BackpackNetworkPresenter : IInitializable, IDisposable
    {
        private readonly IBackpackClient _backpackClient;
        private readonly IBackpack _backpack;

        public BackpackNetworkPresenter(IBackpackClient backpackClient, IBackpack backpack)
        {
            _backpackClient = backpackClient;
            _backpack = backpack;
        }

        public void Initialize()
        {
            _backpack.ItemGot += SendItemStatus;
            _backpack.ItemPut += SendItemStatus;
        }

        public void Dispose()
        {
            _backpack.ItemGot -= SendItemStatus;
            _backpack.ItemPut -= SendItemStatus;
        }

        private void SendItemStatus(int id, string action)
        {
            _backpackClient.SendItemStatus(id, action).Forget();
        }
    }
}