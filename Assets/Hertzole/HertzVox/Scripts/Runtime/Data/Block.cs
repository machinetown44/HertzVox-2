﻿using System;
using Unity.Mathematics;

namespace Hertzole.HertzVox
{
    public struct Block
    {
        public ushort id;

        [NonSerialized]
        internal int topTexture;
        [NonSerialized]
        internal int bottomTexture;
        [NonSerialized]
        internal int northTexture;
        [NonSerialized]
        internal int southTexture;
        [NonSerialized]
        internal int eastTexture;
        [NonSerialized]
        internal int westTexture;
        [NonSerialized]
        internal float4 topColor;
        [NonSerialized]
        internal float4 bottomColor;
        [NonSerialized]
        internal float4 northColor;
        [NonSerialized]
        internal float4 southColor;
        [NonSerialized]
        internal float4 eastColor;
        [NonSerialized]
        internal float4 westColor;

        [NonSerialized]
        public bool solid;
        [NonSerialized]
        public bool transparent;

        public Block(ushort id)
        {
            this.id = id;

            topTexture = 0;
            bottomTexture = 0;
            northTexture = 0;
            southTexture = 0;
            eastTexture = 0;
            westTexture = 0;
            topColor = new float4(1, 1, 1, 1);
            bottomColor = topColor;
            northColor = topColor;
            southColor = topColor;
            eastColor = topColor;
            westColor = topColor;
            solid = true;
            transparent = false;
        }

        public Block(ushort id, int topTexture, int bottomTexture, int northTexture, int southTexture, int eastTexture, int westTexture) : this(id)
        {
            this.topTexture = topTexture;
            this.bottomTexture = bottomTexture;
            this.northTexture = northTexture;
            this.southTexture = southTexture;
            this.eastTexture = eastTexture;
            this.westTexture = westTexture;
        }

        public Block(ushort id, BaseConfig config)
        {
            this.id = id;

            solid = config.Solid;
            transparent = config.Transparent;

            topTexture = 0;
            bottomTexture = 0;
            northTexture = 0;
            southTexture = 0;
            eastTexture = 0;
            westTexture = 0;
            topColor = new float4(1, 1, 1, 1);
            bottomColor = topColor;
            northColor = topColor;
            southColor = topColor;
            eastColor = topColor;
            westColor = topColor;
        }

        public Block(ushort id, CubeConfig cubeConfig) : this(id, (BaseConfig)cubeConfig)
        {
            topTexture = cubeConfig.TopTextureId;
            bottomTexture = cubeConfig.BottomTextureId;
            northTexture = cubeConfig.NorthTextureId;
            southTexture = cubeConfig.SouthTextureId;
            westTexture = cubeConfig.WestTextureId;
            eastTexture = cubeConfig.EastTextureId;

            topColor = new float4(cubeConfig.TopColor.r, cubeConfig.TopColor.g, cubeConfig.TopColor.b, cubeConfig.TopColor.a);
            bottomColor = new float4(cubeConfig.BottomColor.r, cubeConfig.BottomColor.g, cubeConfig.BottomColor.b, cubeConfig.BottomColor.a);
            northColor = new float4(cubeConfig.NorthColor.r, cubeConfig.NorthColor.g, cubeConfig.NorthColor.b, cubeConfig.NorthColor.a);
            southColor = new float4(cubeConfig.SouthColor.r, cubeConfig.SouthColor.g, cubeConfig.SouthColor.b, cubeConfig.SouthColor.a);
            westColor = new float4(cubeConfig.WestColor.r, cubeConfig.WestColor.g, cubeConfig.WestColor.b, cubeConfig.WestColor.a);
            eastColor = new float4(cubeConfig.EastColor.r, cubeConfig.EastColor.g, cubeConfig.EastColor.b, cubeConfig.EastColor.a);
        }

        public override bool Equals(object obj)
        {
            return obj is Block block ? block.id == id : false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(Block left, Block right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Block left, Block right)
        {
            return !(left == right);
        }
    }
}
