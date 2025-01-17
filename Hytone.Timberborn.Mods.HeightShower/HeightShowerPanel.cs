﻿using TimberApi.UiBuilderSystem;
using Timberborn.UILayoutSystem;
using Timberborn.SingletonSystem;
using UnityEngine.UIElements;

namespace Hytone.Timberborn.Mods.HeightShower
{
    public class HeightShowerPanel : ILoadableSingleton
    {
        private readonly UILayout _gameLayout;
        public Label HeightLabel;


        private readonly UIBuilder _builder;
        private VisualElement _root;

        private const int _panelOrder = 8;

        public HeightShowerPanel(
            UILayout gameLayout, 
            UIBuilder uIBuilder)
        {
            _gameLayout = gameLayout;
            _builder = uIBuilder;
        }

        public void Load()
        {
            _root =
                _builder.CreateComponentBuilder()
                        .CreateVisualElement()
                        .AddClass("top-right-item")
                        .AddClass("square-large--green")
                        .SetFlexDirection(FlexDirection.Row)
                        .SetFlexWrap(Wrap.Wrap)
                        .SetJustifyContent(Justify.Center)
                        .AddComponent(builder => builder.AddComponent(_builder.CreateComponentBuilder()
                                                                              .CreateLabel()
                                                                              .AddClass("text--centered")
                                                                              .AddClass("text--yellow")
                                                                              .AddClass("date-panel__text")
                                                                              .AddClass("game-text-normal")
                                                                              .SetName("HeightShowerLabel")
                                                                              .SetLocKey("HeightShower.Panel.Height")
                                              .Build()))
                        .BuildAndInitialize();

            HeightLabel = _root.Q<Label>("HeightShowerLabel");

            _gameLayout.AddTopRight(_root, _panelOrder);
        }
    }
}
