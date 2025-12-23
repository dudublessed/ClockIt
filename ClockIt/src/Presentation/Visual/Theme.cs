using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockIt.src.Presentation.Visual
{
    public static class Theme
    {
        public static readonly Color Background = Color.FromArgb(229, 231, 235);
        public static readonly Color BackgroundAlt = Color.FromArgb(227, 227, 227);

        public static readonly Color Primary = Color.FromArgb(26, 115, 232);
        public static readonly Color Secondary = Color.FromArgb(8, 49, 102);

        public static readonly Color Text = Color.FromArgb(17, 24, 39);
        public static readonly Color TextMuted = Color.Gray;
        public static readonly Color TextWhite = Color.WhiteSmoke;

        public static readonly Color Success = Color.FromArgb(0, 184, 69);
        public static readonly Color Warning = Color.FromArgb(217, 195, 2);
        public static readonly Color Error = Color.FromArgb(153, 27, 27);

        public static readonly Font DefaultFont =
            new Font("Segoe UI", 9F, FontStyle.Bold);

        public static readonly Font LittleTitleFont =
            new Font("Segoe UI", 8.1F, FontStyle.Bold);

        public static readonly Font TitleFont =
            new Font("Segoe UI", 13F, FontStyle.Bold);

        public static readonly Font MidTitleFont =
            new Font("Segoe UI", 12F, FontStyle.Bold);

        public static readonly Font LowTitleFont =
            new Font("Segoe UI", 11F, FontStyle.Bold);

        public static readonly Font EmailCodeFont =
            new Font("Segoe UI", 15F, FontStyle.Bold);
    }
}
