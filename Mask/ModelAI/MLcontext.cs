using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Mask.DataModel;
using Microsoft.ML;

namespace Mask.ModelAI
{
    public class MLcontext
    {
        public string modelPath = Environment.CurrentDirectory + "\\ModelAI\\my_model.onnx";
        public string[] outputColumnNames = new[] { "dense_3" };
        public string[] inputColumnNames = new[] { "sequential_1_input" };
        MLContext mlContext = new MLContext();
        public void Predict(Image<Bgr, byte> image)
        {
            var imageCopy = new Image<Bgr, byte>(224, 224);

            CvInvoke.Resize(image, imageCopy, new Size(224, 224), 0, 0, Inter.Linear);

            var pipeline = mlContext.Transforms.ApplyOnnxModel(outputColumnNames, inputColumnNames, modelPath);
            var emptydv = mlContext.Data.LoadFromEnumerable(new ImageInputData[] {  });
            var onnxpredictionpipeline = pipeline.Fit(emptydv);
            //var onnxpredictionengine = mlContext.Model.CreatePredictionEngine<ImageInputData, OutputMask>(onnxpredictionpipeline);
            //var testinput = new ImageInputData { Data = imageCopy.Bytes };
            //var p = onnxpredictionengine.Predict(testinput);
            //Console.WriteLine(p.Data[0]);
        }
    }
}
