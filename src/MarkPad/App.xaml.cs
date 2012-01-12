﻿using System.IO;
using System.Linq;
using MarkPad.Framework.Events;

namespace MarkPad
{
    public partial class App
    {
        private readonly AppBootstrapper bootstrapper;

        public App()
        {
            InitializeComponent();

            bootstrapper = new AppBootstrapper();
        }

        public void HandleArguments(string[] args)
        {
            if (args.Length == 1)
            {
                var filePath = args[0];
                if (File.Exists(filePath) && Constants.DefaultExtensions.Contains(Path.GetExtension(filePath).ToLower()))
                    bootstrapper.GetEventAggregator().Publish(new FileOpenEvent(filePath));
            }
        }
    }
}
