
/*************************************************************************
Copyright:   SF.
Author:		 Hu Yaowu
Date:		 2017-6-07
Mail:        dongtingyueh@163.com
Description: ¹«ÓÃº¯Êý
*************************************************************************/
#ifndef __SF_IMAGEPROCESS__
#define __SF_IMAGEPROCESS__

#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#include"SFBITMAP.h"
#ifdef ZPHOTOENGINEIO  
#define ZPHOTOENGINEIO_API _declspec(dllexport)  
#else  
#define ZPHOTOENGINEIO_API  _declspec(dllimport)  
#endif  

class SF_ImageReadWrite
{
public:
	SF_ImageReadWrite();
	~SF_ImageReadWrite();
	int ReadImage(char* fileName);
	int SaveImage(char* fileName, int imageFormat);
	LPSFBITMAP sfBitmap;
	void Destroy();
private:
	int QT_ReadPNGImage(char *pngFileName);
	void QT_GetPNGImageSize(int imgSize[]);
	void QT_GetPNGImageData(unsigned char* imgData, int width, int height, int stride);
	int QT_SavePNGImage(unsigned char* srcData, int width, int height, int stride, const char* szPngFileNameOut);
	void QT_PNGFree();
	int QT_ReadJPGImage(char *jpgFileName);
	void QT_GetJPGImageSize(int imgSize[]);
	void QT_GetJPGImageData(unsigned char* imgData, int width, int height, int stride);
	int QT_SaveJPGImage(unsigned char* srcData, int width, int height, int stride,const char* szJpgFileNameOut, int quality);
	void QT_JPGFree();
	int QT_ReadBMPImage(char *bmpFileName);
	void QT_GetBMPImageSize(int imgSize[]);
	void QT_GetBMPImageData(unsigned char* imgData, int width, int height, int stride);
	int QT_SaveBMPImage(unsigned char* srcData, int width, int height, int stride, const char* szBmpFileNameOut);
	void QT_BMPFree();
	int QT_GetImageFormat(char* fileName);
	
	
};

//void  CImage::LoadImage(char *fname)
//{    
//  m_Width = m_Height = 0;
//     
//  ifstream ffin(fname, std::ios::binary);
//     
//  if (!ffin){
//    cout<<"Can not open this file."<<endl;
//    return;
//  }  
//  int result = get_extension(fname);
//  char s1[2] = {0}, s2[2] = {0};
//   
//  switch(result)
//  {
//  case 1:  // gif  
//    ffin.seekg(6);     
//    ffin.read(s1, 2);
//    ffin.read(s2, 2);    
//    m_Width = (unsigned int)(s1[1])<<8|(unsigned int)(s1[0]);
//    m_Height = (unsigned int)(s2[1])<<8|(unsigned int)(s2[0]);  
//    break;
//  case 2:  // jpg
//    ffin.seekg(164);    
//    ffin.read(s1, 2);
//    ffin.read(s2, 2);    
//    m_Width = (unsigned int)(s1[1])<<8|(unsigned int)(s1[0]);
//    m_Height = (unsigned int)(s2[1])<<8|(unsigned int)(s2[0]);  
//    break;
//  case 3:   // png
//    ffin.seekg(17);    
//    ffin.read(s1, 2);
//    ffin.seekg(2, std::ios::cur);
//    ffin.read(s2, 2);   
//    m_Width = (unsigned int)(s1[1])<<8|(unsigned int)(s1[0]);
//    m_Height = (unsigned int)(s2[1])<<8|(unsigned int)(s2[0]);  
//    break;
//  case 4:   // bmp    
//    ffin.seekg(18);    
//    ffin.read(s1, 2);
//    ffin.seekg(2, std::ios::cur);
//    ffin.read(s2, 2);    
//    m_Width = (unsigned int)(s1[1])<<8|(unsigned int)(s1[0]);
//    m_Height = (unsigned int)(s2[1])<<8|(unsigned int)(s2[0]);  
//    break;
//  default:
//    cout<<"NO"<<endl;
//    break;
//  }  
//  ffin.close();
//};

#endif