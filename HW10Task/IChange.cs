using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW10Task
{
    internal interface IChange<T> where T : Account
    {
        /// <summary>
        /// Изменение данных аккаунта
        /// </summary>
        /// <param name="newValue">новое значение</param>
        /// <param name="selectedAcc">выбранный для изменения аккаунт</param>
        /// <param name="trigger"></param>
        /// <returns></returns>
        T Changing(string newValue, T selectedAcc, int trigger);
    }
}
