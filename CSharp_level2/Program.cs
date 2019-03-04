// Чернышов Виктор. Урок 4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyGame
{
    class Program
    {
        static void Task1()
        {
            /* Добавить в программу коллекцию астероидов. Как только она заканчивается (все астероиды
             * сбиты), формируется новая коллекция, в которой на один астероид больше. */

            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }

        static void Task2()
        {
            /* 2. Дана коллекция List<T> . Требуется подсчитать, сколько раз каждый элемент встречается в
             * данной коллекции:
             * a. для целых чисел;
             * b. * для обобщенной коллекции;
             * c. ** используя Linq. */
            List<int> collection = new List<int> { 2, 5, -3, 7, 5, 1};

            foreach (int val in collection.Distinct())
                Console.WriteLine($"Значение {val} встречается: {collection.Where(x => x == val).Count()} раз");

            /* int[] mas = collection.ToArray();
            foreach (int i in mas)
            {
                int count = 0;
                while (collection.Remove(i)) count++;
                if (count > 0)
                    Console.WriteLine("Значение " + i + " повторяется " + count + " раз");
            }*/

            while (collection.Count>0)
            {
                int x = collection[0];
                int count = 0;
                while (collection.Remove(x)) count++;
                Console.WriteLine("Значение " + x + " повторяется " + count + " раз");
            }
        }

        static void Main(string[] args)
        {
            //Task1();
            Task2();

            Console.ReadKey();
        }
    }
}