/*****************************************************************************
Copyright:    Trent
File name:    ZPhotoEngine.h
Description:  ZPHOTO ENGINE LIBRARY FOR IMAGE PROCESSING LIKE PS
Author:       Trent
Version:      V3.6
Date:         2017-08-17
Mail:         dongtingyueh@163.com
*****************************************************************************/

#ifndef __T_PHOTOENGINE__
#define __T_PHOTOENGINE__

//////////////////////////////////////////////////////////////////////////////
//图层混合模式
const int BLEND_MODE_DARKEN                                       =  1;
const int BLEND_MODE_MULTIPLY                                     =  2;
const int BLEND_MODE_COLORBURN                                    =  3;
const int BLEND_MODE_LINEARBURN                                   =  4;
const int BLEND_MODE_DARKNESS                                     =  5;
const int BLEND_MODE_LIGHTEN                                      =  6;
const int BLEND_MODE_SCREEN                                       =  7;
const int BLEND_MODE_COLORDODGE                                   =  8;
const int BLEND_MODE_COLORLINEARDODGE                             =  9;
const int BLEND_MODE_LIGHTCOLOR                                   =  10;
const int BLEND_MODE_OVERLAY                                      =  11;
const int BLEND_MODE_SOFTLIGHT                                    =  12;
const int BLEND_MODE_HARDLIGHT                                    =  13;
const int BLEND_MODE_VIVIDLIGHT                                   =  14;
const int BLEND_MODE_LINEARLIGHT                                  =  15;
const int BLEND_MODE_PINLIGHT                                     =  16;
const int BLEND_MODE_SOLIDCOLORMIXING                             =  17;
const int BLEND_MODE_DIFFERENCE                                   =  18;
const int BLEND_MODE_EXCLUSION                                    =  19;
const int BLEND_MODE_SUBTRACTION                                  =  20;
const int BLEND_MODE_DIVIDE                                       =  21;
///////////////////////////////////////////////////////////////////////////////
#ifdef _MSC_VER

#ifdef __cplusplus
#define EXPORT extern "C" _declspec(dllexport)
#else
#define EXPORT __declspec(dllexport)
#endif

    //基础功能
	/*************************************************
	Function:    ZPHOTO_Saturation
	Description: 饱和度调节.
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 saturation-饱和度值，范围[0,512]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Saturation(unsigned char* srcData,int width, int height, int stride, int saturation);
	/*************************************************
	Function:    ZPHOTO_Posterize
	Description: 色调分离.
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 clusterNum-色调数，范围[2,255]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Posterize(unsigned char *srcData, int width, int height, int stride, int clusterNum);
	/*************************************************
	Function:    ZPHOTO_OverExposure
	Description: 过度曝光.
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_OverExposure(unsigned char *srcData, int width, int height, int stride);//过度曝光
	/*************************************************
	Function:    ZPHOTO_Lightness    
	Description: 明度调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 lightness-明度值，范围[-100,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Lightness(unsigned char* srcData,int width, int height, int stride, int lightness);//明度调节
	/*************************************************
	Function:    ZPHOTO_Invert
	Description: 反相
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Invert(unsigned char *srcData, int width, int height, int stride);//反相
	/*************************************************
	Function:    ZPHOTO_HueAndSaturation
	Description: 色相饱和度调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 hue-色相值，范围[-180,180]
				 saturation-饱和度值，范围为[-100,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_HueAndSaturation(unsigned char* srcData,int width, int height, int stride,int hue, int saturation);//色相饱和度调节
	/*************************************************
	Function:    ZPHOTO_HistagramEqualize
	Description: 色调均化
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_HistagramEqualize(unsigned char* srcData,int width, int height, int stride);//色调均化
	/*************************************************
	Function:    ZPHOTO_Desaturate
	Description: 去色
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 ratio-去色程度，[0-100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Desaturate(unsigned char *srcData, int width, int height, int stride, int ratio);//去色
   /*************************************************
	Function:    ZPHOTO_Curve
	Description: 曲线调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 destChannel-通道选择，Gray通道-0，R通道-1，G通道-2，B通道-3
				 knotsPos-三个点XY坐标数组：起始点+中间点+末尾点，三个点控制一条spline亮度曲线
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Curve(unsigned char* srcData, int width, int height, int stride, int dstChannel, int knotsPos[6]);

	/*************************************************
	Function:    ZPHOTO_CurveLevel
	Description: 色阶调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 destChannel-通道选择，Gray通道-0，R通道-1，G通道-2，B通道-3
				 inputLeftLimit-输入最小值，范围[0,255]
				 inputMiddle-输入中间值，范围[0,9.99]
				 inputRightLimit-输入最大值，范围[0,255]
				 outputLeftLimit-输出最小值，范围[0,255]
				 outputRightLimit-输出最大值，范围[0,255]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ColorLevel(unsigned char * srcData , int width, int height ,int stride , int destChannel, unsigned char inputLeftLimit, float inputMiddle, unsigned char inputRightLimit, unsigned char outputLeftLimit , unsigned char outputRightLimit);//色阶调整
	/*************************************************
	Function:    ZPHOTO_NLinearBrightContrastAdjust
	Description: 线性亮度对比度调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 brightness-亮度值，范围[-255,255]
				 contrast-对比度值，范围[-100,100]
				 threshold-调节阈值，范围[0,255]，默认值为128
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_LinearBrightContrast(unsigned char* srcData,int width,int height,int stride,int bright,int contrast,int threshold);//非线性亮度对比度调整
	/*************************************************
	Function:    ZPHOTO_LinearBrightContrast
	Description: 非线性亮度对比度调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 brightness-亮度值，范围[-100,100]
				 contrast-对比度值，范围[-100,100]
				 threshold-调节阈值，范围[0,255]，默认值为128
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_NLinearBrightContrast(unsigned char* srcData,int width, int height, int stride, int brightness, int contrast,int threshold);//线性亮度对比度调整
	/*************************************************
	Function:    ZPHOTO_Blackwhite
	Description: 黑白
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 kRed-红色比例,范围[-200,300]
				 kGreen-绿色比例,范围[-200,300]
				 kBlue-蓝色比例,范围[-200,300]
				 kYellow-黄色比例,范围[-200,300]
				 kCyan-青色比例,范围[-200,300]
				 kMagenta-洋红比例,范围[-200,300]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_Blackwhite(unsigned char *srcData, int width, int height, int stride, int kRed, int kGreen, int kBlue, int kYellow, int kCyan, int kMagenta);//黑白

	/*************************************************
	Function:    ZPHOTO_AutoContrast
	Description: 自动对比度调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_AutoContrast(unsigned char *srcData, int width, int height, int stride);//自动对比度
	/*************************************************
	Function:    ZPHOTO_AutoContrastAdjustWithParameters
	Description: 参数限制的自动对比度调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 shadowCorrectRatio-阴影修剪比例，范围[0.00,9.99]
				 highlightCorrectRatio-高光修剪比例，范围[0.00,9.99]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_AutoContrastAdjustWithParameters(unsigned char *srcData, int width, int height, int stride, float shadowCorrectRatio, float highlightCorrectRatio);//含参自动对比度
	/*************************************************
	Function:    ZPHOTO_AutoColorGradation
	Description: 自动色阶调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_AutoColorGradation(unsigned char *srcData, int width, int height, int stride);//自动色阶
	/*************************************************
	Function:    ZPHOTO_AutoColorGradationAdjustWithParameters
	Description: 参数限制的自动色阶调节
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 shadowCorrectRatio-阴影修剪比例，范围[0.00,9.99]
				 highlightCorrectRatio-高光修剪比例，范围[0.00,9.99]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_AutoColorGradationAdjustWithParameters(unsigned char *srcData, int width, int height, int stride, float shadowCorrectRatio, float highlightCorrectRatio);//含参自动色阶
	/*************************************************
	Function:    ZPHOTO_Threshold
	Description: 阈值(二值化)
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 threshold-阈值，范围[0,255]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Threshold(unsigned char *srcData, int width, int height, int stride, int threshold);//阈值
	/*************************************************
	Function:    ZPHOTO_ChannelMixProcess
	Description: 通道混合器
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后修为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 channel-Red-0,Green-1,Blue-2,Gray-3
				 kr-Red通道比例，范围[-200,200]
				 kg-Green通道比例，范围[-200,200]
				 kb-Blue通道比例，范围[-200,200]
				 N-常数调节比例，范围[-200,200]
				 singleColor-是否单色，单色-true，彩色-false
				 constAdjust-是否执行常数比例调节，调节-true,不调节-false
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ChannelMixProcess(unsigned char* srcData, int width, int height, int stride, int channel, int kr, int kg, int kb, int N, bool singleColor, bool constAdjust);
	/*************************************************
	Function:    ZPHOTO_FastestGaussFilter
	Description: 极速高斯模糊
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 radius-高斯模糊半径，范围[0,1000]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_FastestGaussFilter(unsigned char* srcData,int width, int height,int stride,float radius);//高斯滤波
	/*************************************************
	Function:    ZPHOTO_HighPass
	Description: 高反差保留
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 radius-高斯模糊半径，范围[0,1000]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_HighPass(unsigned char* srcData,int width, int height,int stride,float mRadius);//高反差保留
	/*************************************************
	Function:    ZPHOTO_USM
	Description: USM锐化
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 radius-高斯半径，范围为[0,1000]
				 amount-锐化程度，范围为[0,500]
				 threshold-锐化阈值，范围为[0,255]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_USM(unsigned char* srcData,int width, int height,int stride,float radius, int amount, int threshold);
	/*************************************************
	Function:    ZPHOTO_FindEdges
	Description: 查找边缘
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_FindEdges(unsigned char *srcData, int width, int height,int stride);//查找边缘
	/////////////////////////////////////////////////////////////////////////////////////////////////////
    
    //图层混合功能
	/*************************************************
	Function:    ZPHOTO_ModeDarken
	Description: 变暗模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeDarken(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeMultiply
	Description: 正片叠底模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeMultiply(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeColorBurn
	Description: 颜色加深模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeColorBurn(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeLinearBurn
	Description: 线性渐变模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeLinearBurn(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeDarkness
	Description: 深色模式
	Input:       baseRed-输入基础像素R值，范围[0,255]，执行后作为输出结果
				 baseGreen-输入基础像素G值，范围[0,255]，执行后作为输出结果
				 baseBlue-输入基础像素B值，范围[0,255]，执行后作为输出结果
				 mixRed-输入混合像素R值，范围[0,255]
				 mixRed-输入混合像素G值，范围[0,255]
				 mixRed-输入混合像素B值，范围[0,255]
	Output:      无.
	Return:      0-成功，其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeDarkness(int *baseRed,int *baseGreen,int *baseBlue,int mixRed,int mixGreen,int mixBlue);
	/*************************************************
	Function:    ZPHOTO_ModeLighten
	Description: 变亮模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeLighten(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeScreen
	Description: 滤色模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeScreen(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeColorDodge
	Description: 颜色减淡模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeColorDodge(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeColorLinearDodge
	Description: 颜色线性减淡模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeColorLinearDodge(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeLightColor
	Description: 浅色模式
	Input:       baseRed-输入基础像素R值，范围[0,255]，执行后作为输出结果
				 baseGreen-输入基础像素G值，范围[0,255]，执行后作为输出结果
				 baseBlue-输入基础像素B值，范围[0,255]，执行后作为输出结果
				 mixRed-输入混合像素R值，范围[0,255]
				 mixRed-输入混合像素G值，范围[0,255]
				 mixRed-输入混合像素B值，范围[0,255]
	Output:      无.
	Return:      0-成功，其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeLightColor(int *baseRed,int *baseGreen,int *baseBlue,int mixRed,int mixGreen,int mixBlue);
	/*************************************************
	Function:    ZPHOTO_ModeOverlay
	Description: 叠加模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeOverlay(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeSoftLight
	Description: 柔光模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeSoftLight(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeHardLight
	Description: 强光模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeHardLight(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeVividLight
	Description: 亮光模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeVividLight(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeLinearLight
	Description: 线性光模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeLinearLight(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModePinLight
	Description: 点光模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModePinLight(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeSolidColorMixing
	Description: 实色混合模式
	Input:       baseRed-输入基础像素R值，范围[0,255]，执行后作为输出结果
				 baseGreen-输入基础像素G值，范围[0,255]，执行后作为输出结果
				 baseBlue-输入基础像素B值，范围[0,255]，执行后作为输出结果
				 mixRed-输入混合像素R值，范围[0,255]
				 mixRed-输入混合像素G值，范围[0,255]
				 mixRed-输入混合像素B值，范围[0,255]
	Output:      无.
	Return:      0-成功，其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeSolidColorMixing(int *baseRed,int *baseGreen,int *baseBlue,int mixRed,int mixGreen,int mixBlue);
	/*************************************************
	Function:    ZPHOTO_ModeDifference
	Description: 差值模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeDifference(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeExclusion
	Description: 排除模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeExclusion(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeSubtraction
	Description: 减去模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeSubtraction(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeDivide
	Description: 划分模式
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeDivide(int basePixel,int mixPixel);
	/*************************************************
	Function:    ZPHOTO_ModeDesaturate
	Description: 去色
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeDesaturate(int red,int green,int blue);
	/*************************************************
	Function:    ZPHOTO_ModeColorInvert
	Description: 反相
	Input:       basePixel-输入基础像素值，范围[0,255]
	             mixPixel-输入混合像素值，范围[0,255]
	Output:      无.
	Return:      图层混合结果值，范围[0,255].
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ModeColorInvert(int *red,int *green,int *blue);
	/*************************************************
	Function:    ZPHOTO_ImageBlendEffect
	Description: 图层混合
	Input:       baseData-基础图层图像Buffer，格式为32位BGRA
	             width-基础图像宽度
				 height-基础图像高度
				 stride-基础图像Stride
				 mixData-混合图层图像Buffer，大小与基础图层图像一致
				 blendMode-图层混合模式
	Output:      无.
	Return:      0-成功，其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_ImageBlendEffect(unsigned char* baseData, int width, int height, int stride, unsigned char* mixData, int blendMode);
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    
    //扩展功能
	/*************************************************
	Function:    ZPHOTO_ColorTemperature
	Description: 色温调节
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 intensity-色温强度，范围[-50,50]；intensity < 0，冷色；intensity = 0,原图；intensity > 0，暖色；
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ColorTemperature(unsigned char* srcData,int width, int height, int stride, int intensity);
	/*************************************************
	Function:    ZPHOTO_Shadow 
	Description: 阴影调节
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 intensity-阴影强度值，取值范围为[0,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Shadow(unsigned char* srcData,int width, int height, int stride, int intensity);
	/*************************************************
	Function:    ZPHOTO_Highlight
	Description: 高光调节
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 intensity--高光强度值，取值范围为[0,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Highlight(unsigned char* srcData,int width, int height, int stride, int intensity);
	/*************************************************
	Function:    ZPHOTO_HighlightShadowPrecise
	Description: 高光阴影调节
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 highlight--高光强度值，取值范围为[-200,100]
				 shadow-阴影强度值，取值范围为[-200,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_HighlightShadowPrecise(unsigned char* srcData,int width, int height, int stride, float highlight, float shadow);
	/*************************************************
	Function:    ZPHOTO_Exposure
	Description: 曝光调节
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 intensity--曝光强度值，取值范围为[0,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_Exposure(unsigned char* srcData,int width, int height, int stride, int intensity);
	/*************************************************
	Function:    ZPHOTO_CalcWH
	Description: 计算图像变换之后的宽高及变换矩阵H，该接口先于ZPHOTO_ImageTransformation调用       
	Input:	     inputImgSize--输入图像宽高信息
				 angle--旋转角度值，取值范围为[-360-360]
				 scale--缩放变换值，取值大于0
				 transform_method--变换方法：
									 transform_scale缩放变换, 取值为0；
									 transform_rotation旋转变换, 取值为1；   
									 transform_rotation_scale缩放旋转变换, 取值为2；
									 transform_affine仿射变换, 取值为3；
									 transform_mirror_h水平镜像变换, 取值为4；
									 transform_mirror_v垂直镜像变换, 取值为5；
									 transform_offset平移变换, 取值为6；
				 outputImgSize--输出图像宽高信息
				 H--变换矩阵数组，长度为6
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_CalcWH( int inputImgSize[2], float angle, float scale, int transform_method, int outputImgSize[2],float H[]);
	/*************************************************
	Function:    ZPHOTO_ImageTransformation
	Description: 图像变换
	Input:       srcData-原始图像，格式为32位BGRA格式
	             srcImgSize--原始图像宽高信息数组
                 dstData--结果图像Buffer，大小由接口ZPHOTO_CalcWH获得
				 dstImgSize--目标图像宽高信息数组
				 H--变换矩阵数组，长度为6
				 Interpolation_method--插值方法选择：interpolation_bilinear,interpolation_nearest
				 Transform_method--变换方法：
									 transform_scale缩放变换, 取值为0；
									 transform_rotation旋转变换, 取值为1；   
									 transform_rotation_scale缩放旋转变换, 取值为2；
									 transform_affine仿射变换, 取值为3；
									 transform_mirror_h水平镜像变换, 取值为4；
									 transform_mirror_v垂直镜像变换, 取值为5；
									 transform_offset平移变换, 取值为6；
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_ImageTransformation(unsigned char *srcData, int srcImgSize[2], unsigned char *dstData, int dstImgSize[2], float H[], int Interpolation_method, int Transform_method);
	/*************************************************
	Function:    ZPHOTO_FastMeanFilter
	Description: 均值模糊
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 radius--均值滤波半径，取值范围为[0,width / 2]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_FastMeanFilter(unsigned char* srcData, int width, int height ,int stride, int radius);
	/*************************************************
	Function:    ZPHOTO_SobelFilter
	Description: Sobel边缘检测
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_SobelFilter(unsigned char *srcData, int width, int height,int stride);

	//For Android Development
	/*************************************************
	Function:    ZPHOTO_RGBA2BGRA
	Description: RGBA格式转BGRA格式，主要为android设置
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_RGBA2BGRA(unsigned char* srcData, int width, int height, int stride);
	/*************************************************
	Function:    ZPHOTO_BGRA2RGBA
	Description: BGRA格式转RGBA格式，主要为android设置
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
    EXPORT int ZPHOTO_BGRA2RGBA(unsigned char* srcData, int width, int height, int stride);

	/*************************************************
	Function:    ZPHOTO_Fragment
	Description: 碎片
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_Fragment(unsigned char *srcData, int width, int height, int stride);
	/*************************************************
	Function:    ZPHOTO_MotionBlur
	Description: 运动模糊
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 angle-运动模糊角度值，取值范围为[0,360]
				 distance-运动模糊距离值，取值范围为[0,200]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_MotionBlur(unsigned char* srcData,int width, int height, int stride, int angle, int distance);
	/*************************************************
	Function:    ZPHOTO_SurfaceBlur
	Description: 表面模糊
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 threshold-表面模糊阈值值，取值范围为[0,255]
				 radius-表面模糊半径值，取值范围为[0,10]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_SurfaceBlur(unsigned char *srcData, int width, int height, int stride,int threshold, int radius);
	/*************************************************
	Function:    ZPHOTO_RadialBlur
	Description: 旋转模糊
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 cenX-选钻模糊中心X坐标
				 cenY-旋转模糊中心Y坐标
				 amount-旋转模糊程度数量，范围为[1-100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_RadialBlur(unsigned char* srcData, int width, int height ,int stride, int cenX, int cenY, int amount);
	/*************************************************
	Function:    ZPHOTO_ZoomBlur
	Description: 缩放模糊
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 cenX-缩放模糊中心X坐标
				 cenY-缩放模糊中心Y坐标
				 sampleRadius-缩放模糊半径，范围为[0-255]
				 amount-缩放模糊程度数量,范围为[1-100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_ZoomBlur(unsigned char* srcData, int width, int height ,int stride, int cenX, int cenY, int sampleRadius, int amount);
	/*************************************************
	Function:    ZPHOTO_Relief
	Description: 浮雕
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度   
				 stride-原始图像的Stride
				 angle-浮雕角度，范围为[0-360]
				 amount-浮雕程度数量,范围为[0-500]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_Relief(unsigned char *srcData, int width, int height, int stride, int angle, int amount);
	/*************************************************
	Function:    ZPHOTO_Mean
	Description: 平均
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_Mean(unsigned char *srcData, int width, int height, int stride);
	/*************************************************
	Function:    ZPHOTO_Mosaic
	Description: 马赛克
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 size-Mosaic半径,范围为[0,200]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_Mosaic(unsigned char* srcData, int width, int height, int stride, int size);
	/*************************************************
	Function:    ZPHOTO_ColorBalance
	Description: 色彩平衡
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 cyan-青色，范围为[-100,100]
				 magenta-洋红，范围为[-100,100]
				 yellow-黄色，范围为[-100,100]
				 channel-通道选择，RGB-0,R-1,G-2,B-3
				 preserveLuminosity-true:保留明度，false:不保留明度
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_ColorBalance(unsigned char* srcData, int width, int height, int stride, int cyan, int magenta, int yellow, int channel, bool preserveLuminosity);
	/*************************************************
	Function:    ZPHOTO_Diffusion
	Description: 扩散
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 intensity-扩散程度，范围为[0,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_Diffusion(unsigned char* srcData,int width, int height,int stride,int intensity);
	/*************************************************
	Function:    ZPHOTO_LSNBlur
	Description: LSNBlur
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 radius-LSNBlur半径，范围为[0,200]
				 delta-[0,500]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_LSNBlur(unsigned char* srcData, int width, int height, int stride, int radius, int delta);
	/*************************************************
	Function:    ZPHOTO_MedianFilter
	Description: 中值滤波(中间色)
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 radius-表面模糊半径值，取值范围为[0,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_MedianFilter(unsigned char *srcData, int width, int height, int stride,int radius);
	/*************************************************
	Function:    ZPHOTO_MaxFilter
	Description: 最大值滤波(最大值)
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 radius-表面模糊半径值，取值范围为[0,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_MaxFilter(unsigned char *srcData, int width, int height, int stride, int radius);
	/*************************************************
	Function:    ZPHOTO_MinFilter
	Description: 最小值滤波(最小值)
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 radius-表面模糊半径值，取值范围为[0,100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_MinFilter(unsigned char *srcData, int width, int height, int stride, int radius);
	/*************************************************
	Function:    ZPHOTO_GlowingEdges
	Description: 照亮边缘滤镜
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 edgeSize-边缘宽度值，取值范围为[1,14]
				 edgeLightness-边缘亮度值，取值范围为[0,20]
				 edgeSmoothness-平滑度，取值范围为[1,15]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_GlowingEdges(unsigned char* srcData, int width ,int height, int stride, int edgeSize, int edgeLightness, int edgeSmoothness);
	
	/*************************************************
	Function:    ZPHOTO_ImageWarpWave
	Description: Wave 变形
	Input:       srcData-原始图像，格式为32位BGRA格式，执行后为结果图像
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 intensity-变形程度，范围[0, 100]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_ImageWarpWave(unsigned char *srcData, int width, int height, int stride, int intensity);
	
	/*************************************************
	Function:    ZPHOTO_RGBToYCbCr
	Description: RGB转YCbCr
	Input:       Red-像素R分量，范围[0,255]
				 Green-像素G分量，范围[0,255]
				 Blue-像素B分量，范围[0,255]
				 Y-像素Y分量
				 Cb-像素Cb分量
				 Cr-像素Cr分量
	Output:      无.
	Return:      无.
	Others:      无.
	*************************************************/
	EXPORT void ZPHOTO_RGBToYCbCr(int R, int G, int B, int*Y,int*Cb, int* Cr);
	/*************************************************
	Function:    ZPHOTO_YCbCrToRGB
	Description: YCbCr转RGB	   
	Input: 	     Y-像素Y分量
				 Cb-像素Cb分量
				 Cr-像素Cr分量
				 Red-像素R分量，范围[0,255]
				 Green-像素G分量，范围[0,255]
				 Blue-像素B分量，范围[0,255]
	Output:      无.
	Return:      无.
	Others:      无.
	*************************************************/
    EXPORT void ZPHOTO_YCbCrToRGB(int Y, int Cb, int Cr, int*Red,int*Green, int* Blue);
	
	/*************************************************
	Function:    ZPHOTO_RGBToLab
	Description: RGB转LAB	   
	Input:    	 Red-像素R分量，范围[0,255]
				 Green-像素G分量，范围[0,255]
				 Blue-像素B分量，范围[0,255]
				 L-像素Y分量，范围[0,255]
				 A-像素I分量，范围[0,255]
				 B-像素Q分量, 范围[0,255]
	Output:      无.
	Return:      无.
	Others:      无.
	*************************************************/
    EXPORT void ZPHOTO_RGBToLab(int Red, int Green, int Blue, int* L, int *A, int *B);
	/*************************************************
	Function:    ZPHOTO_LabToRGB
	Description: LAB转RGB	   
	Input:    	 L-像素Y分量，范围[0,255]
				 A-像素I分量，范围[0,255]
				 B-像素Q分量, 范围[0,255]
				 Red-像素R分量，范围[0,255]
				 Green-像素G分量，范围[0,255]
				 Blue-像素B分量，范围[0,255]
	Output:      无.
	Return:      无.
	Others:      无.
	*************************************************/
    EXPORT void ZPHOTO_LabToRGB(int L, int A, int B, int* Red, int* Green, int* Blue);
	/*************************************************
	Function:    ZPHOTO_GammaCorrect
	Description: Gamma调整
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 intensity-Gamma参数，范围[1,50]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
	*************************************************/
	EXPORT int ZPHOTO_GammaCorrect(unsigned char* srcData, int width, int height, int stride, int intensity);

    /******************************************************************************* 
    * Function Name  : Natural Saturation 
    * Description    : 自然饱和度
    * Input  srcData : image data
    * Input  width   : image width
    * Input  height  : image height
    * Input  stride  : image stride
    * Input  saturation     : saturation value to adjust from -100 to 100
    * Output         : None 
    * Return         : 0-success, others failed
    *******************************************************************************/
	EXPORT int ZPHOTO_NaturalSaturation(unsigned char* srcData,int width, int height, int stride, int saturation);
	EXPORT int ZPHOTO_LUTFilter(unsigned char* srcData, int width ,int height, int stride, unsigned char*Map, int ratio);
/****************************************************Update***************************************************
****************************************************Date:2018-06-21*******************************************
Content:
Smart blur filter
Anisotropic Filter
*************************************************************************************************************/
/*************************************************
	Function:    ZPHOTO_SmartBlurFilter
	Description: Smart Blur
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 size-模糊半径值，取值范围为[0,100]
				 threshold-调节阈值，范围[0,255]
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
*************************************************/
	EXPORT int ZPHOTO_SmartBlurFilter(unsigned char* srcData, int width, int height, int stride, int size, int threshold);
/*************************************************
	Function:    ZPHOTO_AnisotropicFilter
	Description: Anisotropic Filter
	Input:       srcData-原始图像，格式为32位BGRA格式
	             width-原始图像宽度
				 height-原始图像高度
				 stride-原始图像的Stride
				 iter-迭代次数，取值范围为[0,100]
				 k-扩散系数，范围[0,]
				 lambda-[0,0.35],default 0.25
				 offset-[0,10],default 3
	Output:      无.
	Return:      0-成功,其他失败.
	Others:      无.
*************************************************/
	EXPORT int ZPHOTO_AnisotropicFilter(unsigned char* srcData, int width, int height, int stride, int iter, float k, float lambda = 0.25, int offset = 3);
#else

#ifdef __cplusplus
extern "C" {
#endif    
	//基本功能
	int ZPHOTO_Exposure(unsigned char* srcData,int width, int height, int stride, int intensity);
    int ZPHOTO_Saturation(unsigned char* srcData,int width, int height, int stride, int saturation);
	int ZPHOTO_Posterize(unsigned char *srcData, int width, int height, int stride, int clusterNum);
	int ZPHOTO_OverExposure(unsigned char *srcData, int width, int height, int stride);
	int ZPHOTO_Lightness(unsigned char* srcData,int width, int height, int stride, int lightness);
	int ZPHOTO_Invert(unsigned char *srcData, int width, int height, int stride);
	int ZPHOTO_HueAndSaturation(unsigned char* srcData,int width, int height, int stride,int hue, int saturation);
	int ZPHOTO_HistagramEqualize(unsigned char* srcData,int width, int height, int stride);
	int ZPHOTO_Desaturate(unsigned char *srcData, int width, int height, int stride, int ratio);
    int ZPHOTO_Curve(unsigned char* srcData, int width, int height, int stride, int dstChannel, int knotsPos[6]);
	int ZPHOTO_ColorLevel(unsigned char * srcData , int width, int height ,int stride , int destChannel, unsigned char inputLeftLimit, float inputMiddle, unsigned char inputRightLimit, unsigned char outputLeftLimit , unsigned char outputRightLimit);
	int ZPHOTO_NLinearBrightContrast(unsigned char* srcData,int width,int height,int stride,int bright,int contrast,int threshold);
    int ZPHOTO_LinearBrightContrast(unsigned char* srcData,int width, int height, int stride, int brightness, int contrast,int threshold);
    int ZPHOTO_Blackwhite(unsigned char *srcData, int width, int height, int stride, int kRed, int kGreen, int kBlue, int kYellow, int kCyan, int kMagenta);
	int ZPHOTO_AutoContrast(unsigned char *srcData, int width, int height, int stride);
	int ZPHOTO_AutoContrastAdjustWithParameters(unsigned char *srcData, int width, int height, int stride, float shadowCorrectRatio, float highlightCorrectRatio);
	int ZPHOTO_AutoColorGradation(unsigned char *srcData, int width, int height, int stride);
	int ZPHOTO_AutoColorGradationAdjustWithParameters(unsigned char *srcData, int width, int height, int stride, float shadowCorrectRatio, float highlightCorrectRatio);
	int ZPHOTO_Threshold(unsigned char *srcData, int width, int height, int stride, int threshold);
	int ZPHOTO_HighPass(unsigned char* srcData,int width, int height,int stride,float mRadius);
	int ZPHOTO_ChannelMixProcess(unsigned char *srcData, int width, int height, int stride,int rCof,int gCof, int bCof, int rRatio, int gRatio, int bRatio);
	int ZPHOTO_USM(unsigned char* srcData,int width, int height,int stride,float radius, int amount, int threshold);
	int ZPHOTO_FindEdges(unsigned char *srcData, int width, int height,int stride);
	int ZPHOTO_Fragment(unsigned char *srcData, int width, int height, int stride);
	int ZPHOTO_MotionBlur(unsigned char* srcData,int width, int height, int stride, int angle, int distance);
	int ZPHOTO_SurfaceBlur(unsigned char *srcData, int width, int height, int stride,int threshold, int radius);

	//V1.2
	int ZPHOTO_RadialBlur(unsigned char* srcData, int width, int height ,int stride, int cenX, int cenY, int amount);
	int ZPHOTO_ZoomBlur(unsigned char* srcData, int width, int height ,int stride, int cenX, int cenY, int sampleRadius, int amount);
	int ZPHOTO_Relief(unsigned char *srcData, int width, int height, int stride, int angle, int amount);
	int ZPHOTO_Mean(unsigned char *srcData, int width, int height, int stride);
	int ZPHOTO_ColorBalance(unsigned char* srcData, int width, int height, int stride, int cyan, int magenta, int yellow, int channel, bool preserveLuminosity);
	int ZPHOTO_LSNBlur(unsigned char* srcData, int width, int height, int stride, int radius, int delta);
	int ZPHOTO_Mosaic(unsigned char *srcData, int width, int height, int stride, int size);
	int ZPHOTO_Diffusion(unsigned char* srcData,int width, int height,int stride,int intensity);
	int ZPHOTO_MedianFilter(unsigned char *srcData, int width, int height, int stride, int radius);
	int ZPHOTO_MaxFilter(unsigned char *srcData, int width, int height, int stride, int radius);
	int ZPHOTO_MinFilter(unsigned char *srcData, int width, int height, int stride, int radius);
	
	void ZPHOTO_RGBToYCbCr(int R, int G, int B, int*Y,int*Cb, int* Cr);
	void ZPHOTO_YCbCrToRGB(int Y, int Cb, int Cr, int*Red,int*Green, int* Blue);
	void ZPHOTO_RGBToLab(int Red, int Green, int Blue, int* L, int *A, int *B);
	void ZPHOTO_LabToRGB(int L, int A, int B, int* Red, int* Green, int* Blue);
	///图层混合功能
	int ZPHOTO_ModeDarken(int basePixel,int mixPixel);
	int ZPHOTO_ModeMultiply(int basePixel,int mixPixel);
	int ZPHOTO_ModeColorBurn(int basePixel,int mixPixel);
	int ZPHOTO_ModeLinearBurn(int basePixel,int mixPixel);
	int ZPHOTO_ModeDarkness(int *baseRed,int *baseGreen,int *baseBlue,int mixRed,int mixGreen,int mixBlue);
	int ZPHOTO_ModeLighten(int basePixel,int mixPixel);
	int ZPHOTO_ModeScreen(int basePixel,int mixPixel);
	int ZPHOTO_ModeColorDodge(int basePixel,int mixPixel);
	int ZPHOTO_ModeColorLinearDodge(int basePixel,int mixPixel);
	int ZPHOTO_ModeLightColor(int *baseRed,int *baseGreen,int *baseBlue,int mixRed,int mixGreen,int mixBlue);
	int ZPHOTO_ModeOverlay(int basePixel,int mixPixel);
	int ZPHOTO_ModeSoftLight(int basePixel,int mixPixel);
	int ZPHOTO_ModeHardLight(int basePixel,int mixPixel);
	int ZPHOTO_ModeVividLight(int basePixel,int mixPixel);
	int ZPHOTO_ModeLinearLight(int basePixel,int mixPixel);
	int ZPHOTO_ModePinLight(int basePixel,int mixPixel);
	int ZPHOTO_ModeSolidColorMixing(int *baseRed,int *baseGreen,int *baseBlue,int mixRed,int mixGreen,int mixBlue);
	int ZPHOTO_ModeDifference(int basePixel,int mixPixel);
	int ZPHOTO_ModeExclusion(int basePixel,int mixPixel);
	int ZPHOTO_ModeSubtraction(int basePixel,int mixPixel);
	int ZPHOTO_ModeDivide(int basePixel,int mixPixel);
	int ZPHOTO_ModeDesaturate(int red,int green,int blue);
	int ZPHOTO_ModeColorInvert(int *red,int *green,int *blue);
	int ZPHOTO_ImageBlendEffect(unsigned char* baseData, int width, int height, int stride, unsigned char* mixData, int blendMode);//图层混合

	//扩展功能
	int ZPHOTO_FastestGaussFilter(unsigned char* srcData,int width, int height,int stride,float radius);
	int ZPHOTO_ColorTemperature(unsigned char* srcData,int width, int height, int stride, int intensity);
	int ZPHOTO_CalcWH( int inputImgSize[2], float angle, float scale, int transform_method, int outputImgSize[2],float H[]);
    int ZPHOTO_ImageTransformation(unsigned char *srcData, int srcImgSize[2], unsigned char *dstData, int dstImgSize[2], float H[], int Interpolation_method, int Transform_method);
	int ZPHOTO_FastMeanFilter(unsigned char* srcData, int width, int height ,int stride, int radius);
	int ZPHOTO_SobelFilter(unsigned char *srcData, int width, int height,int stride);
	int ZPHOTO_GlowingEdges(unsigned char* srcData, int width ,int height, int stride, int edgeSize, int edgeLightness, int edgeSmoothness);
	int ZPHOTO_ImageWarpWave(unsigned char *srcData, int width, int height, int stride, int intensity);
    //For Android Development
    int ZPHOTO_RGBA2BGRA(unsigned char* srcData, int width, int height, int stride);
    int ZPHOTO_BGRA2RGBA(unsigned char* srcData, int width, int height, int stride);
	int ZPHOTO_GammaCorrect(unsigned char* srcData, int width, int height, int stride, int intensity);
	int ZPHOTO_HighlightShadowPreciseAdjust(unsigned char* srcData,int width, int height, int stride, float highlight, float shadow);
	int ZPHOTO_NaturalSaturation(unsigned char* srcData,int width, int height, int stride, int saturation);
	int ZPHOTO_LUTFilter(unsigned char* srcData, int width ,int height, int stride, unsigned char*Map, int ratio);

	int ZPHOTO_SmartBlurFilter(unsigned char* srcData, int width, int height, int stride, int size, int threshold);
	int ZPHOTO_AnisotropicFilter(unsigned char* srcData, int width, int height, int stride, int iter, float k, float lambda = 0.25, int offset = 3);
#ifdef __cplusplus
}
#endif


#endif



#endif
