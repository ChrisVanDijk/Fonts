﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixLabors.Fonts.Tests
{
    using Xunit;

    public class FontLoaderTests
    {
        [Fact]
        public void LoadFontMetadata()
        {
            FontDescription description = FontDescription.LoadDescription(TestFonts.SimpleFontFileData());

            Assert.Equal("SixLaborsSamplesAB", description.FontName);
            Assert.Equal("AB", description.FontSubFamilyName);
        }

        [Fact]
        public void LoadFont()
        {
            Font font = Font.LoadFont(TestFonts.SimpleFontFileData());

            Assert.Equal("SixLaborsSamplesAB", font.FontName);
            Assert.Equal("AB", font.FontSubFamilyName);

            var glyph = font.GetGlyph('a');
            var r = new GlyphRenderer();
            glyph.RenderTo(r);
            // the test font only has characters .notdef, 'a' & 'b' defined
            Assert.Equal(3, r.ControlPoints.Count);
        }
    }
}
