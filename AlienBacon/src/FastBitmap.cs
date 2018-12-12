/*
 * Copyright (c) 2018 Evan Kale
 * Email: EvanKale91@gmail.com
 * Web: www.youtube.com/EvanKale
 * Social: @EvanKale91
 *
 * This file is part of AlienBeacon.
 *
 * AlienBeacon is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Drawing;
using System.Drawing.Imaging;

namespace AlienBacon
{
	unsafe public class FastBitmap
	{
		public struct Pixel
		{
			public byte b, g, r, a;
		}

		public FastBitmap(Bitmap bmp)
		{
			this.bmp = bmp;
		}

		public void LockImage()
		{
			Rectangle bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
			bmpData = bmp.LockBits(bounds, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			bmpDataPtr = (byte*)bmpData.Scan0.ToPointer();
			currPixel = (Pixel*)bmpDataPtr;
		}

		public void UnlockImage()
		{
			bmp.UnlockBits(bmpData);
			bmpData = null;
			bmpDataPtr = null;
		}

		public Color GetPixel()
		{
			return Color.FromArgb(currPixel->a, currPixel->r, currPixel->g, currPixel->b);
		}

		public void NextPixel()
		{
			++currPixel;
		}

		public Color GetPixel(int x, int y)
		{
			currPixel = (Pixel*)(bmpDataPtr + y * bmp.Width + x * sizeof(Pixel));
			return Color.FromArgb(currPixel->a, currPixel->r, currPixel->g, currPixel->b);
		}

		public void SetPixel(int x, int y, Color color)
		{
			Pixel* pix = (Pixel*)(bmpDataPtr + y * bmp.Width + x * sizeof(Pixel));
			pix->a = color.A;
			pix->r = color.R;
			pix->g = color.G;
			pix->b = color.B;
		}

		public int Width
		{
			get { return bmp.Width; }
		}

		public int Height
		{
			get { return bmp.Height; }
		}

		private Bitmap bmp;
		private BitmapData bmpData;
		private byte* bmpDataPtr;
		private Pixel* currPixel;
	}
}
