using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TestDemo
{
    unsafe class ZPhotoEngineDll
    {

        #region PS基本变换模块
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Desaturate(byte* srcData, int width, int height, int stride, int ratio);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Threshold(byte* srcData, int width, int height, int stride, int threshold);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Saturation(byte* srcData, int width, int height, int stride, int saturation);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_NaturalSaturation(byte* srcData, int width, int height, int stride, int saturation);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Posterize(byte* srcData, int width, int height, int stride, int clusterNum);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_OverExposure(byte* srcData, int width, int height, int stride);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Lightness(byte* srcData, int width, int height, int stride, int lightness);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Invert(byte* srcData, int width, int height, int stride);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_HueAndSaturation(byte* srcData, int width, int height, int stride, int hue, int saturation);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_HistagramEqualize(byte* srcData, int width, int height, int stride);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Curve(byte* srcData, int width, int height, int stride, int DestChannel, int InputLeftLimit, int InputMiddle, int InputRightLimit, int OutputLeftLimit, int OutputRightLimit);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_NLinearBrightContrast(byte* srcData, int width, int height, int stride, int bright, int contrast, int threshold);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_LinearBrightContrast(byte* srcData, int width, int height, int stride, int brightness, int contrast, int threshold);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_AutoContrast(byte* srcData, int width, int height, int stride);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_AutoColorGradation(byte* srcData, int width, int height, int stride);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ChannelMixProcess(byte* srcData, int width, int height, int stride, int channel, int kr, int kg, int kb, int N, bool singleColor, bool constAdjust);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Fragment(byte* srcData, int width, int height, int stride);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_SurfaceBlur(byte* srcData, int width, int height, int stride, int threshold, int radius);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_RadialBlur(byte* srcData, int width, int height, int stride, int cenX, int cenY, int amount);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ZoomBlur(byte* srcData, int width, int height, int stride, int cenX, int cenY, int sampleRadius, int amount);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Relief(byte* srcData, int width, int height, int stride, int angle, int amount);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Mosaic(byte* srcData, int width, int height, int stride, int size);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ColorBalance(byte* srcData, int width, int height, int stride, int cyan, int magenta, int yellow, int channel, bool preserveLuminosity);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Diffusion(byte* srcData, int width, int height, int stride, int intensity);

        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_FastestGaussFilter(byte* srcData, int width, int height, int stride, float radius);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_HighPass(byte* srcData, int width, int height, int stride, float mRadius);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_USM(byte* srcData, int width, int height, int stride, float radius, int amount, int threshold);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_FindEdges(byte* srcData, int width, int height, int stride);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Shadow(byte* srcData, int width, int height, int stride, int intensity, int ratio);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Highlight(byte* srcData, int width, int height, int stride, int intensity, int ratio);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Exposure(byte* srcData, int width, int height, int stride, int intensity);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ColorTemperature(byte* srcData, int width, int height, int stride, int intensity);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_CalcWH(int[] inputImgSize, float angle, float scale, int transform_method, int[] outputImgSize, float[] H);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ImageTransformation(byte* pSrc, int[] srcImgSize, byte* pDst, int[] dstImgSize, float[] H, int Interpolation_method, int transform_method);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_MotionBlur(byte* srcData, int width, int height, int stride, int angle, int distance);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Mean(byte* srcData, int width, int height, int stride);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_FastMeanFilter(byte* srcData, int width, int height ,int stride,int radius);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ColorLevel(byte* srcData, int width, int height, int stride, int destChannel, byte inputLeftLimit, float inputMiddle, byte inputRightLimit, byte outputLeftLimit, byte outputRightLimit);

        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_Blackwhite(byte* srcData, int width, int height, int stride, int kRed, int kGreen, int kBlue, int kYellow, int kCyan, int kMagenta);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_GammaCorrect(byte* srcData, int width, int height, int stride, int intensity);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None, ExactSpelling = true)]
        private static extern void ZPHOTO_MedianFilter(byte* srcData, int width, int height, int stride, int radius);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None, ExactSpelling = true)]
        private static extern void ZPHOTO_MaxFilter(byte* srcData, int width, int height, int stride, int radius);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.None, ExactSpelling = true)]
        private static extern void ZPHOTO_MinFilter(byte* srcData, int width, int height, int stride,int radius);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_GlowingEdges(byte* srcData, int width, int height, int stride, int edgeSize, int edgeLightness, int edgeSmoothness);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_ImageWarpWave(byte* srcData, int width, int height, int stride, int intensity);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_HighlightShadowPrecise(byte* srcData,int width, int height, int stride, float highlight, float shadow);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int ZPHOTO_LUTFilter(byte* srcData, int width, int height, int stride, byte* Map, int ratio);

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region 颜色空间转换模块
       

        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_RGBToYCbCr(int R, int G, int B, ref int Y, ref int Cb, ref int Cr);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_YCbCrToRGB(int Y, int Cb, int Cr, ref int Red, ref int Green, ref int Blue);

        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_RGBToLab(int Red, int Green, int Blue, ref int L, ref int A, ref int B);
        [DllImport("ZPhotoEngine.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void ZPHOTO_LabToRGB(int L, int A, int B, ref int Red, ref int Green, ref int Blue);

        #endregion

        #region  API FOR C SHARP
        public Bitmap LUTFilter(Bitmap src, Bitmap map, int ratio)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            BitmapData mapData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_LUTFilter((byte*)srcData.Scan0, w, h, srcData.Stride, (byte*)mapData.Scan0, ratio);
            a.UnlockBits(srcData);
            map.UnlockBits(mapData);
            return a;
        }
        public Bitmap HighlightShadowPreciseAdjustProcess(Bitmap src, float highlight, float shadow)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_HighlightShadowPrecise((byte*)srcData.Scan0, w, h, srcData.Stride, highlight, shadow);
            a.UnlockBits(srcData);
            return a;
        }

        public Bitmap ImageWarpWaveProcess(Bitmap src, int intensity)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ImageWarpWave((byte*)srcData.Scan0, w, h, srcData.Stride, intensity);
            a.UnlockBits(srcData);
            return a;
        }

        public Bitmap GlowingEdgesProcess(Bitmap src, int edgeSize, int edgeLightness, int edgeSmoothness)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_GlowingEdges((byte*)srcData.Scan0, w, h, srcData.Stride, edgeSize, edgeLightness, edgeSmoothness);
            a.UnlockBits(srcData);
            return a;
        }

        public Bitmap MedianFilterProcess(Bitmap src, int size)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_MedianFilter((byte*)srcData.Scan0, w, h, srcData.Stride, size);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap MaxFilterProcess(Bitmap src, int size)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_MaxFilter((byte*)srcData.Scan0, w, h, srcData.Stride,size);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap MinFilterProcess(Bitmap src, int size)
        {
            Bitmap a = new Bitmap(src);
            int w = a.Width;
            int h = a.Height;
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_MinFilter((byte*)srcData.Scan0, w, h, srcData.Stride, size);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap GammaCorrectProcess(Bitmap src, int intensity)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_GammaCorrect((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity);
            dst.UnlockBits(srcData);
            return dst;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap ChannelMixProcess(Bitmap src, int channel, int kr, int kg, int kb, int N, bool singleColor, bool constAdjust)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ChannelMixProcess((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, channel, kr, kg, kb, N, singleColor, constAdjust);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap MeanProcess(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Mean((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap AutoColorGradationAdjust(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_AutoColorGradation((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap AutoContrastAdjust(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_AutoContrast((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap HistagramEqualize(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_HistagramEqualize((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap MotionBlur(Bitmap src, int angle, int distance)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_MotionBlur((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, angle, distance);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap TransformRotation(Bitmap src, float angle, int transform_method, int Interpolation_method)
        {

            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, angle, 1.0f, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;
            ZPHOTO_ImageTransformation((byte*)srcData.Scan0, srcImgSize, (byte*)dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

        public Bitmap TransformScale(Bitmap src, float scale, int transform_method, int Interpolation_method)
        {

            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, 0, scale, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;
            ZPHOTO_ImageTransformation((byte*)srcData.Scan0, srcImgSize, (byte*)dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

        public Bitmap TransformRotationScale(Bitmap src, float angle, float scale, int transform_method, int Interpolation_method)
        {

            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, angle, scale, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;
            ZPHOTO_ImageTransformation((byte*)srcData.Scan0, srcImgSize, (byte*)dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

        public Bitmap TransformAffine(Bitmap src, float[] H, int transform_method, int Interpolation_method)
        {

            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            //float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, 0, 1.0f, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;
            ZPHOTO_ImageTransformation((byte*)srcData.Scan0, srcImgSize, (byte*)dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }
        public Bitmap Threshold(Bitmap src, int threshold)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Threshold((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, threshold);
            dst.UnlockBits(srcData);
            return dst;
        }

        public Bitmap TransformMirror(Bitmap srcBitmap, int transform_method)
        {
            Bitmap src = new Bitmap(srcBitmap);
            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int[] srcImgSize = new int[3] { src.Width, src.Height, srcData.Stride };
            int[] dstImgSize = new int[3];
            float[] H = new float[6];

            ZPHOTO_CalcWH(srcImgSize, 0, 1.0f, transform_method, dstImgSize, H);

            Bitmap dst = new Bitmap(dstImgSize[0], dstImgSize[1]);
            BitmapData dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            dstImgSize[2] = dstData.Stride;

            int Interpolation_method = 0;
            ZPHOTO_ImageTransformation((byte*)srcData.Scan0, srcImgSize, (byte*)dstData.Scan0, dstImgSize, H, Interpolation_method, transform_method);

            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);

            return dst;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap Fragment(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Fragment((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap HueSaturationAdjust(Bitmap src, int hue, int saturation)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_HueAndSaturation((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, hue, saturation);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap ColorTemperatureProcess(Bitmap src, int intensity)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ColorTemperature((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap Posterize(Bitmap src, int clusterNum)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Posterize((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, clusterNum);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap Desaturate(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Desaturate((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, 100);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap OverExposure(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_OverExposure((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap ExposureAdjust(Bitmap src, int intensity)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Exposure((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap LightnessAdjustProcess(Bitmap src, int lightness)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Lightness((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, lightness);
            dst.UnlockBits(srcData);
            return dst;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Bitmap ShadowAdjust(Bitmap src, int intensity, int ratio)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Shadow((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity, ratio);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap HighlightAdjust(Bitmap src, int intensity, int ratio)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Highlight((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, intensity, ratio);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap Invert(Bitmap src)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Invert((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap SurfaceBlur(Bitmap src, int threshold, int radius)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_SurfaceBlur((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, threshold, radius);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap NLinearBrightContrastAdjust(Bitmap src, int bright, int contrast, int threshold)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_NLinearBrightContrast((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, bright, contrast, threshold);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap LinearBrightContrastAdjust(Bitmap src, int bright, int contrast, int threshold)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_LinearBrightContrast((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, bright, contrast, threshold);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap FindEdgesProcess(Bitmap src)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_FindEdges((byte*)srcData.Scan0, a.Width, a.Height, srcData.Stride);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap GaussFilterProcess(Bitmap src, float radius)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_FastestGaussFilter((byte*)srcData.Scan0, a.Width, a.Height, srcData.Stride, radius);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap MeanFilterProcess(Bitmap src, int radius)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_FastMeanFilter((byte*)srcData.Scan0, a.Width, a.Height, srcData.Stride, radius);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap HighPassProcess(Bitmap src, float radius)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_HighPass((byte*)srcData.Scan0, a.Width, a.Height, srcData.Stride, radius);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap USMProcess(Bitmap src, float radius, int amount, int threshold)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_USM((byte*)srcData.Scan0, a.Width, a.Height, srcData.Stride, radius, amount, threshold);
            a.UnlockBits(srcData);
            return a;
        }

        public Bitmap SaturationProcess(Bitmap src, int saturation)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Saturation((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, saturation);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap NaturalSaturationProcess(Bitmap src, int saturation)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_NaturalSaturation((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, saturation);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap ColorBalanceProcess(Bitmap src, int cyan, int magenta, int yellow, int channel, bool preserveLuminosity)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ColorBalance((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, cyan, magenta, yellow, channel, preserveLuminosity);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap Relief(Bitmap src, int angle, int amount)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Relief((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, angle, amount);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap DiffusionProcess(Bitmap src, int intensity)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Diffusion((byte*)srcData.Scan0, a.Width, a.Height, srcData.Stride, intensity);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap MosaicProcess(Bitmap src, int size)
        {
            Bitmap a = new Bitmap(src);
            BitmapData srcData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Mosaic((byte*)srcData.Scan0, a.Width, a.Height, srcData.Stride, size);
            a.UnlockBits(srcData);
            return a;
        }
        public Bitmap RadialBlurProcess(Bitmap src, int amount)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_RadialBlur((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, dst.Width / 2, dst.Height / 2, amount);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap ZoomBlurProcess(Bitmap src, int radius, int amount)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_ZoomBlur((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, dst.Width / 2, dst.Height / 2, radius, amount);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap ColorLevelProcess(Bitmap src, int DestChannel, int InputLeftLimit, float InputMiddle, int InputRightLimit, int OutputLeftLimit, int OutputRightLimit)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            //f_TCurveAdjust((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, DestChannel, InputLeftLimit, InputMiddle, InputRightLimit, OutputLeftLimit, OutputRightLimit);
            ZPHOTO_ColorLevel((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, DestChannel, (byte)InputLeftLimit, InputMiddle, (byte)InputRightLimit, (byte)OutputLeftLimit, (byte)OutputRightLimit);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap BlackwhiteProcess(Bitmap src, int kRed, int kGreen, int kBlue, int kYellow, int kCyan, int kMagenta)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_Blackwhite((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, kRed, kGreen, kBlue, kYellow, kCyan, kMagenta);
            dst.UnlockBits(srcData);
            return dst;
        }
        public Bitmap LUTFilterProcess(Bitmap src, Bitmap map, int ratio)
        {
            Bitmap dst = new Bitmap(src);
            BitmapData srcData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            BitmapData mapData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ZPHOTO_LUTFilter((byte*)srcData.Scan0, dst.Width, dst.Height, srcData.Stride, (byte*)mapData.Scan0, ratio);
            dst.UnlockBits(srcData);
            map.UnlockBits(mapData);
            return dst;
        }
        #endregion
    }
}
