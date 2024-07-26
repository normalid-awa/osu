// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Localisation;
using osu.Game.Configuration;
using osu.Game.Graphics.UserInterface;
using osu.Game.Localisation;
using osuTK;

namespace osu.Game.Overlays.Settings.Sections.UserInterface
{
    public partial class GeneralSettings : SettingsSubsection
    {
        private const float transition_duration = 150f;

        protected override LocalisableString Header => CommonStrings.General;

        private SettingsSlider<float, SizeSlider<float>> parallaxSlider = null!;

        [BackgroundDependencyLoader]
        private void load(OsuConfigManager config)
        {
            Bindable<bool> parallax = config.GetBindable<bool>(OsuSetting.MenuParallax);

            Children = new Drawable[]
            {
                new SettingsCheckbox
                {
                    LabelText = UserInterfaceStrings.CursorRotation,
                    Current = config.GetBindable<bool>(OsuSetting.CursorRotation)
                },
                new SettingsSlider<float, SizeSlider<float>>
                {
                    LabelText = UserInterfaceStrings.MenuCursorSize,
                    Current = config.GetBindable<float>(OsuSetting.MenuCursorSize),
                    KeyboardStep = 0.01f
                },
                new SettingsCheckbox
                {
                    LabelText = UserInterfaceStrings.Parallax,
                    Current = parallax
                },
                parallaxSlider = new SettingsSlider<float, SizeSlider<float>>
                {
                    LabelText = UserInterfaceStrings.ParallaxMultiplier,
                    Current = config.GetBindable<float>(OsuSetting.ParallaxMultiplier)
                },
                new SettingsSlider<double, TimeSlider>
                {
                    ClassicDefault = 0,
                    LabelText = UserInterfaceStrings.HoldToConfirmActivationTime,
                    Current = config.GetBindable<double>(OsuSetting.UIHoldActivationDelay),
                    Keywords = new[] { @"delay" },
                    KeyboardStep = 50
                },
            };

            parallax.BindValueChanged(v =>
            {
                if (v.NewValue)
                    parallaxSlider
                    .FadeIn(transition_duration)
                    .ScaleTo(new Vector2(1, 1), transition_duration, Easing.InOutQuad);
                else
                    parallaxSlider
                    .FadeOut(transition_duration)
                    .ScaleTo(new Vector2(1, 0), transition_duration, Easing.InOutQuad);
            }, true);
        }
    }
}
