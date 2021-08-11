using Occlusion_voice_chat.Opus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.HRTF
{
    public static class HRTF
    {
		/// <summary>
		/// Checks if this library has HRTF filters matching the given settings.
		/// </summary>
		/// <param name="azimuth"></param>
		/// <param name="elevation"></param>
		/// <param name="samplerate"></param>
		/// <param name="diffused"></param>
		/// <returns>0 if no matching HRTFs where found, or the number of taps of a matching HRTF if found.</returns>
		public static int mit_hrtf_availability(int azimuth, int elevation, int samplerate)
		{
			if (azimuth > 180 || azimuth < -180 || elevation > 90 || elevation < -40)
			{
				return 0;
			}

			switch (samplerate)
			{
				case 44100: return HRTFFilter.MIT_HRTF_44_TAPS;
				case 48000: return HRTFFilter.MIT_HRTF_48_TAPS;
				case 88200: return HRTFFilter.MIT_HRTF_88_TAPS;
				case 96000: return HRTFFilter.MIT_HRTF_96_TAPS;
			}

			return 0;
		}

		/// <summary>
		/// Returns a reference for the given number.
		/// </summary>
		/// <param name="num"></param>
		/// <returns></returns>
		public static unsafe short* NumPtr(short num)
        {
			return &num;
        }

		/// <summary>
		/// Returns a reference for the given number.
		/// </summary>
		/// <param name="num"></param>
		/// <returns></returns>
		public static unsafe int* NumPtr(int num)
		{
			return &num;
		}

		public static int mit_hrtf_get(ref int pAzimuth, ref int pElevation, int samplerate, int diffused, ref double[] pLeft, ref double[] pRight)
		{
			// Stash local copies of azimuth and elevation
			int localAzimuth = pAzimuth;
			int localElevation = pElevation;

			// Check if the requested HRTF exists
			if (mit_hrtf_availability(localAzimuth, localElevation, samplerate) == 0)
			{
				return 0;
			}

			// Snap elevation to the nearest available elevation in the filter set
			if (localElevation < 0)
			{
				localElevation = ((localElevation - 5) / 10) * 10;
			}
			else
			{
				localElevation = ((localElevation + 5) / 10) * 10;
			}

			// Elevation of 50 has a maximum 176 in the azimuth plane so we need to handle that.
			if (localElevation == 50)
			{
				if (localAzimuth < 0)
				{
					localAzimuth = localAzimuth < -176 ? -176 : localAzimuth;
				}
				else
				{
					localAzimuth = localAzimuth > 176 ? 176 : localAzimuth;
				}
			}

			// Snap azimuth to the nearest available azimuth in the filter set.
			float azimuthIncrement = 0;
			switch (localElevation)
			{
				case 0: azimuthIncrement = 180f / (HRTFFilter.MIT_HRTF_AZI_POSITIONS_00 - 1); break;  // 180 5
				case 10:
				case -10: azimuthIncrement = 180f / (HRTFFilter.MIT_HRTF_AZI_POSITIONS_10 - 1); break;    // 180 5
				case 20:
				case -20: azimuthIncrement = 180f / (HRTFFilter.MIT_HRTF_AZI_POSITIONS_20 - 1); break;    // 180 5
				case 30:
				case -30: azimuthIncrement = 180f / (HRTFFilter.MIT_HRTF_AZI_POSITIONS_30 - 1); break;    // 180 6
				case 40:
				case -40: azimuthIncrement = 180f / (HRTFFilter.MIT_HRTF_AZI_POSITIONS_40 - 1); break;    // 180 6.43
				case 50: azimuthIncrement = 176f / (HRTFFilter.MIT_HRTF_AZI_POSITIONS_50 - 1); break; // 176 8
				case 60: azimuthIncrement = 180f / (HRTFFilter.MIT_HRTF_AZI_POSITIONS_60 - 1); break; // 180 10
				case 70: azimuthIncrement = 180f / (HRTFFilter.MIT_HRTF_AZI_POSITIONS_70 - 1); break; // 180 15
				case 80: azimuthIncrement = 180f / (HRTFFilter.MIT_HRTF_AZI_POSITIONS_80 - 1); break; // 180 30
				case 90: azimuthIncrement = 0; break;   // 0   1
			};

			int swapLeftRight = 0;
			if (localAzimuth < 0)
			{
				localAzimuth = (int)((int)((-localAzimuth + azimuthIncrement / 2f) / azimuthIncrement) * azimuthIncrement + 0.5f);
				swapLeftRight = 1;
			}
			else
			{
				localAzimuth = (int)((int)((localAzimuth + azimuthIncrement / 2f) / azimuthIncrement) * azimuthIncrement + 0.5f);
			}

			// Determine array index for azimuth based on elevation
			int azimuthIndex = 0;
			switch (localElevation)
			{
				case 0: azimuthIndex = (int)((localAzimuth / 180f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_00 - 1)); break;
				case 10:
				case -10: azimuthIndex = (int)((localAzimuth / 180f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_10 - 1)); break;
				case 20:
				case -20: azimuthIndex = (int)((localAzimuth / 180f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_20 - 1)); break;
				case 30:
				case -30: azimuthIndex = (int)((localAzimuth / 180f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_30 - 1)); break;
				case 40:
				case -40: azimuthIndex = (int)((localAzimuth / 180f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_40 - 1)); break;
				case 50: azimuthIndex = (int)((localAzimuth / 176f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_50 - 1)); break;
				case 60: azimuthIndex = (int)((localAzimuth / 180f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_60 - 1)); break;
				case 70: azimuthIndex = (int)((localAzimuth / 180f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_70 - 1)); break;
				case 80: azimuthIndex = (int)((localAzimuth / 180f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_80 - 1)); break;
				case 90: azimuthIndex = (int)((localAzimuth / 180f) * (HRTFFilter.MIT_HRTF_AZI_POSITIONS_90 - 1)); break;
			};

			// The azimuths for +/- elevations need special handling
			if (localElevation == 40 || localElevation == -40)
			{
				localAzimuth = mit_hrtf_findAzimuthFor40Elev(localAzimuth);
				azimuthIndex = mit_hrtf_findIndexFor40Elev(localAzimuth);
			}

			// Assign pointer to appropriate array depending on sample rate, normal or diffused filters, elevation, and azimuth index.
			unsafe
			{
				short* pLeftTaps = NumPtr((short)0);
				short* pRightTaps = NumPtr((short)0);
				int totalTaps = 0;

				/*mit_hrtf_filter_set_44 pFilter44;
				mit_hrtf_filter_set_48 FilterSets.CachedNormal48;
				mit_hrtf_filter_set_88 FilterSets.CachedNormal88;
				mit_hrtf_filter_set_96 FilterSets.CachedNormal96;*/


				switch (samplerate)
				{



					case 44100:
						//pFilter44 = diffused != 0 ? diffuse_44 : normal_44;


						switch (localElevation)
						{
							case -10:

								mit_hrtf_filter_44[] filter0 = FilterSets.CachedNormal44.e_10;

								fixed(short* leftArray = filter0[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter0[azimuthIndex].right)
									pRightTaps = rightArray;

								break;
							case -20:
								mit_hrtf_filter_44[] filter1 = FilterSets.CachedNormal44.e_20;

								fixed (short* leftArray = filter1[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter1[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case -30:
								mit_hrtf_filter_44[] filter2 = FilterSets.CachedNormal44.e_30;

								fixed (short* leftArray = filter2[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter2[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case -40:
								mit_hrtf_filter_44[] filter3 = FilterSets.CachedNormal44.e_40;

								fixed (short* leftArray = filter3[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter3[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 0:
								mit_hrtf_filter_44[] filter4 = FilterSets.CachedNormal44.e00;

								fixed (short* leftArray = filter4[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter4[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 10:
								mit_hrtf_filter_44[] filter5 = FilterSets.CachedNormal44.e10;

								fixed (short* leftArray = filter5[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter5[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 20:
								mit_hrtf_filter_44[] filter6 = FilterSets.CachedNormal44.e20;

								fixed (short* leftArray = filter6[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter6[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 30:
								mit_hrtf_filter_44[] filter7 = FilterSets.CachedNormal44.e30;

								fixed (short* leftArray = filter7[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter7[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 40:
								mit_hrtf_filter_44[] filter8 = FilterSets.CachedNormal44.e40;

								fixed (short* leftArray = filter8[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter8[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 50:
								mit_hrtf_filter_44[] filter9 = FilterSets.CachedNormal44.e50;

								fixed (short* leftArray = filter9[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter9[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 60:
								mit_hrtf_filter_44[] filter10 = FilterSets.CachedNormal44.e60;

								fixed (short* leftArray = filter10[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter10[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 70:
								mit_hrtf_filter_44[] filter11 = FilterSets.CachedNormal44.e70;

								fixed (short* leftArray = filter11[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter11[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 80:
								mit_hrtf_filter_44[] filter12 = FilterSets.CachedNormal44.e80;

								fixed (short* leftArray = filter12[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter12[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 90:
								mit_hrtf_filter_44[] filter13 = FilterSets.CachedNormal44.e90;

								fixed (short* leftArray = filter13[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter13[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
						};

						// How many taps to copy later to user's buffers
						totalTaps = HRTFFilter.MIT_HRTF_44_TAPS;
						break;


					case 48000:
						var hrtf48Filter = diffused != 0 ? FilterSets.CachedNormal48Diffuse : FilterSets.CachedNormal48;

						switch (localElevation)
						{
							case -10:

								mit_hrtf_filter_48[] filter0 = hrtf48Filter.e_10;

								fixed (short* leftArray = filter0[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter0[azimuthIndex].right)
									pRightTaps = rightArray;

								break;
							case -20:
								mit_hrtf_filter_48[] filter1 = hrtf48Filter.e_20;

								fixed (short* leftArray = filter1[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter1[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case -30:
								mit_hrtf_filter_48[] filter2 = hrtf48Filter.e_30;

								fixed (short* leftArray = filter2[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter2[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case -40:
								mit_hrtf_filter_48[] filter3 = hrtf48Filter.e_40;

								fixed (short* leftArray = filter3[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter3[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 0:
								mit_hrtf_filter_48[] filter4 = hrtf48Filter.e00;

								fixed (short* leftArray = filter4[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter4[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 10:
								mit_hrtf_filter_48[] filter5 = hrtf48Filter.e10;

								fixed (short* leftArray = filter5[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter5[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 20:
								mit_hrtf_filter_48[] filter6 = hrtf48Filter.e20;

								fixed (short* leftArray = filter6[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter6[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 30:
								mit_hrtf_filter_48[] filter7 = hrtf48Filter.e30;

								fixed (short* leftArray = filter7[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter7[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 40:
								mit_hrtf_filter_48[] filter8 = hrtf48Filter.e40;

								fixed (short* leftArray = filter8[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter8[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 50:
								mit_hrtf_filter_48[] filter9 = hrtf48Filter.e50;

								fixed (short* leftArray = filter9[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter9[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 60:
								mit_hrtf_filter_48[] filter10 = hrtf48Filter.e60;

								fixed (short* leftArray = filter10[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter10[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 70:
								mit_hrtf_filter_48[] filter11 = hrtf48Filter.e70;

								fixed (short* leftArray = filter11[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter11[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 80:
								mit_hrtf_filter_48[] filter12 = hrtf48Filter.e80;

								fixed (short* leftArray = filter12[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter12[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 90:
								mit_hrtf_filter_48[] filter13 = hrtf48Filter.e90;

								fixed (short* leftArray = filter13[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter13[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
						}

						// How many taps to copy later to user's buffers
						totalTaps = HRTFFilter.MIT_HRTF_48_TAPS;
						break;

					case 88200:
						//FilterSets.CachedNormal88 = diffused ? &diffuse_88 : &normal_88;

						switch (localElevation)
						{
							case -10:

								mit_hrtf_filter_88[] filter0 = FilterSets.CachedNormal88.e_10;

								fixed (short* leftArray = filter0[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter0[azimuthIndex].right)
									pRightTaps = rightArray;

								break;
							case -20:
								mit_hrtf_filter_88[] filter1 = FilterSets.CachedNormal88.e_20;

								fixed (short* leftArray = filter1[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter1[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case -30:
								mit_hrtf_filter_88[] filter2 = FilterSets.CachedNormal88.e_30;

								fixed (short* leftArray = filter2[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter2[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case -40:
								mit_hrtf_filter_88[] filter3 = FilterSets.CachedNormal88.e_40;

								fixed (short* leftArray = filter3[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter3[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 0:
								mit_hrtf_filter_88[] filter4 = FilterSets.CachedNormal88.e00;

								fixed (short* leftArray = filter4[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter4[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 10:
								mit_hrtf_filter_88[] filter5 = FilterSets.CachedNormal88.e10;

								fixed (short* leftArray = filter5[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter5[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 20:
								mit_hrtf_filter_88[] filter6 = FilterSets.CachedNormal88.e20;

								fixed (short* leftArray = filter6[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter6[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 30:
								mit_hrtf_filter_88[] filter7 = FilterSets.CachedNormal88.e30;

								fixed (short* leftArray = filter7[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter7[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 40:
								mit_hrtf_filter_88[] filter8 = FilterSets.CachedNormal88.e40;

								fixed (short* leftArray = filter8[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter8[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 50:
								mit_hrtf_filter_88[] filter9 = FilterSets.CachedNormal88.e50;

								fixed (short* leftArray = filter9[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter9[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 60:
								mit_hrtf_filter_88[] filter10 = FilterSets.CachedNormal88.e60;

								fixed (short* leftArray = filter10[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter10[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 70:
								mit_hrtf_filter_88[] filter11 = FilterSets.CachedNormal88.e70;

								fixed (short* leftArray = filter11[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter11[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 80:
								mit_hrtf_filter_88[] filter12 = FilterSets.CachedNormal88.e80;

								fixed (short* leftArray = filter12[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter12[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 90:
								mit_hrtf_filter_88[] filter13 = FilterSets.CachedNormal88.e90;

								fixed (short* leftArray = filter13[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter13[azimuthIndex].right)
									pRightTaps = rightArray;
								break;

						};
						// How many taps to copy later to user's buffers
						totalTaps = HRTFFilter.MIT_HRTF_88_TAPS;
						break;

					case 96000:
						//FilterSets.CachedNormal96 = diffused ? &diffuse_96 : &normal_96;

						switch (localElevation)
						{
							case -10:

								mit_hrtf_filter_96[] filter0 = FilterSets.CachedNormal96.e_10;

								fixed (short* leftArray = filter0[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter0[azimuthIndex].right)
									pRightTaps = rightArray;

								break;
							case -20:
								mit_hrtf_filter_96[] filter1 = FilterSets.CachedNormal96.e_20;

								fixed (short* leftArray = filter1[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter1[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case -30:
								mit_hrtf_filter_96[] filter2 = FilterSets.CachedNormal96.e_30;

								fixed (short* leftArray = filter2[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter2[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case -40:
								mit_hrtf_filter_96[] filter3 = FilterSets.CachedNormal96.e_40;

								fixed (short* leftArray = filter3[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter3[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 0:
								mit_hrtf_filter_96[] filter4 = FilterSets.CachedNormal96.e00;

								fixed (short* leftArray = filter4[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter4[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 10:
								mit_hrtf_filter_96[] filter5 = FilterSets.CachedNormal96.e10;

								fixed (short* leftArray = filter5[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter5[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 20:
								mit_hrtf_filter_96[] filter6 = FilterSets.CachedNormal96.e20;

								fixed (short* leftArray = filter6[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter6[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 30:
								mit_hrtf_filter_96[] filter7 = FilterSets.CachedNormal96.e30;

								fixed (short* leftArray = filter7[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter7[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 40:
								mit_hrtf_filter_96[] filter8 = FilterSets.CachedNormal96.e40;

								fixed (short* leftArray = filter8[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter8[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 50:
								mit_hrtf_filter_96[] filter9 = FilterSets.CachedNormal96.e50;

								fixed (short* leftArray = filter9[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter9[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 60:
								mit_hrtf_filter_96[] filter10 = FilterSets.CachedNormal96.e60;

								fixed (short* leftArray = filter10[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter10[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 70:
								mit_hrtf_filter_96[] filter11 = FilterSets.CachedNormal96.e70;

								fixed (short* leftArray = filter11[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter11[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 80:
								mit_hrtf_filter_96[] filter12 = FilterSets.CachedNormal96.e80;

								fixed (short* leftArray = filter12[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter12[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
							case 90:
								mit_hrtf_filter_96[] filter13 = FilterSets.CachedNormal96.e90;

								fixed (short* leftArray = filter13[azimuthIndex].left)
									pLeftTaps = leftArray;

								fixed (short* rightArray = filter13[azimuthIndex].right)
									pRightTaps = rightArray;
								break;
						};

						// How many taps to copy later to user's buffers
						totalTaps = HRTFFilter.MIT_HRTF_96_TAPS;
						break;
				}
            
			
			
				// Switch left and right ear if the azimuth is to the left of front centre (azimuth < 0)
				if(swapLeftRight != 0)
				{
				
					short* pTempTaps = pRightTaps;
					pRightTaps = pLeftTaps;
					pLeftTaps = pTempTaps;
				
				
				}
	
				// Copy taps to user's arrays
				for(int tap = 0; tap < totalTaps; tap++)
				{
					pLeft[tap] = AudioMath.ClampShortToDouble(pLeftTaps[tap]);
					pRight[tap] = AudioMath.ClampShortToDouble(pRightTaps[tap]);
				}

				// Assign the real azimuth and elevation used
				pAzimuth = localAzimuth;
				pElevation = localElevation;

				return totalTaps;
			}
		}

		

		public static int mit_hrtf_findAzimuthFor40Elev(int azimuth)
		{
			if (azimuth >= 0 && azimuth < 4)
				return 0;
			else if (azimuth >= 4 && azimuth < 10)
				return 6;
			else if (azimuth >= 10 && azimuth < 17)
				return 13;
			else if (azimuth >= 17 && azimuth < 23)
				return 19;
			else if (azimuth >= 23 && azimuth < 30)
				return 26;
			else if (azimuth >= 30 && azimuth < 36)
				return 32;
			else if (azimuth >= 36 && azimuth < 43)
				return 39;
			else if (azimuth >= 43 && azimuth < 49)
				return 45;
			else if (azimuth >= 49 && azimuth < 55)
				return 51;
			else if (azimuth >= 55 && azimuth < 62)
				return 58;
			else if (azimuth >= 62 && azimuth < 68)
				return 64;
			else if (azimuth >= 68 && azimuth < 75)
				return 71;
			else if (azimuth >= 75 && azimuth < 81)
				return 77;
			else if (azimuth >= 81 && azimuth < 88)
				return 84;
			else if (azimuth >= 88 && azimuth < 94)
				return 90;
			else if (azimuth >= 94 && azimuth < 100)
				return 96;
			else if (azimuth >= 100 && azimuth < 107)
				return 103;
			else if (azimuth >= 107 && azimuth < 113)
				return 109;
			else if (azimuth >= 113 && azimuth < 120)
				return 116;
			else if (azimuth >= 120 && azimuth < 126)
				return 122;
			else if (azimuth >= 126 && azimuth < 133)
				return 129;
			else if (azimuth >= 133 && azimuth < 139)
				return 135;
			else if (azimuth >= 139 && azimuth < 145)
				return 141;
			else if (azimuth >= 145 && azimuth < 152)
				return 148;
			else if (azimuth >= 152 && azimuth < 158)
				return 154;
			else if (azimuth >= 158 && azimuth < 165)
				return 161;
			else if (azimuth >= 165 && azimuth < 171)
				return 167;
			else if (azimuth >= 171 && azimuth < 178)
				return 174;
			else
				return 180;
		}



		public static int mit_hrtf_findIndexFor40Elev(int azimuth)
		{
			if (azimuth >= 0 && azimuth < 4)
				return 0;
			else if (azimuth >= 4 && azimuth < 10)
				return 1;
			else if (azimuth >= 10 && azimuth < 17)
				return 2;
			else if (azimuth >= 17 && azimuth < 23)
				return 3;
			else if (azimuth >= 23 && azimuth < 30)
				return 4;
			else if (azimuth >= 30 && azimuth < 36)
				return 5;
			else if (azimuth >= 36 && azimuth < 43)
				return 6;
			else if (azimuth >= 43 && azimuth < 49)
				return 7;
			else if (azimuth >= 49 && azimuth < 55)
				return 8;
			else if (azimuth >= 55 && azimuth < 62)
				return 9;
			else if (azimuth >= 62 && azimuth < 68)
				return 10;
			else if (azimuth >= 68 && azimuth < 75)
				return 11;
			else if (azimuth >= 75 && azimuth < 81)
				return 12;
			else if (azimuth >= 81 && azimuth < 88)
				return 13;
			else if (azimuth >= 88 && azimuth < 94)
				return 14;
			else if (azimuth >= 94 && azimuth < 100)
				return 15;
			else if (azimuth >= 100 && azimuth < 107)
				return 16;
			else if (azimuth >= 107 && azimuth < 113)
				return 17;
			else if (azimuth >= 113 && azimuth < 120)
				return 18;
			else if (azimuth >= 120 && azimuth < 126)
				return 19;
			else if (azimuth >= 126 && azimuth < 133)
				return 20;
			else if (azimuth >= 133 && azimuth < 139)
				return 21;
			else if (azimuth >= 139 && azimuth < 145)
				return 22;
			else if (azimuth >= 145 && azimuth < 152)
				return 23;
			else if (azimuth >= 152 && azimuth < 158)
				return 24;
			else if (azimuth >= 158 && azimuth < 165)
				return 25;
			else if (azimuth >= 165 && azimuth < 171)
				return 26;
			else if (azimuth >= 171 && azimuth < 178)
				return 27;
			else
				return 28;
		}
	}
}
