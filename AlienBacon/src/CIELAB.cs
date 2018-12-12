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

namespace AlienBacon
{
	public struct LABColor
	{
		public float Lf;        //[0,100]
		public float af, bf;    //[-128,128]
		public override string ToString()
		{
			return "(" + Lf + ", " + af + ", " + bf + ")";
		}
	}

	public static class CIELAB
	{
		private static Random rand = new Random();

		private const int LOW_RES_SIZE = 200 * 200;

		public static Color[] LABToRGB(LABColor[] labColors)
		{
			Color[] rgbColors = new Color[labColors.Length];

			for (int i = 0; i < labColors.Length; ++i)
				rgbColors[i] = LABToRGB(labColors[i]);

			return rgbColors;
		}

		public static void GetColorClusters(Bitmap bmp, ref LABColor[] colors, ref int[] clusterCount, int numClusters, Action progressCallback)
		{
			Bitmap lowResBmp = BitmapTool.GetLowerResBitmap(bmp, LOW_RES_SIZE);
			if (lowResBmp != null)
			{
				bmp = lowResBmp;
			}

			LABColor[] labPixelData = GetLABPixelData(bmp);

			int numCentroids = numClusters;
			LABColor[] centroids = PickKMeansCentroids(numCentroids, labPixelData);

			int[] labPixelClosestCentroid = new int[labPixelData.Length];
			int[] centroidClusterCount = new int[centroids.Length];

			//initialize closest centroids to -1 (no centroid)
			for (int p = 0; p < labPixelClosestCentroid.Length; ++p)
				labPixelClosestCentroid[p] = -1;

			bool clustersChanged = false;

			do
			{
				Debug.WriteLine("Calculate clusters");
				clustersChanged = CalculateClusterChanges(labPixelData, centroids, labPixelClosestCentroid, centroidClusterCount);
				RecalculateCentroids(labPixelData, centroids, labPixelClosestCentroid, centroidClusterCount);
				progressCallback();
			} while (clustersChanged);

			for (int c = 0; c < numCentroids; ++c)
				Debug.WriteLine(centroids[c] + " clustersize:" + centroidClusterCount[c]);

			float[] LfAvg = new float[numClusters];
			for (int p = 0; p < labPixelData.Length; ++p)
			{
				LfAvg[labPixelClosestCentroid[p]] += labPixelData[p].Lf;
			}

			for (int c = 0; c < numCentroids; ++c)
			{
				if (centroidClusterCount[c] > 0)
				{
					LfAvg[c] /= centroidClusterCount[c];
				}
				centroids[c].Lf = LfAvg[c];
			}

			colors = centroids;
			clusterCount = centroidClusterCount;

			//cleanup
			if (lowResBmp != null)
				lowResBmp.Dispose();
		}

		public static LABColor[] GetLABPixelData(Bitmap bmp)
		{
			LABColor[] labPixelData = new LABColor[bmp.Width * bmp.Height];

			FastBitmap fastBmp = new FastBitmap(bmp);
			fastBmp.LockImage();

			for (int i = 0; i < labPixelData.Length; ++i)
			{
				labPixelData[i] = RGBToLAB(fastBmp.GetPixel());
				fastBmp.NextPixel();
			}

			fastBmp.UnlockImage();
			return labPixelData;
		}

		public static float GetDistanceSq(LABColor c1, LABColor c2)
		{
			float da = c2.af - c1.af;
			float db = c2.bf - c1.bf;
			return da * da + db * db;
		}

		public static LABColor[] GenerateRandomLABColors(int numColors)
		{
			LABColor[] colors = new LABColor[numColors];
			for (int i = 0; i < numColors; ++i)
			{
				colors[i] = new LABColor();
				colors[i].Lf = (float)rand.NextDouble() * 100f;
				colors[i].af = -128f + (float)rand.NextDouble() * 256f;
				colors[i].bf = -128f + (float)rand.NextDouble() * 256f;
			}
			return colors;
		}

		public static LABColor[] PickKMeansCentroids(int numCentroids, LABColor[] dataPoints)
		{
			LABColor[] centroids = new LABColor[numCentroids];

			//Use K-means++ to choose initial centroid values

			//Choose one center uniformly at random from among the data points.
			centroids[0] = dataPoints[(int)(rand.NextDouble() * numCentroids)];

			//For each data point x, compute D(x), the distance between x and the nearest center that has already been chosen.

			float highestD = 0;
			int highestDIndex = 0;

			float[] D = new float[dataPoints.Length];
			for (int d = 0; d < dataPoints.Length; ++d)
			{
				D[d] = GetDistanceSq(centroids[0], dataPoints[d]);
				if (D[d] > highestD)
				{
					highestD = D[d];
					highestDIndex = d;
				}
			}


			//Choose one new data point at random as a new center, using a weighted probability distribution where a point x is chosen with probability proportional to D(x)^2.
			//Repeat until k centers have been chosen.

			//Note: for now, just choose the datapoint with highest D

			for (int c = 1; c < centroids.Length; ++c)
			{
				centroids[c] = dataPoints[highestDIndex];

				//recalculate D's
				highestD = 0;
				highestDIndex = 0;

				for (int d = 0; d < dataPoints.Length; ++d)
				{
					float currD = GetDistanceSq(centroids[c], dataPoints[d]);
					if (currD < D[d])
					{
						D[d] = currD;
						if (D[d] > highestD)
						{
							highestD = D[d];
							highestDIndex = d;
						}
					}
				}

			}

			return centroids;
		}

		public static void RecalculateCentroids(LABColor[] labPixelData, LABColor[] centroids,
			int[] labPixelClosestCentroid, int[] centroidClusterCount)
		{
			for (int c = 0; c < centroids.Length; ++c)
			{
				if (centroidClusterCount[c] != 0)
				{
					centroids[c].af = 0;
					centroids[c].bf = 0;
				}
			}

			for (int p = 0; p < labPixelData.Length; ++p)
			{
				centroids[labPixelClosestCentroid[p]].af += labPixelData[p].af;
				centroids[labPixelClosestCentroid[p]].bf += labPixelData[p].bf;
			}

			for (int c = 0; c < centroids.Length; ++c)
			{
				if (centroidClusterCount[c] != 0)
				{
					centroids[c].af /= centroidClusterCount[c];
					centroids[c].bf /= centroidClusterCount[c];
				}
			}
		}

		public static bool CalculateClusterChanges(LABColor[] labPixelData, LABColor[] centroids,
			int[] labPixelClosestCentroid, int[] centroidClusterCount)
		{
			bool clusterChanged = false;

			for (int c = 0; c < centroidClusterCount.Length; ++c)
				centroidClusterCount[c] = 0;

			for (int p = 0; p < labPixelData.Length; ++p)
			{
				float minCentroidDistance = float.MaxValue;
				int closestCentroid = 0;

				for (int c = 0; c < centroids.Length; ++c)
				{
					float distToCentroid = GetDistanceSq(labPixelData[p], centroids[c]);
					if (distToCentroid < minCentroidDistance)
					{
						minCentroidDistance = distToCentroid;
						closestCentroid = c;
					}
				}

				centroidClusterCount[closestCentroid]++;
				if (labPixelClosestCentroid[p] != closestCentroid)
				{
					clusterChanged = true;
					labPixelClosestCentroid[p] = closestCentroid;
				}
			}
			return clusterChanged;
		}

		//Reference white - D50
		//http://www.brucelindbloom.com/index.html?Eqn_ChromAdapt.html
		private const float Xr = 0.96422f;
		private const float Yr = 1.0f;
		private const float Zr = 0.82521f;

		//CIE L* constants
		//http://www.brucelindbloom.com/index.html?Eqn_XYZ_to_Lab.html
		private const float epsilon = 216 / 24389f;
		private const float k = 24389 / 27f;

		public static Color LABToRGB(LABColor lab)
		{
			int R, G, B;

			// Lab to XYZ
			// http://www.brucelindbloom.com/index.html?Eqn_Lab_to_XYZ.html

			float fy = (lab.Lf + 16) / 116;
			float fz = fy - (lab.bf / 200);
			float fx = (lab.af / 500) + fy;

			float xr = (float)Math.Pow(fx, 3);
			float yr;
			float zr = (float)Math.Pow(fz, 3);

			if (!(xr > epsilon))
				xr = (116 * fx - 16) / k;

			if (lab.Lf > (k * epsilon))
				yr = (float)Math.Pow((lab.Lf + 16) / 116, 3);
			else
				yr = lab.Lf / k;

			if (!(zr > epsilon))
				xr = (116 * fz - 16) / k;

			float X = xr * Xr;
			float Y = yr * Yr;
			float Z = zr * Zr;

			// XYZ to RGB
			// http://www.brucelindbloom.com/index.html?Eqn_XYZ_to_RGB.html

			// XYZ to Linear RGB (v)
			// [v] = [M]^-1[X,Y,Z]
			// [M]^-1: XYZ to sRGB matrix (with D50 ref white):
			// http://www.brucelindbloom.com/index.html?Eqn_RGB_XYZ_Matrix.html

			float vr = 3.1338561f * X - 1.6168667f * Y - 0.4906146f * Z;
			float vg = -0.9787684f * X + 1.9161415f * Y + 0.0334540f * Z;
			float vb = 0.0719453f * X - 0.2289914f * Y + 1.4052427f * Z;

			// sRGB Companding
			// (linear RGB (v) to sRGB (V))
			float Vr, Vg, Vb;

			if (vr <= 0.0031308)
				Vr = 12.92f * vr;
			else
				Vr = 1.055f * (float)Math.Pow(vr, 1 / 2.4f) - 0.055f;

			if (vg <= 0.0031308)
				Vg = 12.92f * vg;
			else
				Vg = 1.055f * (float)Math.Pow(vg, 1 / 2.4f) - 0.055f;

			if (vb <= 0.0031308)
				Vb = 12.92f * vb;
			else
				Vb = 1.055f * (float)Math.Pow(vb, 1 / 2.4f) - 0.055f;

			//Normalize rgb to [0,255]
			R = (int)(Vr * 255);
			G = (int)(Vg * 255);
			B = (int)(Vb * 255);

			if (R > 255)
				R = 255;
			else if (R < 0)
				R = 0;

			if (G > 255)
				G = 255;
			else if (G < 0)
				G = 0;

			if (B > 255)
				B = 255;
			else if (B < 0)
				B = 0;

			return Color.FromArgb(255, R, G, B);
		}

		public static LABColor RGBToLAB(Color rgb)
		{
			LABColor labColor = new LABColor();

			// RGB to XYZ
			// http://www.brucelindbloom.com/index.html?Eqn_RGB_to_XYZ.html

			//Normalize rgb to [0,1]
			float Vr = rgb.R / 255f;
			float Vg = rgb.G / 255f;
			float Vb = rgb.B / 255f;

			//Inverse sRGB Companding
			// (sRGB (V) to linear RGB (v))
			float vr = Vr;
			float vg = Vg;
			float vb = Vb;

			if (vr <= 0.04045)
				vr = vr / 12.92f;
			else
				vr = (float)Math.Pow((vr + 0.055) / 1.055, 2.4);

			if (vg <= 0.04045)
				vg = vg / 12.92f;
			else
				vg = (float)Math.Pow((vg + 0.055) / 1.055, 2.4);

			if (vb <= 0.04045)
				vb = vb / 12.92f;
			else
				vb = (float)Math.Pow((vb + 0.055) / 1.055, 2.4);

			// Linear RGB to XYZ
			// [X,Y,Z] = [M][v]
			// [M]: sRGB to XYZ matrix (with D50 ref white):
			//http://www.brucelindbloom.com/index.html?Eqn_RGB_XYZ_Matrix.html
			float X = 0.4360747f * vr + 0.3850649f * vg + 0.1430804f * vb;
			float Y = 0.2225045f * vr + 0.7168786f * vg + 0.0606169f * vb;
			float Z = 0.0139322f * vr + 0.0971045f * vg + 0.7141733f * vb;

			// XYZ to Lab
			// http://www.brucelindbloom.com/index.html?Eqn_XYZ_to_Lab.html
			float xr = X / Xr;
			float yr = Y / Yr;
			float zr = Z / Zr;

			float fx, fy, fz;

			if (xr > epsilon)
				fx = (float)Math.Pow(xr, 1 / 3f);
			else
				fx = (k * xr + 16f) / 116f;

			if (yr > epsilon)
				fy = (float)Math.Pow(yr, 1 / 3f);
			else
				fy = (k * yr + 16f) / 116f;

			if (zr > epsilon)
				fz = (float)Math.Pow(zr, 1 / 3f);
			else
				fz = (k * zr + 16f) / 116f;

			labColor.Lf = (116 * fy) - 16;
			labColor.af = 500 * (fx - fy);
			labColor.bf = 200 * (fy - fz);

			return labColor;
		}
	}
}
