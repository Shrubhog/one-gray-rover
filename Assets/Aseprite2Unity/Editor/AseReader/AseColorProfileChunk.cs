﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aseprite2Unity.Editor
{
    public class AseColorProfileChunk : AseChunk
    {
        public override ChunkType ChunkType => ChunkType.ColorProfile;

        public ColorProfileType ColorProfileType { get; }
        public ColorProfileFlags ColorProfileFlags { get; }
        public uint GammaFixed { get; }

        public AseColorProfileChunk(AseFrame frame, AseReader reader)
            : base(frame)
        {
            ColorProfileType = (ColorProfileType)reader.ReadWORD();
            ColorProfileFlags = (ColorProfileFlags)reader.ReadWORD();
            GammaFixed = reader.ReadDWORD();

            // Next 8 bytes are reserved
            reader.ReadBYTEs(8);

            // fixit - what to do with color profile data?
            if (ColorProfileType == ColorProfileType.EmbeddedICC)
            {
                var length = (int)reader.ReadDWORD();
                reader.ReadBYTEs(length);
            }
        }

        public override void Visit(IAseVisitor visitor)
        {
            // fixit - nothing for now
        }
    }
}
