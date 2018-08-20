#include "stdafx.h"
#include"f_error.h"
#include"SFBITMAP.h"
#include"SFImageReadWrite.h"
#pragma  comment(lib,"ZPhotoEngineIO.lib")

int _tmain(int argc, char* argv[])
{
	char* jpgPath = "C:\\Users\\Administrator\\Desktop\\1.jpg";
	char* outjpgPath = "C:\\Users\\Administrator\\Desktop\\Res.jpg";
	long start = clock();
	SF_ImageReadWrite* imgRW = new SF_ImageReadWrite();
	int ret = imgRW->ReadImage(jpgPath);
	if(ret == SF_RET_OK)
	{
		unsigned char* pSrc = imgRW->sfBitmap->pPlaneData[0];
		int w = imgRW->sfBitmap->lWidth;
		int h = imgRW->sfBitmap->lHeight;
		unsigned char* tempData = (unsigned char*)malloc(sizeof(unsigned char) * w * h * 4);
		memcpy(tempData, pSrc, sizeof(unsigned char) * w * h * 4);
		//Image Processing
		
		imgRW->SaveImage(outjpgPath,SF_IMAGE_JPG);
	}
	long end = clock();
	imgRW->Destroy();
	printf("JPG Time cost: %d ms.", (end - start));
    return 0;
}