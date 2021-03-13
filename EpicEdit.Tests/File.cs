#region GPL statement
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

using EpicEdit.Rom;
using System;
using System.IO;
using System.Reflection;

namespace EpicEdit.Tests
{
    /// <summary>
    /// File manipulation class used for unit testing.
    /// </summary>
    internal static class File
    {
        private static string InputPath
        {
            get
            {
                var location = Assembly.GetExecutingAssembly().Location;
                return Directory.GetParent(location).Parent.Parent.FullName +
                    Path.DirectorySeparatorChar +  "files" + Path.DirectorySeparatorChar;
            }
        }

        private static string OutputPath
        {
            get
            {
                var location = Assembly.GetExecutingAssembly().Location;
                return Directory.GetParent(location).FullName +
                    Path.DirectorySeparatorChar + "files" + Path.DirectorySeparatorChar;
            }
        }

        private static string GetRomFileName(Region region)
        {
            switch (region)
            {
                case Region.Jap:
                    return "Super Mario Kart (Japan).sfc";

                default:
                case Region.US:
                    return "Super Mario Kart (USA).sfc";

                case Region.Euro:
                    return "Super Mario Kart (Europe).sfc";
            }
        }

        public static Game GetGame(Region region)
        {
            return GetGame(GetRomFileName(region));
        }

        public static Game GetGame(string fileName)
        {
            return new Game(GetInputPath(fileName));
        }

        public static byte[] ReadRom(Region region)
        {
            return ReadFile(GetRomFileName(region));
        }

        public static byte[] ReadFile(string fileName)
        {
            return System.IO.File.ReadAllBytes(GetInputPath(fileName));
        }

        private static string GetInputPath(string fileName)
        {
            return InputPath + fileName;
        }

        public static string GetOutputPath(string fileName)
        {
            var outputPath = OutputPath;
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            return outputPath + fileName;
        }

        public static byte[] ReadBlock(byte[] buffer, int offset, int length)
        {
            var bytes = new byte[length];
            Buffer.BlockCopy(buffer, offset, bytes, 0, length);
            return bytes;
        }
    }
}
