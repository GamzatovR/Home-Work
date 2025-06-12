using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Informatika
{
    public class FileDownloader
    {
        public async Task DownloadAndUnpackAsync(IProgress<int> progress, CancellationToken cancellationToken = default)
        {
            const int totalSteps = 10;

            for (int i = 1; i <= totalSteps; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(500, cancellationToken);
                progress?.Report(i * 10);
            }
        }
    }

    internal class DZ_Async4
    {
        public async Task RunAsync()
        {
            var downloader = new FileDownloader();

            var progress = new Progress<int>(percent =>
            {
                Console.WriteLine($"Прогресс: {percent}%");
            });
            try
            {
                await downloader.DownloadAndUnpackAsync(progress);
                Console.WriteLine("Операция завершена!");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Операция отменена.");
            }
        }
    }
}
