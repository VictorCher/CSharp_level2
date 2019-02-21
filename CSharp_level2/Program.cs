﻿// Чернышов Виктор. Урок 2

using System;
using System.Windows.Forms;

namespace MyGame
{
    class Program
    {
        static void Task1()
        {
            /* Построить три класса (базовый и 2 потомка), описывающих работников с почасовой
             * оплатой (один из потомков) и фиксированной оплатой (второй потомок):
             * a. Описать в базовом классе абстрактный метод для расчета среднемесячной
             * заработной платы. Для «повременщиков» формула для расчета такова:
             * «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»; для работников с
             * фиксированной оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»;
             * b. Создать на базе абстрактного класса массив сотрудников и заполнить его;
             * c. * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort();
             * d. * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода
             * данных с использованием foreach. */

            BaseSalary[] worker = new BaseSalary[2]; 
            worker[0] = new HourlySalary("Вася", 20);
            worker[1] = new FixedSalary("Петя", 3000);
            MessageBox.Show(worker[0].ToString() + worker[1].ToString());
        }

        static void Task2()
        {
            /* 2. Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках.
             * 3. Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана.
             * 4. Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) 
             * больше 1000 или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException(). */

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
            //Task1();
            Task2();
        }
    }
}