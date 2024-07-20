// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Localisation;
using osu.Game.Localisation;

namespace osu.Game.Configuration
{
    public enum ColorblindMode
    {
        [LocalisableDescription(typeof(GraphicsSettingsStrings), nameof(GraphicsSettingsStrings.ColorblindModeOff))]
        Off,

        [LocalisableDescription(typeof(GraphicsSettingsStrings), nameof(GraphicsSettingsStrings.ColorblindModeDeuteranopia))]
        Deuteranopia,

        [LocalisableDescription(typeof(GraphicsSettingsStrings), nameof(GraphicsSettingsStrings.ColorblindModeProtanopia))]
        Protanopia,

        [LocalisableDescription(typeof(GraphicsSettingsStrings), nameof(GraphicsSettingsStrings.ColorblindModeTritanopia))]
        Tritanopia,

        [LocalisableDescription(typeof(GraphicsSettingsStrings), nameof(GraphicsSettingsStrings.ColorblindModeMonochromacy))]
        Monochromacy,

    }
}
