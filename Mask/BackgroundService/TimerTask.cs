using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Mask.ModelAI;
using Mask.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mask.BackgroundService
{
    public class TimerTask : IHostedService, IDisposable
    {
        private  Timer _timer;
        private readonly IFaceDecection _faceDetection;


        public TimerTask(IFaceDecection faceDetection)
        {
            _faceDetection = faceDetection;
        }



        public Task StartAsync(CancellationToken stoppingToken)
        {

            VideoCapture capture = new VideoCapture(0);
            var frame = new Mat();

            _timer = new Timer(async (o) =>
            {
                capture.Read(frame);
                if (!frame.IsEmpty)
                {
                    await _faceDetection.SendFrame(frame);
                }
                else
                {
                    capture.Read(frame);
                    Console.WriteLine("empty");
                }

            },
                 null,
                 TimeSpan.Zero,
                 TimeSpan.FromSeconds(0.1));


            return Task.CompletedTask;
        }


        public Task StopAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

