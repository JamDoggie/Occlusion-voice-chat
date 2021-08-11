using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/* All of the code under the Occlusion_Voice_Chat_CrossPlatform.HRTF namespace is ported from https://github.com/greekgoddj/mit-hrtf-lib */

namespace Occlusion_Voice_Chat_CrossPlatform.HRTF
{
    public static class HRTFFilter
    {
        public const int MIT_HRTF_AZI_POSITIONS_00 = 37;
        public const int MIT_HRTF_AZI_POSITIONS_10 = 37;
        public const int MIT_HRTF_AZI_POSITIONS_20 = 37;
        public const int MIT_HRTF_AZI_POSITIONS_30 = 31;
        public const int MIT_HRTF_AZI_POSITIONS_40 = 29;
        public const int MIT_HRTF_AZI_POSITIONS_50 = 23;
        public const int MIT_HRTF_AZI_POSITIONS_60 = 19;
        public const int MIT_HRTF_AZI_POSITIONS_70 = 13;
        public const int MIT_HRTF_AZI_POSITIONS_80 = 7;
        public const int MIT_HRTF_AZI_POSITIONS_90 = 1;

        public const int MIT_HRTF_44_TAPS = 128;
        public const int MIT_HRTF_48_TAPS = 140;
        public const int MIT_HRTF_88_TAPS = 256;
        public const int MIT_HRTF_96_TAPS = 279;
    }

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mit_hrtf_filter_44
	{
		public fixed short left[HRTFFilter.MIT_HRTF_44_TAPS];
		public fixed short right[HRTFFilter.MIT_HRTF_44_TAPS];
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mit_hrtf_filter_48
	{
		public fixed short left[HRTFFilter.MIT_HRTF_48_TAPS];
		public fixed short right[HRTFFilter.MIT_HRTF_48_TAPS];
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mit_hrtf_filter_88
	{
		public fixed short left[HRTFFilter.MIT_HRTF_88_TAPS];
		public fixed short right[HRTFFilter.MIT_HRTF_88_TAPS];
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct mit_hrtf_filter_96
	{
		public fixed short left[HRTFFilter.MIT_HRTF_96_TAPS];
		public fixed short right[HRTFFilter.MIT_HRTF_96_TAPS];
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct mit_hrtf_filter_set_44
	{
		public mit_hrtf_filter_44[] e_10;
		public mit_hrtf_filter_44[] e_20;
		public mit_hrtf_filter_44[] e_30;
		public mit_hrtf_filter_44[] e_40;

		public mit_hrtf_filter_44[] e00;
		public mit_hrtf_filter_44[] e10;
		public mit_hrtf_filter_44[] e20;
		public mit_hrtf_filter_44[] e30;
		public mit_hrtf_filter_44[] e40;
		public mit_hrtf_filter_44[] e50;
		public mit_hrtf_filter_44[] e60;
		public mit_hrtf_filter_44[] e70;
		public mit_hrtf_filter_44[] e80;
		public mit_hrtf_filter_44[] e90;

		public static mit_hrtf_filter_set_44 Create()
        {
			mit_hrtf_filter_set_44 filterSet = new();

			filterSet.e_10 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_10];
			filterSet.e_20 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_20];
			filterSet.e_30 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_30];
			filterSet.e_40 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_40];

			filterSet.e00 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_00];
			filterSet.e10 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_10];
			filterSet.e20 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_20];
			filterSet.e30 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_30];
			filterSet.e40 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_40];
			filterSet.e50 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_50];
			filterSet.e60 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_60];
			filterSet.e70 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_70];
			filterSet.e80 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_80];
			filterSet.e90 = new mit_hrtf_filter_44[HRTFFilter.MIT_HRTF_AZI_POSITIONS_90];

			return filterSet;
        }
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct mit_hrtf_filter_set_48
	{
		public mit_hrtf_filter_48[] e_10;
		public mit_hrtf_filter_48[] e_20;
		public mit_hrtf_filter_48[] e_30;
		public mit_hrtf_filter_48[] e_40;

		public mit_hrtf_filter_48[] e00;
		public mit_hrtf_filter_48[] e10;
		public mit_hrtf_filter_48[] e20;
		public mit_hrtf_filter_48[] e30;
		public mit_hrtf_filter_48[] e40;
		public mit_hrtf_filter_48[] e50;
		public mit_hrtf_filter_48[] e60;
		public mit_hrtf_filter_48[] e70;
		public mit_hrtf_filter_48[] e80;
		public mit_hrtf_filter_48[] e90;
		public static mit_hrtf_filter_set_48 Create()
		{
			mit_hrtf_filter_set_48 filterSet = new();

			filterSet.e_10 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_10];
			filterSet.e_20 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_20];
			filterSet.e_30 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_30];
			filterSet.e_40 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_40];

			filterSet.e00 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_00];
			filterSet.e10 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_10];
			filterSet.e20 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_20];
			filterSet.e30 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_30];
			filterSet.e40 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_40];
			filterSet.e50 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_50];
			filterSet.e60 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_60];
			filterSet.e70 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_70];
			filterSet.e80 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_80];
			filterSet.e90 = new mit_hrtf_filter_48[HRTFFilter.MIT_HRTF_AZI_POSITIONS_90];

			return filterSet;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct mit_hrtf_filter_set_88
	{
		public mit_hrtf_filter_88[] e_10;
		public mit_hrtf_filter_88[] e_20;
		public mit_hrtf_filter_88[] e_30;
		public mit_hrtf_filter_88[] e_40;

		public mit_hrtf_filter_88[] e00;
		public mit_hrtf_filter_88[] e10;
		public mit_hrtf_filter_88[] e20;
		public mit_hrtf_filter_88[] e30;
		public mit_hrtf_filter_88[] e40;
		public mit_hrtf_filter_88[] e50;
		public mit_hrtf_filter_88[] e60;
		public mit_hrtf_filter_88[] e70;
		public mit_hrtf_filter_88[] e80;
		public mit_hrtf_filter_88[] e90;


		public static mit_hrtf_filter_set_88 Create()
		{
			mit_hrtf_filter_set_88 filterSet = new();

			filterSet.e_10 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_10];
			filterSet.e_20 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_20];
			filterSet.e_30 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_30];
			filterSet.e_40 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_40];

			filterSet.e00 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_00];
			filterSet.e10 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_10];
			filterSet.e20 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_20];
			filterSet.e30 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_30];
			filterSet.e40 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_40];
			filterSet.e50 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_50];
			filterSet.e60 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_60];
			filterSet.e70 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_70];
			filterSet.e80 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_80];
			filterSet.e90 = new mit_hrtf_filter_88[HRTFFilter.MIT_HRTF_AZI_POSITIONS_90];

			return filterSet;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct mit_hrtf_filter_set_96
	{
		public mit_hrtf_filter_96[] e_10;
		public mit_hrtf_filter_96[] e_20;
		public mit_hrtf_filter_96[] e_30;
		public mit_hrtf_filter_96[] e_40;

		public mit_hrtf_filter_96[] e00;
		public mit_hrtf_filter_96[] e10;
		public mit_hrtf_filter_96[] e20;
		public mit_hrtf_filter_96[] e30;
		public mit_hrtf_filter_96[] e40;
		public mit_hrtf_filter_96[] e50;
		public mit_hrtf_filter_96[] e60;
		public mit_hrtf_filter_96[] e70;
		public mit_hrtf_filter_96[] e80;
		public mit_hrtf_filter_96[] e90;

		public static mit_hrtf_filter_set_96 Create()
		{
			mit_hrtf_filter_set_96 filterSet = new();

			filterSet.e_10 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_10];
			filterSet.e_20 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_20];
			filterSet.e_30 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_30];
			filterSet.e_40 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_40];

			filterSet.e00 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_00];
			filterSet.e10 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_10];
			filterSet.e20 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_20];
			filterSet.e30 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_30];
			filterSet.e40 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_40];
			filterSet.e50 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_50];
			filterSet.e60 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_60];
			filterSet.e70 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_70];
			filterSet.e80 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_80];
			filterSet.e90 = new mit_hrtf_filter_96[HRTFFilter.MIT_HRTF_AZI_POSITIONS_90];

			return filterSet;
		}
	}
}
