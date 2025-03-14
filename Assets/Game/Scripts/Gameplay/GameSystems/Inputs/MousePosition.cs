using System;
using R3;
using UnityEngine;
using Zenject;

namespace Game.GameSystems.Inputs
{
    public class MousePosition : IInitializable, IDisposable, IMousePosition
    {
        private IDisposable _disposable;

        public Vector3 CurrentValue { get; private set; }
        public Observable<Vector3> Value { get; private set; }

        public void Initialize()
        {
            Value = Observable.EveryUpdate()
                .Select(_ => Input.mousePosition);

            _disposable = Value.Subscribe(value => CurrentValue = value);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}