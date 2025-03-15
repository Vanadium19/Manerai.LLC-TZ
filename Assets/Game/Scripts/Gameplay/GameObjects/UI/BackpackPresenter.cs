using System;
using Game.GameObjects.Content.Inventory;
using R3;
using Zenject;

namespace Game.GameObjects.UI
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
            DisposableBuilder builder = Disposable.CreateBuilder();

            _backpack.IsOpen.Subscribe(_view.OpenBackpack).AddTo(ref builder);
            _view.SelectedItem.Subscribe(_backpack.SelectItem).AddTo(ref builder);

            _disposable = builder.Build();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}