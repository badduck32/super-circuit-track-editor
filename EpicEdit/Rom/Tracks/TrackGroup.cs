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

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using EpicEdit.Rom.Settings;

namespace EpicEdit.Rom.Tracks
{
    /// <summary>
    /// A group of tracks.
    /// </summary>
    internal class TrackGroup : IEnumerable<Track>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SuffixedTextItem SuffixedNameItem { get; private set; }

        public string Name
        {
            get { return this.SuffixedNameItem.Value; }
        }

        private Track[] tracks;

        public bool Modified
        {
            get
            {
                foreach (Track track in this.tracks)
                {
                    if (track.Modified)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public TrackGroup(SuffixedTextItem nameItem, Track[] tracks)
        {
            this.SuffixedNameItem = nameItem;
            this.SuffixedNameItem.PropertyChanged += this.SuffixedNameItem_PropertyChanged;
            this.tracks = tracks;
        }

        private void SuffixedNameItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs("SuffixedNameItem"));
            }
        }

        public void ResetModifiedState()
        {
            foreach (Track track in this.tracks)
            {
                track.Modified = false;
            }
        }

        public IEnumerator<Track> GetEnumerator()
        {
            foreach (Track track in this.tracks)
            {
                yield return track;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.tracks.GetEnumerator();
        }

        public int Count
        {
            get { return this.tracks.Length; }
        }

        public Track this[int index]
        {
            get { return this.tracks[index]; }
            set { this.tracks[index] = value; }
        }
    }
}
