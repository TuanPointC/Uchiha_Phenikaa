using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
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
        private readonly ILogger<TimerTask> _logger;
        private Timer _timer;
        private IHubContext<VideoHub> _hubContext;
        private CascadeClassifier _haarcascade = new CascadeClassifier(Environment.CurrentDirectory + "\\SignalR\\haarcascade_frontalface_default.xml");

        public TimerTask(ILogger<TimerTask> logger, IHubContext<VideoHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }
        private async Task SendMessage(Mat frame)
        {

            //await Task.Delay(1000);
            CvInvoke.Resize(frame, frame, new Size(480, 360), 0, 0, Inter.Linear);
            var frameColor = frame.ToImage<Bgr, byte>();
            //var gray = frameColor.Convert<Gray, byte>();
            var faces = _haarcascade.DetectMultiScale(frame, 1.1, 10, Size.Empty);
            foreach (var face in faces)
            {
                frameColor.Draw(face, new Bgr(Color.BurlyWood), 3);
            }

            var buffer_img = CvInvoke.Imencode(".jpg", frameColor);
            var base64 = Convert.ToBase64String(buffer_img);


            await _hubContext.Clients.All.SendAsync("ReceiveMessage", base64);

        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            VideoCapture capture = new VideoCapture(0);
            var frame=new Mat();
            
               
            _timer = new Timer(async (o) =>
            {
                capture.Read(frame);
                await SendMessage (frame);
            },
                 null,
                 TimeSpan.Zero,
                 TimeSpan.FromSeconds(0.1));


            return Task.CompletedTask;
        }


        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

