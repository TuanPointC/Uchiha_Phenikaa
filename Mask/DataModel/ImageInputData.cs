using Microsoft.ML.Data;

namespace Mask.DataModel
{
    public class ImageInputData
    {
        [VectorType(224 * 224 * 3)]
        [ColumnName("sequential_1_input")]
        public byte[] Data { get; set; }
    }
}
