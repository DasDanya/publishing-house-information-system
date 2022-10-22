using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PublishingHouse
{

    /// <summary>
    /// Класс для работы с несколькими формами
    /// </summary>
   public static class Transition
    {
        /// <summary>
        /// Метод перехода между формами
        /// </summary>
        public static void TransitionByForms(Form actualForm, Form openingForm) 
        {
            openingForm.Show();
            //openingForm.FormClosed += (sender, e) => actualForm.Show(); // при закрытии формы со сотрудниками откроется главное меню
            actualForm.Hide();
        }
    }
}
