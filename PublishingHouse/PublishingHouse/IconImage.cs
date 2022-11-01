﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для загрузки иконок
    /// </summary>
    public static class IconImage
    {
        /// <summary>
        /// Метод для загрузки иконок главного меню
        /// </summary>
        /// <param name="firstItem">Вкладка заказов</param>
        /// <param name="secondItem">Вкладка сотрудников</param>
        public static void LoadIconsOfMainTab(ToolStripMenuItem firstItem, ToolStripMenuItem secondItem, ToolStripMenuItem thirdItem) 
        {
            try
            {
                //firstItem.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory() + "/images" + "/orderIcon.png"));
                firstItem.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory() + "/images/employee.ico"));
                secondItem.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory() + "/images/paper.ico"));
                thirdItem.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory() + "/images/printingHouse.ico"));
            }
            catch 
            {
                throw new Exception();
            }
        }

        public static void LoadIconsOfMaterialTab(ToolStripMenuItem item)
        {
            try
            {
                item.Image = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory() + "/images/back.ico"));
            }
            catch 
            {
                throw new Exception();
            }
        }
    }
}
