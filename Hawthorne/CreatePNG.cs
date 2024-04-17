using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Resources;
using System.IO;
using UnityEngine;
using System.ComponentModel;

namespace Hawthorne
{
    public static class CreatePNG
    {
        public static Color32 blank = new Color32(255, 255, 255, 0);
        /*static void Test()
        {
            // Load the source image file
            using (Merger merger = new Merger(@"c:\sample1.png"))
            {
                // Define image join options with horizontal join mode
                ImageJoinOptions joinOptions = new ImageJoinOptions(ImageJoinMode.Horizontal);
                // Add another image file to merge
                merger.Join(@"c:\sample2.png", joinOptions);
                // Add next image file to merge
                merger.Join(@"c:\sample3.png", joinOptions);
                // Merge image files and save result
                merger.Save(@"c:\merged.png");
            }
        }*/
        /*static void TestTwo()
        {
            var fileNames = new List<string> { "Input1.png", "Input2.png" };

            var doc = new Document();
            var builder = new DocumentBuilder(doc);

            var shapes = fileNames.Select(fileName => builder.InsertImage(fileName)).ToList();

            // Calculate the maximum width and height and update page settings 
            // to crop the document to fit the size of the pictures.
            PageSetup pageSetup = builder.PageSetup;
            pageSetup.PageWidth = shapes.Max(shape => shape.Width);
            pageSetup.PageHeight = shapes.Sum(shape => shape.Height);
            pageSetup.TopMargin = 0;
            pageSetup.LeftMargin = 0;
            pageSetup.BottomMargin = 0;
            pageSetup.RightMargin = 0;

            doc.Save("Output.png");
        }*/
        /*public static Bitmap CombineBitmap(string[] files)
        {
            //read all images into memory
            List<Bitmap> images = new List<Bitmap>();
            Bitmap finalImage = null;

            try
            {
                int width = 0;
                int height = 0;

                foreach (string image in files)
                {
                    //create a Bitmap from the file and add it to the list
                    //Bitmap bitmap = new Bitmap(image);

                    //ResourceManager rm = Properties.Resources.ResourceManager;
                    //Bitmap bitmap = (Bitmap)rm.GetObject("myImage");

                    MemoryStream mem = null;
                    try
                    {
                        mem = ResourceLoader.LoadMemory(image);
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError("failed to do silly image things: " + image);
                        Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
                    }
                    if (mem == null) continue;
                    Bitmap bitmap = new Bitmap(mem);

                    //update the size of the final bitmap
                    width += bitmap.Width;
                    height = bitmap.Height > height ? bitmap.Height : height;

                    images.Add(bitmap);
                }

                //create a bitmap to hold the combined image
                finalImage = new Bitmap(width, height);

                //get a graphics object from the image so we can draw on it
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                {
                    //set background color
                    g.Clear(System.Drawing.Color.White);

                    //go through each image and draw it on the final image
                    int offset = 0;
                    foreach (Bitmap image in images)
                    {
                        g.DrawImage(image,
                          new Rectangle(offset, 0, image.Width, image.Height));
                        offset += image.Width;
                    }
                }

                return finalImage;
            }
            catch (Exception ex)
            {
                if (finalImage != null)
                    finalImage.Dispose();

                throw ex;
            }
            finally
            {
                //clean up memory
                foreach (Bitmap image in images)
                {
                    image.Dispose();
                }
            }
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public static void SaveMultiImageTest(string[] files)
        {
            Bitmap ret = CombineBitmap(files);
            if (!Directory.Exists(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\"))
            {
                Directory.CreateDirectory(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\");
            }
            ret.Save(BepInEx.Paths.BepInExRootPath + "\\plugins\\SaltsPages\\Temp.png", ImageFormat.Png);
        }*/
        public static Texture2D CombineTexRow(Texture2D[] textures, bool keep = false)
        {
            int maxheight = 0;
            int totallength = 0;

            foreach (Texture2D t in textures)
            {
                try
                {
                    t.GetPixels(0, 0, 1, 1);
                }
                catch
                {
                    Debug.LogWarning("texture not readable");
                    continue;
                }
                if (t.height > maxheight) maxheight = t.height;
                totallength += t.width;
            }
            Texture2D ret = new Texture2D(totallength, maxheight);
            Color32[] empty = new Color32[ret.width * ret.height];
            for (int i = 0; i < empty.Length; i++) empty[i] = blank;
            ret.SetPixels32(empty);
            int index = 0;
            foreach (Texture2D t in textures)
            {
                try
                {
                    UnityEngine.Color[] cells = t.GetPixels(0, 0, t.width, t.height);
                    ret.SetPixels(index, maxheight - t.height, t.width, t.height, cells);
                    index += t.width;
                }
                catch
                {
                    Debug.LogError("combine horizontal failure");
                    continue;
                }
            }
            if (!keep)
            {
                for (int i = 0; i < textures.Length; i++)
                {
                    UnityEngine.Object.Destroy(textures[i]);
                }
            }
            ret.Apply();
            return ret;
        }
        public static Texture2D CombineTexColumn(Texture2D[] textures, bool keep = false)
        {
            int maxwidth = 0;
            int totalheight = 0;

            foreach (Texture2D t in textures)
            {
                try
                {
                    t.GetPixels(0, 0, 1, 1);
                }
                catch
                {
                    Debug.LogWarning("texture not readable");
                    continue;
                }
                if (t.width > maxwidth) maxwidth = t.width;
                totalheight += t.height;
            }
            Texture2D ret = new Texture2D(maxwidth, totalheight);
            Color32[] empty = new Color32[ret.width * ret.height];
            for (int i = 0; i < empty.Length; i++) empty[i] = blank;
            ret.SetPixels32(empty);
            int index = ret.height;
            foreach (Texture2D t in textures)
            {
                try
                {
                    UnityEngine.Color[] cells = t.GetPixels(0, 0, t.width, t.height);
                    ret.SetPixels(0, index - t.height, t.width, t.height, cells);
                    index -= t.height;
                }
                catch
                {
                    Debug.LogError("combine vertical failure");
                    continue;
                }
            }
            if (!keep)
            {
                for (int i = 0; i < textures.Length; i++)
                {
                    UnityEngine.Object.Destroy(textures[i]);
                }
            }
            ret.Apply();
            return ret;
        }
        public static Texture2D AttachTexture(bool minimum, Texture2D bottom, Texture2D top, bool deletebottom = true, bool deletetop = false)
        {
            int width = minimum ? Math.Min(bottom.width, top.width) : Math.Max(bottom.width, top.width);
            int height = minimum ? Math.Min(bottom.height, top.height) : Math.Max(bottom.height, top.height);
            UnityEngine.Color[][] full = new UnityEngine.Color[height][];
            for (int i = 0; i < height; i++)
            {
                UnityEngine.Color[] ret = new UnityEngine.Color[width];
                UnityEngine.Color[] bot = bottom.height > i ? bottom.GetPixels(0, bottom.height - (i + 1), bottom.width, 1) : new UnityEngine.Color[0];
                UnityEngine.Color[] t = top.height > i ? top.GetPixels(0, top.height - (i + 1), top.width, 1) : new UnityEngine.Color[0];
                int index = 0;
                for (int j = 0; j < bot.Length && j < t.Length; j++)
                {
                    if (((Color32)t[j]).a >= 230) ret[j] = t[j];
                    else if (((Color32)t[j]).a > 30)
                    {
                        Color32 b = bot[j];
                        Color32 to = t[j];
                        Color32 newer = new Color32((byte)Math.Ceiling(((float)(int)b.r + (float)(int)to.r) / 2.0f), (byte)Math.Ceiling(((float)(int)b.g + (float)(int)to.g) / 2.0f), (byte)Math.Ceiling(((float)(int)b.b + (float)(int)to.b) / 2.0f), (byte)Math.Min((float)(int)b.a + (float)(int)to.a, 255));
                        ret[j] = newer;
                    }
                    else ret[j] = bot[j];
                    index = j;
                }
                for (int b = index; b < width; b++)
                {
                    ret[b] = bot.Length > b ? bot[b] : (t.Length > b ? t[b] : new Color32(255, 255, 255, 0));
                }
                full[height - (i + 1)] = ret;
            }
            Texture2D final = new Texture2D(width, height);
            Color32[] empty = new Color32[final.width * final.height];
            for (int i = 0; i < empty.Length; i++) empty[i] = blank;
            final.SetPixels32(empty);
            for (int i = 0; i < full.Length; i++)
            {
                final.SetPixels(0, i, width, 1, full[i]);
            }
            if (deletebottom) UnityEngine.Object.Destroy(bottom);
            if (deletetop) UnityEngine.Object.Destroy(top);
            final.Apply();
            return final;
        }
        public static void WriteToPagesFolder(Texture2D tex,  string name, bool keep = false)
        {
            byte[] bytes = ImageConversion.EncodeToPNG(tex);
            if (!keep) UnityEngine.Object.Destroy(tex);
            if (!Directory.Exists(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\"))
            {
                Directory.CreateDirectory(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\");
            }
            File.WriteAllBytes(BepInEx.Paths.BepInExRootPath + "\\plugins\\" + "SaltsPages\\" + name, bytes);
        }
    }
}
