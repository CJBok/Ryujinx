﻿using OpenTK.Graphics.OpenGL;
using Ryujinx.Graphics.GAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ryujinx.Graphics.OpenGL
{
    class TextureBase
    {
        public int Handle { get; protected set; }

        protected TextureCreateInfo Info { get; }

        public int Width => Info.Width;
        public int Height => Info.Height;

        public Target Target => Info.Target;
        public Format Format => Info.Format;

        public TextureBase(TextureCreateInfo info)
        {
            Info = info;

            Handle = GL.GenTexture();
        }

        public void Bind(int unit)
        {
            Bind(Target.Convert(), unit);
        }

        protected void Bind(TextureTarget target, int unit)
        {
            GL.ActiveTexture(TextureUnit.Texture0 + unit);
            GL.BindTexture(target, Handle);
        }
    }
}
