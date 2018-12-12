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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AlienBacon
{
	public partial class SaveModal : Form
	{
		public SaveModal(ushort frameDelay, List<Color> previewColors)
		{
			this.frameDelay = frameDelay;
			this.previewColors = previewColors;
			exportChannels = new char[3];


			InitializeComponent();
		}

		private void SaveModal_Load(object sender, EventArgs e)
		{
			MaximizeBox = false;
			MinimizeBox = false;
		}

		private void WriteHeader()
		{
			binWriter.Write(magic1);
			binWriter.Write(magic2);
			binWriter.Write(magic3);
			binWriter.Write(magic4);
			binWriter.Write(frameDelay);
		}

		private void WriteColorsInHSL()
		{
			foreach(Color color in previewColors)
			{
				float[] hsl = new float[3];
				float[] rgb = new float[3];

				for(int i=0; i<3; ++i)
				{
					switch(exportChannels[i])
					{
						case 'R':
							rgb[i] = color.R / 255f;
							break;
						case 'G':
							rgb[i] = color.G / 255f;
							break;
						case 'B':
							rgb[i] = color.B / 255f;
							break;
					}				
				}
				
				ColorModelHSL.RGBtoHSL(rgb, hsl);

				hsl[0] *= 255;
				hsl[1] *= 255;
				hsl[2] *= 255;

				binWriter.Write((byte)hsl[0]);
				binWriter.Write((byte)hsl[1]);
				binWriter.Write((byte)hsl[2]);
			}
		}

		private void exportBtn_Click(object sender, EventArgs e)
		{
			exportChannels[0] = rOutGroup.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text.ToCharArray()[0];
			exportChannels[1] = gOutGroup.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text.ToCharArray()[0];
			exportChannels[2] = bOutGroup.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text.ToCharArray()[0];

			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Color files|*.col";

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Debug.WriteLine(saveFileDialog.FileName);
				binWriter = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create));
				if(binWriter!=null)
				{
					WriteHeader();
					WriteColorsInHSL();
					binWriter.Close();
					MessageBox.Show("File exported!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}			

			Close();			
		}

		private const char magic1 = 'E';
		private const char magic2 = 'K';
		private const char magic3 = 'A';
		private const char magic4 = 'B';

		private BinaryWriter binWriter;
		private ushort frameDelay;
		private List<Color> previewColors;
		private char[] exportChannels;
	}
}
