using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Mask.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Mask.ModelAI
{
    public class FaceDetection : IFaceDecection
    {
        private IHubContext<VideoHub> _hubContext;
        private IClassificationMask _classificationMask;
        private CascadeClassifier _haarcascade = new CascadeClassifier(Environment.CurrentDirectory + "\\ModelAI\\haarcascade_frontalface_default.xml");
        
        public FaceDetection(IHubContext<VideoHub> hubContext, IClassificationMask classificationMask)
        {
            _hubContext = hubContext;
            _classificationMask = classificationMask;
        }
        public async Task SendFrame(Mat frame)
        {

            CvInvoke.Resize(frame, frame, new Size(480, 360), 0, 0, Inter.Linear);
            var frameColor = frame.ToImage<Bgr, byte>();
            var frameColorCopy = frameColor.Copy();
            var faces = _haarcascade.DetectMultiScale(frameColor, 1.1, 10, Size.Empty);
            foreach (var face in faces)
            {

                frameColorCopy.ROI = face;
                await Task.Delay(100);
                if (_classificationMask.Run(frameColorCopy))
                {
                    frameColor.Draw(face, new Bgr(Color.Green), 2);
                    CvInvoke.PutText(frameColor, "With Mask", new Point(face.X, face.Y - 5), FontFace.HersheySimplex, 0.5, new Bgr(Color.Green).MCvScalar, 1);
                }
                else
                {
                    frameColor.Draw(face, new Bgr(Color.Red), 2);
                    CvInvoke.PutText(frameColor, "Without Mask", new Point(face.X, face.Y - 5), FontFace.HersheySimplex, 0.5, new Bgr(Color.Red).MCvScalar, 1);
                }
            }

            var buffer_img = CvInvoke.Imencode(".jpg", frameColor);
            var base64 = Convert.ToBase64String(buffer_img);


            await _hubContext.Clients.All.SendAsync("ReceiveFrame", base64);

        }
    }
}
