﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace osu.Game.Users.Drawables
{
    public class UpdateableFlag : ModelBackedDrawable<Country>
    {
        public Country Country
        {
            get => Model;
            set => Model = value;
        }

        public UpdateableFlag(Country country = null)
        {
            Country = country;
        }

        protected override Drawable CreateDrawable(Country country) => new DrawableFlag(country)
        {
            RelativeSizeAxes = Axes.Both,
        };
    }

    public class DrawableFlag : Sprite, IHasTooltip
    {
        private readonly Country country;

        public string TooltipText => country?.FullName;

        public DrawableFlag(Country country)
        {
            this.country = country;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore ts)
        {
            if (ts == null)
                throw new ArgumentNullException(nameof(ts));

            Texture = ts.Get($@"Flags/{country?.FlagName ?? @"__"}");
        }
    }
}
