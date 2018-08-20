package ZPHOTO;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;

import android.content.res.AssetManager;
import android.graphics.Bitmap;
import android.util.Log;

public class PhotoEngine {
	static {
	      System.loadLibrary("photoengine");
	      Log.d("loadlibrary","load photoengine done!");
	  }
		private static String LOG_TAG = "ZPhotoEngine";
	    public static AssetManager assetMgr = null;
		
		public static void initLib(AssetManager am) {
			assetMgr = am;
		}
		
		public static InputStream open_file_binary(String filepath) {
			InputStream stream = null;

			try {
				if (filepath == null)
					return null;
				
				stream = assetMgr.open(filepath);
				if (stream == null)
					return null;
				
				int len = stream.available();
				if (!stream.markSupported())
					Log.d(LOG_TAG, "markSupported = flase");
				stream.mark(len);
			} catch (IOException e) {
				Log.e(LOG_TAG, e.getMessage());
				
				if (e instanceof FileNotFoundException) {
					try {
						stream = new FileInputStream(filepath);
						
						int len = stream.available();
						if (!stream.markSupported())
							Log.d(LOG_TAG, "markSupported = flase");
						stream.mark(len);
					} catch (Exception e2) {
						Log.e(LOG_TAG, e2.getMessage());
					}
				}
			}

			return stream;
		}
		
////////////////////////PHOTO ENGINE LIBRARY//////////////////////////
public native static int native_ZPHOTO_Saturation(Bitmap bitmap, int saturation);
public native static int native_ZPHOTO_Lightness(Bitmap bitmap, int lightness);
public native static int native_ZPHOTO_Invert(Bitmap bitmap);
public native static int native_ZPHOTO_HueAndSaturation(Bitmap bitmap, int hue, int saturation);
public native static int native_ZPHOTO_LinearBrightContrast(Bitmap bitmap, int bright, int contrast, int threshold);
public native static int native_ZPHOTO_NLinearBrightContrast(Bitmap bitmap, int bright, int contrast, int threshold);
public native static int  native_ZPHOTO_Blackwhite(Bitmap bitmap, int kRed, int kGreen, int kBlue, int kYellow, int kCyan, int kMagenta);
public native static int  native_ZPHOTO_Threshold(Bitmap bitmap, int threshold);
public native static int  native_ZPHOTO_ChannelMixProcess(Bitmap bitmap, int channel, int kr, int kg, int kb, int N, boolean singleColor, boolean constAdjust);
public native static int  native_ZPHOTO_FastestGaussFilter(Bitmap bitmap, float radius);
public native static int  native_ZPHOTO_HighPass(Bitmap bitmap, float radius);
public native static int  native_ZPHOTO_USM(Bitmap bitmap, float radius, int amount, int threshold);
public native static int  native_ZPHOTO_FindEdges(Bitmap bitmap);
public native static int  native_ZPHOTO_ImageBlendEffect(Bitmap basebitmap, Bitmap mixBitmap, int blendMode);
public native static int  native_ZPHOTO_ColorTemperature(Bitmap bitmap, int intensity);
public native static int native_ZPHOTO_HighlightShadowPrecise(Bitmap bitmap, float highlight, float shadow);
public native static int  native_ZPHOTO_Exposure(Bitmap bitmap, int intensity);
public native static int native_XIUSDK_GammaCorrect(Bitmap bitmap, int intensity);
public native static int native_ZPHOTO_CalcWH(int[] inputImgSize, float angle, float scale, int transform_method, int[] outputImgSize,float[] H);
public native static int native_ZPHOTO_ImageTransformation(Bitmap bitmap,Bitmap dstbitmap, float[] H, int Interpolation_method, int Transform_method);
public native static int native_ZPHOTO_FastMeanFilter(Bitmap bitmap, int radius);
public native static int native_ZPHOTO_SobelFilter(Bitmap bitmap);
public native static int native_ZPHOTO_Posterize(Bitmap bitmap, int clusterNum);
public native static int native_ZPHOTO_Fragment(Bitmap bitmap);
public native static int native_ZPHOTO_MotionBlur(Bitmap bitmap, int angle, int distance);
public native static int native_ZPHOTO_SurfaceBlur(Bitmap bitmap, int threshold, int radius);
public native static int native_ZPHOTO_RadialBlur(Bitmap bitmap, int cenX, int cenY, int amount);
public native static int native_ZPHOTO_ZoomBlur(Bitmap bitmap, int cenX, int cenY, int sampleRadius, int amount);
public native static int native_ZPHOTO_Relief(Bitmap bitmap, int angle, int amount);
public native static int native_ZPHOTO_Mean(Bitmap bitmap);
public native static int native_ZPHOTO_Mosaic(Bitmap bitmap, int size);
public native static int native_ZPHOTO_OverExposure(Bitmap bitmap);
public native static int native_ZPHOTO_HistagramEqualize(Bitmap bitmap);
public native static int native_ZPHOTO_Desaturate(Bitmap bitmap, int ratio);
public native static int native_ZPHOTO_Curve(Bitmap bitmap, int destChannel, int[] knotsPos);
public native static int native_ZPHOTO_AutoContrast(Bitmap bitmap);
public native static int native_ZPHOTO_AutoContrastAdjustWithParameters(Bitmap bitmap,float shadowCorrectRatio, float highlightCorrectRatio);
public native static int native_ZPHOTO_AutoColorGradation(Bitmap bitmap);
public native static int native_ZPHOTO_AutoColorGradationAdjustWithParameters(Bitmap bitmap, float shadowCorrectRatio, float highlightCorrectRatio);
public native static int native_ZPHOTO_Diffusion(Bitmap bitmap, int intensity);
public native static int native_ZPHOTO_LSNBlur(Bitmap bitmap, int radius, int delta);
public native static int native_ZPHOTO_MedianFilter(Bitmap bitmap, int radius);
public native static int native_ZPHOTO_MaxFilter(Bitmap bitmap, int radius);
public native static int native_ZPHOTO_MinFilter(Bitmap bitmap, int radius);
public native static int native_ZPHOTO_GlowingEdges(Bitmap bitmap, int edgeSize, int edgeLightness, int edgeSmoothness);
public native static int native_ZPHOTO_ImageWarpWave(Bitmap bitmap, int intensity);
public native static int native_ZPHOTO_GammaCorrect(Bitmap bitmap, int intensity);
public native static int native_ZPHOTO_NaturalSaturation(Bitmap bitmap, int saturation);
public native static int native_ZPHOTO_ColorBalance(Bitmap bitmap, int cyan, int magenta, int yellow, int channel, boolean preserveLuminosity);
public native static int native_ZPHOTO_ColorLevel(Bitmap bitmap, int destChannel, byte inputLeftLimit, float inputMiddle, byte inputRightLimit, byte outputLeftLimit , byte outputRightLimit);
public native static int native_ZPHOTO_LUTFilter(Bitmap bitmap,Bitmap dstbitmap, int ratio);
public native static int native_ZPHOTO_SmartBlurFilter(Bitmap bitmap, int size, int threshold);
public native static int native_ZPHOTO_AnisotropicFilter(Bitmap bitmap, int iter, float k, float lambda, int offset);
public native static int native_ZPHOTO_DisplacementFilter(Bitmap bitmap,Bitmap maskBitmap, int hRatio, int vRatio);
public native static int  native_ZPHOTO_NoiseEffect(Bitmap bitmap, int ratio, float sigma, float phase);
}