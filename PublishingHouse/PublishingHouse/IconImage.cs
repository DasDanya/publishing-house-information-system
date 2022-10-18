﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PublishingHouse
{
    public static class IconImage
    {
        public static void LoadIconsOfMainTab(ToolStripMenuItem firstItem, ToolStripMenuItem secondItem) 
        {
            firstItem.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory() + "/images" + "/orderIcon.png"));
            secondItem.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory() + "/images" + "/employees.jpg"));

        }
    }
}
