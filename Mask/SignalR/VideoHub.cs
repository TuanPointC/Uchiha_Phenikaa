using Emgu.CV;
using Emgu.CV.Structure;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Mask.SignalR
{
    public class VideoHub:Hub
    {
        private Mat frame = new Mat();
        private VideoCapture capture = new VideoCapture();
        private CascadeClassifier haarcascade = new CascadeClassifier(Environment.CurrentDirectory + "\\SignalR\\haarcascade_frontalface_default.xml");

        public Task SendMessage()
        { 

            capture.Read(frame);
            var frameColor = new Image<Bgr, byte>(frame.Bitmap);
            var gray = frameColor.Convert<Gray, byte>();
            var faces = haarcascade.DetectMultiScale(frame, 1.1, 10, Size.Empty); 
            foreach (var face in faces)
            {
                frameColor.Draw(face, new Bgr(Color.BurlyWood), 3); 
            }

            var buffer_img = CvInvoke.Imencode(".jpg", frameColor);
            var base64 = Convert.ToBase64String(buffer_img);


            return Clients.All.SendAsync("ReceiveMessage", base64);

        }
    }
}
