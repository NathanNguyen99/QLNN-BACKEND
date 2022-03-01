
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Commons
{
    public struct TFaceRecord
    {
        public byte[] Template; //Face Template;
        //public FSDK.TFacePosition FacePosition;
        //public FSDK.TPoint[] FacialFeatures; //Facial Features;

        //public FSDK.CImage image;
        //public FSDK.CImage faceImage;
    }
    public class floatReverseComparer : IComparer<float>
    {
        public int Compare(float x, float y)
        {
            return y.CompareTo(x);
        }
    }
    public class FaceClass
    {
        public static float FaceDetectionThreshold = 3;
        public static float FARValue = 100;
        public static double Compare(TFaceRecord SearchFace, TFaceRecord sourceFace)
        {
            //float Threshold = 0.0f;
            //FSDK.GetMatchingThresholdAtFAR(FARValue / 100, ref Threshold);


            //float Similarity = 0.0f;
            //FSDK.MatchFaces(ref SearchFace.Template, ref sourceFace.Template, ref Similarity);
            //if (Similarity >= Threshold)
            //{
            //    return Similarity;
            //}
            return 0;
        }

        public static void InitializeFaceSDK()
        {
            //if (FSDK.FSDKE_OK != FSDK.ActivateLibrary("S2saNAbHSojeba9lCGqLXUD7Bn6dDI6J3hsU9QcsP+rTl+fNegPvMtkWND7sMoA5hq1a59wmF5o7xEgPcNmuo9R+3dOJ5eLd291O7Nu0Y3Yr6Evdzd8b7jyEETpxRisnw6zBUAZWxlS2VGkeaFHUk9sKVubHuv04rmRXTWwj54U="))
            //{
            //    NLogAction.instance.logger.Error("fail License Face SDK");
            //}

            //if (FSDK.InitializeLibrary() != FSDK.FSDKE_OK)
            //    NLogAction.instance.logger.Error("Error initializing FaceSDK!");
        }
    }
}
