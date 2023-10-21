using System;
using static System.Net.Mime.MediaTypeNames;

public class ImageToAdTransformer
{
	public Transformer()
	{
        Image imageBackground = Image.FromFile("ad template 1.png");
        Image imageOverlay = Image.FromFile("spam.png");

        Image img = new Bitmap(imageBackground.Width, imageBackground.Height);
        using (Graphics gr = Graphics.FromImage(img))
        {
            gr.DrawImage(imageBackground, new Point(0, 0));
            gr.DrawImage(imageOverlay, new Point(0, 0));
        }
        img.Save("output.png", ImageFormat.Png);
    }
}
