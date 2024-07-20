// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Logging;
using osu.Game.Configuration;
using osuTK;

namespace osu.Game.Graphics.Containers
{
    /// <summary>
    /// Handles user-defined scaling, allowing application at multiple levels defined by <see cref="ScalingMode"/>.
    /// </summary>
    public partial class ColorblindContainer : Container
    {
        private Bindable<ColorblindMode> colorblindMode = new Bindable<ColorblindMode>();

        private ColorblindModeContent content { get; set; }

        public new ColorblindModeContent Content
        {
            get => content;
            set => content = value;
        }

        private Container filterContainer;

        public ColorblindContainer(ColorblindModeContent content)
        {
            this.content = content;
            InternalChild = filterContainer = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Child = content
            };
            colorblindMode.BindValueChanged(_ => updateColorblindMode(), true);
        }

        [BackgroundDependencyLoader]
        private void load(OsuConfigManager config)
        {
            config.BindWith(OsuSetting.ColorblindMode, colorblindMode);
        }

        private void updateColorblindMode()
        {
            Logger.Log("mode");
            switch (colorblindMode.Value)
            {
                case ColorblindMode.Off:
                    content.Scale = new Vector2(0.2f);
                    break;
                case ColorblindMode.Deuteranopia:
                    content.Scale = new Vector2(0.4f);
                    break;
                case ColorblindMode.Protanopia:
                    content.Scale = new Vector2(0.6f);
                    break;
                case ColorblindMode.Tritanopia:
                    content.Scale = new Vector2(0.8f);
                    break;
                case ColorblindMode.Monochromacy:
                    content.Scale = new Vector2(1f);
                    break;
            }
            FinishTransforms();
        }

        public partial class ColorblindModeContent : Container
        {
            public ColorblindModeContent()
            {
                RelativeSizeAxes = Axes.Both;
            }
        }
    }
}
