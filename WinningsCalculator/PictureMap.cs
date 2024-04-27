using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinningsCalculator
{
    public class PictureMap
    {
        public PictureBox PictureBox { get; set; }
        public String ImageId { get; set; }
        public PictureMap(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
        }
        public PictureMap()
        {
        }
        public bool equalsTo(PictureMap pictureMap)
        {
            return (this.ImageId == pictureMap.ImageId);
        }
    }
}
