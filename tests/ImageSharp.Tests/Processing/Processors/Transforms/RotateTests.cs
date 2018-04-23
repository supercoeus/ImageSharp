﻿// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Transforms;

using Xunit;

namespace SixLabors.ImageSharp.Tests.Processing.Processors.Transforms
{
    public class RotateTests : FileTestBase
    {
        public static readonly TheoryData<float> RotateAngles
            = new TheoryData<float>
        {
            50, -50, 170, -170
        };

        public static readonly TheoryData<RotateMode> RotateEnumValues
            = new TheoryData<RotateMode>
        {
            RotateMode.None,
            RotateMode.Rotate90,
            RotateMode.Rotate180,
            RotateMode.Rotate270
        };
        
        [Theory]
        [WithTestPatternImages(nameof(RotateAngles), 100, 50, DefaultPixelType)]
        [WithTestPatternImages(nameof(RotateAngles), 50, 100, DefaultPixelType)]
        public void Rotate_WithAngle<TPixel>(TestImageProvider<TPixel> provider, float value)
            where TPixel : struct, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage())
            {
                image.Mutate(x => x.Rotate(value));
                image.DebugSave(provider, value);
            }
        }
        
        [Theory]
        [WithTestPatternImages(nameof(RotateEnumValues), 100, 50, DefaultPixelType)]
        [WithTestPatternImages(nameof(RotateEnumValues), 50, 100, DefaultPixelType)]
        public void Rotate_WithRotateTypeEnum<TPixel>(TestImageProvider<TPixel> provider, RotateMode value)
            where TPixel : struct, IPixel<TPixel>
        {
            using (Image<TPixel> image = provider.GetImage())
            {
                image.Mutate(x => x.Rotate(value));
                image.DebugSave(provider, value);
            }
        }
    }
}