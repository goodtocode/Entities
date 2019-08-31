﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GoodToCode.Entity.WebClient
{
    public static partial class ServicesExtensions
    {
        public static IServiceCollection AddFileIo(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            return services.AddSingleton<IFileService, FileService>();
        }
    }

    public interface IFileService
    {
        Task<bool> Save(string path, string file, byte[] content);
    }

    public class FileService : IFileService
    {
        private IHostingEnvironment _hostingEnvironment { get; set; }

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> Save(string path, string file, byte[] content)
        {
            Directory.CreateDirectory(Path.Combine(path));
            File.AppendAllText(Path.Combine(path, file), content.ToString());
            return await Task.Run(() => true);
        }
    }
}