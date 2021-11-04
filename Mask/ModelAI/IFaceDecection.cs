using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mask.ModelAI
{
    public interface IFaceDecection
    {
        public  Task SendFrame(Mat frame);
    }
}
