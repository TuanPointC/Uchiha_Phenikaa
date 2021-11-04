using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mask.DataModel
{
    public class OutputMask
    {
        [VectorType(2)]
        [ColumnName("dense_3")] 
        public float[] Data { get; set; }
    }
}
