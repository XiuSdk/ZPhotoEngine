#ifndef  __SF_EFFOR__
#define  __SF_EFFOR__

static int SF_SUCCESS = 0;
static int SF_FORMAT_ERROR = -2;
static int SF_FILE_ERROR = -1;
static int SF_OTHER_ERROR = -5;
static int SF_PARAMS_ERROR = -3;
static int SF_MEMORY_ERROR = -4;

#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <limits.h>
#include <float.h>
#include <time.h>
#include <string.h>
#include <assert.h>



typedef enum _sf_ret {
	SF_RET_OK,
	SF_RET_ERR_PARA,
	SF_RET_ERR_MEM,
	SF_RET_ERR_NOT_SUPPORT      = 0x04,
	SF_RET_ERR_OPEN_FILE        = 0x08,
	SF_RET_ERR_DATA_UNINITED    = 0x10,
	SF_RET_ERR_UNKNOWN          = 0x20,
	SF_RET_ERR_END_OF_FILE      = 0x40,
	SF_RET_ERR_DATA_UNREADABLE  = 0x101,
	SF_RET_ERR_DATA_NOWRITEABLE = 0x102,

}SF_RET;

#define SF_PRINT_LOG(message)  printf("Error occurred: %s \nError position:\nFile:%s \nLine:%d\n", message, __FILE__, __LINE__);

static const char* sf_error_string[] = {
	"Good! Normal return!",
	"Your input params are wrong!",
	"Allocating memory failure! ",
	"Current version can not support!",
	"Opening file errors!",
	"Data are uninitialized!",
	"Unknown error!",
	"Arriving the end of the file!",
	"Data are waiting!",
	"Data length is not enough!"
};

#define SF_LOG(level)                                  \
	{                                                  \
	if (level == SF_RET_ERR_PARA){                     \
	     SF_PRINT_LOG(sf_error_string[1]);             \
	} else if (level == SF_RET_ERR_MEM){               \
	     SF_PRINT_LOG(sf_error_string[2]);             \
	} else if (level == SF_RET_ERR_NOT_SUPPORT){       \
	     SF_PRINT_LOG(sf_error_string[3]);             \
	} else if (level == SF_RET_ERR_OPEN_FILE){         \
	     SF_PRINT_LOG(sf_error_string[4]);             \
	} else if (level == SF_RET_ERR_DATA_UNINITED){     \
	     SF_PRINT_LOG(sf_error_string[5]);             \
	} else if (level == SF_RET_ERR_UNKNOWN){           \
	     SF_PRINT_LOG(sf_error_string[6]);             \
	} else if (level == SF_RET_ERR_END_OF_FILE){       \
	     SF_PRINT_LOG(sf_error_string[7]);             \
	} else if (level == SF_RET_ERR_DATA_UNREADABLE){   \
	     SF_PRINT_LOG(sf_error_string[8]);             \
	} else if (level == SF_RET_ERR_DATA_NOWRITEABLE){  \
	     SF_PRINT_LOG(sf_error_string[9]);             \
	}                                                  \
	}
#endif