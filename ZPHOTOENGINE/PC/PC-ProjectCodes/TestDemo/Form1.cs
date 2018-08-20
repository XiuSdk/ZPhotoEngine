using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using CCWin;

namespace TestDemo
{
    unsafe public partial class Form1 : CCWin.Skin_Mac
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
        }

        #region  V Defination
        //image path
        private String curFileName = null;
        //current image
        private Bitmap curBitmap = null;
        //source image
        private Bitmap srcBitmap = null;
        //zphotoengine instance
        private ZPhotoEngineDll zPhoto = null;

        //temp image for makeup
        public static Bitmap tempBitmap = null;

        private int[] faceInfos;
        private int faceNum = 0;
        private int baseLMLen = 144;
        private int[] landMark;

        #endregion

        #region  Image open and save
        //打开图像函数
        public void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;" +
                   "*.tif; *.ico; *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf|" +
                   "位图( *.bmp; *.jpg; *.png;...) | *.bmp; *.pcx; *.png; *.jpg; *.gif; *.tif; *.ico|" +
                   "矢量图( *.wmf; *.eps; *.emf;...) | *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf";
            ofd.ShowHelp = true;
            ofd.Title = "打开图像文件";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                curFileName = ofd.FileName;
                try
                {
                    curBitmap = (Bitmap)System.Drawing.Image.FromFile(curFileName);

                    if (Math.Max(curBitmap.Width, curBitmap.Height) > 1280)
                    {
                        srcBitmap = new Bitmap(curBitmap, 1280 * curBitmap.Width / Math.Max(curBitmap.Width, curBitmap.Height), 1280 * curBitmap.Height / Math.Max(curBitmap.Width, curBitmap.Height));
                        curBitmap = new Bitmap(srcBitmap);
                    }
                    else
                    {
                        srcBitmap = new Bitmap(curBitmap);
                    }

                }
                catch (Exception exp)
                { MessageBox.Show(exp.Message); }
            }
        }
        //保存图像函数
        public void SaveFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG文件(*.png)|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName, ImageFormat.Png);
            }

        }
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
            // facedetection            
            faceInfos = new int[baseLMLen * 1 + 5]; //
            landMark = new int[baseLMLen];
            string xmlPath = Application.StartupPath.ToString() + "\\model\\";
            if (curBitmap != null)
            {
                pictureBox1.Image = (Image)curBitmap;
                toolStripStatusLabel2.Text = "图像宽高: (" + curBitmap.Width.ToString() + "," + curBitmap.Height.ToString() + ")";
            }
            pictureBox1.Image = curBitmap;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFile();
            }
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://blog.csdn.net/trent1985");
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (srcBitmap != null)
                pictureBox1.Image = srcBitmap;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (curBitmap != null)
                pictureBox1.Image = curBitmap;
        }
        #endregion

        #region Thread for image processing
        //Aysn image process for UI refreshing
        //define delegate for image process.
        public delegate void AysnImageProcessDelegate(int id);
        private bool processing = false;
        private void BeginImageProcess(int id)
        {
            if (processing)
            {
                MessageForm mf = new MessageForm("正在处理中，请稍候！");
                {
                    mf.ShowDialog();
                }
                return;
            }
            this.Invoke((EventHandler)delegate
            {
                toolStripStatusLabel3.Text = "当前进度：正在处理中......";
                toolStripStatusLabel3.BackColor = Color.Red;
                processing = true;
            });
            AysnImageProcessDelegate sysndelegate = new AysnImageProcessDelegate(ImageProcessing);
            sysndelegate.BeginInvoke(id, ImageProcessDone, sysndelegate);
            //return sysndelegate.BeginInvoke(id, ImageProcessDone, sysndelegate);
        }
        private void ImageProcessDone(IAsyncResult result)
        {
            AysnImageProcessDelegate aysnDelegate = result.AsyncState as AysnImageProcessDelegate;
            if (aysnDelegate != null)
            {
                pictureBox1.Image = (Image)curBitmap;
            }
            this.Invoke((EventHandler)delegate
            {
                toolStripStatusLabel3.Text = "当前进度：完成";
                toolStripStatusLabel3.BackColor = Color.Transparent;
                processing = false;
            });
        }
        private void ImageProcessing(int id)
        {
            if (pictureBox1.Image == null)
                return;
            switch (id)
            {
                case ImageProcessId.ID_ROTATE:
                    RotateForm rotate = new RotateForm(curFileName);
                    if (rotate.ShowDialog() == DialogResult.OK)
                    {
                        int degree = rotate.getDegree;
                        curBitmap = zPhoto.TransformRotation(curBitmap, degree, 1, 0);
                    }
                    break;
                case ImageProcessId.ID_ZOOM:
                    ZoomForm zoom = new ZoomForm();
                    if (zoom.ShowDialog() == DialogResult.OK)
                    {
                        float scale = zoom.getScale;
                        curBitmap = zPhoto.TransformScale(curBitmap, scale, 1, 0);
                    }
                    break;
                case ImageProcessId.ID_HMIRROR:
                    curBitmap = zPhoto.TransformMirror(curBitmap, 4);
                    break;
                case ImageProcessId.ID_VMIRROR:
                    curBitmap = zPhoto.TransformMirror(curBitmap, 5);
                    break;
                case ImageProcessId.ID_AUTO_COLORGRADATION:
                    curBitmap = zPhoto.AutoColorGradationAdjust(curBitmap);
                    break;
                case ImageProcessId.ID_AUTO_CONTRAST:
                    curBitmap = zPhoto.AutoContrastAdjust(curBitmap);
                    break;
                case ImageProcessId.ID_HISTAGRAMEQUALIZE:
                    curBitmap = zPhoto.HistagramEqualize(curBitmap);
                    break;
                case ImageProcessId.ID_BRIGHTCONTRAST:
                    BrightContrastForm bc = new BrightContrastForm(curFileName);
                    if (bc.ShowDialog() == DialogResult.OK)
                    {
                        int bright = bc.getBright;
                        int contrast = bc.getContrast;
                        if (bc.getVersion)
                        {
                            curBitmap = zPhoto.NLinearBrightContrastAdjust(curBitmap, bright, contrast, 128);
                        }
                        else
                        {
                            curBitmap = zPhoto.LinearBrightContrastAdjust(curBitmap, bright, contrast, 128);
                        }
                    }
                    break;
                case ImageProcessId.ID_COLORLEVEL:
                    LevelForm form = new LevelForm(curFileName);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int lInput = form.getLeftInput;
                        double mInput = form.getMidInput;
                        int rInput = form.getRightInput;
                        int lOutput = form.getLeftOutput;
                        int rOutput = form.getRightOutput;
                        int channel = form.getChannel;
                        curBitmap = zPhoto.ColorLevelProcess(curBitmap, channel, lInput, (float)mInput, rInput, lOutput, rOutput);
                    }
                    break;
                case ImageProcessId.ID_HSL:
                    HSLForm hsl = new HSLForm(curFileName);
                    if (hsl.ShowDialog() == DialogResult.OK)
                    {
                        int h = hsl.getHue;
                        int s = hsl.getSaturation;
                        int l = hsl.getLightness;
                        curBitmap = zPhoto.HueSaturationAdjust(curBitmap, h, s);
                        curBitmap = zPhoto.LightnessAdjustProcess(curBitmap, l);

                    }
                    break;
                case ImageProcessId.ID_COLORBALANCE:
                    ColorbalanceForm corB = new ColorbalanceForm(curFileName);
                    if (corB.ShowDialog() == DialogResult.OK)
                    {
                        int cyan = corB.getCyan;
                        int magenta = corB.getMagenta;
                        int yellow = corB.getYellow;
                        curBitmap = zPhoto.ColorBalanceProcess(curBitmap, cyan, magenta, yellow, 0, corB.getLum);
                    }
                    break;
                case ImageProcessId.ID_INVERT:
                    curBitmap = zPhoto.Invert(curBitmap);
                    break;
                case ImageProcessId.ID_POSTERIZE:
                    PosterizeForm poster = new PosterizeForm(curFileName);
                    if (poster.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.Posterize(curBitmap, poster.getLevelNum);
                    }
                    break;
                case ImageProcessId.ID_THRESHOLD:
                    ThresholdForm threForm = new ThresholdForm(curFileName);
                    if (threForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.Threshold(curBitmap, threForm.getThresold);
                    }
                    break;
                case ImageProcessId.ID_DESATURATE:
                    curBitmap = zPhoto.Desaturate(curBitmap);
                    break;
                case ImageProcessId.ID_HIGHLIGHTSHADOW:
                    HighlightShadowForm hsform = new HighlightShadowForm(curFileName);
                    if (hsform.ShowDialog() == DialogResult.OK)
                    {
                        int shadow = hsform.getShadow;
                        int highlight = hsform.getHighlight;
                        curBitmap = zPhoto.HighlightShadowPreciseAdjustProcess(curBitmap, highlight, shadow);
                        //Bitmap tmp = zPhoto.ShadowAdjust(curBitmap, shadow, 100);
                        //curBitmap = zPhoto.HighlightAdjust(tmp, highlight, 100);
                    }
                    break;
                case ImageProcessId.ID_EXPOSURE:
                    ExposureForm eform = new ExposureForm(curFileName);
                    if (eform.ShowDialog() == DialogResult.OK)
                    {
                        int intensity = eform.getIntensity;
                        curBitmap = zPhoto.ExposureAdjust(curBitmap, intensity);
                    }
                    break;
                case ImageProcessId.ID_COLORTEMPEATURE:
                    TempreatureForm teform = new TempreatureForm(curFileName);
                    if (teform.ShowDialog() == DialogResult.OK)
                    {
                        int intensity = teform.getTempeature;
                        curBitmap = zPhoto.ColorTemperatureProcess(curBitmap, intensity);
                    }
                    break;
                case ImageProcessId.ID_FINDEDGES:
                    curBitmap = zPhoto.FindEdgesProcess(curBitmap);
                    break;
                case ImageProcessId.ID_RELIEF:
                    ReliefForm rform = new ReliefForm(curFileName);
                    if (rform.ShowDialog() == DialogResult.OK)
                    {
                        int angle = rform.getAngle;
                        int amount = rform.getAmount;
                        curBitmap = zPhoto.Relief(curBitmap, angle, amount);
                    }
                    break;
                case ImageProcessId.ID_DIFUSSION:
                    DifussionForm dform = new DifussionForm(curFileName);
                    if (dform.ShowDialog() == DialogResult.OK)
                    {
                        int intensity = dform.getIntensity;
                        curBitmap = zPhoto.DiffusionProcess(curBitmap, intensity);
                    }
                    break;
                case ImageProcessId.ID_OVEREXPOSURE:
                    curBitmap = zPhoto.OverExposure(curBitmap);
                    break;
                case ImageProcessId.ID_SURFACEBLUR:
                    SurfaceBlurForm srform = new SurfaceBlurForm(curFileName);
                    if (srform.ShowDialog() == DialogResult.OK)
                    {
                        int radius = srform.getRadius;
                        int threshold = srform.getThreshld;
                        curBitmap = zPhoto.SurfaceBlur(curBitmap, threshold, radius);
                    }
                    break;
                case ImageProcessId.ID_MOTIONBLUR:
                    MotionBlurForm moform = new MotionBlurForm(curFileName);
                    if (moform.ShowDialog() == DialogResult.OK)
                    {
                        int angle = moform.getAngle;
                        int distance = moform.getDistance;
                        curBitmap = zPhoto.MotionBlur(curBitmap, angle, distance);
                    }
                    break;
                case ImageProcessId.ID_MEANBLUR:
                    MeanBlurForm meform = new MeanBlurForm(curFileName);
                    if (meform.ShowDialog() == DialogResult.OK)
                    {
                        int radius = meform.getRadius;
                        curBitmap = zPhoto.MeanFilterProcess(curBitmap, radius);
                    }
                    break;
                case ImageProcessId.ID_GAUSSBLUR:
                    GaussBlurForm gauform = new GaussBlurForm(curFileName);
                    if (gauform.ShowDialog() == DialogResult.OK)
                    {
                        double radius = gauform.getRadius;
                        curBitmap = zPhoto.GaussFilterProcess(curBitmap, (float)radius);
                    }
                    break;
                case ImageProcessId.ID_RADIAL:
                    RadialBlurForm raform = new RadialBlurForm(curFileName);
                    if (raform.ShowDialog() == DialogResult.OK)
                    {
                        int amount = raform.getAmount;
                        curBitmap = zPhoto.RadialBlurProcess(curBitmap, amount);
                    }
                    break;
                case ImageProcessId.ID_ZOOMBLUR:
                    ZoomBlurForm zoomform = new ZoomBlurForm(curFileName);
                    if (zoomform.ShowDialog() == DialogResult.OK)
                    {
                        int amount = zoomform.getAmount;
                        int radius = zoomform.getRadius;
                        curBitmap = zPhoto.ZoomBlurProcess(curBitmap, radius, amount);
                    }
                    break;
                case ImageProcessId.ID_MEAN:
                    curBitmap = zPhoto.MeanProcess(curBitmap);
                    break;
                case ImageProcessId.ID_MOSCIA:
                    MosciaForm mosciaform = new MosciaForm(curFileName);
                    if (mosciaform.ShowDialog() == DialogResult.OK)
                    {
                        int blockSize = mosciaform.getBlocksize;
                        curBitmap = zPhoto.MosaicProcess(curBitmap, blockSize);
                    }
                    break;
                case ImageProcessId.ID_FRAGMENT:
                    curBitmap = zPhoto.Fragment(curBitmap);
                    break;
                case ImageProcessId.ID_HIGHPASS:
                    HighpassForm hpform = new HighpassForm(curFileName);
                    if (hpform.ShowDialog() == DialogResult.OK)
                    {
                        double radius = hpform.getRadius;
                        curBitmap = zPhoto.HighPassProcess(curBitmap, (float)radius);
                    }
                    break;
                case ImageProcessId.ID_USM:
                    USMForm usmform = new USMForm(curFileName);
                    if (usmform.ShowDialog() == DialogResult.OK)
                    {
                        double radius = usmform.getRadius;
                        int amount = usmform.getAmount;
                        int threshold = usmform.getThreshold;
                        curBitmap = zPhoto.USMProcess(curBitmap, (float)radius, amount, threshold);
                    }
                    break;
                case ImageProcessId.ID_CHANNELMIXER:
                    ChannelMixForm cmform = new ChannelMixForm(curFileName);
                    if (cmform.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = new Bitmap(cmform.getResImage);
                    }
                    break;
                case ImageProcessId.ID_BLACKWHITE:
                    BlackWhiteForm whform = new BlackWhiteForm(curFileName);
                    if (whform.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.BlackwhiteProcess(curBitmap, whform.getKRed, whform.getKGreen, whform.getKBlue, whform.getKYellow, whform.getKCyan, whform.getKMagenta);
                    }
                    break;
                case ImageProcessId.ID_GAMMA:
                    GammaForm gammaForm = new GammaForm(curFileName);
                    if (gammaForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.GammaCorrectProcess(curBitmap, gammaForm.getGamma);
                    }
                    break;
                case ImageProcessId.ID_MEDIANFILTER:
                    MedianForm medianForm = new MedianForm(curFileName);
                    if (medianForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.MedianFilterProcess(curBitmap, medianForm.getRadius);
                    }
                    break;
                case ImageProcessId.ID_MAXFILTER:
                    MaxForm maxForm = new MaxForm(curFileName);
                    if (maxForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.MaxFilterProcess(curBitmap, maxForm.getRadius);
                    }
                    break;
                case ImageProcessId.ID_MINFILTER:
                    MinForm minForm = new MinForm(curFileName);
                    if (minForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.MinFilterProcess(curBitmap, minForm.getRadius);
                    }
                    break;
                case ImageProcessId.ID_NATURALSATURATION:
                    NSaturationForm nsatForm = new NSaturationForm(curFileName);
                    if (nsatForm.ShowDialog() == DialogResult.OK)
                    {
                        curBitmap = zPhoto.NaturalSaturationProcess(curBitmap, nsatForm.getSaturation);
                    }
                    break;
                case ImageProcessId.ID_IMAGEWARP_WAVE:
                    curBitmap = zPhoto.ImageWarpWaveProcess(curBitmap, 60);
                    /////////////////////////////////////////////////////////
                    
                    break;
                case ImageProcessId.ID_SMARTBLUR:
                    SmartBlurForm sbform = new SmartBlurForm(curFileName);
                    if (sbform.ShowDialog() == DialogResult.OK)
                    {
                        int radius = sbform.getRadius;
                        int threshold = sbform.getThreshld;
                        curBitmap = zPhoto.SmartBlurProcess(curBitmap, radius, threshold);
                    }
                    break;
                case ImageProcessId.ID_DISPLACEMENTFILTER:
                    DisplacementFrom displacementform = new DisplacementFrom();
                    if (displacementform.ShowDialog() == DialogResult.OK)
                    {
                        string mskPath = displacementform.getMaskPath;
                        int hRatio = displacementform.getHRatio;
                        int vRatio = displacementform.getVRatio;
                        try
                        {
                            curBitmap = zPhoto.DisplacementFilter(curBitmap, new Bitmap(mskPath), hRatio, vRatio);
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show("Please check input params!");
                        }
                    }
                    break;
                case ImageProcessId.ID_NOISEEFFECT:
                    curBitmap = zPhoto.NoiseEffect(curBitmap, 100, 0.5f, 50.0f);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region UI response
        private void 图像旋转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_ROTATE);
        }

        private void 恢复原图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curFileName != null)
            {
                curBitmap = new Bitmap(curFileName);
                pictureBox1.Image = (Image)curBitmap;
            }
        }

        private void 图像缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_ZOOM);
        }


        private void 水平翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HMIRROR);
        }

        private void 垂直翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_VMIRROR);
        }

        private void 自动色调ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_AUTO_COLORGRADATION);
        }

        private void 自动对比度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_AUTO_CONTRAST);
        }

        private void 色调均化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HISTAGRAMEQUALIZE);
        }

        private void 亮度对比度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_BRIGHTCONTRAST);
        }

        private void 色阶ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_COLORLEVEL);
        }

        private void 色相饱和度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HSL);
        }

        private void 色彩平衡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_COLORBALANCE);
        }

        private void 反相ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_INVERT);
        }

        private void 色调分离ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_POSTERIZE);
        }

        private void 阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_THRESHOLD);
        }
        private void 去色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_DESATURATE);
        }

        private void 高光阴影调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HIGHLIGHTSHADOW);
        }

        private void 曝光调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_EXPOSURE);
        }

        private void 色温调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_COLORTEMPEATURE);
        }

        private void 查找边缘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_FINDEDGES);
        }

        private void 浮雕效果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_RELIEF);
        }

        private void 扩散ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_DIFUSSION);
        }

        private void 曝光过度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_OVEREXPOSURE);
        }

        private void 表面模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_SURFACEBLUR);
        }

        private void 动感模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MOTIONBLUR);
        }

        private void 均值模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MEANBLUR);
        }

        private void 高斯模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_GAUSSBLUR);
        }

        private void 旋转模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_RADIAL);
        }

        private void 缩放模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_ZOOMBLUR);
        }

        private void 平均ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MEAN);
        }

        private void 马赛克ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MOSCIA);
        }

        private void 碎片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_FRAGMENT);
        }

        private void 高反差保留ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_HIGHPASS);
        }

        private void uSM锐化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_USM);
        }
        private void 通道混合器ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_CHANNELMIXER);

        }

        private void 黑白ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_BLACKWHITE);
        }
        private void 直方图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                HistagramForm form = new HistagramForm(curFileName);
                form.Show();
            }
        }
        private void gamma调节ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_GAMMA);
        }
        private void 中间色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MEDIANFILTER);
        }

        private void 最大值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MAXFILTER);
        }

        private void 最小值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_MINFILTER);
        }

        private void waveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_IMAGEWARP_WAVE);
        }

        private void 自然饱和度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_NATURALSATURATION);
        }
        private void smartBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_SMARTBLUR);
        }
        #endregion

        private void anisotropicFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_ANISOTROPICFILTER);
        }

        private void 置换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_DISPLACEMENTFILTER);
        }

        private void 噪声ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginImageProcess(ImageProcessId.ID_NOISEEFFECT);
        }






    }
}
