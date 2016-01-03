using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class ImageResize
    {
        public ImageResize()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void Resize1(string DirectoryName, string FileName, bool DeleteAfterResize, string SavedFileName, int Width, int Hieght)
        {
            System.Drawing.Image NormalImg = System.Drawing.Image.FromFile(DirectoryName + "/" + FileName);
            System.Drawing.Image.GetThumbnailImageAbort dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image thumbNailImg = NormalImg.GetThumbnailImage(Width, Hieght, dummyCallBack, IntPtr.Zero);
            thumbNailImg.Save(DirectoryName + "/" + SavedFileName);
            NormalImg.Dispose();
            thumbNailImg.Dispose();
            if (DeleteAfterResize)
            {
                System.IO.File.Delete(DirectoryName + "/" + FileName);
            }
        }


        public bool ThumbnailCallback()
        {
            return false;
        }
    }
