﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Api {
    public class Program {
        public static void Main(string[] args) {

            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            if (isService) {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                Directory.SetCurrentDirectory(pathToContentRoot);
            }

            var builder = CreateWebHostBuilder(
                args.Where(arg => arg != "--console").ToArray());

            var host = builder.Build();

            //if (isService) {
                // To run the app without the CustomWebHostService change the
                // next line to host.RunAsService();
               // host.RunAsService();
            //} else {
                host.Run();
            //}
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) => {
                })
                .ConfigureAppConfiguration((context, config) => {
                })
                .UseStartup<Startup>();
    }

}