// Чернышов Виктор. Урок 3

using System;
using System.Windows.Forms;

namespace MyGame
{
    class Program
    {
        static void Task1()
        {
            /* 1. Добавить космический корабль, как описано в уроке.
             * 2. Доработать игру «Астероиды»:
             * a. Добавить ведение журнала в консоль с помощью делегатов;
             * b. * добавить это и в файл.
             * 3. Разработать аптечки, которые добавляют энергию.
             * 4. Добавить подсчет очков за сбитые астероиды. */

            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }

        static void Main(string[] args)
        {
            Task1();
        }
    }
}