﻿using System;
using System.Drawing;
namespace MyGame
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
    abstract class BaseObject:ICollision
    {
        public delegate void Message();
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public int X=>Pos.X;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw(); // Объект можно нарисовать

        public virtual void Update() // Объект можно обновить
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }

        //при столкновении объектов присваиваются координаты намного меньше границ экрана,
        //заставляя генерировать объект новые параметры (стартовые)
        public virtual void Update(bool x)
        {
            if (x) { Pos.X = -1; Update(); }
        }

        //Так как переданный объект тоже должен будет реализовывать интерфейс ICollision, мы
        // можем использовать его свойство Rect и метод IntersectsWith для обнаружения пересечения с
        // нашим объектом (а можно наоборот)
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}