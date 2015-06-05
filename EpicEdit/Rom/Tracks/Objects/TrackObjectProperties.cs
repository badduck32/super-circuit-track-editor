﻿#region GPL statement
/*Epic Edit is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 3 of the License.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.*/
#endregion

using System;

namespace EpicEdit.Rom.Tracks.Objects
{
    internal class TrackObjectProperties
    {
        public ObjectType Tileset { get; set; }
        public ObjectType Interaction { get; set; }
        public ObjectType Routine { get; set; }
        public ByteArray PaletteIndexes { get; private set; }

        public Palette Palette
        {
            get { return this.palettes[this.PaletteIndexes[0] + Palettes.SpritePaletteStart]; }
        }

        /// <summary>
        /// If true, the object sprites will loop through 4 color palettes at 60 FPS
        /// (like the Rainbow Road Thwomps do).
        /// </summary>
        public bool Flashing { get; set; }

        public ObjectLoading Loading
        {
            get
            {
                switch (this.Routine)
                {
                    case ObjectType.Pipe:
                    case ObjectType.Thwomp:
                    case ObjectType.Mole:
                    case ObjectType.Plant:
                    case ObjectType.RThwomp:
                        return ObjectLoading.Regular;

                    case ObjectType.Fish:
                        return ObjectLoading.Fish;

                    case ObjectType.Pillar:
                        return ObjectLoading.Pillar;

                    default:
                        return ObjectLoading.None;
                }
            }
        }

        private readonly Palettes palettes;

        public TrackObjectProperties(byte[] data, Palettes palettes)
        {
            this.Tileset = (ObjectType)data[0];
            this.Interaction = (ObjectType)data[1];
            this.Routine = (ObjectType)data[2];
            this.palettes = palettes;
            this.PaletteIndexes = new ByteArray(new [] { data[3], data[4], data[5], data[6] });
            this.Flashing = data[7] != 0;
        }
    }

    internal class ByteArray
    {
        private readonly byte[] data;

        public ByteArray(byte[] data)
        {
            this.data = data;
        }

        public byte this[int index]
        {
            get { return this.data[index]; }
            set { this.data[index] = value; }
        }

        public byte[] GetBytes()
        {
            byte[] data = new byte[this.data.Length];
            Buffer.BlockCopy(this.data, 0, data, 0, data.Length);
            return data;
        }
    }
}
