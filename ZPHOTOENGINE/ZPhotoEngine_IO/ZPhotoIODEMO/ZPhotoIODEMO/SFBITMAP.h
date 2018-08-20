#ifndef _IN_BITMAP_H_
#define _IN_BITMAP_H_
#include"f_error.h"
#define SF_IMAGE_MAX_PLANES  4
/*图像结构体BITMAP
/*
*pixelFormat:像素格式，BGR24,BGRA32
*lWidth:图像宽度
*lHeight:图像高度
*lBitCounts:每个像素位数
*lPitch:每行的bytes
*pPlandData:图像数据的数组指针
*/
typedef struct _tag_SFBITMAP{
	int pixelFormat;
	int lWidth;
	int lHeight;
	int lBitCounts;
	long lPitch[SF_IMAGE_MAX_PLANES];
	unsigned char* pPlaneData[SF_IMAGE_MAX_PLANES];
	
}SFBITMAP,*LPSFBITMAP;


/*
*图像像素格式定义
*/
typedef enum _sf_image_pixelformat{SF_IMAGE_PIXELFORMAT_YUV420,SF_IMAGE_PIXELFORMAT_BGR24,SF_IMAGE_PIXELFORMAT_BGRA32,SF_IMAGE_PIXELFORMAT_RGB24,SF_IMAGE_PIXELFORMAT_RGBA32
}SFPixelFormat;
/*
*图像格式定义
*/
typedef enum _sf_imageformat{SF_IMAGE_PNG,SF_IMAGE_BMP,SF_IMAGE_JPG, SF_IMAGE_GIF, SF_IMAGE_UNKNOWN}SFImageFormat;




/*
*描述：根据传入格式图像数据，创建INBITMAP
*srcData:输入图像内存数据
*width:图像宽度
*height:图像高度
*bitCounts:图像单个像素bit数
*pixelFormat:图像像素格式
*dstBitmap：INBITMAP对象
*/
int SFBITMAP_CreateFromImage(unsigned char* srcData, int width, int height, int bitCounts, int pixelFormat,SFBITMAP* dstBitmap);
/*
*描述：讲INBITMAP转换为指定格式，填充到指定内存区域
*srcBitmap:INBITMAP对象
*srcData：目标格式图像内存Buffer
*width:目标图像宽度
*height:目标图像高度
*bitCounts:目标图像单个像素bit数
*pixelFormat:目标图像像素格式
*/
int SFBITMAP_ConvertToImage(SFBITMAP srcBitmap, unsigned char* srcData, int width, int height, int bitCounts, int pixelFormat);
/*描述：销毁INBITMAP对象
*bitmap:需要销毁释放的INBITMAP对象
*/
void SFBITMAP_Free(SFBITMAP* bitmap);
#endif


