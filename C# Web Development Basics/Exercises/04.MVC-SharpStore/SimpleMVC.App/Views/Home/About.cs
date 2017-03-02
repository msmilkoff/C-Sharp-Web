﻿namespace SimpleMVC.App.Views.Home
{
    using System.IO;
    using MVC.Interfaces;

    public class About : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/about.html");
        }
    }
}
