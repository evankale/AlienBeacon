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

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace AlienBacon
{
	public static class BitmapTool
	{
		public static Bitmap GetLowerResBitmap(Bitmap bmp, float numTargetPixels)
		{
			if (bmp.Width * bmp.Height < numTargetPixels)
				return null;

			float ratioWH = (float)bmp.Width / bmp.Height;
			int outputWidth = (int)Math.Sqrt(numTargetPixels * ratioWH);
			int outputHeight = (int)(outputWidth * (1 / ratioWH));

			Bitmap resized = new Bitmap(bmp, new Size(outputWidth, outputHeight));

			return resized;
		}

		public static Color GetCenterColor(Bitmap bmp)
		{
			int regionWidth = bmp.Width / 2;
			int regionHeight = bmp.Height / 2;
			int regionX = (bmp.Width - regionWidth) / 2;
			int regionY = (bmp.Height - regionHeight) / 2;

			BitmapData bmpData = bmp.LockBits(
						new Rectangle(regionX, regionY, regionWidth, regionHeight),
						ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

			long rAvg = 0;
			long gAvg = 0;
			long bAvg = 0;
		
			unsafe
			{
				byte* bmpPtr = (byte*)(void*)bmpData.Scan0;

				for (int y = 0; y < regionHeight; y++)
				{
					for (int x = 0; x < regionWidth; x++)
					{
						int idx = (y * bmpData.Stride) + x * 4;
						bAvg += bmpPtr[idx];
						gAvg += bmpPtr[idx+1];
						rAvg += bmpPtr[idx+2];
					}
				}
			}

			long size = regionWidth * regionHeight;
			rAvg /= size;
			gAvg /= size;
			bAvg /= size;

			bmp.UnlockBits(bmpData);

			return Color.FromArgb(255, (int)rAvg, (int)gAvg, (int)bAvg);
		}

		public static Color GetCenterPixelColor(Bitmap bmp)
		{
			Color pixelColor = bmp.GetPixel(bmp.Width / 2, bmp.Height / 2);
			return Color.FromArgb(255, pixelColor.R, pixelColor.G, pixelColor.B);
		}
	}
}
