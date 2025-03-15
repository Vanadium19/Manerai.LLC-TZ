using System;
using Game.GameObjects.Content.Inventory;
using R3;
using Zenject;

namespace Game.GameObjects.Content.UI
{
    public class BackpackPresenter : IInitializable, IDisposable
    {
        private readonly IBackpack _backpack;
        private readonly BackpackView _view;

        private IDisposable _disposable;

        public BackpackPresenter(IBackpack backpack, BackpackView view)
        {
            _backpack = backpack;
            _view = view;
        }

        public void Initialize()
        {
            _disposable = _backpack.IsOpen.Subscribe(_view.OpenBackpack);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}