// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Localisation;
using osu.Game.Configuration;
using osu.Framework.Localisation;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace osu.Game.Overlays.Settings.Sections.Graphics
{
    public partial class ColorblindSettings : SettingsSubsection
    {
        protected override LocalisableString Header => GraphicsSettingsStrings.ColorblindMode;

        [BackgroundDependencyLoader]
        private void load(OsuConfigManager config)
        {
            Children = new Drawable[]
            {
                new SettingsEnumDropdown<ColorblindMode>
                {
                    LabelText = GraphicsSettingsStrings.ColorblindMode,
                    Current = config.GetBindable<ColorblindMode>(OsuSetting.ColorblindMode)
                },
            };
        }
    }
}
