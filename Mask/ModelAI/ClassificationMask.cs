using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Keras.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Mask.ModelAI
{
    public class ClassificationMask: IClassificationMask
    {
        public BaseModel _modelMask = BaseModel.LoadModel(Environment.CurrentDirectory + "\\ModelAI\\modelMask.h5");
        public  bool Run(Image<Bgr, byte> image)
        {

            //CvInvoke.Resize(image, image, new Size(224, 224), 0, 0, Inter.Linear);
            //var h_hat=_modelMask.Predict(image.Bytes);
           _modelMask.Summary();
            //Console.WriteLine(h_hat);
            return false;
        }

    }
}
