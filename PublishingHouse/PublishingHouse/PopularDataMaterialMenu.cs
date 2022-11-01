﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{
    public partial class PopularDataMaterialMenu : Form
    {
        public PopularDataMaterialMenu()
        {
            InitializeComponent();
        }

        
        private void PopularDataMaterialMenu_Load(object sender, EventArgs e)
        {
            //Загружаем иконки для вкладок
            IconImage.LoadIconsOfMaterialTab(backTab);

            // Списки лейблов
            List<Label> popularType = new List<Label>{ firstTypeLabel, secondTypeLabel, thirdTypeLabel };
            List<Label> popularColor = new List<Label> { firstColorLabel, secondColorLabel, thirdColorLabel };
            List<Label> popularSize = new List<Label> { firstSizeLabel, secondSizeLabel, thirdSizeLabel };
            
            // Выводим популярные данные
            PopularData.GetPopularData(popularType, Material.PopularDataAboutMaterial("Тип"));
            PopularData.GetPopularData(popularColor, Material.PopularDataAboutMaterial("Цвет"));
            PopularData.GetPopularData(popularSize, Material.PopularDataAboutMaterial("Размер"));
        }

        private void PopularDataMaterialMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void backTab_Click(object sender, EventArgs e)
        {
            MaterialMenu materialMenu = new MaterialMenu();
            Transition.TransitionByForms(this, materialMenu);
        }
    }
}