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

using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AlienBacon
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			MaximizeBox = false;

			defaultPreviewColors = new List<Color>();
			defaultPreviewColors.Add(Color.FromArgb(255, 0, 0, 0));
			SetPreviewColorList(defaultPreviewColors);

			allControls = new List<Control>();
			allControls.Add(saveBtn);
			allControls.Add(playBtn);
			allControls.Add(imgSrcBtn);
			allControls.Add(folderSrcBtn);
			allControls.Add(delayUpDown);

			FormClosing += OnFormClose;
		}

		private void ImageReadThread()
		{
			DisableAllControls();
			SetProgressBar(0);

			LABColor[] labColors = null;
			int[] clusterCount = null;
			const int numClusters = 5;

			CIELAB.GetColorClusters(imageReadBmp, ref labColors, ref clusterCount, numClusters, ImageReadThread_GetColorClustersCallback);
			imageReadBmp.Dispose();

			const int colorClusterProgressCap = 85;
			SetProgressBar(colorClusterProgressCap);

			Color[] rgbColors = CIELAB.LABToRGB(labColors);

			//blend the colors
			List<Color> rgbColorList = new List<Color>();

			const int totalAnimationFrames = 400;
			const int numTransitionFrames = 40;
			int numSolidFrames = totalAnimationFrames - numTransitionFrames * clusterCount.Length;

			int totalClusterCount = 0;
			for (int i = 0; i < clusterCount.Length; ++i)
				totalClusterCount += clusterCount[i];

			for (int i = 0; i < clusterCount.Length; ++i)
			{
				//Add solid frames
				for (int f = 0; f < numSolidFrames; ++f)
					rgbColorList.Add(rgbColors[i]);

				//Add transistion frames
				int ii = i + 1;
				if (ii == clusterCount.Length)
					ii = 0;

				for (int f = 0; f < numTransitionFrames; ++f)
				{
					float percent = (float)f / (numTransitionFrames - 1);
					float r = rgbColors[i].R + percent * (rgbColors[ii].R - rgbColors[i].R);
					float g = rgbColors[i].G + percent * (rgbColors[ii].G - rgbColors[i].G);
					float b = rgbColors[i].B + percent * (rgbColors[ii].B - rgbColors[i].B);
					rgbColorList.Add(Color.FromArgb(255, (int)r, (int)g, (int)b));
				}

				SetProgressBar((int)(colorClusterProgressCap + (100 - colorClusterProgressCap) * ((i + 1f) / clusterCount.Length)));
			}

			SetPreviewColorList(rgbColorList);

			SetProgressBar(100);
			EnableAllControls();
		}

		private void ImageReadThread_GetColorClustersCallback()
		{
			AdvanceProgressBar(5, 85);
		}

		private void FolderReadThread()
		{
			DisableAllControls();
			List<Color> rgbColorList = new List<Color>();

			SetProgressBar(0);

			for (int i = 0; i < folderReadFilenames.Length; ++i)
			{
				Debug.WriteLine(folderReadFilenames[i]);
				Bitmap bmp = null;
				try { bmp = new Bitmap(folderReadFilenames[i]); }
				catch (Exception) { Debug.WriteLine("Could not open " + folderReadFilenames[i]); }

				if (bmp != null)
				{
					Color centerColor = BitmapTool.GetCenterColor(bmp);
					Debug.WriteLine("Color is " + centerColor.R + " " + centerColor.G + " " + centerColor.B);
					rgbColorList.Add(centerColor);
					bmp.Dispose();
				}

				SetProgressBar((int)((i + 1f) / folderReadFilenames.Length * 100));
			}

			SetProgressBar(100);

			if (rgbColorList.Count == 0)
			{
				MessageBox.Show("No images found in selected folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				SetPreviewColorList(rgbColorList);
			}
			EnableAllControls();
		}

		private void PlayPreview()
		{
			playBtn.Text = "Stop";
			isPreviewPlaying = true;

			previewThread = new Thread(new ThreadStart(this.PlayPreviewThread));
			previewThread.Start();
		}

		private void PlayPreviewThread()
		{
			while (isPreviewPlaying)
			{
				SetPreviewColorFrame(currPreviewFrame);

				Thread.Sleep(GetPreviewDelay());

				if (currPreviewFrame >= previewColors.Count - 1)
					currPreviewFrame = 0;
				else
					++currPreviewFrame;
			}
		}

		private void StopPreview()
		{
			playBtn.Text = "Play";
			isPreviewPlaying = false;
		}

		private void SetPreviewColorList(List<Color> colorList)
		{
			if (colorList.Count > 0)
				previewColors = colorList;
			else
				previewColors = defaultPreviewColors;

			SetPreviewColorFrame(0);
		}

		private void SetPreviewColorFrame(int frameIndex)
		{
			if (colorBox.InvokeRequired)
			{
				SetPreviewColorFrameDelegate func = new SetPreviewColorFrameDelegate(SetPreviewColorFrame);
				try { Invoke(func, new object[] { frameIndex }); }
				catch (Exception) { }
			}
			else
			{
				colorBox.BackColor = previewColors[frameIndex];
				colorBox.Update();
			}
			currPreviewFrame = frameIndex;
		}

		private ushort GetPreviewDelay()
		{
			return (ushort)delayUpDown.Value;
		}

		private void DisableAllControls()
		{
			foreach (Control c in allControls)
			{
				SetEnableControl(c, false);
			}
		}

		private void EnableAllControls()
		{
			foreach (Control c in allControls)
			{
				SetEnableControl(c, true);
			}
		}

		private void SetEnableControl(Control control, bool isEnabled)
		{
			if (control.InvokeRequired)
			{
				SetEnableControlDelegate func = new SetEnableControlDelegate(SetEnableControl);
				try { Invoke(func, new object[] { control, isEnabled }); }
				catch (Exception) { }
			}
			else
				control.Enabled = isEnabled;
		}

		private void SetProgressBar(int value)
		{
			if (progressBar.InvokeRequired)
			{
				SetProgressBarDelegate func = new SetProgressBarDelegate(SetProgressBar);
				try { Invoke(func, new object[] { value }); }
				catch (Exception) { }
			}
			else
				progressBar.Value = value;
		}

		private void AdvanceProgressBar(int incrementValue, int capValue)
		{
			if (progressBar.InvokeRequired)
			{
				AdvanceProgressBarDelegate func = new AdvanceProgressBarDelegate(AdvanceProgressBar);
				try { Invoke(func, new object[] { incrementValue, capValue }); }
				catch (Exception) { }
			}
			else
			{
				int newValue = progressBar.Value + incrementValue;
				if (newValue > capValue)
					newValue = capValue;
				progressBar.Value = newValue;
			}
		}

		private void videoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			StopPreview();
			System.Diagnostics.Process.Start("http://youtube.com/evankale");
		}

		private void folderSrcBtn_Click(object sender, EventArgs e)
		{
			StopPreview();

			CommonOpenFileDialog dialog = new CommonOpenFileDialog();

			//dialog.InitialDirectory = Application.StartupPath;
			dialog.IsFolderPicker = true;
			dialog.Title = "Select Folder";

			if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
			{
				Debug.WriteLine("You selected: " + dialog.FileName);
				folderReadFilenames = Directory.GetFiles(dialog.FileName);

				folderReadThread = new Thread(new ThreadStart(this.FolderReadThread));
				folderReadThread.Start();
			}
		}

		private void imgSrcBtn_Click(object sender, EventArgs e)
		{
			StopPreview();

			OpenFileDialog dialog = new OpenFileDialog();

			dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
			//dialog.InitialDirectory = Application.StartupPath;
			dialog.Title = "Select Image";

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				try { imageReadBmp = new Bitmap(dialog.FileName); }
				catch (Exception) { MessageBox.Show("Invalid image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

				if (imageReadBmp != null)
				{
					imageReadThread = new Thread(new ThreadStart(ImageReadThread));
					imageReadThread.Start();
				}
			}
		}

		private void playBtn_Click(object sender, EventArgs e)
		{
			if (isPreviewPlaying)
				StopPreview();
			else
				PlayPreview();
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			StopPreview();
			SaveModal saveModal =  new SaveModal(GetPreviewDelay(), previewColors);
			saveModal.ShowDialog();
		}

		private void OnFormClose(object sender, FormClosingEventArgs e)
		{
			//dirty dirty
			Environment.Exit(0);
		}

		private List<Color> defaultPreviewColors;
		private List<Color> previewColors;
		private int currPreviewFrame;
		private volatile bool isPreviewPlaying;

		private List<Control> allControls;

		private Thread previewThread;
		private Thread folderReadThread;
		private Thread imageReadThread;

		private Bitmap imageReadBmp;
		private string[] folderReadFilenames;

		private delegate void SetPreviewColorFrameDelegate(int frameIndex);
		private delegate void SetEnableControlDelegate(Control control, bool isEnabled);
		private delegate void SetProgressBarDelegate(int value);
		private delegate void AdvanceProgressBarDelegate(int incrementValue, int capValue);
	}
}
