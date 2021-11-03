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
    public class VideoHub : Hub
    {
        private Mat frame = new Mat();

        private CascadeClassifier haarcascade = new CascadeClassifier(Environment.CurrentDirectory + "\\SignalR\\haarcascade_frontalface_default.xml");

       
    }
}
