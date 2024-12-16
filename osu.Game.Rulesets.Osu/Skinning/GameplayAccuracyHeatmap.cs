// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics.Containers;
using osu.Game.Skinning;
using osu.Game.Rulesets.Osu.Statistics;
using osu.Game.Scoring;
using osu.Framework.Bindables;
using osu.Game.Beatmaps;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Scoring;
using System.Collections.Generic;
using osu.Game.Rulesets.Osu.Objects;
using System.Linq;
using osu.Game.Rulesets.Objects.Legacy;

namespace osu.Game.Rulesets.Osu.Skinning
{
    public partial class GameplayAccuracyHeatmap : Container, ISerialisableDrawable
    {
        [Resolved]
        private IBindable<WorkingBeatmap> beatmap { get; set; } = null!;

        [Resolved]
        private ScoreProcessor scoreProcessor { get; set; } = null!;

        public bool UsesFixedAnchor { get; set; }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            Width = 100;
            Height = 100;

            AccuracyHeatmap heatmap;
            Child = heatmap = new AccuracyHeatmap(new ScoreInfo { BeatmapInfo = beatmap.Value.BeatmapInfo, HitEvents = (List<HitEvent>)scoreProcessor.HitEvents }, beatmap.Value.Beatmap, false)
            {
                RelativeSizeAxes = Axes.Both
            };

            float radius = OsuHitObject.OBJECT_RADIUS * LegacyRulesetExtensions.CalculateScaleFromCircleSize(beatmap.Value.Beatmap.Difficulty.CircleSize, true);

            scoreProcessor.TotalScore.BindValueChanged((v) =>
            {
                ScoreInfo scoreInfo = new ScoreInfo { BeatmapInfo = beatmap.Value.BeatmapInfo, HitEvents = (List<HitEvent>)scoreProcessor.HitEvents };
                if (scoreInfo.HitEvents.Count < 1)
                    return;
                var e = scoreInfo.HitEvents.Last();
                if (e.LastHitObject == null || e.Position == null)
                    return;
                heatmap.AddPoint(((OsuHitObject)e.LastHitObject).StackedEndPosition, ((OsuHitObject)e.HitObject).StackedEndPosition, e.Position.Value, radius);
            });
        }
    }
}
