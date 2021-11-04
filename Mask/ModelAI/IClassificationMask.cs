using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mask.ModelAI
{
    public interface IClassificationMask
    {
        public bool Run(Image<Emgu.CV.Structure.Bgr, byte> image);
    }
}
