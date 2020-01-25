﻿using System;
using Unity.Collections;
using Unity.Mathematics;

namespace Hertzole.HertzVox
{
    public struct ChunkBlocks : IDisposable
    {
        public NativeArray<Block> blocks;

        public Block Get(int x, int y, int z)
        {
            return blocks[Helpers.GetIndex1DFrom3D(x, y, z, Chunk.CHUNK_SIZE)];
        }

        public Block Get(int3 position)
        {
            return Get(position.x, position.y, position.z);
        }

        public void Set(int x, int y, int z, Block block)
        {
            blocks[Helpers.GetIndex1DFrom3D(x, y, z, Chunk.CHUNK_SIZE)] = block;
        }

        public void Set(int3 position, Block block)
        {
            Set(position.x, position.y, position.z, block);
        }

        public void Dispose()
        {
            if (blocks.IsCreated)
            {
                blocks.Dispose();
            }
        }

        public NativeList<int2> Compress()
        {
            NativeList<int2> compressedBlocks = new NativeList<int2>(Allocator.Temp);

            int currentBlock = blocks[0].id;
            int blockCount = 1;
            for (int i = 1; i < blocks.Length; i++)
            {
                if (blocks[i].id == currentBlock)
                {
                    blockCount++;
                }
                else
                {
                    compressedBlocks.Add(new int2(currentBlock, blockCount));
                    currentBlock = blocks[i].id;
                    blockCount = 1;
                }
            }

            return compressedBlocks;
        }

        public void DecompressAndApply(NativeList<int2> list)
        {
            int index = 0;

            for (int i = 0; i < list.Length; i++)
            {
                Block block = BlockProvider.GetBlock((ushort)list[i].x);

                for (int j = 0; j < list[i].y; j++)
                {
                    blocks[index] = block;
                    index++;
                }
            }

            list.Dispose();
        }
    }
}