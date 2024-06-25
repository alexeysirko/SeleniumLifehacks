using OpenCvSharp;

namespace Unit8Practice.OpenCV
{
    internal class OpenCVTest
    {
        private const string ImagesFolder = "OpenCV/";
        private const string InputFileName = "example.jpg";
        private const string InputFilePath = ImagesFolder + InputFileName;

        public static void OpenCVLogic()
        {
            string outputFileName = $"{Path.GetFileNameWithoutExtension(InputFileName)}-gray.jpg";
            string outputFilePath = ImagesFolder + outputFileName;

            MakePhotoGray(InputFilePath, outputFilePath);
            ShowImage(InputFilePath);
            ShowImage(outputFilePath);
            ShowEdges(InputFilePath);
            MergeImages(outputFilePath, ImagesFolder + "another.png");
            ShowDifference(InputFilePath, ImagesFolder + "exampleDefect.jpg");
            PrintDifferencePercent(InputFilePath, ImagesFolder + "exampleDefect.jpg");
        }



        private static void MakePhotoGray(string inputFilePath, string outputFilePath)
        {
            using (var image = new Mat(inputFilePath))
                using (var gray = image.CvtColor(ColorConversionCodes.BGR2GRAY))
                    gray.SaveImage(outputFilePath);
        }

        private static void ShowImage(string inputFilePath)
        {
            using (var image = new Mat(inputFilePath))
                Cv2.ImShow("Image", image);
                Cv2.WaitKey(0);
                Cv2.DestroyAllWindows();
        } 
        
        private static void ShowEdges(string inputFilePath)
        {
            using var image = new Mat(inputFilePath);
            using Mat edges = new Mat();    
            Cv2.Canny(image, edges, 100, 200);
            Cv2.ImShow("Edges", edges);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        private static void MergeImages(string inputFilePath, string outputFilePath)
        {
            using Mat img1 = Cv2.ImRead(inputFilePath);
            using Mat img2 = Cv2.ImRead(outputFilePath);
            Cv2.Resize(img2, img2, new Size(img1.Width, img1.Height));
            Mat result = new Mat();
            Cv2.AddWeighted(img1, 0.5, img2, 0.5, 0, result);
            Cv2.ImShow("Blended Image", result);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        private static void ShowDifference(string inputFilePath, string outputFilePath)
        {
            using Mat img1 = Cv2.ImRead(inputFilePath);
            using Mat img2 = Cv2.ImRead(outputFilePath);

            using Mat diff = new Mat();
            Cv2.Absdiff(img1, img2, diff);                     

            Mat thresh = new Mat();
            // Changing пороговое значение разницы
            Cv2.Threshold(diff, thresh, 30, 255, ThresholdTypes.Binary);

            Cv2.ImShow("Difference", diff);            
            Cv2.WaitKey(0);
            Cv2.ImShow("Threshdiff", thresh);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        private static void PrintDifferencePercent(string inputFilePath, string outputFilePath)
        {
            using Mat img1 = Cv2.ImRead(inputFilePath);
            using Mat img2 = Cv2.ImRead(outputFilePath);

            int img2Channels = img2.Channels();
            Mat grayImg1 = img1.Channels() == 1 ? img1 : new Mat();
            Mat grayImg2 = img2.Channels() == 1 ? img2 : new Mat();

            // Convert images to grayscale
            if (img1.Channels() != 1)
                Cv2.CvtColor(img1, grayImg1, ColorConversionCodes.BGR2GRAY);
            if (img2.Channels() != 1)
                Cv2.CvtColor(img2, grayImg2, ColorConversionCodes.BGR2GRAY);

            using Mat diff = new Mat();
            Cv2.Absdiff(grayImg1, grayImg2, diff);

            // Now count non-zero pixels
            double nonZeroPixels = Cv2.CountNonZero(diff);
            double totalPixels = diff.Rows * diff.Cols;
            double percentageDifference = (nonZeroPixels / totalPixels) * 100;

            Console.WriteLine($"Percentage Difference: {percentageDifference}%");
        }
    }
}
