using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.HRTF
{

    public static class FilterSets
    {
        public static mit_hrtf_filter_set_44 CachedNormal44 { get; internal set; }

        public static mit_hrtf_filter_set_48 CachedNormal48 { get; internal set; }

        public static mit_hrtf_filter_set_48 CachedNormal48Diffuse { get; internal set; }

        public static mit_hrtf_filter_set_88 CachedNormal88 { get; internal set; }

        public static mit_hrtf_filter_set_96 CachedNormal96 { get; internal set; }


        static FilterSets()
        {
            CachedNormal44 = normal_44;
            CachedNormal48 = normal_48;
            CachedNormal48Diffuse = normal_48_diffuse;
            CachedNormal88 = normal_88;
            CachedNormal96 = normal_96;
        }


        #region 44khz
        private static mit_hrtf_filter_set_44 normal_44
        {
            get
            {
                unsafe
                {
                    var fourFourFilters = mit_hrtf_filter_set_44.Create();


                    // e_10
                    fourFourFilters.e_10[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[0].left[i] = Filter44.elev_10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[0].right[i] = Filter44.elev_10_0_r[i];


                    fourFourFilters.e_10[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[1].left[i] = Filter44.elev_10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[1].right[i] = Filter44.elev_10_1_r[i];


                    fourFourFilters.e_10[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[2].left[i] = Filter44.elev_10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[2].right[i] = Filter44.elev_10_2_r[i];


                    fourFourFilters.e_10[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[3].left[i] = Filter44.elev_10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[3].right[i] = Filter44.elev_10_3_r[i];


                    fourFourFilters.e_10[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[4].left[i] = Filter44.elev_10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[4].right[i] = Filter44.elev_10_4_r[i];


                    fourFourFilters.e_10[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[5].left[i] = Filter44.elev_10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[5].right[i] = Filter44.elev_10_5_r[i];


                    fourFourFilters.e_10[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[6].left[i] = Filter44.elev_10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[6].right[i] = Filter44.elev_10_6_r[i];


                    fourFourFilters.e_10[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[7].left[i] = Filter44.elev_10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[7].right[i] = Filter44.elev_10_7_r[i];


                    fourFourFilters.e_10[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[8].left[i] = Filter44.elev_10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[8].right[i] = Filter44.elev_10_8_r[i];


                    fourFourFilters.e_10[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[9].left[i] = Filter44.elev_10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[9].right[i] = Filter44.elev_10_9_r[i];


                    fourFourFilters.e_10[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[10].left[i] = Filter44.elev_10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[10].right[i] = Filter44.elev_10_10_r[i];


                    fourFourFilters.e_10[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[11].left[i] = Filter44.elev_10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[11].right[i] = Filter44.elev_10_11_r[i];


                    fourFourFilters.e_10[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[12].left[i] = Filter44.elev_10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[12].right[i] = Filter44.elev_10_12_r[i];


                    fourFourFilters.e_10[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[13].left[i] = Filter44.elev_10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[13].right[i] = Filter44.elev_10_13_r[i];


                    fourFourFilters.e_10[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[14].left[i] = Filter44.elev_10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[14].right[i] = Filter44.elev_10_14_r[i];


                    fourFourFilters.e_10[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[15].left[i] = Filter44.elev_10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[15].right[i] = Filter44.elev_10_15_r[i];


                    fourFourFilters.e_10[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[16].left[i] = Filter44.elev_10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[16].right[i] = Filter44.elev_10_16_r[i];


                    fourFourFilters.e_10[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[17].left[i] = Filter44.elev_10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[17].right[i] = Filter44.elev_10_17_r[i];


                    fourFourFilters.e_10[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[18].left[i] = Filter44.elev_10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[18].right[i] = Filter44.elev_10_18_r[i];


                    fourFourFilters.e_10[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[19].left[i] = Filter44.elev_10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[19].right[i] = Filter44.elev_10_19_r[i];


                    fourFourFilters.e_10[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[20].left[i] = Filter44.elev_10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[20].right[i] = Filter44.elev_10_20_r[i];


                    fourFourFilters.e_10[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[21].left[i] = Filter44.elev_10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[21].right[i] = Filter44.elev_10_21_r[i];


                    fourFourFilters.e_10[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[22].left[i] = Filter44.elev_10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[22].right[i] = Filter44.elev_10_22_r[i];


                    fourFourFilters.e_10[23] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[23].left[i] = Filter44.elev_10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[23].right[i] = Filter44.elev_10_23_r[i];


                    fourFourFilters.e_10[24] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[24].left[i] = Filter44.elev_10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[24].right[i] = Filter44.elev_10_24_r[i];


                    fourFourFilters.e_10[25] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[25].left[i] = Filter44.elev_10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[25].right[i] = Filter44.elev_10_25_r[i];


                    fourFourFilters.e_10[26] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[26].left[i] = Filter44.elev_10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[26].right[i] = Filter44.elev_10_26_r[i];


                    fourFourFilters.e_10[27] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[27].left[i] = Filter44.elev_10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[27].right[i] = Filter44.elev_10_27_r[i];


                    fourFourFilters.e_10[28] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[28].left[i] = Filter44.elev_10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[28].right[i] = Filter44.elev_10_28_r[i];


                    fourFourFilters.e_10[29] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[29].left[i] = Filter44.elev_10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[29].right[i] = Filter44.elev_10_29_r[i];


                    fourFourFilters.e_10[30] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[30].left[i] = Filter44.elev_10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[30].right[i] = Filter44.elev_10_30_r[i];


                    fourFourFilters.e_10[31] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[31].left[i] = Filter44.elev_10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[31].right[i] = Filter44.elev_10_31_r[i];


                    fourFourFilters.e_10[32] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[32].left[i] = Filter44.elev_10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[32].right[i] = Filter44.elev_10_32_r[i];


                    fourFourFilters.e_10[33] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[33].left[i] = Filter44.elev_10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[33].right[i] = Filter44.elev_10_33_r[i];


                    fourFourFilters.e_10[34] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[34].left[i] = Filter44.elev_10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[34].right[i] = Filter44.elev_10_34_r[i];


                    fourFourFilters.e_10[35] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[35].left[i] = Filter44.elev_10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[35].right[i] = Filter44.elev_10_35_r[i];


                    fourFourFilters.e_10[36] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[36].left[i] = Filter44.elev_10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_10[36].right[i] = Filter44.elev_10_36_r[i];



                    // e_20
                    fourFourFilters.e_20[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[0].left[i] = Filter44.elev_20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[0].right[i] = Filter44.elev_20_0_r[i];


                    fourFourFilters.e_20[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[1].left[i] = Filter44.elev_20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[1].right[i] = Filter44.elev_20_1_r[i];


                    fourFourFilters.e_20[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[2].left[i] = Filter44.elev_20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[2].right[i] = Filter44.elev_20_2_r[i];


                    fourFourFilters.e_20[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[3].left[i] = Filter44.elev_20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[3].right[i] = Filter44.elev_20_3_r[i];


                    fourFourFilters.e_20[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[4].left[i] = Filter44.elev_20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[4].right[i] = Filter44.elev_20_4_r[i];


                    fourFourFilters.e_20[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[5].left[i] = Filter44.elev_20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[5].right[i] = Filter44.elev_20_5_r[i];


                    fourFourFilters.e_20[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[6].left[i] = Filter44.elev_20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[6].right[i] = Filter44.elev_20_6_r[i];


                    fourFourFilters.e_20[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[7].left[i] = Filter44.elev_20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[7].right[i] = Filter44.elev_20_7_r[i];


                    fourFourFilters.e_20[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[8].left[i] = Filter44.elev_20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[8].right[i] = Filter44.elev_20_8_r[i];


                    fourFourFilters.e_20[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[9].left[i] = Filter44.elev_20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[9].right[i] = Filter44.elev_20_9_r[i];


                    fourFourFilters.e_20[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[10].left[i] = Filter44.elev_20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[10].right[i] = Filter44.elev_20_10_r[i];


                    fourFourFilters.e_20[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[11].left[i] = Filter44.elev_20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[11].right[i] = Filter44.elev_20_11_r[i];


                    fourFourFilters.e_20[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[12].left[i] = Filter44.elev_20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[12].right[i] = Filter44.elev_20_12_r[i];


                    fourFourFilters.e_20[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[13].left[i] = Filter44.elev_20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[13].right[i] = Filter44.elev_20_13_r[i];


                    fourFourFilters.e_20[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[14].left[i] = Filter44.elev_20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[14].right[i] = Filter44.elev_20_14_r[i];


                    fourFourFilters.e_20[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[15].left[i] = Filter44.elev_20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[15].right[i] = Filter44.elev_20_15_r[i];


                    fourFourFilters.e_20[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[16].left[i] = Filter44.elev_20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[16].right[i] = Filter44.elev_20_16_r[i];


                    fourFourFilters.e_20[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[17].left[i] = Filter44.elev_20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[17].right[i] = Filter44.elev_20_17_r[i];


                    fourFourFilters.e_20[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[18].left[i] = Filter44.elev_20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[18].right[i] = Filter44.elev_20_18_r[i];


                    fourFourFilters.e_20[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[19].left[i] = Filter44.elev_20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[19].right[i] = Filter44.elev_20_19_r[i];


                    fourFourFilters.e_20[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[20].left[i] = Filter44.elev_20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[20].right[i] = Filter44.elev_20_20_r[i];


                    fourFourFilters.e_20[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[21].left[i] = Filter44.elev_20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[21].right[i] = Filter44.elev_20_21_r[i];


                    fourFourFilters.e_20[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[22].left[i] = Filter44.elev_20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[22].right[i] = Filter44.elev_20_22_r[i];


                    fourFourFilters.e_20[23] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[23].left[i] = Filter44.elev_20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[23].right[i] = Filter44.elev_20_23_r[i];


                    fourFourFilters.e_20[24] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[24].left[i] = Filter44.elev_20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[24].right[i] = Filter44.elev_20_24_r[i];


                    fourFourFilters.e_20[25] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[25].left[i] = Filter44.elev_20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[25].right[i] = Filter44.elev_20_25_r[i];


                    fourFourFilters.e_20[26] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[26].left[i] = Filter44.elev_20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[26].right[i] = Filter44.elev_20_26_r[i];


                    fourFourFilters.e_20[27] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[27].left[i] = Filter44.elev_20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[27].right[i] = Filter44.elev_20_27_r[i];


                    fourFourFilters.e_20[28] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[28].left[i] = Filter44.elev_20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[28].right[i] = Filter44.elev_20_28_r[i];


                    fourFourFilters.e_20[29] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[29].left[i] = Filter44.elev_20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[29].right[i] = Filter44.elev_20_29_r[i];


                    fourFourFilters.e_20[30] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[30].left[i] = Filter44.elev_20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[30].right[i] = Filter44.elev_20_30_r[i];


                    fourFourFilters.e_20[31] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[31].left[i] = Filter44.elev_20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[31].right[i] = Filter44.elev_20_31_r[i];


                    fourFourFilters.e_20[32] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[32].left[i] = Filter44.elev_20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[32].right[i] = Filter44.elev_20_32_r[i];


                    fourFourFilters.e_20[33] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[33].left[i] = Filter44.elev_20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[33].right[i] = Filter44.elev_20_33_r[i];


                    fourFourFilters.e_20[34] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[34].left[i] = Filter44.elev_20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[34].right[i] = Filter44.elev_20_34_r[i];


                    fourFourFilters.e_20[35] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[35].left[i] = Filter44.elev_20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[35].right[i] = Filter44.elev_20_35_r[i];


                    fourFourFilters.e_20[36] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[36].left[i] = Filter44.elev_20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_20[36].right[i] = Filter44.elev_20_36_r[i];




                    // e_30
                    fourFourFilters.e_30[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[0].left[i] = Filter44.elev_30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[0].right[i] = Filter44.elev_30_0_r[i];


                    fourFourFilters.e_30[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[1].left[i] = Filter44.elev_30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[1].right[i] = Filter44.elev_30_1_r[i];


                    fourFourFilters.e_30[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[2].left[i] = Filter44.elev_30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[2].right[i] = Filter44.elev_30_2_r[i];


                    fourFourFilters.e_30[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[3].left[i] = Filter44.elev_30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[3].right[i] = Filter44.elev_30_3_r[i];


                    fourFourFilters.e_30[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[4].left[i] = Filter44.elev_30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[4].right[i] = Filter44.elev_30_4_r[i];


                    fourFourFilters.e_30[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[5].left[i] = Filter44.elev_30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[5].right[i] = Filter44.elev_30_5_r[i];


                    fourFourFilters.e_30[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[6].left[i] = Filter44.elev_30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[6].right[i] = Filter44.elev_30_6_r[i];


                    fourFourFilters.e_30[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[7].left[i] = Filter44.elev_30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[7].right[i] = Filter44.elev_30_7_r[i];


                    fourFourFilters.e_30[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[8].left[i] = Filter44.elev_30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[8].right[i] = Filter44.elev_30_8_r[i];


                    fourFourFilters.e_30[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[9].left[i] = Filter44.elev_30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[9].right[i] = Filter44.elev_30_9_r[i];


                    fourFourFilters.e_30[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[10].left[i] = Filter44.elev_30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[10].right[i] = Filter44.elev_30_10_r[i];


                    fourFourFilters.e_30[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[11].left[i] = Filter44.elev_30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[11].right[i] = Filter44.elev_30_11_r[i];


                    fourFourFilters.e_30[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[12].left[i] = Filter44.elev_30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[12].right[i] = Filter44.elev_30_12_r[i];


                    fourFourFilters.e_30[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[13].left[i] = Filter44.elev_30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[13].right[i] = Filter44.elev_30_13_r[i];


                    fourFourFilters.e_30[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[14].left[i] = Filter44.elev_30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[14].right[i] = Filter44.elev_30_14_r[i];


                    fourFourFilters.e_30[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[15].left[i] = Filter44.elev_30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[15].right[i] = Filter44.elev_30_15_r[i];


                    fourFourFilters.e_30[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[16].left[i] = Filter44.elev_30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[16].right[i] = Filter44.elev_30_16_r[i];


                    fourFourFilters.e_30[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[17].left[i] = Filter44.elev_30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[17].right[i] = Filter44.elev_30_17_r[i];


                    fourFourFilters.e_30[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[18].left[i] = Filter44.elev_30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[18].right[i] = Filter44.elev_30_18_r[i];


                    fourFourFilters.e_30[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[19].left[i] = Filter44.elev_30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[19].right[i] = Filter44.elev_30_19_r[i];


                    fourFourFilters.e_30[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[20].left[i] = Filter44.elev_30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[20].right[i] = Filter44.elev_30_20_r[i];


                    fourFourFilters.e_30[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[21].left[i] = Filter44.elev_30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[21].right[i] = Filter44.elev_30_21_r[i];


                    fourFourFilters.e_30[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[22].left[i] = Filter44.elev_30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[22].right[i] = Filter44.elev_30_22_r[i];


                    fourFourFilters.e_30[23] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[23].left[i] = Filter44.elev_30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[23].right[i] = Filter44.elev_30_23_r[i];


                    fourFourFilters.e_30[24] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[24].left[i] = Filter44.elev_30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[24].right[i] = Filter44.elev_30_24_r[i];


                    fourFourFilters.e_30[25] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[25].left[i] = Filter44.elev_30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[25].right[i] = Filter44.elev_30_25_r[i];


                    fourFourFilters.e_30[26] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[26].left[i] = Filter44.elev_30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[26].right[i] = Filter44.elev_30_26_r[i];


                    fourFourFilters.e_30[27] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[27].left[i] = Filter44.elev_30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[27].right[i] = Filter44.elev_30_27_r[i];


                    fourFourFilters.e_30[28] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[28].left[i] = Filter44.elev_30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[28].right[i] = Filter44.elev_30_28_r[i];


                    fourFourFilters.e_30[29] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[29].left[i] = Filter44.elev_30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[29].right[i] = Filter44.elev_30_29_r[i];


                    fourFourFilters.e_30[30] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[30].left[i] = Filter44.elev_30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_30[30].right[i] = Filter44.elev_30_30_r[i];



                    // e_40
                    fourFourFilters.e_40[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[0].left[i] = Filter44.elev_40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[0].right[i] = Filter44.elev_40_0_r[i];


                    fourFourFilters.e_40[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[1].left[i] = Filter44.elev_40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[1].right[i] = Filter44.elev_40_1_r[i];


                    fourFourFilters.e_40[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[2].left[i] = Filter44.elev_40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[2].right[i] = Filter44.elev_40_2_r[i];


                    fourFourFilters.e_40[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[3].left[i] = Filter44.elev_40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[3].right[i] = Filter44.elev_40_3_r[i];


                    fourFourFilters.e_40[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[4].left[i] = Filter44.elev_40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[4].right[i] = Filter44.elev_40_4_r[i];


                    fourFourFilters.e_40[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[5].left[i] = Filter44.elev_40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[5].right[i] = Filter44.elev_40_5_r[i];


                    fourFourFilters.e_40[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[6].left[i] = Filter44.elev_40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[6].right[i] = Filter44.elev_40_6_r[i];


                    fourFourFilters.e_40[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[7].left[i] = Filter44.elev_40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[7].right[i] = Filter44.elev_40_7_r[i];


                    fourFourFilters.e_40[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[8].left[i] = Filter44.elev_40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[8].right[i] = Filter44.elev_40_8_r[i];


                    fourFourFilters.e_40[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[9].left[i] = Filter44.elev_40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[9].right[i] = Filter44.elev_40_9_r[i];


                    fourFourFilters.e_40[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[10].left[i] = Filter44.elev_40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[10].right[i] = Filter44.elev_40_10_r[i];


                    fourFourFilters.e_40[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[11].left[i] = Filter44.elev_40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[11].right[i] = Filter44.elev_40_11_r[i];


                    fourFourFilters.e_40[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[12].left[i] = Filter44.elev_40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[12].right[i] = Filter44.elev_40_12_r[i];


                    fourFourFilters.e_40[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[13].left[i] = Filter44.elev_40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[13].right[i] = Filter44.elev_40_13_r[i];


                    fourFourFilters.e_40[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[14].left[i] = Filter44.elev_40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[14].right[i] = Filter44.elev_40_14_r[i];


                    fourFourFilters.e_40[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[15].left[i] = Filter44.elev_40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[15].right[i] = Filter44.elev_40_15_r[i];


                    fourFourFilters.e_40[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[16].left[i] = Filter44.elev_40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[16].right[i] = Filter44.elev_40_16_r[i];


                    fourFourFilters.e_40[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[17].left[i] = Filter44.elev_40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[17].right[i] = Filter44.elev_40_17_r[i];


                    fourFourFilters.e_40[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[18].left[i] = Filter44.elev_40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[18].right[i] = Filter44.elev_40_18_r[i];


                    fourFourFilters.e_40[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[19].left[i] = Filter44.elev_40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[19].right[i] = Filter44.elev_40_19_r[i];


                    fourFourFilters.e_40[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[20].left[i] = Filter44.elev_40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[20].right[i] = Filter44.elev_40_20_r[i];


                    fourFourFilters.e_40[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[21].left[i] = Filter44.elev_40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[21].right[i] = Filter44.elev_40_21_r[i];


                    fourFourFilters.e_40[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[22].left[i] = Filter44.elev_40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[22].right[i] = Filter44.elev_40_22_r[i];


                    fourFourFilters.e_40[23] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[23].left[i] = Filter44.elev_40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[23].right[i] = Filter44.elev_40_23_r[i];


                    fourFourFilters.e_40[24] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[24].left[i] = Filter44.elev_40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[24].right[i] = Filter44.elev_40_24_r[i];


                    fourFourFilters.e_40[25] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[25].left[i] = Filter44.elev_40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[25].right[i] = Filter44.elev_40_25_r[i];


                    fourFourFilters.e_40[26] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[26].left[i] = Filter44.elev_40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[26].right[i] = Filter44.elev_40_26_r[i];


                    fourFourFilters.e_40[27] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[27].left[i] = Filter44.elev_40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[27].right[i] = Filter44.elev_40_27_r[i];


                    fourFourFilters.e_40[28] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[28].left[i] = Filter44.elev_40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e_40[28].right[i] = Filter44.elev_40_28_r[i];




                    // e0
                    fourFourFilters.e00[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[0].left[i] = Filter44.elev0_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[0].right[i] = Filter44.elev0_0_r[i];


                    fourFourFilters.e00[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[1].left[i] = Filter44.elev0_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[1].right[i] = Filter44.elev0_1_r[i];


                    fourFourFilters.e00[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[2].left[i] = Filter44.elev0_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[2].right[i] = Filter44.elev0_2_r[i];


                    fourFourFilters.e00[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[3].left[i] = Filter44.elev0_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[3].right[i] = Filter44.elev0_3_r[i];


                    fourFourFilters.e00[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[4].left[i] = Filter44.elev0_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[4].right[i] = Filter44.elev0_4_r[i];


                    fourFourFilters.e00[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[5].left[i] = Filter44.elev0_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[5].right[i] = Filter44.elev0_5_r[i];


                    fourFourFilters.e00[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[6].left[i] = Filter44.elev0_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[6].right[i] = Filter44.elev0_6_r[i];


                    fourFourFilters.e00[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[7].left[i] = Filter44.elev0_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[7].right[i] = Filter44.elev0_7_r[i];


                    fourFourFilters.e00[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[8].left[i] = Filter44.elev0_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[8].right[i] = Filter44.elev0_8_r[i];


                    fourFourFilters.e00[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[9].left[i] = Filter44.elev0_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[9].right[i] = Filter44.elev0_9_r[i];


                    fourFourFilters.e00[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[10].left[i] = Filter44.elev0_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[10].right[i] = Filter44.elev0_10_r[i];


                    fourFourFilters.e00[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[11].left[i] = Filter44.elev0_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[11].right[i] = Filter44.elev0_11_r[i];


                    fourFourFilters.e00[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[12].left[i] = Filter44.elev0_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[12].right[i] = Filter44.elev0_12_r[i];


                    fourFourFilters.e00[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[13].left[i] = Filter44.elev0_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[13].right[i] = Filter44.elev0_13_r[i];


                    fourFourFilters.e00[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[14].left[i] = Filter44.elev0_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[14].right[i] = Filter44.elev0_14_r[i];


                    fourFourFilters.e00[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[15].left[i] = Filter44.elev0_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[15].right[i] = Filter44.elev0_15_r[i];


                    fourFourFilters.e00[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[16].left[i] = Filter44.elev0_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[16].right[i] = Filter44.elev0_16_r[i];


                    fourFourFilters.e00[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[17].left[i] = Filter44.elev0_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[17].right[i] = Filter44.elev0_17_r[i];


                    fourFourFilters.e00[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[18].left[i] = Filter44.elev0_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[18].right[i] = Filter44.elev0_18_r[i];


                    fourFourFilters.e00[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[19].left[i] = Filter44.elev0_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[19].right[i] = Filter44.elev0_19_r[i];


                    fourFourFilters.e00[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[20].left[i] = Filter44.elev0_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[20].right[i] = Filter44.elev0_20_r[i];


                    fourFourFilters.e00[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[21].left[i] = Filter44.elev0_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[21].right[i] = Filter44.elev0_21_r[i];


                    fourFourFilters.e00[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[22].left[i] = Filter44.elev0_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[22].right[i] = Filter44.elev0_22_r[i];


                    fourFourFilters.e00[23] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[23].left[i] = Filter44.elev0_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[23].right[i] = Filter44.elev0_23_r[i];


                    fourFourFilters.e00[24] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[24].left[i] = Filter44.elev0_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[24].right[i] = Filter44.elev0_24_r[i];


                    fourFourFilters.e00[25] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[25].left[i] = Filter44.elev0_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[25].right[i] = Filter44.elev0_25_r[i];


                    fourFourFilters.e00[26] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[26].left[i] = Filter44.elev0_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[26].right[i] = Filter44.elev0_26_r[i];


                    fourFourFilters.e00[27] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[27].left[i] = Filter44.elev0_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[27].right[i] = Filter44.elev0_27_r[i];


                    fourFourFilters.e00[28] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[28].left[i] = Filter44.elev0_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[28].right[i] = Filter44.elev0_28_r[i];


                    fourFourFilters.e00[29] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[29].left[i] = Filter44.elev0_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[29].right[i] = Filter44.elev0_29_r[i];


                    fourFourFilters.e00[30] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[30].left[i] = Filter44.elev0_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[30].right[i] = Filter44.elev0_30_r[i];


                    fourFourFilters.e00[31] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[31].left[i] = Filter44.elev0_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[31].right[i] = Filter44.elev0_31_r[i];


                    fourFourFilters.e00[32] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[32].left[i] = Filter44.elev0_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[32].right[i] = Filter44.elev0_32_r[i];


                    fourFourFilters.e00[33] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[33].left[i] = Filter44.elev0_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[33].right[i] = Filter44.elev0_33_r[i];


                    fourFourFilters.e00[34] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[34].left[i] = Filter44.elev0_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[34].right[i] = Filter44.elev0_34_r[i];


                    fourFourFilters.e00[35] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[35].left[i] = Filter44.elev0_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[35].right[i] = Filter44.elev0_35_r[i];


                    fourFourFilters.e00[36] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[36].left[i] = Filter44.elev0_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e00[36].right[i] = Filter44.elev0_36_r[i];




                    // e10
                    fourFourFilters.e10[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[0].left[i] = Filter44.elev10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[0].right[i] = Filter44.elev10_0_r[i];


                    fourFourFilters.e10[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[1].left[i] = Filter44.elev10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[1].right[i] = Filter44.elev10_1_r[i];


                    fourFourFilters.e10[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[2].left[i] = Filter44.elev10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[2].right[i] = Filter44.elev10_2_r[i];


                    fourFourFilters.e10[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[3].left[i] = Filter44.elev10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[3].right[i] = Filter44.elev10_3_r[i];


                    fourFourFilters.e10[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[4].left[i] = Filter44.elev10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[4].right[i] = Filter44.elev10_4_r[i];


                    fourFourFilters.e10[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[5].left[i] = Filter44.elev10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[5].right[i] = Filter44.elev10_5_r[i];


                    fourFourFilters.e10[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[6].left[i] = Filter44.elev10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[6].right[i] = Filter44.elev10_6_r[i];


                    fourFourFilters.e10[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[7].left[i] = Filter44.elev10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[7].right[i] = Filter44.elev10_7_r[i];


                    fourFourFilters.e10[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[8].left[i] = Filter44.elev10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[8].right[i] = Filter44.elev10_8_r[i];


                    fourFourFilters.e10[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[9].left[i] = Filter44.elev10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[9].right[i] = Filter44.elev10_9_r[i];


                    fourFourFilters.e10[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[10].left[i] = Filter44.elev10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[10].right[i] = Filter44.elev10_10_r[i];


                    fourFourFilters.e10[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[11].left[i] = Filter44.elev10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[11].right[i] = Filter44.elev10_11_r[i];


                    fourFourFilters.e10[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[12].left[i] = Filter44.elev10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[12].right[i] = Filter44.elev10_12_r[i];


                    fourFourFilters.e10[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[13].left[i] = Filter44.elev10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[13].right[i] = Filter44.elev10_13_r[i];


                    fourFourFilters.e10[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[14].left[i] = Filter44.elev10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[14].right[i] = Filter44.elev10_14_r[i];


                    fourFourFilters.e10[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[15].left[i] = Filter44.elev10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[15].right[i] = Filter44.elev10_15_r[i];


                    fourFourFilters.e10[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[16].left[i] = Filter44.elev10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[16].right[i] = Filter44.elev10_16_r[i];


                    fourFourFilters.e10[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[17].left[i] = Filter44.elev10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[17].right[i] = Filter44.elev10_17_r[i];


                    fourFourFilters.e10[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[18].left[i] = Filter44.elev10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[18].right[i] = Filter44.elev10_18_r[i];


                    fourFourFilters.e10[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[19].left[i] = Filter44.elev10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[19].right[i] = Filter44.elev10_19_r[i];


                    fourFourFilters.e10[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[20].left[i] = Filter44.elev10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[20].right[i] = Filter44.elev10_20_r[i];


                    fourFourFilters.e10[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[21].left[i] = Filter44.elev10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[21].right[i] = Filter44.elev10_21_r[i];


                    fourFourFilters.e10[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[22].left[i] = Filter44.elev10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[22].right[i] = Filter44.elev10_22_r[i];


                    fourFourFilters.e10[23] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[23].left[i] = Filter44.elev10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[23].right[i] = Filter44.elev10_23_r[i];


                    fourFourFilters.e10[24] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[24].left[i] = Filter44.elev10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[24].right[i] = Filter44.elev10_24_r[i];


                    fourFourFilters.e10[25] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[25].left[i] = Filter44.elev10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[25].right[i] = Filter44.elev10_25_r[i];


                    fourFourFilters.e10[26] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[26].left[i] = Filter44.elev10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[26].right[i] = Filter44.elev10_26_r[i];


                    fourFourFilters.e10[27] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[27].left[i] = Filter44.elev10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[27].right[i] = Filter44.elev10_27_r[i];


                    fourFourFilters.e10[28] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[28].left[i] = Filter44.elev10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[28].right[i] = Filter44.elev10_28_r[i];


                    fourFourFilters.e10[29] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[29].left[i] = Filter44.elev10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[29].right[i] = Filter44.elev10_29_r[i];


                    fourFourFilters.e10[30] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[30].left[i] = Filter44.elev10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[30].right[i] = Filter44.elev10_30_r[i];


                    fourFourFilters.e10[31] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[31].left[i] = Filter44.elev10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[31].right[i] = Filter44.elev10_31_r[i];


                    fourFourFilters.e10[32] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[32].left[i] = Filter44.elev10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[32].right[i] = Filter44.elev10_32_r[i];


                    fourFourFilters.e10[33] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[33].left[i] = Filter44.elev10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[33].right[i] = Filter44.elev10_33_r[i];


                    fourFourFilters.e10[34] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[34].left[i] = Filter44.elev10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[34].right[i] = Filter44.elev10_34_r[i];


                    fourFourFilters.e10[35] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[35].left[i] = Filter44.elev10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[35].right[i] = Filter44.elev10_35_r[i];


                    fourFourFilters.e10[36] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[36].left[i] = Filter44.elev10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e10[36].right[i] = Filter44.elev10_36_r[i];




                    // e20
                    fourFourFilters.e20[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[0].left[i] = Filter44.elev20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[0].right[i] = Filter44.elev20_0_r[i];


                    fourFourFilters.e20[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[1].left[i] = Filter44.elev20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[1].right[i] = Filter44.elev20_1_r[i];


                    fourFourFilters.e20[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[2].left[i] = Filter44.elev20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[2].right[i] = Filter44.elev20_2_r[i];


                    fourFourFilters.e20[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[3].left[i] = Filter44.elev20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[3].right[i] = Filter44.elev20_3_r[i];


                    fourFourFilters.e20[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[4].left[i] = Filter44.elev20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[4].right[i] = Filter44.elev20_4_r[i];


                    fourFourFilters.e20[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[5].left[i] = Filter44.elev20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[5].right[i] = Filter44.elev20_5_r[i];


                    fourFourFilters.e20[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[6].left[i] = Filter44.elev20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[6].right[i] = Filter44.elev20_6_r[i];


                    fourFourFilters.e20[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[7].left[i] = Filter44.elev20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[7].right[i] = Filter44.elev20_7_r[i];


                    fourFourFilters.e20[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[8].left[i] = Filter44.elev20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[8].right[i] = Filter44.elev20_8_r[i];


                    fourFourFilters.e20[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[9].left[i] = Filter44.elev20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[9].right[i] = Filter44.elev20_9_r[i];


                    fourFourFilters.e20[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[10].left[i] = Filter44.elev20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[10].right[i] = Filter44.elev20_10_r[i];


                    fourFourFilters.e20[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[11].left[i] = Filter44.elev20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[11].right[i] = Filter44.elev20_11_r[i];


                    fourFourFilters.e20[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[12].left[i] = Filter44.elev20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[12].right[i] = Filter44.elev20_12_r[i];


                    fourFourFilters.e20[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[13].left[i] = Filter44.elev20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[13].right[i] = Filter44.elev20_13_r[i];


                    fourFourFilters.e20[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[14].left[i] = Filter44.elev20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[14].right[i] = Filter44.elev20_14_r[i];


                    fourFourFilters.e20[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[15].left[i] = Filter44.elev20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[15].right[i] = Filter44.elev20_15_r[i];


                    fourFourFilters.e20[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[16].left[i] = Filter44.elev20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[16].right[i] = Filter44.elev20_16_r[i];


                    fourFourFilters.e20[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[17].left[i] = Filter44.elev20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[17].right[i] = Filter44.elev20_17_r[i];


                    fourFourFilters.e20[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[18].left[i] = Filter44.elev20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[18].right[i] = Filter44.elev20_18_r[i];


                    fourFourFilters.e20[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[19].left[i] = Filter44.elev20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[19].right[i] = Filter44.elev20_19_r[i];


                    fourFourFilters.e20[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[20].left[i] = Filter44.elev20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[20].right[i] = Filter44.elev20_20_r[i];


                    fourFourFilters.e20[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[21].left[i] = Filter44.elev20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[21].right[i] = Filter44.elev20_21_r[i];


                    fourFourFilters.e20[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[22].left[i] = Filter44.elev20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[22].right[i] = Filter44.elev20_22_r[i];


                    fourFourFilters.e20[23] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[23].left[i] = Filter44.elev20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[23].right[i] = Filter44.elev20_23_r[i];


                    fourFourFilters.e20[24] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[24].left[i] = Filter44.elev20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[24].right[i] = Filter44.elev20_24_r[i];


                    fourFourFilters.e20[25] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[25].left[i] = Filter44.elev20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[25].right[i] = Filter44.elev20_25_r[i];


                    fourFourFilters.e20[26] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[26].left[i] = Filter44.elev20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[26].right[i] = Filter44.elev20_26_r[i];


                    fourFourFilters.e20[27] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[27].left[i] = Filter44.elev20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[27].right[i] = Filter44.elev20_27_r[i];


                    fourFourFilters.e20[28] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[28].left[i] = Filter44.elev20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[28].right[i] = Filter44.elev20_28_r[i];


                    fourFourFilters.e20[29] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[29].left[i] = Filter44.elev20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[29].right[i] = Filter44.elev20_29_r[i];


                    fourFourFilters.e20[30] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[30].left[i] = Filter44.elev20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[30].right[i] = Filter44.elev20_30_r[i];


                    fourFourFilters.e20[31] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[31].left[i] = Filter44.elev20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[31].right[i] = Filter44.elev20_31_r[i];


                    fourFourFilters.e20[32] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[32].left[i] = Filter44.elev20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[32].right[i] = Filter44.elev20_32_r[i];


                    fourFourFilters.e20[33] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[33].left[i] = Filter44.elev20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[33].right[i] = Filter44.elev20_33_r[i];


                    fourFourFilters.e20[34] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[34].left[i] = Filter44.elev20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[34].right[i] = Filter44.elev20_34_r[i];


                    fourFourFilters.e20[35] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[35].left[i] = Filter44.elev20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[35].right[i] = Filter44.elev20_35_r[i];


                    fourFourFilters.e20[36] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[36].left[i] = Filter44.elev20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e20[36].right[i] = Filter44.elev20_36_r[i];




                    // e30
                    fourFourFilters.e30[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[0].left[i] = Filter44.elev30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[0].right[i] = Filter44.elev30_0_r[i];


                    fourFourFilters.e30[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[1].left[i] = Filter44.elev30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[1].right[i] = Filter44.elev30_1_r[i];


                    fourFourFilters.e30[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[2].left[i] = Filter44.elev30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[2].right[i] = Filter44.elev30_2_r[i];


                    fourFourFilters.e30[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[3].left[i] = Filter44.elev30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[3].right[i] = Filter44.elev30_3_r[i];


                    fourFourFilters.e30[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[4].left[i] = Filter44.elev30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[4].right[i] = Filter44.elev30_4_r[i];


                    fourFourFilters.e30[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[5].left[i] = Filter44.elev30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[5].right[i] = Filter44.elev30_5_r[i];


                    fourFourFilters.e30[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[6].left[i] = Filter44.elev30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[6].right[i] = Filter44.elev30_6_r[i];


                    fourFourFilters.e30[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[7].left[i] = Filter44.elev30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[7].right[i] = Filter44.elev30_7_r[i];


                    fourFourFilters.e30[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[8].left[i] = Filter44.elev30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[8].right[i] = Filter44.elev30_8_r[i];


                    fourFourFilters.e30[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[9].left[i] = Filter44.elev30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[9].right[i] = Filter44.elev30_9_r[i];


                    fourFourFilters.e30[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[10].left[i] = Filter44.elev30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[10].right[i] = Filter44.elev30_10_r[i];


                    fourFourFilters.e30[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[11].left[i] = Filter44.elev30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[11].right[i] = Filter44.elev30_11_r[i];


                    fourFourFilters.e30[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[12].left[i] = Filter44.elev30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[12].right[i] = Filter44.elev30_12_r[i];


                    fourFourFilters.e30[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[13].left[i] = Filter44.elev30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[13].right[i] = Filter44.elev30_13_r[i];


                    fourFourFilters.e30[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[14].left[i] = Filter44.elev30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[14].right[i] = Filter44.elev30_14_r[i];


                    fourFourFilters.e30[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[15].left[i] = Filter44.elev30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[15].right[i] = Filter44.elev30_15_r[i];


                    fourFourFilters.e30[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[16].left[i] = Filter44.elev30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[16].right[i] = Filter44.elev30_16_r[i];


                    fourFourFilters.e30[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[17].left[i] = Filter44.elev30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[17].right[i] = Filter44.elev30_17_r[i];


                    fourFourFilters.e30[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[18].left[i] = Filter44.elev30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[18].right[i] = Filter44.elev30_18_r[i];


                    fourFourFilters.e30[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[19].left[i] = Filter44.elev30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[19].right[i] = Filter44.elev30_19_r[i];


                    fourFourFilters.e30[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[20].left[i] = Filter44.elev30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[20].right[i] = Filter44.elev30_20_r[i];


                    fourFourFilters.e30[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[21].left[i] = Filter44.elev30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[21].right[i] = Filter44.elev30_21_r[i];


                    fourFourFilters.e30[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[22].left[i] = Filter44.elev30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[22].right[i] = Filter44.elev30_22_r[i];


                    fourFourFilters.e30[23] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[23].left[i] = Filter44.elev30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[23].right[i] = Filter44.elev30_23_r[i];


                    fourFourFilters.e30[24] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[24].left[i] = Filter44.elev30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[24].right[i] = Filter44.elev30_24_r[i];


                    fourFourFilters.e30[25] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[25].left[i] = Filter44.elev30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[25].right[i] = Filter44.elev30_25_r[i];


                    fourFourFilters.e30[26] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[26].left[i] = Filter44.elev30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[26].right[i] = Filter44.elev30_26_r[i];


                    fourFourFilters.e30[27] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[27].left[i] = Filter44.elev30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[27].right[i] = Filter44.elev30_27_r[i];


                    fourFourFilters.e30[28] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[28].left[i] = Filter44.elev30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[28].right[i] = Filter44.elev30_28_r[i];


                    fourFourFilters.e30[29] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[29].left[i] = Filter44.elev30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[29].right[i] = Filter44.elev30_29_r[i];


                    fourFourFilters.e30[30] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[30].left[i] = Filter44.elev30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e30[30].right[i] = Filter44.elev30_30_r[i];




                    // e40
                    fourFourFilters.e40[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[0].left[i] = Filter44.elev40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[0].right[i] = Filter44.elev40_0_r[i];


                    fourFourFilters.e40[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[1].left[i] = Filter44.elev40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[1].right[i] = Filter44.elev40_1_r[i];


                    fourFourFilters.e40[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[2].left[i] = Filter44.elev40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[2].right[i] = Filter44.elev40_2_r[i];


                    fourFourFilters.e40[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[3].left[i] = Filter44.elev40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[3].right[i] = Filter44.elev40_3_r[i];


                    fourFourFilters.e40[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[4].left[i] = Filter44.elev40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[4].right[i] = Filter44.elev40_4_r[i];


                    fourFourFilters.e40[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[5].left[i] = Filter44.elev40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[5].right[i] = Filter44.elev40_5_r[i];


                    fourFourFilters.e40[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[6].left[i] = Filter44.elev40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[6].right[i] = Filter44.elev40_6_r[i];


                    fourFourFilters.e40[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[7].left[i] = Filter44.elev40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[7].right[i] = Filter44.elev40_7_r[i];


                    fourFourFilters.e40[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[8].left[i] = Filter44.elev40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[8].right[i] = Filter44.elev40_8_r[i];


                    fourFourFilters.e40[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[9].left[i] = Filter44.elev40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[9].right[i] = Filter44.elev40_9_r[i];


                    fourFourFilters.e40[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[10].left[i] = Filter44.elev40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[10].right[i] = Filter44.elev40_10_r[i];


                    fourFourFilters.e40[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[11].left[i] = Filter44.elev40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[11].right[i] = Filter44.elev40_11_r[i];


                    fourFourFilters.e40[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[12].left[i] = Filter44.elev40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[12].right[i] = Filter44.elev40_12_r[i];


                    fourFourFilters.e40[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[13].left[i] = Filter44.elev40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[13].right[i] = Filter44.elev40_13_r[i];


                    fourFourFilters.e40[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[14].left[i] = Filter44.elev40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[14].right[i] = Filter44.elev40_14_r[i];


                    fourFourFilters.e40[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[15].left[i] = Filter44.elev40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[15].right[i] = Filter44.elev40_15_r[i];


                    fourFourFilters.e40[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[16].left[i] = Filter44.elev40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[16].right[i] = Filter44.elev40_16_r[i];


                    fourFourFilters.e40[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[17].left[i] = Filter44.elev40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[17].right[i] = Filter44.elev40_17_r[i];


                    fourFourFilters.e40[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[18].left[i] = Filter44.elev40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[18].right[i] = Filter44.elev40_18_r[i];


                    fourFourFilters.e40[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[19].left[i] = Filter44.elev40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[19].right[i] = Filter44.elev40_19_r[i];


                    fourFourFilters.e40[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[20].left[i] = Filter44.elev40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[20].right[i] = Filter44.elev40_20_r[i];


                    fourFourFilters.e40[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[21].left[i] = Filter44.elev40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[21].right[i] = Filter44.elev40_21_r[i];


                    fourFourFilters.e40[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[22].left[i] = Filter44.elev40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[22].right[i] = Filter44.elev40_22_r[i];


                    fourFourFilters.e40[23] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[23].left[i] = Filter44.elev40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[23].right[i] = Filter44.elev40_23_r[i];


                    fourFourFilters.e40[24] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[24].left[i] = Filter44.elev40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[24].right[i] = Filter44.elev40_24_r[i];


                    fourFourFilters.e40[25] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[25].left[i] = Filter44.elev40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[25].right[i] = Filter44.elev40_25_r[i];


                    fourFourFilters.e40[26] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[26].left[i] = Filter44.elev40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[26].right[i] = Filter44.elev40_26_r[i];


                    fourFourFilters.e40[27] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[27].left[i] = Filter44.elev40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[27].right[i] = Filter44.elev40_27_r[i];


                    fourFourFilters.e40[28] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[28].left[i] = Filter44.elev40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e40[28].right[i] = Filter44.elev40_28_r[i];




                    // e50
                    fourFourFilters.e50[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[0].left[i] = Filter44.elev50_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[0].right[i] = Filter44.elev50_0_r[i];


                    fourFourFilters.e50[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[1].left[i] = Filter44.elev50_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[1].right[i] = Filter44.elev50_1_r[i];


                    fourFourFilters.e50[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[2].left[i] = Filter44.elev50_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[2].right[i] = Filter44.elev50_2_r[i];


                    fourFourFilters.e50[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[3].left[i] = Filter44.elev50_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[3].right[i] = Filter44.elev50_3_r[i];


                    fourFourFilters.e50[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[4].left[i] = Filter44.elev50_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[4].right[i] = Filter44.elev50_4_r[i];


                    fourFourFilters.e50[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[5].left[i] = Filter44.elev50_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[5].right[i] = Filter44.elev50_5_r[i];


                    fourFourFilters.e50[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[6].left[i] = Filter44.elev50_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[6].right[i] = Filter44.elev50_6_r[i];


                    fourFourFilters.e50[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[7].left[i] = Filter44.elev50_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[7].right[i] = Filter44.elev50_7_r[i];


                    fourFourFilters.e50[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[8].left[i] = Filter44.elev50_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[8].right[i] = Filter44.elev50_8_r[i];


                    fourFourFilters.e50[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[9].left[i] = Filter44.elev50_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[9].right[i] = Filter44.elev50_9_r[i];


                    fourFourFilters.e50[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[10].left[i] = Filter44.elev50_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[10].right[i] = Filter44.elev50_10_r[i];


                    fourFourFilters.e50[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[11].left[i] = Filter44.elev50_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[11].right[i] = Filter44.elev50_11_r[i];


                    fourFourFilters.e50[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[12].left[i] = Filter44.elev50_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[12].right[i] = Filter44.elev50_12_r[i];


                    fourFourFilters.e50[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[13].left[i] = Filter44.elev50_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[13].right[i] = Filter44.elev50_13_r[i];


                    fourFourFilters.e50[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[14].left[i] = Filter44.elev50_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[14].right[i] = Filter44.elev50_14_r[i];


                    fourFourFilters.e50[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[15].left[i] = Filter44.elev50_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[15].right[i] = Filter44.elev50_15_r[i];


                    fourFourFilters.e50[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[16].left[i] = Filter44.elev50_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[16].right[i] = Filter44.elev50_16_r[i];


                    fourFourFilters.e50[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[17].left[i] = Filter44.elev50_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[17].right[i] = Filter44.elev50_17_r[i];


                    fourFourFilters.e50[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[18].left[i] = Filter44.elev50_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[18].right[i] = Filter44.elev50_18_r[i];


                    fourFourFilters.e50[19] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[19].left[i] = Filter44.elev50_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[19].right[i] = Filter44.elev50_19_r[i];


                    fourFourFilters.e50[20] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[20].left[i] = Filter44.elev50_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[20].right[i] = Filter44.elev50_20_r[i];


                    fourFourFilters.e50[21] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[21].left[i] = Filter44.elev50_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[21].right[i] = Filter44.elev50_21_r[i];


                    fourFourFilters.e50[22] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[22].left[i] = Filter44.elev50_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e50[22].right[i] = Filter44.elev50_22_r[i];




                    // e60
                    fourFourFilters.e60[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[0].left[i] = Filter44.elev60_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[0].right[i] = Filter44.elev60_0_r[i];


                    fourFourFilters.e60[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[1].left[i] = Filter44.elev60_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[1].right[i] = Filter44.elev60_1_r[i];


                    fourFourFilters.e60[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[2].left[i] = Filter44.elev60_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[2].right[i] = Filter44.elev60_2_r[i];


                    fourFourFilters.e60[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[3].left[i] = Filter44.elev60_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[3].right[i] = Filter44.elev60_3_r[i];


                    fourFourFilters.e60[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[4].left[i] = Filter44.elev60_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[4].right[i] = Filter44.elev60_4_r[i];


                    fourFourFilters.e60[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[5].left[i] = Filter44.elev60_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[5].right[i] = Filter44.elev60_5_r[i];


                    fourFourFilters.e60[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[6].left[i] = Filter44.elev60_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[6].right[i] = Filter44.elev60_6_r[i];


                    fourFourFilters.e60[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[7].left[i] = Filter44.elev60_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[7].right[i] = Filter44.elev60_7_r[i];


                    fourFourFilters.e60[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[8].left[i] = Filter44.elev60_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[8].right[i] = Filter44.elev60_8_r[i];


                    fourFourFilters.e60[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[9].left[i] = Filter44.elev60_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[9].right[i] = Filter44.elev60_9_r[i];


                    fourFourFilters.e60[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[10].left[i] = Filter44.elev60_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[10].right[i] = Filter44.elev60_10_r[i];


                    fourFourFilters.e60[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[11].left[i] = Filter44.elev60_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[11].right[i] = Filter44.elev60_11_r[i];


                    fourFourFilters.e60[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[12].left[i] = Filter44.elev60_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[12].right[i] = Filter44.elev60_12_r[i];


                    fourFourFilters.e60[13] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[13].left[i] = Filter44.elev60_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[13].right[i] = Filter44.elev60_13_r[i];


                    fourFourFilters.e60[14] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[14].left[i] = Filter44.elev60_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[14].right[i] = Filter44.elev60_14_r[i];


                    fourFourFilters.e60[15] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[15].left[i] = Filter44.elev60_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[15].right[i] = Filter44.elev60_15_r[i];


                    fourFourFilters.e60[16] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[16].left[i] = Filter44.elev60_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[16].right[i] = Filter44.elev60_16_r[i];


                    fourFourFilters.e60[17] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[17].left[i] = Filter44.elev60_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[17].right[i] = Filter44.elev60_17_r[i];


                    fourFourFilters.e60[18] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[18].left[i] = Filter44.elev60_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e60[18].right[i] = Filter44.elev60_18_r[i];




                    // e70
                    fourFourFilters.e70[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[0].left[i] = Filter44.elev70_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[0].right[i] = Filter44.elev70_0_r[i];


                    fourFourFilters.e70[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[1].left[i] = Filter44.elev70_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[1].right[i] = Filter44.elev70_1_r[i];


                    fourFourFilters.e70[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[2].left[i] = Filter44.elev70_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[2].right[i] = Filter44.elev70_2_r[i];


                    fourFourFilters.e70[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[3].left[i] = Filter44.elev70_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[3].right[i] = Filter44.elev70_3_r[i];


                    fourFourFilters.e70[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[4].left[i] = Filter44.elev70_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[4].right[i] = Filter44.elev70_4_r[i];


                    fourFourFilters.e70[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[5].left[i] = Filter44.elev70_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[5].right[i] = Filter44.elev70_5_r[i];


                    fourFourFilters.e70[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[6].left[i] = Filter44.elev70_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[6].right[i] = Filter44.elev70_6_r[i];


                    fourFourFilters.e70[7] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[7].left[i] = Filter44.elev70_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[7].right[i] = Filter44.elev70_7_r[i];


                    fourFourFilters.e70[8] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[8].left[i] = Filter44.elev70_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[8].right[i] = Filter44.elev70_8_r[i];


                    fourFourFilters.e70[9] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[9].left[i] = Filter44.elev70_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[9].right[i] = Filter44.elev70_9_r[i];


                    fourFourFilters.e70[10] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[10].left[i] = Filter44.elev70_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[10].right[i] = Filter44.elev70_10_r[i];


                    fourFourFilters.e70[11] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[11].left[i] = Filter44.elev70_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[11].right[i] = Filter44.elev70_11_r[i];


                    fourFourFilters.e70[12] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[12].left[i] = Filter44.elev70_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e70[12].right[i] = Filter44.elev70_12_r[i];




                    // e80
                    fourFourFilters.e80[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[0].left[i] = Filter44.elev80_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[0].right[i] = Filter44.elev80_0_r[i];


                    fourFourFilters.e80[1] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[1].left[i] = Filter44.elev80_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[1].right[i] = Filter44.elev80_1_r[i];


                    fourFourFilters.e80[2] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[2].left[i] = Filter44.elev80_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[2].right[i] = Filter44.elev80_2_r[i];


                    fourFourFilters.e80[3] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[3].left[i] = Filter44.elev80_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[3].right[i] = Filter44.elev80_3_r[i];


                    fourFourFilters.e80[4] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[4].left[i] = Filter44.elev80_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[4].right[i] = Filter44.elev80_4_r[i];


                    fourFourFilters.e80[5] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[5].left[i] = Filter44.elev80_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[5].right[i] = Filter44.elev80_5_r[i];


                    fourFourFilters.e80[6] = new mit_hrtf_filter_44();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[6].left[i] = Filter44.elev80_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e80[6].right[i] = Filter44.elev80_6_r[i];




                    // e90
                    fourFourFilters.e90[0] = new mit_hrtf_filter_44();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e90[0].left[i] = Filter44.elev90_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_44_TAPS; i++)
                        fourFourFilters.e90[0].right[i] = Filter44.elev90_0_r[i];



                    // Finally, return the fully populated filter set.
                    return fourFourFilters;
                }

            }
        }
        #endregion

        #region 48khz
        private static mit_hrtf_filter_set_48 normal_48
        {
            get
            {
                unsafe
                {
                    var filterSet = mit_hrtf_filter_set_48.Create();


                    // e_10
                    filterSet.e_10[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[0].left[i] = Filter48.elev_10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[0].right[i] = Filter48.elev_10_0_r[i];


                    filterSet.e_10[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[1].left[i] = Filter48.elev_10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[1].right[i] = Filter48.elev_10_1_r[i];


                    filterSet.e_10[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[2].left[i] = Filter48.elev_10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[2].right[i] = Filter48.elev_10_2_r[i];


                    filterSet.e_10[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[3].left[i] = Filter48.elev_10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[3].right[i] = Filter48.elev_10_3_r[i];


                    filterSet.e_10[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[4].left[i] = Filter48.elev_10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[4].right[i] = Filter48.elev_10_4_r[i];


                    filterSet.e_10[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[5].left[i] = Filter48.elev_10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[5].right[i] = Filter48.elev_10_5_r[i];


                    filterSet.e_10[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[6].left[i] = Filter48.elev_10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[6].right[i] = Filter48.elev_10_6_r[i];


                    filterSet.e_10[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[7].left[i] = Filter48.elev_10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[7].right[i] = Filter48.elev_10_7_r[i];


                    filterSet.e_10[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[8].left[i] = Filter48.elev_10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[8].right[i] = Filter48.elev_10_8_r[i];


                    filterSet.e_10[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[9].left[i] = Filter48.elev_10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[9].right[i] = Filter48.elev_10_9_r[i];


                    filterSet.e_10[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[10].left[i] = Filter48.elev_10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[10].right[i] = Filter48.elev_10_10_r[i];


                    filterSet.e_10[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[11].left[i] = Filter48.elev_10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[11].right[i] = Filter48.elev_10_11_r[i];


                    filterSet.e_10[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[12].left[i] = Filter48.elev_10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[12].right[i] = Filter48.elev_10_12_r[i];


                    filterSet.e_10[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[13].left[i] = Filter48.elev_10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[13].right[i] = Filter48.elev_10_13_r[i];


                    filterSet.e_10[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[14].left[i] = Filter48.elev_10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[14].right[i] = Filter48.elev_10_14_r[i];


                    filterSet.e_10[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[15].left[i] = Filter48.elev_10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[15].right[i] = Filter48.elev_10_15_r[i];


                    filterSet.e_10[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[16].left[i] = Filter48.elev_10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[16].right[i] = Filter48.elev_10_16_r[i];


                    filterSet.e_10[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[17].left[i] = Filter48.elev_10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[17].right[i] = Filter48.elev_10_17_r[i];


                    filterSet.e_10[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[18].left[i] = Filter48.elev_10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[18].right[i] = Filter48.elev_10_18_r[i];


                    filterSet.e_10[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[19].left[i] = Filter48.elev_10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[19].right[i] = Filter48.elev_10_19_r[i];


                    filterSet.e_10[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[20].left[i] = Filter48.elev_10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[20].right[i] = Filter48.elev_10_20_r[i];


                    filterSet.e_10[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[21].left[i] = Filter48.elev_10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[21].right[i] = Filter48.elev_10_21_r[i];


                    filterSet.e_10[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[22].left[i] = Filter48.elev_10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[22].right[i] = Filter48.elev_10_22_r[i];


                    filterSet.e_10[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[23].left[i] = Filter48.elev_10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[23].right[i] = Filter48.elev_10_23_r[i];


                    filterSet.e_10[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[24].left[i] = Filter48.elev_10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[24].right[i] = Filter48.elev_10_24_r[i];


                    filterSet.e_10[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[25].left[i] = Filter48.elev_10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[25].right[i] = Filter48.elev_10_25_r[i];


                    filterSet.e_10[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[26].left[i] = Filter48.elev_10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[26].right[i] = Filter48.elev_10_26_r[i];


                    filterSet.e_10[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[27].left[i] = Filter48.elev_10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[27].right[i] = Filter48.elev_10_27_r[i];


                    filterSet.e_10[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[28].left[i] = Filter48.elev_10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[28].right[i] = Filter48.elev_10_28_r[i];


                    filterSet.e_10[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[29].left[i] = Filter48.elev_10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[29].right[i] = Filter48.elev_10_29_r[i];


                    filterSet.e_10[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[30].left[i] = Filter48.elev_10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[30].right[i] = Filter48.elev_10_30_r[i];


                    filterSet.e_10[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[31].left[i] = Filter48.elev_10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[31].right[i] = Filter48.elev_10_31_r[i];


                    filterSet.e_10[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[32].left[i] = Filter48.elev_10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[32].right[i] = Filter48.elev_10_32_r[i];


                    filterSet.e_10[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[33].left[i] = Filter48.elev_10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[33].right[i] = Filter48.elev_10_33_r[i];


                    filterSet.e_10[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[34].left[i] = Filter48.elev_10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[34].right[i] = Filter48.elev_10_34_r[i];


                    filterSet.e_10[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[35].left[i] = Filter48.elev_10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[35].right[i] = Filter48.elev_10_35_r[i];


                    filterSet.e_10[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[36].left[i] = Filter48.elev_10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[36].right[i] = Filter48.elev_10_36_r[i];



                    // e_20
                    filterSet.e_20[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[0].left[i] = Filter48.elev_20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[0].right[i] = Filter48.elev_20_0_r[i];


                    filterSet.e_20[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[1].left[i] = Filter48.elev_20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[1].right[i] = Filter48.elev_20_1_r[i];


                    filterSet.e_20[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[2].left[i] = Filter48.elev_20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[2].right[i] = Filter48.elev_20_2_r[i];


                    filterSet.e_20[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[3].left[i] = Filter48.elev_20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[3].right[i] = Filter48.elev_20_3_r[i];


                    filterSet.e_20[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[4].left[i] = Filter48.elev_20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[4].right[i] = Filter48.elev_20_4_r[i];


                    filterSet.e_20[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[5].left[i] = Filter48.elev_20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[5].right[i] = Filter48.elev_20_5_r[i];


                    filterSet.e_20[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[6].left[i] = Filter48.elev_20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[6].right[i] = Filter48.elev_20_6_r[i];


                    filterSet.e_20[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[7].left[i] = Filter48.elev_20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[7].right[i] = Filter48.elev_20_7_r[i];


                    filterSet.e_20[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[8].left[i] = Filter48.elev_20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[8].right[i] = Filter48.elev_20_8_r[i];


                    filterSet.e_20[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[9].left[i] = Filter48.elev_20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[9].right[i] = Filter48.elev_20_9_r[i];


                    filterSet.e_20[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[10].left[i] = Filter48.elev_20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[10].right[i] = Filter48.elev_20_10_r[i];


                    filterSet.e_20[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[11].left[i] = Filter48.elev_20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[11].right[i] = Filter48.elev_20_11_r[i];


                    filterSet.e_20[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[12].left[i] = Filter48.elev_20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[12].right[i] = Filter48.elev_20_12_r[i];


                    filterSet.e_20[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[13].left[i] = Filter48.elev_20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[13].right[i] = Filter48.elev_20_13_r[i];


                    filterSet.e_20[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[14].left[i] = Filter48.elev_20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[14].right[i] = Filter48.elev_20_14_r[i];


                    filterSet.e_20[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[15].left[i] = Filter48.elev_20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[15].right[i] = Filter48.elev_20_15_r[i];


                    filterSet.e_20[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[16].left[i] = Filter48.elev_20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[16].right[i] = Filter48.elev_20_16_r[i];


                    filterSet.e_20[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[17].left[i] = Filter48.elev_20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[17].right[i] = Filter48.elev_20_17_r[i];


                    filterSet.e_20[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[18].left[i] = Filter48.elev_20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[18].right[i] = Filter48.elev_20_18_r[i];


                    filterSet.e_20[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[19].left[i] = Filter48.elev_20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[19].right[i] = Filter48.elev_20_19_r[i];


                    filterSet.e_20[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[20].left[i] = Filter48.elev_20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[20].right[i] = Filter48.elev_20_20_r[i];


                    filterSet.e_20[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[21].left[i] = Filter48.elev_20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[21].right[i] = Filter48.elev_20_21_r[i];


                    filterSet.e_20[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[22].left[i] = Filter48.elev_20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[22].right[i] = Filter48.elev_20_22_r[i];


                    filterSet.e_20[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[23].left[i] = Filter48.elev_20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[23].right[i] = Filter48.elev_20_23_r[i];


                    filterSet.e_20[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[24].left[i] = Filter48.elev_20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[24].right[i] = Filter48.elev_20_24_r[i];


                    filterSet.e_20[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[25].left[i] = Filter48.elev_20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[25].right[i] = Filter48.elev_20_25_r[i];


                    filterSet.e_20[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[26].left[i] = Filter48.elev_20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[26].right[i] = Filter48.elev_20_26_r[i];


                    filterSet.e_20[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[27].left[i] = Filter48.elev_20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[27].right[i] = Filter48.elev_20_27_r[i];


                    filterSet.e_20[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[28].left[i] = Filter48.elev_20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[28].right[i] = Filter48.elev_20_28_r[i];


                    filterSet.e_20[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[29].left[i] = Filter48.elev_20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[29].right[i] = Filter48.elev_20_29_r[i];


                    filterSet.e_20[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[30].left[i] = Filter48.elev_20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[30].right[i] = Filter48.elev_20_30_r[i];


                    filterSet.e_20[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[31].left[i] = Filter48.elev_20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[31].right[i] = Filter48.elev_20_31_r[i];


                    filterSet.e_20[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[32].left[i] = Filter48.elev_20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[32].right[i] = Filter48.elev_20_32_r[i];


                    filterSet.e_20[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[33].left[i] = Filter48.elev_20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[33].right[i] = Filter48.elev_20_33_r[i];


                    filterSet.e_20[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[34].left[i] = Filter48.elev_20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[34].right[i] = Filter48.elev_20_34_r[i];


                    filterSet.e_20[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[35].left[i] = Filter48.elev_20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[35].right[i] = Filter48.elev_20_35_r[i];


                    filterSet.e_20[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[36].left[i] = Filter48.elev_20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[36].right[i] = Filter48.elev_20_36_r[i];




                    // e_30
                    filterSet.e_30[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[0].left[i] = Filter48.elev_30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[0].right[i] = Filter48.elev_30_0_r[i];


                    filterSet.e_30[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[1].left[i] = Filter48.elev_30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[1].right[i] = Filter48.elev_30_1_r[i];


                    filterSet.e_30[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[2].left[i] = Filter48.elev_30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[2].right[i] = Filter48.elev_30_2_r[i];


                    filterSet.e_30[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[3].left[i] = Filter48.elev_30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[3].right[i] = Filter48.elev_30_3_r[i];


                    filterSet.e_30[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[4].left[i] = Filter48.elev_30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[4].right[i] = Filter48.elev_30_4_r[i];


                    filterSet.e_30[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[5].left[i] = Filter48.elev_30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[5].right[i] = Filter48.elev_30_5_r[i];


                    filterSet.e_30[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[6].left[i] = Filter48.elev_30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[6].right[i] = Filter48.elev_30_6_r[i];


                    filterSet.e_30[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[7].left[i] = Filter48.elev_30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[7].right[i] = Filter48.elev_30_7_r[i];


                    filterSet.e_30[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[8].left[i] = Filter48.elev_30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[8].right[i] = Filter48.elev_30_8_r[i];


                    filterSet.e_30[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[9].left[i] = Filter48.elev_30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[9].right[i] = Filter48.elev_30_9_r[i];


                    filterSet.e_30[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[10].left[i] = Filter48.elev_30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[10].right[i] = Filter48.elev_30_10_r[i];


                    filterSet.e_30[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[11].left[i] = Filter48.elev_30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[11].right[i] = Filter48.elev_30_11_r[i];


                    filterSet.e_30[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[12].left[i] = Filter48.elev_30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[12].right[i] = Filter48.elev_30_12_r[i];


                    filterSet.e_30[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[13].left[i] = Filter48.elev_30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[13].right[i] = Filter48.elev_30_13_r[i];


                    filterSet.e_30[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[14].left[i] = Filter48.elev_30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[14].right[i] = Filter48.elev_30_14_r[i];


                    filterSet.e_30[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[15].left[i] = Filter48.elev_30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[15].right[i] = Filter48.elev_30_15_r[i];


                    filterSet.e_30[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[16].left[i] = Filter48.elev_30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[16].right[i] = Filter48.elev_30_16_r[i];


                    filterSet.e_30[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[17].left[i] = Filter48.elev_30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[17].right[i] = Filter48.elev_30_17_r[i];


                    filterSet.e_30[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[18].left[i] = Filter48.elev_30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[18].right[i] = Filter48.elev_30_18_r[i];


                    filterSet.e_30[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[19].left[i] = Filter48.elev_30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[19].right[i] = Filter48.elev_30_19_r[i];


                    filterSet.e_30[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[20].left[i] = Filter48.elev_30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[20].right[i] = Filter48.elev_30_20_r[i];


                    filterSet.e_30[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[21].left[i] = Filter48.elev_30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[21].right[i] = Filter48.elev_30_21_r[i];


                    filterSet.e_30[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[22].left[i] = Filter48.elev_30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[22].right[i] = Filter48.elev_30_22_r[i];


                    filterSet.e_30[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[23].left[i] = Filter48.elev_30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[23].right[i] = Filter48.elev_30_23_r[i];


                    filterSet.e_30[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[24].left[i] = Filter48.elev_30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[24].right[i] = Filter48.elev_30_24_r[i];


                    filterSet.e_30[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[25].left[i] = Filter48.elev_30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[25].right[i] = Filter48.elev_30_25_r[i];


                    filterSet.e_30[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[26].left[i] = Filter48.elev_30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[26].right[i] = Filter48.elev_30_26_r[i];


                    filterSet.e_30[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[27].left[i] = Filter48.elev_30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[27].right[i] = Filter48.elev_30_27_r[i];


                    filterSet.e_30[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[28].left[i] = Filter48.elev_30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[28].right[i] = Filter48.elev_30_28_r[i];


                    filterSet.e_30[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[29].left[i] = Filter48.elev_30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[29].right[i] = Filter48.elev_30_29_r[i];


                    filterSet.e_30[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[30].left[i] = Filter48.elev_30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[30].right[i] = Filter48.elev_30_30_r[i];



                    // e_40
                    filterSet.e_40[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[0].left[i] = Filter48.elev_40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[0].right[i] = Filter48.elev_40_0_r[i];


                    filterSet.e_40[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[1].left[i] = Filter48.elev_40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[1].right[i] = Filter48.elev_40_1_r[i];


                    filterSet.e_40[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[2].left[i] = Filter48.elev_40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[2].right[i] = Filter48.elev_40_2_r[i];


                    filterSet.e_40[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[3].left[i] = Filter48.elev_40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[3].right[i] = Filter48.elev_40_3_r[i];


                    filterSet.e_40[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[4].left[i] = Filter48.elev_40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[4].right[i] = Filter48.elev_40_4_r[i];


                    filterSet.e_40[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[5].left[i] = Filter48.elev_40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[5].right[i] = Filter48.elev_40_5_r[i];


                    filterSet.e_40[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[6].left[i] = Filter48.elev_40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[6].right[i] = Filter48.elev_40_6_r[i];


                    filterSet.e_40[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[7].left[i] = Filter48.elev_40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[7].right[i] = Filter48.elev_40_7_r[i];


                    filterSet.e_40[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[8].left[i] = Filter48.elev_40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[8].right[i] = Filter48.elev_40_8_r[i];


                    filterSet.e_40[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[9].left[i] = Filter48.elev_40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[9].right[i] = Filter48.elev_40_9_r[i];


                    filterSet.e_40[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[10].left[i] = Filter48.elev_40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[10].right[i] = Filter48.elev_40_10_r[i];


                    filterSet.e_40[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[11].left[i] = Filter48.elev_40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[11].right[i] = Filter48.elev_40_11_r[i];


                    filterSet.e_40[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[12].left[i] = Filter48.elev_40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[12].right[i] = Filter48.elev_40_12_r[i];


                    filterSet.e_40[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[13].left[i] = Filter48.elev_40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[13].right[i] = Filter48.elev_40_13_r[i];


                    filterSet.e_40[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[14].left[i] = Filter48.elev_40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[14].right[i] = Filter48.elev_40_14_r[i];


                    filterSet.e_40[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[15].left[i] = Filter48.elev_40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[15].right[i] = Filter48.elev_40_15_r[i];


                    filterSet.e_40[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[16].left[i] = Filter48.elev_40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[16].right[i] = Filter48.elev_40_16_r[i];


                    filterSet.e_40[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[17].left[i] = Filter48.elev_40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[17].right[i] = Filter48.elev_40_17_r[i];


                    filterSet.e_40[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[18].left[i] = Filter48.elev_40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[18].right[i] = Filter48.elev_40_18_r[i];


                    filterSet.e_40[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[19].left[i] = Filter48.elev_40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[19].right[i] = Filter48.elev_40_19_r[i];


                    filterSet.e_40[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[20].left[i] = Filter48.elev_40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[20].right[i] = Filter48.elev_40_20_r[i];


                    filterSet.e_40[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[21].left[i] = Filter48.elev_40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[21].right[i] = Filter48.elev_40_21_r[i];


                    filterSet.e_40[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[22].left[i] = Filter48.elev_40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[22].right[i] = Filter48.elev_40_22_r[i];


                    filterSet.e_40[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[23].left[i] = Filter48.elev_40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[23].right[i] = Filter48.elev_40_23_r[i];


                    filterSet.e_40[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[24].left[i] = Filter48.elev_40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[24].right[i] = Filter48.elev_40_24_r[i];


                    filterSet.e_40[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[25].left[i] = Filter48.elev_40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[25].right[i] = Filter48.elev_40_25_r[i];


                    filterSet.e_40[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[26].left[i] = Filter48.elev_40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[26].right[i] = Filter48.elev_40_26_r[i];


                    filterSet.e_40[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[27].left[i] = Filter48.elev_40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[27].right[i] = Filter48.elev_40_27_r[i];


                    filterSet.e_40[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[28].left[i] = Filter48.elev_40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[28].right[i] = Filter48.elev_40_28_r[i];




                    // e0
                    filterSet.e00[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[0].left[i] = Filter48.elev0_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[0].right[i] = Filter48.elev0_0_r[i];


                    filterSet.e00[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[1].left[i] = Filter48.elev0_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[1].right[i] = Filter48.elev0_1_r[i];


                    filterSet.e00[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[2].left[i] = Filter48.elev0_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[2].right[i] = Filter48.elev0_2_r[i];


                    filterSet.e00[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[3].left[i] = Filter48.elev0_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[3].right[i] = Filter48.elev0_3_r[i];


                    filterSet.e00[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[4].left[i] = Filter48.elev0_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[4].right[i] = Filter48.elev0_4_r[i];


                    filterSet.e00[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[5].left[i] = Filter48.elev0_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[5].right[i] = Filter48.elev0_5_r[i];


                    filterSet.e00[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[6].left[i] = Filter48.elev0_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[6].right[i] = Filter48.elev0_6_r[i];


                    filterSet.e00[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[7].left[i] = Filter48.elev0_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[7].right[i] = Filter48.elev0_7_r[i];


                    filterSet.e00[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[8].left[i] = Filter48.elev0_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[8].right[i] = Filter48.elev0_8_r[i];


                    filterSet.e00[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[9].left[i] = Filter48.elev0_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[9].right[i] = Filter48.elev0_9_r[i];


                    filterSet.e00[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[10].left[i] = Filter48.elev0_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[10].right[i] = Filter48.elev0_10_r[i];


                    filterSet.e00[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[11].left[i] = Filter48.elev0_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[11].right[i] = Filter48.elev0_11_r[i];


                    filterSet.e00[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[12].left[i] = Filter48.elev0_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[12].right[i] = Filter48.elev0_12_r[i];


                    filterSet.e00[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[13].left[i] = Filter48.elev0_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[13].right[i] = Filter48.elev0_13_r[i];


                    filterSet.e00[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[14].left[i] = Filter48.elev0_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[14].right[i] = Filter48.elev0_14_r[i];


                    filterSet.e00[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[15].left[i] = Filter48.elev0_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[15].right[i] = Filter48.elev0_15_r[i];


                    filterSet.e00[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[16].left[i] = Filter48.elev0_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[16].right[i] = Filter48.elev0_16_r[i];


                    filterSet.e00[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[17].left[i] = Filter48.elev0_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[17].right[i] = Filter48.elev0_17_r[i];


                    filterSet.e00[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[18].left[i] = Filter48.elev0_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[18].right[i] = Filter48.elev0_18_r[i];


                    filterSet.e00[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[19].left[i] = Filter48.elev0_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[19].right[i] = Filter48.elev0_19_r[i];


                    filterSet.e00[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[20].left[i] = Filter48.elev0_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[20].right[i] = Filter48.elev0_20_r[i];


                    filterSet.e00[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[21].left[i] = Filter48.elev0_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[21].right[i] = Filter48.elev0_21_r[i];


                    filterSet.e00[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[22].left[i] = Filter48.elev0_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[22].right[i] = Filter48.elev0_22_r[i];


                    filterSet.e00[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[23].left[i] = Filter48.elev0_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[23].right[i] = Filter48.elev0_23_r[i];


                    filterSet.e00[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[24].left[i] = Filter48.elev0_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[24].right[i] = Filter48.elev0_24_r[i];


                    filterSet.e00[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[25].left[i] = Filter48.elev0_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[25].right[i] = Filter48.elev0_25_r[i];


                    filterSet.e00[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[26].left[i] = Filter48.elev0_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[26].right[i] = Filter48.elev0_26_r[i];


                    filterSet.e00[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[27].left[i] = Filter48.elev0_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[27].right[i] = Filter48.elev0_27_r[i];


                    filterSet.e00[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[28].left[i] = Filter48.elev0_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[28].right[i] = Filter48.elev0_28_r[i];


                    filterSet.e00[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[29].left[i] = Filter48.elev0_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[29].right[i] = Filter48.elev0_29_r[i];


                    filterSet.e00[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[30].left[i] = Filter48.elev0_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[30].right[i] = Filter48.elev0_30_r[i];


                    filterSet.e00[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[31].left[i] = Filter48.elev0_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[31].right[i] = Filter48.elev0_31_r[i];


                    filterSet.e00[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[32].left[i] = Filter48.elev0_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[32].right[i] = Filter48.elev0_32_r[i];


                    filterSet.e00[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[33].left[i] = Filter48.elev0_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[33].right[i] = Filter48.elev0_33_r[i];


                    filterSet.e00[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[34].left[i] = Filter48.elev0_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[34].right[i] = Filter48.elev0_34_r[i];


                    filterSet.e00[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[35].left[i] = Filter48.elev0_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[35].right[i] = Filter48.elev0_35_r[i];


                    filterSet.e00[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[36].left[i] = Filter48.elev0_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[36].right[i] = Filter48.elev0_36_r[i];




                    // e10
                    filterSet.e10[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[0].left[i] = Filter48.elev10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[0].right[i] = Filter48.elev10_0_r[i];


                    filterSet.e10[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[1].left[i] = Filter48.elev10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[1].right[i] = Filter48.elev10_1_r[i];


                    filterSet.e10[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[2].left[i] = Filter48.elev10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[2].right[i] = Filter48.elev10_2_r[i];


                    filterSet.e10[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[3].left[i] = Filter48.elev10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[3].right[i] = Filter48.elev10_3_r[i];


                    filterSet.e10[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[4].left[i] = Filter48.elev10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[4].right[i] = Filter48.elev10_4_r[i];


                    filterSet.e10[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[5].left[i] = Filter48.elev10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[5].right[i] = Filter48.elev10_5_r[i];


                    filterSet.e10[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[6].left[i] = Filter48.elev10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[6].right[i] = Filter48.elev10_6_r[i];


                    filterSet.e10[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[7].left[i] = Filter48.elev10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[7].right[i] = Filter48.elev10_7_r[i];


                    filterSet.e10[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[8].left[i] = Filter48.elev10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[8].right[i] = Filter48.elev10_8_r[i];


                    filterSet.e10[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[9].left[i] = Filter48.elev10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[9].right[i] = Filter48.elev10_9_r[i];


                    filterSet.e10[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[10].left[i] = Filter48.elev10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[10].right[i] = Filter48.elev10_10_r[i];


                    filterSet.e10[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[11].left[i] = Filter48.elev10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[11].right[i] = Filter48.elev10_11_r[i];


                    filterSet.e10[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[12].left[i] = Filter48.elev10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[12].right[i] = Filter48.elev10_12_r[i];


                    filterSet.e10[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[13].left[i] = Filter48.elev10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[13].right[i] = Filter48.elev10_13_r[i];


                    filterSet.e10[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[14].left[i] = Filter48.elev10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[14].right[i] = Filter48.elev10_14_r[i];


                    filterSet.e10[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[15].left[i] = Filter48.elev10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[15].right[i] = Filter48.elev10_15_r[i];


                    filterSet.e10[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[16].left[i] = Filter48.elev10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[16].right[i] = Filter48.elev10_16_r[i];


                    filterSet.e10[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[17].left[i] = Filter48.elev10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[17].right[i] = Filter48.elev10_17_r[i];


                    filterSet.e10[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[18].left[i] = Filter48.elev10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[18].right[i] = Filter48.elev10_18_r[i];


                    filterSet.e10[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[19].left[i] = Filter48.elev10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[19].right[i] = Filter48.elev10_19_r[i];


                    filterSet.e10[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[20].left[i] = Filter48.elev10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[20].right[i] = Filter48.elev10_20_r[i];


                    filterSet.e10[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[21].left[i] = Filter48.elev10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[21].right[i] = Filter48.elev10_21_r[i];


                    filterSet.e10[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[22].left[i] = Filter48.elev10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[22].right[i] = Filter48.elev10_22_r[i];


                    filterSet.e10[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[23].left[i] = Filter48.elev10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[23].right[i] = Filter48.elev10_23_r[i];


                    filterSet.e10[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[24].left[i] = Filter48.elev10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[24].right[i] = Filter48.elev10_24_r[i];


                    filterSet.e10[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[25].left[i] = Filter48.elev10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[25].right[i] = Filter48.elev10_25_r[i];


                    filterSet.e10[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[26].left[i] = Filter48.elev10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[26].right[i] = Filter48.elev10_26_r[i];


                    filterSet.e10[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[27].left[i] = Filter48.elev10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[27].right[i] = Filter48.elev10_27_r[i];


                    filterSet.e10[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[28].left[i] = Filter48.elev10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[28].right[i] = Filter48.elev10_28_r[i];


                    filterSet.e10[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[29].left[i] = Filter48.elev10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[29].right[i] = Filter48.elev10_29_r[i];


                    filterSet.e10[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[30].left[i] = Filter48.elev10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[30].right[i] = Filter48.elev10_30_r[i];


                    filterSet.e10[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[31].left[i] = Filter48.elev10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[31].right[i] = Filter48.elev10_31_r[i];


                    filterSet.e10[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[32].left[i] = Filter48.elev10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[32].right[i] = Filter48.elev10_32_r[i];


                    filterSet.e10[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[33].left[i] = Filter48.elev10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[33].right[i] = Filter48.elev10_33_r[i];


                    filterSet.e10[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[34].left[i] = Filter48.elev10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[34].right[i] = Filter48.elev10_34_r[i];


                    filterSet.e10[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[35].left[i] = Filter48.elev10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[35].right[i] = Filter48.elev10_35_r[i];


                    filterSet.e10[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[36].left[i] = Filter48.elev10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[36].right[i] = Filter48.elev10_36_r[i];




                    // e20
                    filterSet.e20[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[0].left[i] = Filter48.elev20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[0].right[i] = Filter48.elev20_0_r[i];


                    filterSet.e20[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[1].left[i] = Filter48.elev20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[1].right[i] = Filter48.elev20_1_r[i];


                    filterSet.e20[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[2].left[i] = Filter48.elev20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[2].right[i] = Filter48.elev20_2_r[i];


                    filterSet.e20[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[3].left[i] = Filter48.elev20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[3].right[i] = Filter48.elev20_3_r[i];


                    filterSet.e20[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[4].left[i] = Filter48.elev20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[4].right[i] = Filter48.elev20_4_r[i];


                    filterSet.e20[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[5].left[i] = Filter48.elev20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[5].right[i] = Filter48.elev20_5_r[i];


                    filterSet.e20[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[6].left[i] = Filter48.elev20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[6].right[i] = Filter48.elev20_6_r[i];


                    filterSet.e20[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[7].left[i] = Filter48.elev20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[7].right[i] = Filter48.elev20_7_r[i];


                    filterSet.e20[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[8].left[i] = Filter48.elev20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[8].right[i] = Filter48.elev20_8_r[i];


                    filterSet.e20[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[9].left[i] = Filter48.elev20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[9].right[i] = Filter48.elev20_9_r[i];


                    filterSet.e20[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[10].left[i] = Filter48.elev20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[10].right[i] = Filter48.elev20_10_r[i];


                    filterSet.e20[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[11].left[i] = Filter48.elev20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[11].right[i] = Filter48.elev20_11_r[i];


                    filterSet.e20[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[12].left[i] = Filter48.elev20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[12].right[i] = Filter48.elev20_12_r[i];


                    filterSet.e20[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[13].left[i] = Filter48.elev20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[13].right[i] = Filter48.elev20_13_r[i];


                    filterSet.e20[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[14].left[i] = Filter48.elev20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[14].right[i] = Filter48.elev20_14_r[i];


                    filterSet.e20[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[15].left[i] = Filter48.elev20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[15].right[i] = Filter48.elev20_15_r[i];


                    filterSet.e20[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[16].left[i] = Filter48.elev20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[16].right[i] = Filter48.elev20_16_r[i];


                    filterSet.e20[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[17].left[i] = Filter48.elev20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[17].right[i] = Filter48.elev20_17_r[i];


                    filterSet.e20[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[18].left[i] = Filter48.elev20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[18].right[i] = Filter48.elev20_18_r[i];


                    filterSet.e20[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[19].left[i] = Filter48.elev20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[19].right[i] = Filter48.elev20_19_r[i];


                    filterSet.e20[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[20].left[i] = Filter48.elev20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[20].right[i] = Filter48.elev20_20_r[i];


                    filterSet.e20[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[21].left[i] = Filter48.elev20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[21].right[i] = Filter48.elev20_21_r[i];


                    filterSet.e20[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[22].left[i] = Filter48.elev20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[22].right[i] = Filter48.elev20_22_r[i];


                    filterSet.e20[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[23].left[i] = Filter48.elev20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[23].right[i] = Filter48.elev20_23_r[i];


                    filterSet.e20[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[24].left[i] = Filter48.elev20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[24].right[i] = Filter48.elev20_24_r[i];


                    filterSet.e20[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[25].left[i] = Filter48.elev20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[25].right[i] = Filter48.elev20_25_r[i];


                    filterSet.e20[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[26].left[i] = Filter48.elev20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[26].right[i] = Filter48.elev20_26_r[i];


                    filterSet.e20[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[27].left[i] = Filter48.elev20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[27].right[i] = Filter48.elev20_27_r[i];


                    filterSet.e20[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[28].left[i] = Filter48.elev20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[28].right[i] = Filter48.elev20_28_r[i];


                    filterSet.e20[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[29].left[i] = Filter48.elev20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[29].right[i] = Filter48.elev20_29_r[i];


                    filterSet.e20[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[30].left[i] = Filter48.elev20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[30].right[i] = Filter48.elev20_30_r[i];


                    filterSet.e20[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[31].left[i] = Filter48.elev20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[31].right[i] = Filter48.elev20_31_r[i];


                    filterSet.e20[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[32].left[i] = Filter48.elev20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[32].right[i] = Filter48.elev20_32_r[i];


                    filterSet.e20[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[33].left[i] = Filter48.elev20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[33].right[i] = Filter48.elev20_33_r[i];


                    filterSet.e20[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[34].left[i] = Filter48.elev20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[34].right[i] = Filter48.elev20_34_r[i];


                    filterSet.e20[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[35].left[i] = Filter48.elev20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[35].right[i] = Filter48.elev20_35_r[i];


                    filterSet.e20[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[36].left[i] = Filter48.elev20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[36].right[i] = Filter48.elev20_36_r[i];




                    // e30
                    filterSet.e30[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[0].left[i] = Filter48.elev30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[0].right[i] = Filter48.elev30_0_r[i];


                    filterSet.e30[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[1].left[i] = Filter48.elev30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[1].right[i] = Filter48.elev30_1_r[i];


                    filterSet.e30[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[2].left[i] = Filter48.elev30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[2].right[i] = Filter48.elev30_2_r[i];


                    filterSet.e30[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[3].left[i] = Filter48.elev30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[3].right[i] = Filter48.elev30_3_r[i];


                    filterSet.e30[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[4].left[i] = Filter48.elev30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[4].right[i] = Filter48.elev30_4_r[i];


                    filterSet.e30[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[5].left[i] = Filter48.elev30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[5].right[i] = Filter48.elev30_5_r[i];


                    filterSet.e30[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[6].left[i] = Filter48.elev30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[6].right[i] = Filter48.elev30_6_r[i];


                    filterSet.e30[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[7].left[i] = Filter48.elev30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[7].right[i] = Filter48.elev30_7_r[i];


                    filterSet.e30[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[8].left[i] = Filter48.elev30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[8].right[i] = Filter48.elev30_8_r[i];


                    filterSet.e30[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[9].left[i] = Filter48.elev30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[9].right[i] = Filter48.elev30_9_r[i];


                    filterSet.e30[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[10].left[i] = Filter48.elev30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[10].right[i] = Filter48.elev30_10_r[i];


                    filterSet.e30[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[11].left[i] = Filter48.elev30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[11].right[i] = Filter48.elev30_11_r[i];


                    filterSet.e30[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[12].left[i] = Filter48.elev30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[12].right[i] = Filter48.elev30_12_r[i];


                    filterSet.e30[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[13].left[i] = Filter48.elev30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[13].right[i] = Filter48.elev30_13_r[i];


                    filterSet.e30[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[14].left[i] = Filter48.elev30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[14].right[i] = Filter48.elev30_14_r[i];


                    filterSet.e30[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[15].left[i] = Filter48.elev30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[15].right[i] = Filter48.elev30_15_r[i];


                    filterSet.e30[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[16].left[i] = Filter48.elev30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[16].right[i] = Filter48.elev30_16_r[i];


                    filterSet.e30[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[17].left[i] = Filter48.elev30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[17].right[i] = Filter48.elev30_17_r[i];


                    filterSet.e30[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[18].left[i] = Filter48.elev30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[18].right[i] = Filter48.elev30_18_r[i];


                    filterSet.e30[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[19].left[i] = Filter48.elev30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[19].right[i] = Filter48.elev30_19_r[i];


                    filterSet.e30[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[20].left[i] = Filter48.elev30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[20].right[i] = Filter48.elev30_20_r[i];


                    filterSet.e30[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[21].left[i] = Filter48.elev30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[21].right[i] = Filter48.elev30_21_r[i];


                    filterSet.e30[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[22].left[i] = Filter48.elev30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[22].right[i] = Filter48.elev30_22_r[i];


                    filterSet.e30[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[23].left[i] = Filter48.elev30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[23].right[i] = Filter48.elev30_23_r[i];


                    filterSet.e30[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[24].left[i] = Filter48.elev30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[24].right[i] = Filter48.elev30_24_r[i];


                    filterSet.e30[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[25].left[i] = Filter48.elev30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[25].right[i] = Filter48.elev30_25_r[i];


                    filterSet.e30[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[26].left[i] = Filter48.elev30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[26].right[i] = Filter48.elev30_26_r[i];


                    filterSet.e30[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[27].left[i] = Filter48.elev30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[27].right[i] = Filter48.elev30_27_r[i];


                    filterSet.e30[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[28].left[i] = Filter48.elev30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[28].right[i] = Filter48.elev30_28_r[i];


                    filterSet.e30[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[29].left[i] = Filter48.elev30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[29].right[i] = Filter48.elev30_29_r[i];


                    filterSet.e30[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[30].left[i] = Filter48.elev30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[30].right[i] = Filter48.elev30_30_r[i];




                    // e40
                    filterSet.e40[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[0].left[i] = Filter48.elev40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[0].right[i] = Filter48.elev40_0_r[i];


                    filterSet.e40[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[1].left[i] = Filter48.elev40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[1].right[i] = Filter48.elev40_1_r[i];


                    filterSet.e40[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[2].left[i] = Filter48.elev40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[2].right[i] = Filter48.elev40_2_r[i];


                    filterSet.e40[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[3].left[i] = Filter48.elev40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[3].right[i] = Filter48.elev40_3_r[i];


                    filterSet.e40[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[4].left[i] = Filter48.elev40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[4].right[i] = Filter48.elev40_4_r[i];


                    filterSet.e40[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[5].left[i] = Filter48.elev40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[5].right[i] = Filter48.elev40_5_r[i];


                    filterSet.e40[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[6].left[i] = Filter48.elev40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[6].right[i] = Filter48.elev40_6_r[i];


                    filterSet.e40[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[7].left[i] = Filter48.elev40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[7].right[i] = Filter48.elev40_7_r[i];


                    filterSet.e40[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[8].left[i] = Filter48.elev40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[8].right[i] = Filter48.elev40_8_r[i];


                    filterSet.e40[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[9].left[i] = Filter48.elev40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[9].right[i] = Filter48.elev40_9_r[i];


                    filterSet.e40[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[10].left[i] = Filter48.elev40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[10].right[i] = Filter48.elev40_10_r[i];


                    filterSet.e40[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[11].left[i] = Filter48.elev40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[11].right[i] = Filter48.elev40_11_r[i];


                    filterSet.e40[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[12].left[i] = Filter48.elev40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[12].right[i] = Filter48.elev40_12_r[i];


                    filterSet.e40[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[13].left[i] = Filter48.elev40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[13].right[i] = Filter48.elev40_13_r[i];


                    filterSet.e40[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[14].left[i] = Filter48.elev40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[14].right[i] = Filter48.elev40_14_r[i];


                    filterSet.e40[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[15].left[i] = Filter48.elev40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[15].right[i] = Filter48.elev40_15_r[i];


                    filterSet.e40[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[16].left[i] = Filter48.elev40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[16].right[i] = Filter48.elev40_16_r[i];


                    filterSet.e40[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[17].left[i] = Filter48.elev40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[17].right[i] = Filter48.elev40_17_r[i];


                    filterSet.e40[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[18].left[i] = Filter48.elev40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[18].right[i] = Filter48.elev40_18_r[i];


                    filterSet.e40[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[19].left[i] = Filter48.elev40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[19].right[i] = Filter48.elev40_19_r[i];


                    filterSet.e40[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[20].left[i] = Filter48.elev40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[20].right[i] = Filter48.elev40_20_r[i];


                    filterSet.e40[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[21].left[i] = Filter48.elev40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[21].right[i] = Filter48.elev40_21_r[i];


                    filterSet.e40[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[22].left[i] = Filter48.elev40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[22].right[i] = Filter48.elev40_22_r[i];


                    filterSet.e40[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[23].left[i] = Filter48.elev40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[23].right[i] = Filter48.elev40_23_r[i];


                    filterSet.e40[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[24].left[i] = Filter48.elev40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[24].right[i] = Filter48.elev40_24_r[i];


                    filterSet.e40[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[25].left[i] = Filter48.elev40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[25].right[i] = Filter48.elev40_25_r[i];


                    filterSet.e40[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[26].left[i] = Filter48.elev40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[26].right[i] = Filter48.elev40_26_r[i];


                    filterSet.e40[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[27].left[i] = Filter48.elev40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[27].right[i] = Filter48.elev40_27_r[i];


                    filterSet.e40[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[28].left[i] = Filter48.elev40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[28].right[i] = Filter48.elev40_28_r[i];




                    // e50
                    filterSet.e50[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[0].left[i] = Filter48.elev50_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[0].right[i] = Filter48.elev50_0_r[i];


                    filterSet.e50[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[1].left[i] = Filter48.elev50_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[1].right[i] = Filter48.elev50_1_r[i];


                    filterSet.e50[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[2].left[i] = Filter48.elev50_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[2].right[i] = Filter48.elev50_2_r[i];


                    filterSet.e50[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[3].left[i] = Filter48.elev50_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[3].right[i] = Filter48.elev50_3_r[i];


                    filterSet.e50[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[4].left[i] = Filter48.elev50_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[4].right[i] = Filter48.elev50_4_r[i];


                    filterSet.e50[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[5].left[i] = Filter48.elev50_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[5].right[i] = Filter48.elev50_5_r[i];


                    filterSet.e50[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[6].left[i] = Filter48.elev50_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[6].right[i] = Filter48.elev50_6_r[i];


                    filterSet.e50[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[7].left[i] = Filter48.elev50_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[7].right[i] = Filter48.elev50_7_r[i];


                    filterSet.e50[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[8].left[i] = Filter48.elev50_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[8].right[i] = Filter48.elev50_8_r[i];


                    filterSet.e50[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[9].left[i] = Filter48.elev50_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[9].right[i] = Filter48.elev50_9_r[i];


                    filterSet.e50[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[10].left[i] = Filter48.elev50_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[10].right[i] = Filter48.elev50_10_r[i];


                    filterSet.e50[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[11].left[i] = Filter48.elev50_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[11].right[i] = Filter48.elev50_11_r[i];


                    filterSet.e50[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[12].left[i] = Filter48.elev50_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[12].right[i] = Filter48.elev50_12_r[i];


                    filterSet.e50[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[13].left[i] = Filter48.elev50_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[13].right[i] = Filter48.elev50_13_r[i];


                    filterSet.e50[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[14].left[i] = Filter48.elev50_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[14].right[i] = Filter48.elev50_14_r[i];


                    filterSet.e50[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[15].left[i] = Filter48.elev50_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[15].right[i] = Filter48.elev50_15_r[i];


                    filterSet.e50[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[16].left[i] = Filter48.elev50_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[16].right[i] = Filter48.elev50_16_r[i];


                    filterSet.e50[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[17].left[i] = Filter48.elev50_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[17].right[i] = Filter48.elev50_17_r[i];


                    filterSet.e50[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[18].left[i] = Filter48.elev50_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[18].right[i] = Filter48.elev50_18_r[i];


                    filterSet.e50[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[19].left[i] = Filter48.elev50_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[19].right[i] = Filter48.elev50_19_r[i];


                    filterSet.e50[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[20].left[i] = Filter48.elev50_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[20].right[i] = Filter48.elev50_20_r[i];


                    filterSet.e50[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[21].left[i] = Filter48.elev50_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[21].right[i] = Filter48.elev50_21_r[i];


                    filterSet.e50[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[22].left[i] = Filter48.elev50_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[22].right[i] = Filter48.elev50_22_r[i];




                    // e60
                    filterSet.e60[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[0].left[i] = Filter48.elev60_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[0].right[i] = Filter48.elev60_0_r[i];


                    filterSet.e60[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[1].left[i] = Filter48.elev60_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[1].right[i] = Filter48.elev60_1_r[i];


                    filterSet.e60[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[2].left[i] = Filter48.elev60_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[2].right[i] = Filter48.elev60_2_r[i];


                    filterSet.e60[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[3].left[i] = Filter48.elev60_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[3].right[i] = Filter48.elev60_3_r[i];


                    filterSet.e60[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[4].left[i] = Filter48.elev60_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[4].right[i] = Filter48.elev60_4_r[i];


                    filterSet.e60[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[5].left[i] = Filter48.elev60_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[5].right[i] = Filter48.elev60_5_r[i];


                    filterSet.e60[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[6].left[i] = Filter48.elev60_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[6].right[i] = Filter48.elev60_6_r[i];


                    filterSet.e60[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[7].left[i] = Filter48.elev60_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[7].right[i] = Filter48.elev60_7_r[i];


                    filterSet.e60[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[8].left[i] = Filter48.elev60_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[8].right[i] = Filter48.elev60_8_r[i];


                    filterSet.e60[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[9].left[i] = Filter48.elev60_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[9].right[i] = Filter48.elev60_9_r[i];


                    filterSet.e60[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[10].left[i] = Filter48.elev60_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[10].right[i] = Filter48.elev60_10_r[i];


                    filterSet.e60[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[11].left[i] = Filter48.elev60_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[11].right[i] = Filter48.elev60_11_r[i];


                    filterSet.e60[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[12].left[i] = Filter48.elev60_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[12].right[i] = Filter48.elev60_12_r[i];


                    filterSet.e60[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[13].left[i] = Filter48.elev60_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[13].right[i] = Filter48.elev60_13_r[i];


                    filterSet.e60[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[14].left[i] = Filter48.elev60_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[14].right[i] = Filter48.elev60_14_r[i];


                    filterSet.e60[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[15].left[i] = Filter48.elev60_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[15].right[i] = Filter48.elev60_15_r[i];


                    filterSet.e60[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[16].left[i] = Filter48.elev60_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[16].right[i] = Filter48.elev60_16_r[i];


                    filterSet.e60[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[17].left[i] = Filter48.elev60_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[17].right[i] = Filter48.elev60_17_r[i];


                    filterSet.e60[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[18].left[i] = Filter48.elev60_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[18].right[i] = Filter48.elev60_18_r[i];




                    // e70
                    filterSet.e70[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[0].left[i] = Filter48.elev70_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[0].right[i] = Filter48.elev70_0_r[i];


                    filterSet.e70[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[1].left[i] = Filter48.elev70_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[1].right[i] = Filter48.elev70_1_r[i];


                    filterSet.e70[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[2].left[i] = Filter48.elev70_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[2].right[i] = Filter48.elev70_2_r[i];


                    filterSet.e70[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[3].left[i] = Filter48.elev70_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[3].right[i] = Filter48.elev70_3_r[i];


                    filterSet.e70[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[4].left[i] = Filter48.elev70_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[4].right[i] = Filter48.elev70_4_r[i];


                    filterSet.e70[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[5].left[i] = Filter48.elev70_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[5].right[i] = Filter48.elev70_5_r[i];


                    filterSet.e70[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[6].left[i] = Filter48.elev70_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[6].right[i] = Filter48.elev70_6_r[i];


                    filterSet.e70[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[7].left[i] = Filter48.elev70_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[7].right[i] = Filter48.elev70_7_r[i];


                    filterSet.e70[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[8].left[i] = Filter48.elev70_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[8].right[i] = Filter48.elev70_8_r[i];


                    filterSet.e70[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[9].left[i] = Filter48.elev70_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[9].right[i] = Filter48.elev70_9_r[i];


                    filterSet.e70[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[10].left[i] = Filter48.elev70_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[10].right[i] = Filter48.elev70_10_r[i];


                    filterSet.e70[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[11].left[i] = Filter48.elev70_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[11].right[i] = Filter48.elev70_11_r[i];


                    filterSet.e70[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[12].left[i] = Filter48.elev70_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[12].right[i] = Filter48.elev70_12_r[i];




                    // e80
                    filterSet.e80[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[0].left[i] = Filter48.elev80_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[0].right[i] = Filter48.elev80_0_r[i];


                    filterSet.e80[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[1].left[i] = Filter48.elev80_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[1].right[i] = Filter48.elev80_1_r[i];


                    filterSet.e80[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[2].left[i] = Filter48.elev80_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[2].right[i] = Filter48.elev80_2_r[i];


                    filterSet.e80[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[3].left[i] = Filter48.elev80_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[3].right[i] = Filter48.elev80_3_r[i];


                    filterSet.e80[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[4].left[i] = Filter48.elev80_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[4].right[i] = Filter48.elev80_4_r[i];


                    filterSet.e80[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[5].left[i] = Filter48.elev80_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[5].right[i] = Filter48.elev80_5_r[i];


                    filterSet.e80[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[6].left[i] = Filter48.elev80_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[6].right[i] = Filter48.elev80_6_r[i];




                    // e90
                    filterSet.e90[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e90[0].left[i] = Filter48.elev90_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e90[0].right[i] = Filter48.elev90_0_r[i];



                    // Finally, return the fully populated filter set.
                    return filterSet;
                }

            }
        }
        #endregion

        #region 48khz diffuse
        private static mit_hrtf_filter_set_48 normal_48_diffuse
        {
            get
            {
                unsafe
                {
                    var filterSet = mit_hrtf_filter_set_48.Create();


                    // e_10
                    filterSet.e_10[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[0].left[i] = Filter48Diffused.elev_10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[0].right[i] = Filter48Diffused.elev_10_0_r[i];


                    filterSet.e_10[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[1].left[i] = Filter48Diffused.elev_10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[1].right[i] = Filter48Diffused.elev_10_1_r[i];


                    filterSet.e_10[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[2].left[i] = Filter48Diffused.elev_10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[2].right[i] = Filter48Diffused.elev_10_2_r[i];


                    filterSet.e_10[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[3].left[i] = Filter48Diffused.elev_10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[3].right[i] = Filter48Diffused.elev_10_3_r[i];


                    filterSet.e_10[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[4].left[i] = Filter48Diffused.elev_10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[4].right[i] = Filter48Diffused.elev_10_4_r[i];


                    filterSet.e_10[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[5].left[i] = Filter48Diffused.elev_10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[5].right[i] = Filter48Diffused.elev_10_5_r[i];


                    filterSet.e_10[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[6].left[i] = Filter48Diffused.elev_10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[6].right[i] = Filter48Diffused.elev_10_6_r[i];


                    filterSet.e_10[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[7].left[i] = Filter48Diffused.elev_10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[7].right[i] = Filter48Diffused.elev_10_7_r[i];


                    filterSet.e_10[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[8].left[i] = Filter48Diffused.elev_10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[8].right[i] = Filter48Diffused.elev_10_8_r[i];


                    filterSet.e_10[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[9].left[i] = Filter48Diffused.elev_10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[9].right[i] = Filter48Diffused.elev_10_9_r[i];


                    filterSet.e_10[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[10].left[i] = Filter48Diffused.elev_10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[10].right[i] = Filter48Diffused.elev_10_10_r[i];


                    filterSet.e_10[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[11].left[i] = Filter48Diffused.elev_10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[11].right[i] = Filter48Diffused.elev_10_11_r[i];


                    filterSet.e_10[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[12].left[i] = Filter48Diffused.elev_10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[12].right[i] = Filter48Diffused.elev_10_12_r[i];


                    filterSet.e_10[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[13].left[i] = Filter48Diffused.elev_10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[13].right[i] = Filter48Diffused.elev_10_13_r[i];


                    filterSet.e_10[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[14].left[i] = Filter48Diffused.elev_10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[14].right[i] = Filter48Diffused.elev_10_14_r[i];


                    filterSet.e_10[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[15].left[i] = Filter48Diffused.elev_10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[15].right[i] = Filter48Diffused.elev_10_15_r[i];


                    filterSet.e_10[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[16].left[i] = Filter48Diffused.elev_10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[16].right[i] = Filter48Diffused.elev_10_16_r[i];


                    filterSet.e_10[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[17].left[i] = Filter48Diffused.elev_10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[17].right[i] = Filter48Diffused.elev_10_17_r[i];


                    filterSet.e_10[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[18].left[i] = Filter48Diffused.elev_10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[18].right[i] = Filter48Diffused.elev_10_18_r[i];


                    filterSet.e_10[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[19].left[i] = Filter48Diffused.elev_10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[19].right[i] = Filter48Diffused.elev_10_19_r[i];


                    filterSet.e_10[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[20].left[i] = Filter48Diffused.elev_10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[20].right[i] = Filter48Diffused.elev_10_20_r[i];


                    filterSet.e_10[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[21].left[i] = Filter48Diffused.elev_10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[21].right[i] = Filter48Diffused.elev_10_21_r[i];


                    filterSet.e_10[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[22].left[i] = Filter48Diffused.elev_10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[22].right[i] = Filter48Diffused.elev_10_22_r[i];


                    filterSet.e_10[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[23].left[i] = Filter48Diffused.elev_10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[23].right[i] = Filter48Diffused.elev_10_23_r[i];


                    filterSet.e_10[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[24].left[i] = Filter48Diffused.elev_10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[24].right[i] = Filter48Diffused.elev_10_24_r[i];


                    filterSet.e_10[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[25].left[i] = Filter48Diffused.elev_10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[25].right[i] = Filter48Diffused.elev_10_25_r[i];


                    filterSet.e_10[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[26].left[i] = Filter48Diffused.elev_10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[26].right[i] = Filter48Diffused.elev_10_26_r[i];


                    filterSet.e_10[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[27].left[i] = Filter48Diffused.elev_10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[27].right[i] = Filter48Diffused.elev_10_27_r[i];


                    filterSet.e_10[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[28].left[i] = Filter48Diffused.elev_10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[28].right[i] = Filter48Diffused.elev_10_28_r[i];


                    filterSet.e_10[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[29].left[i] = Filter48Diffused.elev_10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[29].right[i] = Filter48Diffused.elev_10_29_r[i];


                    filterSet.e_10[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[30].left[i] = Filter48Diffused.elev_10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[30].right[i] = Filter48Diffused.elev_10_30_r[i];


                    filterSet.e_10[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[31].left[i] = Filter48Diffused.elev_10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[31].right[i] = Filter48Diffused.elev_10_31_r[i];


                    filterSet.e_10[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[32].left[i] = Filter48Diffused.elev_10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[32].right[i] = Filter48Diffused.elev_10_32_r[i];


                    filterSet.e_10[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[33].left[i] = Filter48Diffused.elev_10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[33].right[i] = Filter48Diffused.elev_10_33_r[i];


                    filterSet.e_10[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[34].left[i] = Filter48Diffused.elev_10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[34].right[i] = Filter48Diffused.elev_10_34_r[i];


                    filterSet.e_10[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[35].left[i] = Filter48Diffused.elev_10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[35].right[i] = Filter48Diffused.elev_10_35_r[i];


                    filterSet.e_10[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[36].left[i] = Filter48Diffused.elev_10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_10[36].right[i] = Filter48Diffused.elev_10_36_r[i];



                    // e_20
                    filterSet.e_20[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[0].left[i] = Filter48Diffused.elev_20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[0].right[i] = Filter48Diffused.elev_20_0_r[i];


                    filterSet.e_20[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[1].left[i] = Filter48Diffused.elev_20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[1].right[i] = Filter48Diffused.elev_20_1_r[i];


                    filterSet.e_20[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[2].left[i] = Filter48Diffused.elev_20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[2].right[i] = Filter48Diffused.elev_20_2_r[i];


                    filterSet.e_20[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[3].left[i] = Filter48Diffused.elev_20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[3].right[i] = Filter48Diffused.elev_20_3_r[i];


                    filterSet.e_20[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[4].left[i] = Filter48Diffused.elev_20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[4].right[i] = Filter48Diffused.elev_20_4_r[i];


                    filterSet.e_20[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[5].left[i] = Filter48Diffused.elev_20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[5].right[i] = Filter48Diffused.elev_20_5_r[i];


                    filterSet.e_20[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[6].left[i] = Filter48Diffused.elev_20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[6].right[i] = Filter48Diffused.elev_20_6_r[i];


                    filterSet.e_20[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[7].left[i] = Filter48Diffused.elev_20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[7].right[i] = Filter48Diffused.elev_20_7_r[i];


                    filterSet.e_20[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[8].left[i] = Filter48Diffused.elev_20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[8].right[i] = Filter48Diffused.elev_20_8_r[i];


                    filterSet.e_20[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[9].left[i] = Filter48Diffused.elev_20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[9].right[i] = Filter48Diffused.elev_20_9_r[i];


                    filterSet.e_20[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[10].left[i] = Filter48Diffused.elev_20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[10].right[i] = Filter48Diffused.elev_20_10_r[i];


                    filterSet.e_20[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[11].left[i] = Filter48Diffused.elev_20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[11].right[i] = Filter48Diffused.elev_20_11_r[i];


                    filterSet.e_20[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[12].left[i] = Filter48Diffused.elev_20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[12].right[i] = Filter48Diffused.elev_20_12_r[i];


                    filterSet.e_20[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[13].left[i] = Filter48Diffused.elev_20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[13].right[i] = Filter48Diffused.elev_20_13_r[i];


                    filterSet.e_20[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[14].left[i] = Filter48Diffused.elev_20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[14].right[i] = Filter48Diffused.elev_20_14_r[i];


                    filterSet.e_20[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[15].left[i] = Filter48Diffused.elev_20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[15].right[i] = Filter48Diffused.elev_20_15_r[i];


                    filterSet.e_20[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[16].left[i] = Filter48Diffused.elev_20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[16].right[i] = Filter48Diffused.elev_20_16_r[i];


                    filterSet.e_20[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[17].left[i] = Filter48Diffused.elev_20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[17].right[i] = Filter48Diffused.elev_20_17_r[i];


                    filterSet.e_20[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[18].left[i] = Filter48Diffused.elev_20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[18].right[i] = Filter48Diffused.elev_20_18_r[i];


                    filterSet.e_20[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[19].left[i] = Filter48Diffused.elev_20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[19].right[i] = Filter48Diffused.elev_20_19_r[i];


                    filterSet.e_20[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[20].left[i] = Filter48Diffused.elev_20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[20].right[i] = Filter48Diffused.elev_20_20_r[i];


                    filterSet.e_20[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[21].left[i] = Filter48Diffused.elev_20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[21].right[i] = Filter48Diffused.elev_20_21_r[i];


                    filterSet.e_20[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[22].left[i] = Filter48Diffused.elev_20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[22].right[i] = Filter48Diffused.elev_20_22_r[i];


                    filterSet.e_20[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[23].left[i] = Filter48Diffused.elev_20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[23].right[i] = Filter48Diffused.elev_20_23_r[i];


                    filterSet.e_20[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[24].left[i] = Filter48Diffused.elev_20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[24].right[i] = Filter48Diffused.elev_20_24_r[i];


                    filterSet.e_20[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[25].left[i] = Filter48Diffused.elev_20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[25].right[i] = Filter48Diffused.elev_20_25_r[i];


                    filterSet.e_20[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[26].left[i] = Filter48Diffused.elev_20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[26].right[i] = Filter48Diffused.elev_20_26_r[i];


                    filterSet.e_20[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[27].left[i] = Filter48Diffused.elev_20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[27].right[i] = Filter48Diffused.elev_20_27_r[i];


                    filterSet.e_20[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[28].left[i] = Filter48Diffused.elev_20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[28].right[i] = Filter48Diffused.elev_20_28_r[i];


                    filterSet.e_20[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[29].left[i] = Filter48Diffused.elev_20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[29].right[i] = Filter48Diffused.elev_20_29_r[i];


                    filterSet.e_20[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[30].left[i] = Filter48Diffused.elev_20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[30].right[i] = Filter48Diffused.elev_20_30_r[i];


                    filterSet.e_20[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[31].left[i] = Filter48Diffused.elev_20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[31].right[i] = Filter48Diffused.elev_20_31_r[i];


                    filterSet.e_20[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[32].left[i] = Filter48Diffused.elev_20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[32].right[i] = Filter48Diffused.elev_20_32_r[i];


                    filterSet.e_20[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[33].left[i] = Filter48Diffused.elev_20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[33].right[i] = Filter48Diffused.elev_20_33_r[i];


                    filterSet.e_20[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[34].left[i] = Filter48Diffused.elev_20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[34].right[i] = Filter48Diffused.elev_20_34_r[i];


                    filterSet.e_20[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[35].left[i] = Filter48Diffused.elev_20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[35].right[i] = Filter48Diffused.elev_20_35_r[i];


                    filterSet.e_20[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[36].left[i] = Filter48Diffused.elev_20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_20[36].right[i] = Filter48Diffused.elev_20_36_r[i];




                    // e_30
                    filterSet.e_30[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[0].left[i] = Filter48Diffused.elev_30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[0].right[i] = Filter48Diffused.elev_30_0_r[i];


                    filterSet.e_30[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[1].left[i] = Filter48Diffused.elev_30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[1].right[i] = Filter48Diffused.elev_30_1_r[i];


                    filterSet.e_30[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[2].left[i] = Filter48Diffused.elev_30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[2].right[i] = Filter48Diffused.elev_30_2_r[i];


                    filterSet.e_30[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[3].left[i] = Filter48Diffused.elev_30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[3].right[i] = Filter48Diffused.elev_30_3_r[i];


                    filterSet.e_30[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[4].left[i] = Filter48Diffused.elev_30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[4].right[i] = Filter48Diffused.elev_30_4_r[i];


                    filterSet.e_30[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[5].left[i] = Filter48Diffused.elev_30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[5].right[i] = Filter48Diffused.elev_30_5_r[i];


                    filterSet.e_30[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[6].left[i] = Filter48Diffused.elev_30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[6].right[i] = Filter48Diffused.elev_30_6_r[i];


                    filterSet.e_30[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[7].left[i] = Filter48Diffused.elev_30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[7].right[i] = Filter48Diffused.elev_30_7_r[i];


                    filterSet.e_30[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[8].left[i] = Filter48Diffused.elev_30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[8].right[i] = Filter48Diffused.elev_30_8_r[i];


                    filterSet.e_30[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[9].left[i] = Filter48Diffused.elev_30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[9].right[i] = Filter48Diffused.elev_30_9_r[i];


                    filterSet.e_30[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[10].left[i] = Filter48Diffused.elev_30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[10].right[i] = Filter48Diffused.elev_30_10_r[i];


                    filterSet.e_30[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[11].left[i] = Filter48Diffused.elev_30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[11].right[i] = Filter48Diffused.elev_30_11_r[i];


                    filterSet.e_30[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[12].left[i] = Filter48Diffused.elev_30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[12].right[i] = Filter48Diffused.elev_30_12_r[i];


                    filterSet.e_30[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[13].left[i] = Filter48Diffused.elev_30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[13].right[i] = Filter48Diffused.elev_30_13_r[i];


                    filterSet.e_30[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[14].left[i] = Filter48Diffused.elev_30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[14].right[i] = Filter48Diffused.elev_30_14_r[i];


                    filterSet.e_30[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[15].left[i] = Filter48Diffused.elev_30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[15].right[i] = Filter48Diffused.elev_30_15_r[i];


                    filterSet.e_30[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[16].left[i] = Filter48Diffused.elev_30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[16].right[i] = Filter48Diffused.elev_30_16_r[i];


                    filterSet.e_30[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[17].left[i] = Filter48Diffused.elev_30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[17].right[i] = Filter48Diffused.elev_30_17_r[i];


                    filterSet.e_30[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[18].left[i] = Filter48Diffused.elev_30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[18].right[i] = Filter48Diffused.elev_30_18_r[i];


                    filterSet.e_30[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[19].left[i] = Filter48Diffused.elev_30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[19].right[i] = Filter48Diffused.elev_30_19_r[i];


                    filterSet.e_30[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[20].left[i] = Filter48Diffused.elev_30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[20].right[i] = Filter48Diffused.elev_30_20_r[i];


                    filterSet.e_30[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[21].left[i] = Filter48Diffused.elev_30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[21].right[i] = Filter48Diffused.elev_30_21_r[i];


                    filterSet.e_30[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[22].left[i] = Filter48Diffused.elev_30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[22].right[i] = Filter48Diffused.elev_30_22_r[i];


                    filterSet.e_30[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[23].left[i] = Filter48Diffused.elev_30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[23].right[i] = Filter48Diffused.elev_30_23_r[i];


                    filterSet.e_30[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[24].left[i] = Filter48Diffused.elev_30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[24].right[i] = Filter48Diffused.elev_30_24_r[i];


                    filterSet.e_30[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[25].left[i] = Filter48Diffused.elev_30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[25].right[i] = Filter48Diffused.elev_30_25_r[i];


                    filterSet.e_30[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[26].left[i] = Filter48Diffused.elev_30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[26].right[i] = Filter48Diffused.elev_30_26_r[i];


                    filterSet.e_30[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[27].left[i] = Filter48Diffused.elev_30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[27].right[i] = Filter48Diffused.elev_30_27_r[i];


                    filterSet.e_30[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[28].left[i] = Filter48Diffused.elev_30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[28].right[i] = Filter48Diffused.elev_30_28_r[i];


                    filterSet.e_30[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[29].left[i] = Filter48Diffused.elev_30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[29].right[i] = Filter48Diffused.elev_30_29_r[i];


                    filterSet.e_30[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[30].left[i] = Filter48Diffused.elev_30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_30[30].right[i] = Filter48Diffused.elev_30_30_r[i];



                    // e_40
                    filterSet.e_40[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[0].left[i] = Filter48Diffused.elev_40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[0].right[i] = Filter48Diffused.elev_40_0_r[i];


                    filterSet.e_40[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[1].left[i] = Filter48Diffused.elev_40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[1].right[i] = Filter48Diffused.elev_40_1_r[i];


                    filterSet.e_40[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[2].left[i] = Filter48Diffused.elev_40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[2].right[i] = Filter48Diffused.elev_40_2_r[i];


                    filterSet.e_40[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[3].left[i] = Filter48Diffused.elev_40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[3].right[i] = Filter48Diffused.elev_40_3_r[i];


                    filterSet.e_40[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[4].left[i] = Filter48Diffused.elev_40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[4].right[i] = Filter48Diffused.elev_40_4_r[i];


                    filterSet.e_40[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[5].left[i] = Filter48Diffused.elev_40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[5].right[i] = Filter48Diffused.elev_40_5_r[i];


                    filterSet.e_40[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[6].left[i] = Filter48Diffused.elev_40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[6].right[i] = Filter48Diffused.elev_40_6_r[i];


                    filterSet.e_40[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[7].left[i] = Filter48Diffused.elev_40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[7].right[i] = Filter48Diffused.elev_40_7_r[i];


                    filterSet.e_40[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[8].left[i] = Filter48Diffused.elev_40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[8].right[i] = Filter48Diffused.elev_40_8_r[i];


                    filterSet.e_40[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[9].left[i] = Filter48Diffused.elev_40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[9].right[i] = Filter48Diffused.elev_40_9_r[i];


                    filterSet.e_40[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[10].left[i] = Filter48Diffused.elev_40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[10].right[i] = Filter48Diffused.elev_40_10_r[i];


                    filterSet.e_40[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[11].left[i] = Filter48Diffused.elev_40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[11].right[i] = Filter48Diffused.elev_40_11_r[i];


                    filterSet.e_40[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[12].left[i] = Filter48Diffused.elev_40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[12].right[i] = Filter48Diffused.elev_40_12_r[i];


                    filterSet.e_40[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[13].left[i] = Filter48Diffused.elev_40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[13].right[i] = Filter48Diffused.elev_40_13_r[i];


                    filterSet.e_40[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[14].left[i] = Filter48Diffused.elev_40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[14].right[i] = Filter48Diffused.elev_40_14_r[i];


                    filterSet.e_40[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[15].left[i] = Filter48Diffused.elev_40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[15].right[i] = Filter48Diffused.elev_40_15_r[i];


                    filterSet.e_40[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[16].left[i] = Filter48Diffused.elev_40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[16].right[i] = Filter48Diffused.elev_40_16_r[i];


                    filterSet.e_40[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[17].left[i] = Filter48Diffused.elev_40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[17].right[i] = Filter48Diffused.elev_40_17_r[i];


                    filterSet.e_40[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[18].left[i] = Filter48Diffused.elev_40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[18].right[i] = Filter48Diffused.elev_40_18_r[i];


                    filterSet.e_40[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[19].left[i] = Filter48Diffused.elev_40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[19].right[i] = Filter48Diffused.elev_40_19_r[i];


                    filterSet.e_40[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[20].left[i] = Filter48Diffused.elev_40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[20].right[i] = Filter48Diffused.elev_40_20_r[i];


                    filterSet.e_40[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[21].left[i] = Filter48Diffused.elev_40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[21].right[i] = Filter48Diffused.elev_40_21_r[i];


                    filterSet.e_40[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[22].left[i] = Filter48Diffused.elev_40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[22].right[i] = Filter48Diffused.elev_40_22_r[i];


                    filterSet.e_40[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[23].left[i] = Filter48Diffused.elev_40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[23].right[i] = Filter48Diffused.elev_40_23_r[i];


                    filterSet.e_40[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[24].left[i] = Filter48Diffused.elev_40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[24].right[i] = Filter48Diffused.elev_40_24_r[i];


                    filterSet.e_40[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[25].left[i] = Filter48Diffused.elev_40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[25].right[i] = Filter48Diffused.elev_40_25_r[i];


                    filterSet.e_40[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[26].left[i] = Filter48Diffused.elev_40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[26].right[i] = Filter48Diffused.elev_40_26_r[i];


                    filterSet.e_40[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[27].left[i] = Filter48Diffused.elev_40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[27].right[i] = Filter48Diffused.elev_40_27_r[i];


                    filterSet.e_40[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[28].left[i] = Filter48Diffused.elev_40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e_40[28].right[i] = Filter48Diffused.elev_40_28_r[i];




                    // e0
                    filterSet.e00[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[0].left[i] = Filter48Diffused.elev0_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[0].right[i] = Filter48Diffused.elev0_0_r[i];


                    filterSet.e00[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[1].left[i] = Filter48Diffused.elev0_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[1].right[i] = Filter48Diffused.elev0_1_r[i];


                    filterSet.e00[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[2].left[i] = Filter48Diffused.elev0_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[2].right[i] = Filter48Diffused.elev0_2_r[i];


                    filterSet.e00[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[3].left[i] = Filter48Diffused.elev0_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[3].right[i] = Filter48Diffused.elev0_3_r[i];


                    filterSet.e00[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[4].left[i] = Filter48Diffused.elev0_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[4].right[i] = Filter48Diffused.elev0_4_r[i];


                    filterSet.e00[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[5].left[i] = Filter48Diffused.elev0_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[5].right[i] = Filter48Diffused.elev0_5_r[i];


                    filterSet.e00[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[6].left[i] = Filter48Diffused.elev0_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[6].right[i] = Filter48Diffused.elev0_6_r[i];


                    filterSet.e00[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[7].left[i] = Filter48Diffused.elev0_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[7].right[i] = Filter48Diffused.elev0_7_r[i];


                    filterSet.e00[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[8].left[i] = Filter48Diffused.elev0_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[8].right[i] = Filter48Diffused.elev0_8_r[i];


                    filterSet.e00[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[9].left[i] = Filter48Diffused.elev0_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[9].right[i] = Filter48Diffused.elev0_9_r[i];


                    filterSet.e00[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[10].left[i] = Filter48Diffused.elev0_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[10].right[i] = Filter48Diffused.elev0_10_r[i];


                    filterSet.e00[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[11].left[i] = Filter48Diffused.elev0_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[11].right[i] = Filter48Diffused.elev0_11_r[i];


                    filterSet.e00[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[12].left[i] = Filter48Diffused.elev0_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[12].right[i] = Filter48Diffused.elev0_12_r[i];


                    filterSet.e00[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[13].left[i] = Filter48Diffused.elev0_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[13].right[i] = Filter48Diffused.elev0_13_r[i];


                    filterSet.e00[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[14].left[i] = Filter48Diffused.elev0_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[14].right[i] = Filter48Diffused.elev0_14_r[i];


                    filterSet.e00[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[15].left[i] = Filter48Diffused.elev0_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[15].right[i] = Filter48Diffused.elev0_15_r[i];


                    filterSet.e00[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[16].left[i] = Filter48Diffused.elev0_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[16].right[i] = Filter48Diffused.elev0_16_r[i];


                    filterSet.e00[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[17].left[i] = Filter48Diffused.elev0_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[17].right[i] = Filter48Diffused.elev0_17_r[i];


                    filterSet.e00[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[18].left[i] = Filter48Diffused.elev0_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[18].right[i] = Filter48Diffused.elev0_18_r[i];


                    filterSet.e00[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[19].left[i] = Filter48Diffused.elev0_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[19].right[i] = Filter48Diffused.elev0_19_r[i];


                    filterSet.e00[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[20].left[i] = Filter48Diffused.elev0_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[20].right[i] = Filter48Diffused.elev0_20_r[i];


                    filterSet.e00[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[21].left[i] = Filter48Diffused.elev0_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[21].right[i] = Filter48Diffused.elev0_21_r[i];


                    filterSet.e00[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[22].left[i] = Filter48Diffused.elev0_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[22].right[i] = Filter48Diffused.elev0_22_r[i];


                    filterSet.e00[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[23].left[i] = Filter48Diffused.elev0_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[23].right[i] = Filter48Diffused.elev0_23_r[i];


                    filterSet.e00[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[24].left[i] = Filter48Diffused.elev0_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[24].right[i] = Filter48Diffused.elev0_24_r[i];


                    filterSet.e00[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[25].left[i] = Filter48Diffused.elev0_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[25].right[i] = Filter48Diffused.elev0_25_r[i];


                    filterSet.e00[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[26].left[i] = Filter48Diffused.elev0_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[26].right[i] = Filter48Diffused.elev0_26_r[i];


                    filterSet.e00[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[27].left[i] = Filter48Diffused.elev0_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[27].right[i] = Filter48Diffused.elev0_27_r[i];


                    filterSet.e00[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[28].left[i] = Filter48Diffused.elev0_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[28].right[i] = Filter48Diffused.elev0_28_r[i];


                    filterSet.e00[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[29].left[i] = Filter48Diffused.elev0_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[29].right[i] = Filter48Diffused.elev0_29_r[i];


                    filterSet.e00[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[30].left[i] = Filter48Diffused.elev0_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[30].right[i] = Filter48Diffused.elev0_30_r[i];


                    filterSet.e00[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[31].left[i] = Filter48Diffused.elev0_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[31].right[i] = Filter48Diffused.elev0_31_r[i];


                    filterSet.e00[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[32].left[i] = Filter48Diffused.elev0_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[32].right[i] = Filter48Diffused.elev0_32_r[i];


                    filterSet.e00[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[33].left[i] = Filter48Diffused.elev0_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[33].right[i] = Filter48Diffused.elev0_33_r[i];


                    filterSet.e00[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[34].left[i] = Filter48Diffused.elev0_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[34].right[i] = Filter48Diffused.elev0_34_r[i];


                    filterSet.e00[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[35].left[i] = Filter48Diffused.elev0_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[35].right[i] = Filter48Diffused.elev0_35_r[i];


                    filterSet.e00[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[36].left[i] = Filter48Diffused.elev0_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e00[36].right[i] = Filter48Diffused.elev0_36_r[i];




                    // e10
                    filterSet.e10[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[0].left[i] = Filter48Diffused.elev10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[0].right[i] = Filter48Diffused.elev10_0_r[i];


                    filterSet.e10[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[1].left[i] = Filter48Diffused.elev10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[1].right[i] = Filter48Diffused.elev10_1_r[i];


                    filterSet.e10[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[2].left[i] = Filter48Diffused.elev10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[2].right[i] = Filter48Diffused.elev10_2_r[i];


                    filterSet.e10[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[3].left[i] = Filter48Diffused.elev10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[3].right[i] = Filter48Diffused.elev10_3_r[i];


                    filterSet.e10[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[4].left[i] = Filter48Diffused.elev10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[4].right[i] = Filter48Diffused.elev10_4_r[i];


                    filterSet.e10[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[5].left[i] = Filter48Diffused.elev10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[5].right[i] = Filter48Diffused.elev10_5_r[i];


                    filterSet.e10[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[6].left[i] = Filter48Diffused.elev10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[6].right[i] = Filter48Diffused.elev10_6_r[i];


                    filterSet.e10[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[7].left[i] = Filter48Diffused.elev10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[7].right[i] = Filter48Diffused.elev10_7_r[i];


                    filterSet.e10[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[8].left[i] = Filter48Diffused.elev10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[8].right[i] = Filter48Diffused.elev10_8_r[i];


                    filterSet.e10[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[9].left[i] = Filter48Diffused.elev10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[9].right[i] = Filter48Diffused.elev10_9_r[i];


                    filterSet.e10[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[10].left[i] = Filter48Diffused.elev10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[10].right[i] = Filter48Diffused.elev10_10_r[i];


                    filterSet.e10[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[11].left[i] = Filter48Diffused.elev10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[11].right[i] = Filter48Diffused.elev10_11_r[i];


                    filterSet.e10[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[12].left[i] = Filter48Diffused.elev10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[12].right[i] = Filter48Diffused.elev10_12_r[i];


                    filterSet.e10[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[13].left[i] = Filter48Diffused.elev10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[13].right[i] = Filter48Diffused.elev10_13_r[i];


                    filterSet.e10[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[14].left[i] = Filter48Diffused.elev10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[14].right[i] = Filter48Diffused.elev10_14_r[i];


                    filterSet.e10[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[15].left[i] = Filter48Diffused.elev10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[15].right[i] = Filter48Diffused.elev10_15_r[i];


                    filterSet.e10[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[16].left[i] = Filter48Diffused.elev10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[16].right[i] = Filter48Diffused.elev10_16_r[i];


                    filterSet.e10[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[17].left[i] = Filter48Diffused.elev10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[17].right[i] = Filter48Diffused.elev10_17_r[i];


                    filterSet.e10[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[18].left[i] = Filter48Diffused.elev10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[18].right[i] = Filter48Diffused.elev10_18_r[i];


                    filterSet.e10[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[19].left[i] = Filter48Diffused.elev10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[19].right[i] = Filter48Diffused.elev10_19_r[i];


                    filterSet.e10[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[20].left[i] = Filter48Diffused.elev10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[20].right[i] = Filter48Diffused.elev10_20_r[i];


                    filterSet.e10[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[21].left[i] = Filter48Diffused.elev10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[21].right[i] = Filter48Diffused.elev10_21_r[i];


                    filterSet.e10[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[22].left[i] = Filter48Diffused.elev10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[22].right[i] = Filter48Diffused.elev10_22_r[i];


                    filterSet.e10[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[23].left[i] = Filter48Diffused.elev10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[23].right[i] = Filter48Diffused.elev10_23_r[i];


                    filterSet.e10[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[24].left[i] = Filter48Diffused.elev10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[24].right[i] = Filter48Diffused.elev10_24_r[i];


                    filterSet.e10[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[25].left[i] = Filter48Diffused.elev10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[25].right[i] = Filter48Diffused.elev10_25_r[i];


                    filterSet.e10[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[26].left[i] = Filter48Diffused.elev10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[26].right[i] = Filter48Diffused.elev10_26_r[i];


                    filterSet.e10[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[27].left[i] = Filter48Diffused.elev10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[27].right[i] = Filter48Diffused.elev10_27_r[i];


                    filterSet.e10[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[28].left[i] = Filter48Diffused.elev10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[28].right[i] = Filter48Diffused.elev10_28_r[i];


                    filterSet.e10[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[29].left[i] = Filter48Diffused.elev10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[29].right[i] = Filter48Diffused.elev10_29_r[i];


                    filterSet.e10[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[30].left[i] = Filter48Diffused.elev10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[30].right[i] = Filter48Diffused.elev10_30_r[i];


                    filterSet.e10[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[31].left[i] = Filter48Diffused.elev10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[31].right[i] = Filter48Diffused.elev10_31_r[i];


                    filterSet.e10[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[32].left[i] = Filter48Diffused.elev10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[32].right[i] = Filter48Diffused.elev10_32_r[i];


                    filterSet.e10[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[33].left[i] = Filter48Diffused.elev10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[33].right[i] = Filter48Diffused.elev10_33_r[i];


                    filterSet.e10[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[34].left[i] = Filter48Diffused.elev10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[34].right[i] = Filter48Diffused.elev10_34_r[i];


                    filterSet.e10[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[35].left[i] = Filter48Diffused.elev10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[35].right[i] = Filter48Diffused.elev10_35_r[i];


                    filterSet.e10[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[36].left[i] = Filter48Diffused.elev10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e10[36].right[i] = Filter48Diffused.elev10_36_r[i];




                    // e20
                    filterSet.e20[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[0].left[i] = Filter48Diffused.elev20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[0].right[i] = Filter48Diffused.elev20_0_r[i];


                    filterSet.e20[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[1].left[i] = Filter48Diffused.elev20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[1].right[i] = Filter48Diffused.elev20_1_r[i];


                    filterSet.e20[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[2].left[i] = Filter48Diffused.elev20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[2].right[i] = Filter48Diffused.elev20_2_r[i];


                    filterSet.e20[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[3].left[i] = Filter48Diffused.elev20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[3].right[i] = Filter48Diffused.elev20_3_r[i];


                    filterSet.e20[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[4].left[i] = Filter48Diffused.elev20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[4].right[i] = Filter48Diffused.elev20_4_r[i];


                    filterSet.e20[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[5].left[i] = Filter48Diffused.elev20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[5].right[i] = Filter48Diffused.elev20_5_r[i];


                    filterSet.e20[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[6].left[i] = Filter48Diffused.elev20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[6].right[i] = Filter48Diffused.elev20_6_r[i];


                    filterSet.e20[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[7].left[i] = Filter48Diffused.elev20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[7].right[i] = Filter48Diffused.elev20_7_r[i];


                    filterSet.e20[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[8].left[i] = Filter48Diffused.elev20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[8].right[i] = Filter48Diffused.elev20_8_r[i];


                    filterSet.e20[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[9].left[i] = Filter48Diffused.elev20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[9].right[i] = Filter48Diffused.elev20_9_r[i];


                    filterSet.e20[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[10].left[i] = Filter48Diffused.elev20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[10].right[i] = Filter48Diffused.elev20_10_r[i];


                    filterSet.e20[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[11].left[i] = Filter48Diffused.elev20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[11].right[i] = Filter48Diffused.elev20_11_r[i];


                    filterSet.e20[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[12].left[i] = Filter48Diffused.elev20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[12].right[i] = Filter48Diffused.elev20_12_r[i];


                    filterSet.e20[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[13].left[i] = Filter48Diffused.elev20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[13].right[i] = Filter48Diffused.elev20_13_r[i];


                    filterSet.e20[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[14].left[i] = Filter48Diffused.elev20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[14].right[i] = Filter48Diffused.elev20_14_r[i];


                    filterSet.e20[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[15].left[i] = Filter48Diffused.elev20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[15].right[i] = Filter48Diffused.elev20_15_r[i];


                    filterSet.e20[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[16].left[i] = Filter48Diffused.elev20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[16].right[i] = Filter48Diffused.elev20_16_r[i];


                    filterSet.e20[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[17].left[i] = Filter48Diffused.elev20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[17].right[i] = Filter48Diffused.elev20_17_r[i];


                    filterSet.e20[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[18].left[i] = Filter48Diffused.elev20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[18].right[i] = Filter48Diffused.elev20_18_r[i];


                    filterSet.e20[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[19].left[i] = Filter48Diffused.elev20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[19].right[i] = Filter48Diffused.elev20_19_r[i];


                    filterSet.e20[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[20].left[i] = Filter48Diffused.elev20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[20].right[i] = Filter48Diffused.elev20_20_r[i];


                    filterSet.e20[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[21].left[i] = Filter48Diffused.elev20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[21].right[i] = Filter48Diffused.elev20_21_r[i];


                    filterSet.e20[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[22].left[i] = Filter48Diffused.elev20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[22].right[i] = Filter48Diffused.elev20_22_r[i];


                    filterSet.e20[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[23].left[i] = Filter48Diffused.elev20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[23].right[i] = Filter48Diffused.elev20_23_r[i];


                    filterSet.e20[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[24].left[i] = Filter48Diffused.elev20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[24].right[i] = Filter48Diffused.elev20_24_r[i];


                    filterSet.e20[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[25].left[i] = Filter48Diffused.elev20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[25].right[i] = Filter48Diffused.elev20_25_r[i];


                    filterSet.e20[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[26].left[i] = Filter48Diffused.elev20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[26].right[i] = Filter48Diffused.elev20_26_r[i];


                    filterSet.e20[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[27].left[i] = Filter48Diffused.elev20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[27].right[i] = Filter48Diffused.elev20_27_r[i];


                    filterSet.e20[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[28].left[i] = Filter48Diffused.elev20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[28].right[i] = Filter48Diffused.elev20_28_r[i];


                    filterSet.e20[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[29].left[i] = Filter48Diffused.elev20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[29].right[i] = Filter48Diffused.elev20_29_r[i];


                    filterSet.e20[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[30].left[i] = Filter48Diffused.elev20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[30].right[i] = Filter48Diffused.elev20_30_r[i];


                    filterSet.e20[31] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[31].left[i] = Filter48Diffused.elev20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[31].right[i] = Filter48Diffused.elev20_31_r[i];


                    filterSet.e20[32] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[32].left[i] = Filter48Diffused.elev20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[32].right[i] = Filter48Diffused.elev20_32_r[i];


                    filterSet.e20[33] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[33].left[i] = Filter48Diffused.elev20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[33].right[i] = Filter48Diffused.elev20_33_r[i];


                    filterSet.e20[34] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[34].left[i] = Filter48Diffused.elev20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[34].right[i] = Filter48Diffused.elev20_34_r[i];


                    filterSet.e20[35] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[35].left[i] = Filter48Diffused.elev20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[35].right[i] = Filter48Diffused.elev20_35_r[i];


                    filterSet.e20[36] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[36].left[i] = Filter48Diffused.elev20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e20[36].right[i] = Filter48Diffused.elev20_36_r[i];




                    // e30
                    filterSet.e30[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[0].left[i] = Filter48Diffused.elev30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[0].right[i] = Filter48Diffused.elev30_0_r[i];


                    filterSet.e30[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[1].left[i] = Filter48Diffused.elev30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[1].right[i] = Filter48Diffused.elev30_1_r[i];


                    filterSet.e30[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[2].left[i] = Filter48Diffused.elev30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[2].right[i] = Filter48Diffused.elev30_2_r[i];


                    filterSet.e30[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[3].left[i] = Filter48Diffused.elev30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[3].right[i] = Filter48Diffused.elev30_3_r[i];


                    filterSet.e30[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[4].left[i] = Filter48Diffused.elev30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[4].right[i] = Filter48Diffused.elev30_4_r[i];


                    filterSet.e30[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[5].left[i] = Filter48Diffused.elev30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[5].right[i] = Filter48Diffused.elev30_5_r[i];


                    filterSet.e30[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[6].left[i] = Filter48Diffused.elev30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[6].right[i] = Filter48Diffused.elev30_6_r[i];


                    filterSet.e30[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[7].left[i] = Filter48Diffused.elev30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[7].right[i] = Filter48Diffused.elev30_7_r[i];


                    filterSet.e30[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[8].left[i] = Filter48Diffused.elev30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[8].right[i] = Filter48Diffused.elev30_8_r[i];


                    filterSet.e30[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[9].left[i] = Filter48Diffused.elev30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[9].right[i] = Filter48Diffused.elev30_9_r[i];


                    filterSet.e30[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[10].left[i] = Filter48Diffused.elev30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[10].right[i] = Filter48Diffused.elev30_10_r[i];


                    filterSet.e30[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[11].left[i] = Filter48Diffused.elev30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[11].right[i] = Filter48Diffused.elev30_11_r[i];


                    filterSet.e30[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[12].left[i] = Filter48Diffused.elev30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[12].right[i] = Filter48Diffused.elev30_12_r[i];


                    filterSet.e30[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[13].left[i] = Filter48Diffused.elev30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[13].right[i] = Filter48Diffused.elev30_13_r[i];


                    filterSet.e30[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[14].left[i] = Filter48Diffused.elev30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[14].right[i] = Filter48Diffused.elev30_14_r[i];


                    filterSet.e30[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[15].left[i] = Filter48Diffused.elev30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[15].right[i] = Filter48Diffused.elev30_15_r[i];


                    filterSet.e30[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[16].left[i] = Filter48Diffused.elev30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[16].right[i] = Filter48Diffused.elev30_16_r[i];


                    filterSet.e30[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[17].left[i] = Filter48Diffused.elev30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[17].right[i] = Filter48Diffused.elev30_17_r[i];


                    filterSet.e30[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[18].left[i] = Filter48Diffused.elev30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[18].right[i] = Filter48Diffused.elev30_18_r[i];


                    filterSet.e30[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[19].left[i] = Filter48Diffused.elev30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[19].right[i] = Filter48Diffused.elev30_19_r[i];


                    filterSet.e30[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[20].left[i] = Filter48Diffused.elev30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[20].right[i] = Filter48Diffused.elev30_20_r[i];


                    filterSet.e30[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[21].left[i] = Filter48Diffused.elev30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[21].right[i] = Filter48Diffused.elev30_21_r[i];


                    filterSet.e30[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[22].left[i] = Filter48Diffused.elev30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[22].right[i] = Filter48Diffused.elev30_22_r[i];


                    filterSet.e30[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[23].left[i] = Filter48Diffused.elev30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[23].right[i] = Filter48Diffused.elev30_23_r[i];


                    filterSet.e30[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[24].left[i] = Filter48Diffused.elev30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[24].right[i] = Filter48Diffused.elev30_24_r[i];


                    filterSet.e30[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[25].left[i] = Filter48Diffused.elev30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[25].right[i] = Filter48Diffused.elev30_25_r[i];


                    filterSet.e30[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[26].left[i] = Filter48Diffused.elev30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[26].right[i] = Filter48Diffused.elev30_26_r[i];


                    filterSet.e30[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[27].left[i] = Filter48Diffused.elev30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[27].right[i] = Filter48Diffused.elev30_27_r[i];


                    filterSet.e30[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[28].left[i] = Filter48Diffused.elev30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[28].right[i] = Filter48Diffused.elev30_28_r[i];


                    filterSet.e30[29] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[29].left[i] = Filter48Diffused.elev30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[29].right[i] = Filter48Diffused.elev30_29_r[i];


                    filterSet.e30[30] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[30].left[i] = Filter48Diffused.elev30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e30[30].right[i] = Filter48Diffused.elev30_30_r[i];




                    // e40
                    filterSet.e40[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[0].left[i] = Filter48Diffused.elev40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[0].right[i] = Filter48Diffused.elev40_0_r[i];


                    filterSet.e40[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[1].left[i] = Filter48Diffused.elev40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[1].right[i] = Filter48Diffused.elev40_1_r[i];


                    filterSet.e40[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[2].left[i] = Filter48Diffused.elev40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[2].right[i] = Filter48Diffused.elev40_2_r[i];


                    filterSet.e40[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[3].left[i] = Filter48Diffused.elev40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[3].right[i] = Filter48Diffused.elev40_3_r[i];


                    filterSet.e40[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[4].left[i] = Filter48Diffused.elev40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[4].right[i] = Filter48Diffused.elev40_4_r[i];


                    filterSet.e40[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[5].left[i] = Filter48Diffused.elev40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[5].right[i] = Filter48Diffused.elev40_5_r[i];


                    filterSet.e40[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[6].left[i] = Filter48Diffused.elev40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[6].right[i] = Filter48Diffused.elev40_6_r[i];


                    filterSet.e40[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[7].left[i] = Filter48Diffused.elev40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[7].right[i] = Filter48Diffused.elev40_7_r[i];


                    filterSet.e40[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[8].left[i] = Filter48Diffused.elev40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[8].right[i] = Filter48Diffused.elev40_8_r[i];


                    filterSet.e40[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[9].left[i] = Filter48Diffused.elev40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[9].right[i] = Filter48Diffused.elev40_9_r[i];


                    filterSet.e40[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[10].left[i] = Filter48Diffused.elev40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[10].right[i] = Filter48Diffused.elev40_10_r[i];


                    filterSet.e40[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[11].left[i] = Filter48Diffused.elev40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[11].right[i] = Filter48Diffused.elev40_11_r[i];


                    filterSet.e40[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[12].left[i] = Filter48Diffused.elev40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[12].right[i] = Filter48Diffused.elev40_12_r[i];


                    filterSet.e40[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[13].left[i] = Filter48Diffused.elev40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[13].right[i] = Filter48Diffused.elev40_13_r[i];


                    filterSet.e40[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[14].left[i] = Filter48Diffused.elev40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[14].right[i] = Filter48Diffused.elev40_14_r[i];


                    filterSet.e40[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[15].left[i] = Filter48Diffused.elev40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[15].right[i] = Filter48Diffused.elev40_15_r[i];


                    filterSet.e40[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[16].left[i] = Filter48Diffused.elev40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[16].right[i] = Filter48Diffused.elev40_16_r[i];


                    filterSet.e40[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[17].left[i] = Filter48Diffused.elev40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[17].right[i] = Filter48Diffused.elev40_17_r[i];


                    filterSet.e40[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[18].left[i] = Filter48Diffused.elev40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[18].right[i] = Filter48Diffused.elev40_18_r[i];


                    filterSet.e40[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[19].left[i] = Filter48Diffused.elev40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[19].right[i] = Filter48Diffused.elev40_19_r[i];


                    filterSet.e40[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[20].left[i] = Filter48Diffused.elev40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[20].right[i] = Filter48Diffused.elev40_20_r[i];


                    filterSet.e40[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[21].left[i] = Filter48Diffused.elev40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[21].right[i] = Filter48Diffused.elev40_21_r[i];


                    filterSet.e40[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[22].left[i] = Filter48Diffused.elev40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[22].right[i] = Filter48Diffused.elev40_22_r[i];


                    filterSet.e40[23] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[23].left[i] = Filter48Diffused.elev40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[23].right[i] = Filter48Diffused.elev40_23_r[i];


                    filterSet.e40[24] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[24].left[i] = Filter48Diffused.elev40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[24].right[i] = Filter48Diffused.elev40_24_r[i];


                    filterSet.e40[25] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[25].left[i] = Filter48Diffused.elev40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[25].right[i] = Filter48Diffused.elev40_25_r[i];


                    filterSet.e40[26] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[26].left[i] = Filter48Diffused.elev40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[26].right[i] = Filter48Diffused.elev40_26_r[i];


                    filterSet.e40[27] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[27].left[i] = Filter48Diffused.elev40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[27].right[i] = Filter48Diffused.elev40_27_r[i];


                    filterSet.e40[28] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[28].left[i] = Filter48Diffused.elev40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e40[28].right[i] = Filter48Diffused.elev40_28_r[i];




                    // e50
                    filterSet.e50[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[0].left[i] = Filter48Diffused.elev50_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[0].right[i] = Filter48Diffused.elev50_0_r[i];


                    filterSet.e50[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[1].left[i] = Filter48Diffused.elev50_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[1].right[i] = Filter48Diffused.elev50_1_r[i];


                    filterSet.e50[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[2].left[i] = Filter48Diffused.elev50_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[2].right[i] = Filter48Diffused.elev50_2_r[i];


                    filterSet.e50[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[3].left[i] = Filter48Diffused.elev50_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[3].right[i] = Filter48Diffused.elev50_3_r[i];


                    filterSet.e50[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[4].left[i] = Filter48Diffused.elev50_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[4].right[i] = Filter48Diffused.elev50_4_r[i];


                    filterSet.e50[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[5].left[i] = Filter48Diffused.elev50_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[5].right[i] = Filter48Diffused.elev50_5_r[i];


                    filterSet.e50[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[6].left[i] = Filter48Diffused.elev50_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[6].right[i] = Filter48Diffused.elev50_6_r[i];


                    filterSet.e50[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[7].left[i] = Filter48Diffused.elev50_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[7].right[i] = Filter48Diffused.elev50_7_r[i];


                    filterSet.e50[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[8].left[i] = Filter48Diffused.elev50_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[8].right[i] = Filter48Diffused.elev50_8_r[i];


                    filterSet.e50[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[9].left[i] = Filter48Diffused.elev50_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[9].right[i] = Filter48Diffused.elev50_9_r[i];


                    filterSet.e50[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[10].left[i] = Filter48Diffused.elev50_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[10].right[i] = Filter48Diffused.elev50_10_r[i];


                    filterSet.e50[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[11].left[i] = Filter48Diffused.elev50_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[11].right[i] = Filter48Diffused.elev50_11_r[i];


                    filterSet.e50[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[12].left[i] = Filter48Diffused.elev50_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[12].right[i] = Filter48Diffused.elev50_12_r[i];


                    filterSet.e50[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[13].left[i] = Filter48Diffused.elev50_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[13].right[i] = Filter48Diffused.elev50_13_r[i];


                    filterSet.e50[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[14].left[i] = Filter48Diffused.elev50_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[14].right[i] = Filter48Diffused.elev50_14_r[i];


                    filterSet.e50[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[15].left[i] = Filter48Diffused.elev50_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[15].right[i] = Filter48Diffused.elev50_15_r[i];


                    filterSet.e50[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[16].left[i] = Filter48Diffused.elev50_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[16].right[i] = Filter48Diffused.elev50_16_r[i];


                    filterSet.e50[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[17].left[i] = Filter48Diffused.elev50_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[17].right[i] = Filter48Diffused.elev50_17_r[i];


                    filterSet.e50[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[18].left[i] = Filter48Diffused.elev50_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[18].right[i] = Filter48Diffused.elev50_18_r[i];


                    filterSet.e50[19] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[19].left[i] = Filter48Diffused.elev50_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[19].right[i] = Filter48Diffused.elev50_19_r[i];


                    filterSet.e50[20] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[20].left[i] = Filter48Diffused.elev50_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[20].right[i] = Filter48Diffused.elev50_20_r[i];


                    filterSet.e50[21] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[21].left[i] = Filter48Diffused.elev50_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[21].right[i] = Filter48Diffused.elev50_21_r[i];


                    filterSet.e50[22] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[22].left[i] = Filter48Diffused.elev50_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e50[22].right[i] = Filter48Diffused.elev50_22_r[i];




                    // e60
                    filterSet.e60[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[0].left[i] = Filter48Diffused.elev60_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[0].right[i] = Filter48Diffused.elev60_0_r[i];


                    filterSet.e60[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[1].left[i] = Filter48Diffused.elev60_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[1].right[i] = Filter48Diffused.elev60_1_r[i];


                    filterSet.e60[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[2].left[i] = Filter48Diffused.elev60_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[2].right[i] = Filter48Diffused.elev60_2_r[i];


                    filterSet.e60[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[3].left[i] = Filter48Diffused.elev60_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[3].right[i] = Filter48Diffused.elev60_3_r[i];


                    filterSet.e60[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[4].left[i] = Filter48Diffused.elev60_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[4].right[i] = Filter48Diffused.elev60_4_r[i];


                    filterSet.e60[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[5].left[i] = Filter48Diffused.elev60_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[5].right[i] = Filter48Diffused.elev60_5_r[i];


                    filterSet.e60[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[6].left[i] = Filter48Diffused.elev60_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[6].right[i] = Filter48Diffused.elev60_6_r[i];


                    filterSet.e60[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[7].left[i] = Filter48Diffused.elev60_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[7].right[i] = Filter48Diffused.elev60_7_r[i];


                    filterSet.e60[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[8].left[i] = Filter48Diffused.elev60_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[8].right[i] = Filter48Diffused.elev60_8_r[i];


                    filterSet.e60[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[9].left[i] = Filter48Diffused.elev60_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[9].right[i] = Filter48Diffused.elev60_9_r[i];


                    filterSet.e60[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[10].left[i] = Filter48Diffused.elev60_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[10].right[i] = Filter48Diffused.elev60_10_r[i];


                    filterSet.e60[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[11].left[i] = Filter48Diffused.elev60_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[11].right[i] = Filter48Diffused.elev60_11_r[i];


                    filterSet.e60[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[12].left[i] = Filter48Diffused.elev60_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[12].right[i] = Filter48Diffused.elev60_12_r[i];


                    filterSet.e60[13] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[13].left[i] = Filter48Diffused.elev60_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[13].right[i] = Filter48Diffused.elev60_13_r[i];


                    filterSet.e60[14] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[14].left[i] = Filter48Diffused.elev60_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[14].right[i] = Filter48Diffused.elev60_14_r[i];


                    filterSet.e60[15] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[15].left[i] = Filter48Diffused.elev60_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[15].right[i] = Filter48Diffused.elev60_15_r[i];


                    filterSet.e60[16] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[16].left[i] = Filter48Diffused.elev60_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[16].right[i] = Filter48Diffused.elev60_16_r[i];


                    filterSet.e60[17] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[17].left[i] = Filter48Diffused.elev60_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[17].right[i] = Filter48Diffused.elev60_17_r[i];


                    filterSet.e60[18] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[18].left[i] = Filter48Diffused.elev60_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e60[18].right[i] = Filter48Diffused.elev60_18_r[i];




                    // e70
                    filterSet.e70[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[0].left[i] = Filter48Diffused.elev70_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[0].right[i] = Filter48Diffused.elev70_0_r[i];


                    filterSet.e70[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[1].left[i] = Filter48Diffused.elev70_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[1].right[i] = Filter48Diffused.elev70_1_r[i];


                    filterSet.e70[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[2].left[i] = Filter48Diffused.elev70_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[2].right[i] = Filter48Diffused.elev70_2_r[i];


                    filterSet.e70[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[3].left[i] = Filter48Diffused.elev70_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[3].right[i] = Filter48Diffused.elev70_3_r[i];


                    filterSet.e70[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[4].left[i] = Filter48Diffused.elev70_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[4].right[i] = Filter48Diffused.elev70_4_r[i];


                    filterSet.e70[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[5].left[i] = Filter48Diffused.elev70_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[5].right[i] = Filter48Diffused.elev70_5_r[i];


                    filterSet.e70[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[6].left[i] = Filter48Diffused.elev70_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[6].right[i] = Filter48Diffused.elev70_6_r[i];


                    filterSet.e70[7] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[7].left[i] = Filter48Diffused.elev70_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[7].right[i] = Filter48Diffused.elev70_7_r[i];


                    filterSet.e70[8] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[8].left[i] = Filter48Diffused.elev70_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[8].right[i] = Filter48Diffused.elev70_8_r[i];


                    filterSet.e70[9] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[9].left[i] = Filter48Diffused.elev70_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[9].right[i] = Filter48Diffused.elev70_9_r[i];


                    filterSet.e70[10] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[10].left[i] = Filter48Diffused.elev70_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[10].right[i] = Filter48Diffused.elev70_10_r[i];


                    filterSet.e70[11] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[11].left[i] = Filter48Diffused.elev70_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[11].right[i] = Filter48Diffused.elev70_11_r[i];


                    filterSet.e70[12] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[12].left[i] = Filter48Diffused.elev70_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e70[12].right[i] = Filter48Diffused.elev70_12_r[i];




                    // e80
                    filterSet.e80[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[0].left[i] = Filter48Diffused.elev80_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[0].right[i] = Filter48Diffused.elev80_0_r[i];


                    filterSet.e80[1] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[1].left[i] = Filter48Diffused.elev80_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[1].right[i] = Filter48Diffused.elev80_1_r[i];


                    filterSet.e80[2] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[2].left[i] = Filter48Diffused.elev80_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[2].right[i] = Filter48Diffused.elev80_2_r[i];


                    filterSet.e80[3] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[3].left[i] = Filter48Diffused.elev80_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[3].right[i] = Filter48Diffused.elev80_3_r[i];


                    filterSet.e80[4] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[4].left[i] = Filter48Diffused.elev80_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[4].right[i] = Filter48Diffused.elev80_4_r[i];


                    filterSet.e80[5] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[5].left[i] = Filter48Diffused.elev80_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[5].right[i] = Filter48Diffused.elev80_5_r[i];


                    filterSet.e80[6] = new mit_hrtf_filter_48();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[6].left[i] = Filter48Diffused.elev80_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e80[6].right[i] = Filter48Diffused.elev80_6_r[i];




                    // e90
                    filterSet.e90[0] = new mit_hrtf_filter_48();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e90[0].left[i] = Filter48Diffused.elev90_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_48_TAPS; i++)
                        filterSet.e90[0].right[i] = Filter48Diffused.elev90_0_r[i];



                    // Finally, return the fully populated filter set.
                    return filterSet;
                }

            }
        }
        #endregion

        #region 88khz
        private static mit_hrtf_filter_set_88 normal_88
        {
            get
            {
                unsafe
                {
                    var filterSet = mit_hrtf_filter_set_88.Create();


                    // e_10
                    filterSet.e_10[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[0].left[i] = Filter88.elev_10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[0].right[i] = Filter88.elev_10_0_r[i];


                    filterSet.e_10[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[1].left[i] = Filter88.elev_10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[1].right[i] = Filter88.elev_10_1_r[i];


                    filterSet.e_10[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[2].left[i] = Filter88.elev_10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[2].right[i] = Filter88.elev_10_2_r[i];


                    filterSet.e_10[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[3].left[i] = Filter88.elev_10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[3].right[i] = Filter88.elev_10_3_r[i];


                    filterSet.e_10[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[4].left[i] = Filter88.elev_10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[4].right[i] = Filter88.elev_10_4_r[i];


                    filterSet.e_10[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[5].left[i] = Filter88.elev_10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[5].right[i] = Filter88.elev_10_5_r[i];


                    filterSet.e_10[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[6].left[i] = Filter88.elev_10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[6].right[i] = Filter88.elev_10_6_r[i];


                    filterSet.e_10[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[7].left[i] = Filter88.elev_10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[7].right[i] = Filter88.elev_10_7_r[i];


                    filterSet.e_10[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[8].left[i] = Filter88.elev_10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[8].right[i] = Filter88.elev_10_8_r[i];


                    filterSet.e_10[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[9].left[i] = Filter88.elev_10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[9].right[i] = Filter88.elev_10_9_r[i];


                    filterSet.e_10[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[10].left[i] = Filter88.elev_10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[10].right[i] = Filter88.elev_10_10_r[i];


                    filterSet.e_10[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[11].left[i] = Filter88.elev_10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[11].right[i] = Filter88.elev_10_11_r[i];


                    filterSet.e_10[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[12].left[i] = Filter88.elev_10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[12].right[i] = Filter88.elev_10_12_r[i];


                    filterSet.e_10[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[13].left[i] = Filter88.elev_10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[13].right[i] = Filter88.elev_10_13_r[i];


                    filterSet.e_10[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[14].left[i] = Filter88.elev_10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[14].right[i] = Filter88.elev_10_14_r[i];


                    filterSet.e_10[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[15].left[i] = Filter88.elev_10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[15].right[i] = Filter88.elev_10_15_r[i];


                    filterSet.e_10[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[16].left[i] = Filter88.elev_10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[16].right[i] = Filter88.elev_10_16_r[i];


                    filterSet.e_10[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[17].left[i] = Filter88.elev_10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[17].right[i] = Filter88.elev_10_17_r[i];


                    filterSet.e_10[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[18].left[i] = Filter88.elev_10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[18].right[i] = Filter88.elev_10_18_r[i];


                    filterSet.e_10[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[19].left[i] = Filter88.elev_10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[19].right[i] = Filter88.elev_10_19_r[i];


                    filterSet.e_10[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[20].left[i] = Filter88.elev_10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[20].right[i] = Filter88.elev_10_20_r[i];


                    filterSet.e_10[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[21].left[i] = Filter88.elev_10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[21].right[i] = Filter88.elev_10_21_r[i];


                    filterSet.e_10[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[22].left[i] = Filter88.elev_10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[22].right[i] = Filter88.elev_10_22_r[i];


                    filterSet.e_10[23] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[23].left[i] = Filter88.elev_10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[23].right[i] = Filter88.elev_10_23_r[i];


                    filterSet.e_10[24] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[24].left[i] = Filter88.elev_10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[24].right[i] = Filter88.elev_10_24_r[i];


                    filterSet.e_10[25] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[25].left[i] = Filter88.elev_10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[25].right[i] = Filter88.elev_10_25_r[i];


                    filterSet.e_10[26] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[26].left[i] = Filter88.elev_10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[26].right[i] = Filter88.elev_10_26_r[i];


                    filterSet.e_10[27] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[27].left[i] = Filter88.elev_10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[27].right[i] = Filter88.elev_10_27_r[i];


                    filterSet.e_10[28] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[28].left[i] = Filter88.elev_10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[28].right[i] = Filter88.elev_10_28_r[i];


                    filterSet.e_10[29] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[29].left[i] = Filter88.elev_10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[29].right[i] = Filter88.elev_10_29_r[i];


                    filterSet.e_10[30] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[30].left[i] = Filter88.elev_10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[30].right[i] = Filter88.elev_10_30_r[i];


                    filterSet.e_10[31] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[31].left[i] = Filter88.elev_10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[31].right[i] = Filter88.elev_10_31_r[i];


                    filterSet.e_10[32] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[32].left[i] = Filter88.elev_10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[32].right[i] = Filter88.elev_10_32_r[i];


                    filterSet.e_10[33] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[33].left[i] = Filter88.elev_10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[33].right[i] = Filter88.elev_10_33_r[i];


                    filterSet.e_10[34] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[34].left[i] = Filter88.elev_10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[34].right[i] = Filter88.elev_10_34_r[i];


                    filterSet.e_10[35] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[35].left[i] = Filter88.elev_10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[35].right[i] = Filter88.elev_10_35_r[i];


                    filterSet.e_10[36] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[36].left[i] = Filter88.elev_10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_10[36].right[i] = Filter88.elev_10_36_r[i];



                    // e_20
                    filterSet.e_20[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[0].left[i] = Filter88.elev_20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[0].right[i] = Filter88.elev_20_0_r[i];


                    filterSet.e_20[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[1].left[i] = Filter88.elev_20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[1].right[i] = Filter88.elev_20_1_r[i];


                    filterSet.e_20[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[2].left[i] = Filter88.elev_20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[2].right[i] = Filter88.elev_20_2_r[i];


                    filterSet.e_20[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[3].left[i] = Filter88.elev_20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[3].right[i] = Filter88.elev_20_3_r[i];


                    filterSet.e_20[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[4].left[i] = Filter88.elev_20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[4].right[i] = Filter88.elev_20_4_r[i];


                    filterSet.e_20[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[5].left[i] = Filter88.elev_20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[5].right[i] = Filter88.elev_20_5_r[i];


                    filterSet.e_20[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[6].left[i] = Filter88.elev_20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[6].right[i] = Filter88.elev_20_6_r[i];


                    filterSet.e_20[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[7].left[i] = Filter88.elev_20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[7].right[i] = Filter88.elev_20_7_r[i];


                    filterSet.e_20[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[8].left[i] = Filter88.elev_20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[8].right[i] = Filter88.elev_20_8_r[i];


                    filterSet.e_20[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[9].left[i] = Filter88.elev_20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[9].right[i] = Filter88.elev_20_9_r[i];


                    filterSet.e_20[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[10].left[i] = Filter88.elev_20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[10].right[i] = Filter88.elev_20_10_r[i];


                    filterSet.e_20[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[11].left[i] = Filter88.elev_20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[11].right[i] = Filter88.elev_20_11_r[i];


                    filterSet.e_20[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[12].left[i] = Filter88.elev_20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[12].right[i] = Filter88.elev_20_12_r[i];


                    filterSet.e_20[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[13].left[i] = Filter88.elev_20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[13].right[i] = Filter88.elev_20_13_r[i];


                    filterSet.e_20[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[14].left[i] = Filter88.elev_20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[14].right[i] = Filter88.elev_20_14_r[i];


                    filterSet.e_20[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[15].left[i] = Filter88.elev_20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[15].right[i] = Filter88.elev_20_15_r[i];


                    filterSet.e_20[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[16].left[i] = Filter88.elev_20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[16].right[i] = Filter88.elev_20_16_r[i];


                    filterSet.e_20[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[17].left[i] = Filter88.elev_20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[17].right[i] = Filter88.elev_20_17_r[i];


                    filterSet.e_20[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[18].left[i] = Filter88.elev_20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[18].right[i] = Filter88.elev_20_18_r[i];


                    filterSet.e_20[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[19].left[i] = Filter88.elev_20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[19].right[i] = Filter88.elev_20_19_r[i];


                    filterSet.e_20[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[20].left[i] = Filter88.elev_20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[20].right[i] = Filter88.elev_20_20_r[i];


                    filterSet.e_20[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[21].left[i] = Filter88.elev_20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[21].right[i] = Filter88.elev_20_21_r[i];


                    filterSet.e_20[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[22].left[i] = Filter88.elev_20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[22].right[i] = Filter88.elev_20_22_r[i];


                    filterSet.e_20[23] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[23].left[i] = Filter88.elev_20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[23].right[i] = Filter88.elev_20_23_r[i];


                    filterSet.e_20[24] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[24].left[i] = Filter88.elev_20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[24].right[i] = Filter88.elev_20_24_r[i];


                    filterSet.e_20[25] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[25].left[i] = Filter88.elev_20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[25].right[i] = Filter88.elev_20_25_r[i];


                    filterSet.e_20[26] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[26].left[i] = Filter88.elev_20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[26].right[i] = Filter88.elev_20_26_r[i];


                    filterSet.e_20[27] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[27].left[i] = Filter88.elev_20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[27].right[i] = Filter88.elev_20_27_r[i];


                    filterSet.e_20[28] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[28].left[i] = Filter88.elev_20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[28].right[i] = Filter88.elev_20_28_r[i];


                    filterSet.e_20[29] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[29].left[i] = Filter88.elev_20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[29].right[i] = Filter88.elev_20_29_r[i];


                    filterSet.e_20[30] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[30].left[i] = Filter88.elev_20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[30].right[i] = Filter88.elev_20_30_r[i];


                    filterSet.e_20[31] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[31].left[i] = Filter88.elev_20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[31].right[i] = Filter88.elev_20_31_r[i];


                    filterSet.e_20[32] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[32].left[i] = Filter88.elev_20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[32].right[i] = Filter88.elev_20_32_r[i];


                    filterSet.e_20[33] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[33].left[i] = Filter88.elev_20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[33].right[i] = Filter88.elev_20_33_r[i];


                    filterSet.e_20[34] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[34].left[i] = Filter88.elev_20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[34].right[i] = Filter88.elev_20_34_r[i];


                    filterSet.e_20[35] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[35].left[i] = Filter88.elev_20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[35].right[i] = Filter88.elev_20_35_r[i];


                    filterSet.e_20[36] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[36].left[i] = Filter88.elev_20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_20[36].right[i] = Filter88.elev_20_36_r[i];




                    // e_30
                    filterSet.e_30[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[0].left[i] = Filter88.elev_30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[0].right[i] = Filter88.elev_30_0_r[i];


                    filterSet.e_30[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[1].left[i] = Filter88.elev_30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[1].right[i] = Filter88.elev_30_1_r[i];


                    filterSet.e_30[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[2].left[i] = Filter88.elev_30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[2].right[i] = Filter88.elev_30_2_r[i];


                    filterSet.e_30[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[3].left[i] = Filter88.elev_30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[3].right[i] = Filter88.elev_30_3_r[i];


                    filterSet.e_30[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[4].left[i] = Filter88.elev_30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[4].right[i] = Filter88.elev_30_4_r[i];


                    filterSet.e_30[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[5].left[i] = Filter88.elev_30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[5].right[i] = Filter88.elev_30_5_r[i];


                    filterSet.e_30[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[6].left[i] = Filter88.elev_30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[6].right[i] = Filter88.elev_30_6_r[i];


                    filterSet.e_30[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[7].left[i] = Filter88.elev_30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[7].right[i] = Filter88.elev_30_7_r[i];


                    filterSet.e_30[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[8].left[i] = Filter88.elev_30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[8].right[i] = Filter88.elev_30_8_r[i];


                    filterSet.e_30[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[9].left[i] = Filter88.elev_30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[9].right[i] = Filter88.elev_30_9_r[i];


                    filterSet.e_30[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[10].left[i] = Filter88.elev_30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[10].right[i] = Filter88.elev_30_10_r[i];


                    filterSet.e_30[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[11].left[i] = Filter88.elev_30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[11].right[i] = Filter88.elev_30_11_r[i];


                    filterSet.e_30[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[12].left[i] = Filter88.elev_30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[12].right[i] = Filter88.elev_30_12_r[i];


                    filterSet.e_30[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[13].left[i] = Filter88.elev_30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[13].right[i] = Filter88.elev_30_13_r[i];


                    filterSet.e_30[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[14].left[i] = Filter88.elev_30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[14].right[i] = Filter88.elev_30_14_r[i];


                    filterSet.e_30[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[15].left[i] = Filter88.elev_30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[15].right[i] = Filter88.elev_30_15_r[i];


                    filterSet.e_30[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[16].left[i] = Filter88.elev_30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[16].right[i] = Filter88.elev_30_16_r[i];


                    filterSet.e_30[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[17].left[i] = Filter88.elev_30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[17].right[i] = Filter88.elev_30_17_r[i];


                    filterSet.e_30[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[18].left[i] = Filter88.elev_30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[18].right[i] = Filter88.elev_30_18_r[i];


                    filterSet.e_30[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[19].left[i] = Filter88.elev_30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[19].right[i] = Filter88.elev_30_19_r[i];


                    filterSet.e_30[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[20].left[i] = Filter88.elev_30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[20].right[i] = Filter88.elev_30_20_r[i];


                    filterSet.e_30[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[21].left[i] = Filter88.elev_30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[21].right[i] = Filter88.elev_30_21_r[i];


                    filterSet.e_30[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[22].left[i] = Filter88.elev_30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[22].right[i] = Filter88.elev_30_22_r[i];


                    filterSet.e_30[23] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[23].left[i] = Filter88.elev_30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[23].right[i] = Filter88.elev_30_23_r[i];


                    filterSet.e_30[24] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[24].left[i] = Filter88.elev_30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[24].right[i] = Filter88.elev_30_24_r[i];


                    filterSet.e_30[25] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[25].left[i] = Filter88.elev_30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[25].right[i] = Filter88.elev_30_25_r[i];


                    filterSet.e_30[26] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[26].left[i] = Filter88.elev_30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[26].right[i] = Filter88.elev_30_26_r[i];


                    filterSet.e_30[27] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[27].left[i] = Filter88.elev_30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[27].right[i] = Filter88.elev_30_27_r[i];


                    filterSet.e_30[28] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[28].left[i] = Filter88.elev_30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[28].right[i] = Filter88.elev_30_28_r[i];


                    filterSet.e_30[29] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[29].left[i] = Filter88.elev_30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[29].right[i] = Filter88.elev_30_29_r[i];


                    filterSet.e_30[30] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[30].left[i] = Filter88.elev_30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_30[30].right[i] = Filter88.elev_30_30_r[i];



                    // e_40
                    filterSet.e_40[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[0].left[i] = Filter88.elev_40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[0].right[i] = Filter88.elev_40_0_r[i];


                    filterSet.e_40[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[1].left[i] = Filter88.elev_40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[1].right[i] = Filter88.elev_40_1_r[i];


                    filterSet.e_40[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[2].left[i] = Filter88.elev_40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[2].right[i] = Filter88.elev_40_2_r[i];


                    filterSet.e_40[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[3].left[i] = Filter88.elev_40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[3].right[i] = Filter88.elev_40_3_r[i];


                    filterSet.e_40[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[4].left[i] = Filter88.elev_40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[4].right[i] = Filter88.elev_40_4_r[i];


                    filterSet.e_40[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[5].left[i] = Filter88.elev_40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[5].right[i] = Filter88.elev_40_5_r[i];


                    filterSet.e_40[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[6].left[i] = Filter88.elev_40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[6].right[i] = Filter88.elev_40_6_r[i];


                    filterSet.e_40[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[7].left[i] = Filter88.elev_40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[7].right[i] = Filter88.elev_40_7_r[i];


                    filterSet.e_40[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[8].left[i] = Filter88.elev_40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[8].right[i] = Filter88.elev_40_8_r[i];


                    filterSet.e_40[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[9].left[i] = Filter88.elev_40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[9].right[i] = Filter88.elev_40_9_r[i];


                    filterSet.e_40[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[10].left[i] = Filter88.elev_40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[10].right[i] = Filter88.elev_40_10_r[i];


                    filterSet.e_40[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[11].left[i] = Filter88.elev_40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[11].right[i] = Filter88.elev_40_11_r[i];


                    filterSet.e_40[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[12].left[i] = Filter88.elev_40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[12].right[i] = Filter88.elev_40_12_r[i];


                    filterSet.e_40[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[13].left[i] = Filter88.elev_40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[13].right[i] = Filter88.elev_40_13_r[i];


                    filterSet.e_40[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[14].left[i] = Filter88.elev_40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[14].right[i] = Filter88.elev_40_14_r[i];


                    filterSet.e_40[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[15].left[i] = Filter88.elev_40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[15].right[i] = Filter88.elev_40_15_r[i];


                    filterSet.e_40[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[16].left[i] = Filter88.elev_40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[16].right[i] = Filter88.elev_40_16_r[i];


                    filterSet.e_40[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[17].left[i] = Filter88.elev_40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[17].right[i] = Filter88.elev_40_17_r[i];


                    filterSet.e_40[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[18].left[i] = Filter88.elev_40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[18].right[i] = Filter88.elev_40_18_r[i];


                    filterSet.e_40[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[19].left[i] = Filter88.elev_40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[19].right[i] = Filter88.elev_40_19_r[i];


                    filterSet.e_40[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[20].left[i] = Filter88.elev_40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[20].right[i] = Filter88.elev_40_20_r[i];


                    filterSet.e_40[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[21].left[i] = Filter88.elev_40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[21].right[i] = Filter88.elev_40_21_r[i];


                    filterSet.e_40[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[22].left[i] = Filter88.elev_40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[22].right[i] = Filter88.elev_40_22_r[i];


                    filterSet.e_40[23] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[23].left[i] = Filter88.elev_40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[23].right[i] = Filter88.elev_40_23_r[i];


                    filterSet.e_40[24] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[24].left[i] = Filter88.elev_40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[24].right[i] = Filter88.elev_40_24_r[i];


                    filterSet.e_40[25] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[25].left[i] = Filter88.elev_40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[25].right[i] = Filter88.elev_40_25_r[i];


                    filterSet.e_40[26] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[26].left[i] = Filter88.elev_40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[26].right[i] = Filter88.elev_40_26_r[i];


                    filterSet.e_40[27] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[27].left[i] = Filter88.elev_40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[27].right[i] = Filter88.elev_40_27_r[i];


                    filterSet.e_40[28] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[28].left[i] = Filter88.elev_40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e_40[28].right[i] = Filter88.elev_40_28_r[i];




                    // e0
                    filterSet.e00[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[0].left[i] = Filter88.elev0_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[0].right[i] = Filter88.elev0_0_r[i];


                    filterSet.e00[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[1].left[i] = Filter88.elev0_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[1].right[i] = Filter88.elev0_1_r[i];


                    filterSet.e00[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[2].left[i] = Filter88.elev0_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[2].right[i] = Filter88.elev0_2_r[i];


                    filterSet.e00[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[3].left[i] = Filter88.elev0_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[3].right[i] = Filter88.elev0_3_r[i];


                    filterSet.e00[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[4].left[i] = Filter88.elev0_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[4].right[i] = Filter88.elev0_4_r[i];


                    filterSet.e00[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[5].left[i] = Filter88.elev0_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[5].right[i] = Filter88.elev0_5_r[i];


                    filterSet.e00[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[6].left[i] = Filter88.elev0_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[6].right[i] = Filter88.elev0_6_r[i];


                    filterSet.e00[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[7].left[i] = Filter88.elev0_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[7].right[i] = Filter88.elev0_7_r[i];


                    filterSet.e00[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[8].left[i] = Filter88.elev0_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[8].right[i] = Filter88.elev0_8_r[i];


                    filterSet.e00[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[9].left[i] = Filter88.elev0_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[9].right[i] = Filter88.elev0_9_r[i];


                    filterSet.e00[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[10].left[i] = Filter88.elev0_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[10].right[i] = Filter88.elev0_10_r[i];


                    filterSet.e00[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[11].left[i] = Filter88.elev0_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[11].right[i] = Filter88.elev0_11_r[i];


                    filterSet.e00[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[12].left[i] = Filter88.elev0_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[12].right[i] = Filter88.elev0_12_r[i];


                    filterSet.e00[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[13].left[i] = Filter88.elev0_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[13].right[i] = Filter88.elev0_13_r[i];


                    filterSet.e00[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[14].left[i] = Filter88.elev0_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[14].right[i] = Filter88.elev0_14_r[i];


                    filterSet.e00[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[15].left[i] = Filter88.elev0_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[15].right[i] = Filter88.elev0_15_r[i];


                    filterSet.e00[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[16].left[i] = Filter88.elev0_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[16].right[i] = Filter88.elev0_16_r[i];


                    filterSet.e00[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[17].left[i] = Filter88.elev0_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[17].right[i] = Filter88.elev0_17_r[i];


                    filterSet.e00[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[18].left[i] = Filter88.elev0_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[18].right[i] = Filter88.elev0_18_r[i];


                    filterSet.e00[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[19].left[i] = Filter88.elev0_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[19].right[i] = Filter88.elev0_19_r[i];


                    filterSet.e00[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[20].left[i] = Filter88.elev0_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[20].right[i] = Filter88.elev0_20_r[i];


                    filterSet.e00[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[21].left[i] = Filter88.elev0_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[21].right[i] = Filter88.elev0_21_r[i];


                    filterSet.e00[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[22].left[i] = Filter88.elev0_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[22].right[i] = Filter88.elev0_22_r[i];


                    filterSet.e00[23] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[23].left[i] = Filter88.elev0_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[23].right[i] = Filter88.elev0_23_r[i];


                    filterSet.e00[24] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[24].left[i] = Filter88.elev0_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[24].right[i] = Filter88.elev0_24_r[i];


                    filterSet.e00[25] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[25].left[i] = Filter88.elev0_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[25].right[i] = Filter88.elev0_25_r[i];


                    filterSet.e00[26] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[26].left[i] = Filter88.elev0_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[26].right[i] = Filter88.elev0_26_r[i];


                    filterSet.e00[27] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[27].left[i] = Filter88.elev0_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[27].right[i] = Filter88.elev0_27_r[i];


                    filterSet.e00[28] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[28].left[i] = Filter88.elev0_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[28].right[i] = Filter88.elev0_28_r[i];


                    filterSet.e00[29] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[29].left[i] = Filter88.elev0_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[29].right[i] = Filter88.elev0_29_r[i];


                    filterSet.e00[30] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[30].left[i] = Filter88.elev0_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[30].right[i] = Filter88.elev0_30_r[i];


                    filterSet.e00[31] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[31].left[i] = Filter88.elev0_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[31].right[i] = Filter88.elev0_31_r[i];


                    filterSet.e00[32] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[32].left[i] = Filter88.elev0_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[32].right[i] = Filter88.elev0_32_r[i];


                    filterSet.e00[33] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[33].left[i] = Filter88.elev0_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[33].right[i] = Filter88.elev0_33_r[i];


                    filterSet.e00[34] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[34].left[i] = Filter88.elev0_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[34].right[i] = Filter88.elev0_34_r[i];


                    filterSet.e00[35] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[35].left[i] = Filter88.elev0_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[35].right[i] = Filter88.elev0_35_r[i];


                    filterSet.e00[36] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[36].left[i] = Filter88.elev0_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e00[36].right[i] = Filter88.elev0_36_r[i];




                    // e10
                    filterSet.e10[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[0].left[i] = Filter88.elev10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[0].right[i] = Filter88.elev10_0_r[i];


                    filterSet.e10[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[1].left[i] = Filter88.elev10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[1].right[i] = Filter88.elev10_1_r[i];


                    filterSet.e10[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[2].left[i] = Filter88.elev10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[2].right[i] = Filter88.elev10_2_r[i];


                    filterSet.e10[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[3].left[i] = Filter88.elev10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[3].right[i] = Filter88.elev10_3_r[i];


                    filterSet.e10[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[4].left[i] = Filter88.elev10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[4].right[i] = Filter88.elev10_4_r[i];


                    filterSet.e10[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[5].left[i] = Filter88.elev10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[5].right[i] = Filter88.elev10_5_r[i];


                    filterSet.e10[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[6].left[i] = Filter88.elev10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[6].right[i] = Filter88.elev10_6_r[i];


                    filterSet.e10[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[7].left[i] = Filter88.elev10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[7].right[i] = Filter88.elev10_7_r[i];


                    filterSet.e10[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[8].left[i] = Filter88.elev10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[8].right[i] = Filter88.elev10_8_r[i];


                    filterSet.e10[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[9].left[i] = Filter88.elev10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[9].right[i] = Filter88.elev10_9_r[i];


                    filterSet.e10[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[10].left[i] = Filter88.elev10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[10].right[i] = Filter88.elev10_10_r[i];


                    filterSet.e10[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[11].left[i] = Filter88.elev10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[11].right[i] = Filter88.elev10_11_r[i];


                    filterSet.e10[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[12].left[i] = Filter88.elev10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[12].right[i] = Filter88.elev10_12_r[i];


                    filterSet.e10[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[13].left[i] = Filter88.elev10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[13].right[i] = Filter88.elev10_13_r[i];


                    filterSet.e10[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[14].left[i] = Filter88.elev10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[14].right[i] = Filter88.elev10_14_r[i];


                    filterSet.e10[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[15].left[i] = Filter88.elev10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[15].right[i] = Filter88.elev10_15_r[i];


                    filterSet.e10[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[16].left[i] = Filter88.elev10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[16].right[i] = Filter88.elev10_16_r[i];


                    filterSet.e10[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[17].left[i] = Filter88.elev10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[17].right[i] = Filter88.elev10_17_r[i];


                    filterSet.e10[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[18].left[i] = Filter88.elev10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[18].right[i] = Filter88.elev10_18_r[i];


                    filterSet.e10[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[19].left[i] = Filter88.elev10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[19].right[i] = Filter88.elev10_19_r[i];


                    filterSet.e10[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[20].left[i] = Filter88.elev10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[20].right[i] = Filter88.elev10_20_r[i];


                    filterSet.e10[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[21].left[i] = Filter88.elev10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[21].right[i] = Filter88.elev10_21_r[i];


                    filterSet.e10[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[22].left[i] = Filter88.elev10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[22].right[i] = Filter88.elev10_22_r[i];


                    filterSet.e10[23] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[23].left[i] = Filter88.elev10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[23].right[i] = Filter88.elev10_23_r[i];


                    filterSet.e10[24] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[24].left[i] = Filter88.elev10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[24].right[i] = Filter88.elev10_24_r[i];


                    filterSet.e10[25] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[25].left[i] = Filter88.elev10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[25].right[i] = Filter88.elev10_25_r[i];


                    filterSet.e10[26] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[26].left[i] = Filter88.elev10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[26].right[i] = Filter88.elev10_26_r[i];


                    filterSet.e10[27] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[27].left[i] = Filter88.elev10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[27].right[i] = Filter88.elev10_27_r[i];


                    filterSet.e10[28] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[28].left[i] = Filter88.elev10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[28].right[i] = Filter88.elev10_28_r[i];


                    filterSet.e10[29] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[29].left[i] = Filter88.elev10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[29].right[i] = Filter88.elev10_29_r[i];


                    filterSet.e10[30] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[30].left[i] = Filter88.elev10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[30].right[i] = Filter88.elev10_30_r[i];


                    filterSet.e10[31] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[31].left[i] = Filter88.elev10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[31].right[i] = Filter88.elev10_31_r[i];


                    filterSet.e10[32] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[32].left[i] = Filter88.elev10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[32].right[i] = Filter88.elev10_32_r[i];


                    filterSet.e10[33] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[33].left[i] = Filter88.elev10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[33].right[i] = Filter88.elev10_33_r[i];


                    filterSet.e10[34] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[34].left[i] = Filter88.elev10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[34].right[i] = Filter88.elev10_34_r[i];


                    filterSet.e10[35] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[35].left[i] = Filter88.elev10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[35].right[i] = Filter88.elev10_35_r[i];


                    filterSet.e10[36] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[36].left[i] = Filter88.elev10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e10[36].right[i] = Filter88.elev10_36_r[i];




                    // e20
                    filterSet.e20[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[0].left[i] = Filter88.elev20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[0].right[i] = Filter88.elev20_0_r[i];


                    filterSet.e20[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[1].left[i] = Filter88.elev20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[1].right[i] = Filter88.elev20_1_r[i];


                    filterSet.e20[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[2].left[i] = Filter88.elev20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[2].right[i] = Filter88.elev20_2_r[i];


                    filterSet.e20[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[3].left[i] = Filter88.elev20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[3].right[i] = Filter88.elev20_3_r[i];


                    filterSet.e20[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[4].left[i] = Filter88.elev20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[4].right[i] = Filter88.elev20_4_r[i];


                    filterSet.e20[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[5].left[i] = Filter88.elev20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[5].right[i] = Filter88.elev20_5_r[i];


                    filterSet.e20[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[6].left[i] = Filter88.elev20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[6].right[i] = Filter88.elev20_6_r[i];


                    filterSet.e20[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[7].left[i] = Filter88.elev20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[7].right[i] = Filter88.elev20_7_r[i];


                    filterSet.e20[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[8].left[i] = Filter88.elev20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[8].right[i] = Filter88.elev20_8_r[i];


                    filterSet.e20[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[9].left[i] = Filter88.elev20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[9].right[i] = Filter88.elev20_9_r[i];


                    filterSet.e20[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[10].left[i] = Filter88.elev20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[10].right[i] = Filter88.elev20_10_r[i];


                    filterSet.e20[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[11].left[i] = Filter88.elev20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[11].right[i] = Filter88.elev20_11_r[i];


                    filterSet.e20[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[12].left[i] = Filter88.elev20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[12].right[i] = Filter88.elev20_12_r[i];


                    filterSet.e20[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[13].left[i] = Filter88.elev20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[13].right[i] = Filter88.elev20_13_r[i];


                    filterSet.e20[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[14].left[i] = Filter88.elev20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[14].right[i] = Filter88.elev20_14_r[i];


                    filterSet.e20[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[15].left[i] = Filter88.elev20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[15].right[i] = Filter88.elev20_15_r[i];


                    filterSet.e20[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[16].left[i] = Filter88.elev20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[16].right[i] = Filter88.elev20_16_r[i];


                    filterSet.e20[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[17].left[i] = Filter88.elev20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[17].right[i] = Filter88.elev20_17_r[i];


                    filterSet.e20[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[18].left[i] = Filter88.elev20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[18].right[i] = Filter88.elev20_18_r[i];


                    filterSet.e20[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[19].left[i] = Filter88.elev20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[19].right[i] = Filter88.elev20_19_r[i];


                    filterSet.e20[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[20].left[i] = Filter88.elev20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[20].right[i] = Filter88.elev20_20_r[i];


                    filterSet.e20[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[21].left[i] = Filter88.elev20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[21].right[i] = Filter88.elev20_21_r[i];


                    filterSet.e20[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[22].left[i] = Filter88.elev20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[22].right[i] = Filter88.elev20_22_r[i];


                    filterSet.e20[23] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[23].left[i] = Filter88.elev20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[23].right[i] = Filter88.elev20_23_r[i];


                    filterSet.e20[24] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[24].left[i] = Filter88.elev20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[24].right[i] = Filter88.elev20_24_r[i];


                    filterSet.e20[25] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[25].left[i] = Filter88.elev20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[25].right[i] = Filter88.elev20_25_r[i];


                    filterSet.e20[26] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[26].left[i] = Filter88.elev20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[26].right[i] = Filter88.elev20_26_r[i];


                    filterSet.e20[27] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[27].left[i] = Filter88.elev20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[27].right[i] = Filter88.elev20_27_r[i];


                    filterSet.e20[28] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[28].left[i] = Filter88.elev20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[28].right[i] = Filter88.elev20_28_r[i];


                    filterSet.e20[29] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[29].left[i] = Filter88.elev20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[29].right[i] = Filter88.elev20_29_r[i];


                    filterSet.e20[30] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[30].left[i] = Filter88.elev20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[30].right[i] = Filter88.elev20_30_r[i];


                    filterSet.e20[31] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[31].left[i] = Filter88.elev20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[31].right[i] = Filter88.elev20_31_r[i];


                    filterSet.e20[32] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[32].left[i] = Filter88.elev20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[32].right[i] = Filter88.elev20_32_r[i];


                    filterSet.e20[33] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[33].left[i] = Filter88.elev20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[33].right[i] = Filter88.elev20_33_r[i];


                    filterSet.e20[34] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[34].left[i] = Filter88.elev20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[34].right[i] = Filter88.elev20_34_r[i];


                    filterSet.e20[35] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[35].left[i] = Filter88.elev20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[35].right[i] = Filter88.elev20_35_r[i];


                    filterSet.e20[36] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[36].left[i] = Filter88.elev20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e20[36].right[i] = Filter88.elev20_36_r[i];




                    // e30
                    filterSet.e30[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[0].left[i] = Filter88.elev30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[0].right[i] = Filter88.elev30_0_r[i];


                    filterSet.e30[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[1].left[i] = Filter88.elev30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[1].right[i] = Filter88.elev30_1_r[i];


                    filterSet.e30[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[2].left[i] = Filter88.elev30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[2].right[i] = Filter88.elev30_2_r[i];


                    filterSet.e30[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[3].left[i] = Filter88.elev30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[3].right[i] = Filter88.elev30_3_r[i];


                    filterSet.e30[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[4].left[i] = Filter88.elev30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[4].right[i] = Filter88.elev30_4_r[i];


                    filterSet.e30[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[5].left[i] = Filter88.elev30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[5].right[i] = Filter88.elev30_5_r[i];


                    filterSet.e30[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[6].left[i] = Filter88.elev30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[6].right[i] = Filter88.elev30_6_r[i];


                    filterSet.e30[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[7].left[i] = Filter88.elev30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[7].right[i] = Filter88.elev30_7_r[i];


                    filterSet.e30[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[8].left[i] = Filter88.elev30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[8].right[i] = Filter88.elev30_8_r[i];


                    filterSet.e30[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[9].left[i] = Filter88.elev30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[9].right[i] = Filter88.elev30_9_r[i];


                    filterSet.e30[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[10].left[i] = Filter88.elev30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[10].right[i] = Filter88.elev30_10_r[i];


                    filterSet.e30[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[11].left[i] = Filter88.elev30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[11].right[i] = Filter88.elev30_11_r[i];


                    filterSet.e30[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[12].left[i] = Filter88.elev30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[12].right[i] = Filter88.elev30_12_r[i];


                    filterSet.e30[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[13].left[i] = Filter88.elev30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[13].right[i] = Filter88.elev30_13_r[i];


                    filterSet.e30[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[14].left[i] = Filter88.elev30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[14].right[i] = Filter88.elev30_14_r[i];


                    filterSet.e30[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[15].left[i] = Filter88.elev30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[15].right[i] = Filter88.elev30_15_r[i];


                    filterSet.e30[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[16].left[i] = Filter88.elev30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[16].right[i] = Filter88.elev30_16_r[i];


                    filterSet.e30[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[17].left[i] = Filter88.elev30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[17].right[i] = Filter88.elev30_17_r[i];


                    filterSet.e30[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[18].left[i] = Filter88.elev30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[18].right[i] = Filter88.elev30_18_r[i];


                    filterSet.e30[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[19].left[i] = Filter88.elev30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[19].right[i] = Filter88.elev30_19_r[i];


                    filterSet.e30[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[20].left[i] = Filter88.elev30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[20].right[i] = Filter88.elev30_20_r[i];


                    filterSet.e30[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[21].left[i] = Filter88.elev30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[21].right[i] = Filter88.elev30_21_r[i];


                    filterSet.e30[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[22].left[i] = Filter88.elev30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[22].right[i] = Filter88.elev30_22_r[i];


                    filterSet.e30[23] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[23].left[i] = Filter88.elev30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[23].right[i] = Filter88.elev30_23_r[i];


                    filterSet.e30[24] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[24].left[i] = Filter88.elev30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[24].right[i] = Filter88.elev30_24_r[i];


                    filterSet.e30[25] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[25].left[i] = Filter88.elev30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[25].right[i] = Filter88.elev30_25_r[i];


                    filterSet.e30[26] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[26].left[i] = Filter88.elev30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[26].right[i] = Filter88.elev30_26_r[i];


                    filterSet.e30[27] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[27].left[i] = Filter88.elev30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[27].right[i] = Filter88.elev30_27_r[i];


                    filterSet.e30[28] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[28].left[i] = Filter88.elev30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[28].right[i] = Filter88.elev30_28_r[i];


                    filterSet.e30[29] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[29].left[i] = Filter88.elev30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[29].right[i] = Filter88.elev30_29_r[i];


                    filterSet.e30[30] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[30].left[i] = Filter88.elev30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e30[30].right[i] = Filter88.elev30_30_r[i];




                    // e40
                    filterSet.e40[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[0].left[i] = Filter88.elev40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[0].right[i] = Filter88.elev40_0_r[i];


                    filterSet.e40[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[1].left[i] = Filter88.elev40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[1].right[i] = Filter88.elev40_1_r[i];


                    filterSet.e40[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[2].left[i] = Filter88.elev40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[2].right[i] = Filter88.elev40_2_r[i];


                    filterSet.e40[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[3].left[i] = Filter88.elev40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[3].right[i] = Filter88.elev40_3_r[i];


                    filterSet.e40[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[4].left[i] = Filter88.elev40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[4].right[i] = Filter88.elev40_4_r[i];


                    filterSet.e40[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[5].left[i] = Filter88.elev40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[5].right[i] = Filter88.elev40_5_r[i];


                    filterSet.e40[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[6].left[i] = Filter88.elev40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[6].right[i] = Filter88.elev40_6_r[i];


                    filterSet.e40[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[7].left[i] = Filter88.elev40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[7].right[i] = Filter88.elev40_7_r[i];


                    filterSet.e40[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[8].left[i] = Filter88.elev40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[8].right[i] = Filter88.elev40_8_r[i];


                    filterSet.e40[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[9].left[i] = Filter88.elev40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[9].right[i] = Filter88.elev40_9_r[i];


                    filterSet.e40[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[10].left[i] = Filter88.elev40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[10].right[i] = Filter88.elev40_10_r[i];


                    filterSet.e40[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[11].left[i] = Filter88.elev40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[11].right[i] = Filter88.elev40_11_r[i];


                    filterSet.e40[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[12].left[i] = Filter88.elev40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[12].right[i] = Filter88.elev40_12_r[i];


                    filterSet.e40[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[13].left[i] = Filter88.elev40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[13].right[i] = Filter88.elev40_13_r[i];


                    filterSet.e40[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[14].left[i] = Filter88.elev40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[14].right[i] = Filter88.elev40_14_r[i];


                    filterSet.e40[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[15].left[i] = Filter88.elev40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[15].right[i] = Filter88.elev40_15_r[i];


                    filterSet.e40[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[16].left[i] = Filter88.elev40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[16].right[i] = Filter88.elev40_16_r[i];


                    filterSet.e40[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[17].left[i] = Filter88.elev40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[17].right[i] = Filter88.elev40_17_r[i];


                    filterSet.e40[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[18].left[i] = Filter88.elev40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[18].right[i] = Filter88.elev40_18_r[i];


                    filterSet.e40[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[19].left[i] = Filter88.elev40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[19].right[i] = Filter88.elev40_19_r[i];


                    filterSet.e40[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[20].left[i] = Filter88.elev40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[20].right[i] = Filter88.elev40_20_r[i];


                    filterSet.e40[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[21].left[i] = Filter88.elev40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[21].right[i] = Filter88.elev40_21_r[i];


                    filterSet.e40[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[22].left[i] = Filter88.elev40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[22].right[i] = Filter88.elev40_22_r[i];


                    filterSet.e40[23] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[23].left[i] = Filter88.elev40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[23].right[i] = Filter88.elev40_23_r[i];


                    filterSet.e40[24] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[24].left[i] = Filter88.elev40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[24].right[i] = Filter88.elev40_24_r[i];


                    filterSet.e40[25] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[25].left[i] = Filter88.elev40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[25].right[i] = Filter88.elev40_25_r[i];


                    filterSet.e40[26] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[26].left[i] = Filter88.elev40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[26].right[i] = Filter88.elev40_26_r[i];


                    filterSet.e40[27] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[27].left[i] = Filter88.elev40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[27].right[i] = Filter88.elev40_27_r[i];


                    filterSet.e40[28] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[28].left[i] = Filter88.elev40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e40[28].right[i] = Filter88.elev40_28_r[i];




                    // e50
                    filterSet.e50[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[0].left[i] = Filter88.elev50_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[0].right[i] = Filter88.elev50_0_r[i];


                    filterSet.e50[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[1].left[i] = Filter88.elev50_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[1].right[i] = Filter88.elev50_1_r[i];


                    filterSet.e50[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[2].left[i] = Filter88.elev50_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[2].right[i] = Filter88.elev50_2_r[i];


                    filterSet.e50[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[3].left[i] = Filter88.elev50_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[3].right[i] = Filter88.elev50_3_r[i];


                    filterSet.e50[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[4].left[i] = Filter88.elev50_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[4].right[i] = Filter88.elev50_4_r[i];


                    filterSet.e50[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[5].left[i] = Filter88.elev50_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[5].right[i] = Filter88.elev50_5_r[i];


                    filterSet.e50[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[6].left[i] = Filter88.elev50_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[6].right[i] = Filter88.elev50_6_r[i];


                    filterSet.e50[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[7].left[i] = Filter88.elev50_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[7].right[i] = Filter88.elev50_7_r[i];


                    filterSet.e50[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[8].left[i] = Filter88.elev50_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[8].right[i] = Filter88.elev50_8_r[i];


                    filterSet.e50[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[9].left[i] = Filter88.elev50_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[9].right[i] = Filter88.elev50_9_r[i];


                    filterSet.e50[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[10].left[i] = Filter88.elev50_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[10].right[i] = Filter88.elev50_10_r[i];


                    filterSet.e50[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[11].left[i] = Filter88.elev50_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[11].right[i] = Filter88.elev50_11_r[i];


                    filterSet.e50[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[12].left[i] = Filter88.elev50_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[12].right[i] = Filter88.elev50_12_r[i];


                    filterSet.e50[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[13].left[i] = Filter88.elev50_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[13].right[i] = Filter88.elev50_13_r[i];


                    filterSet.e50[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[14].left[i] = Filter88.elev50_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[14].right[i] = Filter88.elev50_14_r[i];


                    filterSet.e50[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[15].left[i] = Filter88.elev50_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[15].right[i] = Filter88.elev50_15_r[i];


                    filterSet.e50[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[16].left[i] = Filter88.elev50_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[16].right[i] = Filter88.elev50_16_r[i];


                    filterSet.e50[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[17].left[i] = Filter88.elev50_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[17].right[i] = Filter88.elev50_17_r[i];


                    filterSet.e50[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[18].left[i] = Filter88.elev50_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[18].right[i] = Filter88.elev50_18_r[i];


                    filterSet.e50[19] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[19].left[i] = Filter88.elev50_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[19].right[i] = Filter88.elev50_19_r[i];


                    filterSet.e50[20] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[20].left[i] = Filter88.elev50_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[20].right[i] = Filter88.elev50_20_r[i];


                    filterSet.e50[21] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[21].left[i] = Filter88.elev50_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[21].right[i] = Filter88.elev50_21_r[i];


                    filterSet.e50[22] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[22].left[i] = Filter88.elev50_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e50[22].right[i] = Filter88.elev50_22_r[i];




                    // e60
                    filterSet.e60[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[0].left[i] = Filter88.elev60_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[0].right[i] = Filter88.elev60_0_r[i];


                    filterSet.e60[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[1].left[i] = Filter88.elev60_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[1].right[i] = Filter88.elev60_1_r[i];


                    filterSet.e60[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[2].left[i] = Filter88.elev60_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[2].right[i] = Filter88.elev60_2_r[i];


                    filterSet.e60[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[3].left[i] = Filter88.elev60_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[3].right[i] = Filter88.elev60_3_r[i];


                    filterSet.e60[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[4].left[i] = Filter88.elev60_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[4].right[i] = Filter88.elev60_4_r[i];


                    filterSet.e60[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[5].left[i] = Filter88.elev60_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[5].right[i] = Filter88.elev60_5_r[i];


                    filterSet.e60[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[6].left[i] = Filter88.elev60_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[6].right[i] = Filter88.elev60_6_r[i];


                    filterSet.e60[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[7].left[i] = Filter88.elev60_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[7].right[i] = Filter88.elev60_7_r[i];


                    filterSet.e60[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[8].left[i] = Filter88.elev60_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[8].right[i] = Filter88.elev60_8_r[i];


                    filterSet.e60[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[9].left[i] = Filter88.elev60_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[9].right[i] = Filter88.elev60_9_r[i];


                    filterSet.e60[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[10].left[i] = Filter88.elev60_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[10].right[i] = Filter88.elev60_10_r[i];


                    filterSet.e60[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[11].left[i] = Filter88.elev60_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[11].right[i] = Filter88.elev60_11_r[i];


                    filterSet.e60[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[12].left[i] = Filter88.elev60_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[12].right[i] = Filter88.elev60_12_r[i];


                    filterSet.e60[13] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[13].left[i] = Filter88.elev60_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[13].right[i] = Filter88.elev60_13_r[i];


                    filterSet.e60[14] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[14].left[i] = Filter88.elev60_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[14].right[i] = Filter88.elev60_14_r[i];


                    filterSet.e60[15] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[15].left[i] = Filter88.elev60_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[15].right[i] = Filter88.elev60_15_r[i];


                    filterSet.e60[16] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[16].left[i] = Filter88.elev60_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[16].right[i] = Filter88.elev60_16_r[i];


                    filterSet.e60[17] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[17].left[i] = Filter88.elev60_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[17].right[i] = Filter88.elev60_17_r[i];


                    filterSet.e60[18] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[18].left[i] = Filter88.elev60_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e60[18].right[i] = Filter88.elev60_18_r[i];




                    // e70
                    filterSet.e70[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[0].left[i] = Filter88.elev70_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[0].right[i] = Filter88.elev70_0_r[i];


                    filterSet.e70[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[1].left[i] = Filter88.elev70_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[1].right[i] = Filter88.elev70_1_r[i];


                    filterSet.e70[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[2].left[i] = Filter88.elev70_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[2].right[i] = Filter88.elev70_2_r[i];


                    filterSet.e70[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[3].left[i] = Filter88.elev70_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[3].right[i] = Filter88.elev70_3_r[i];


                    filterSet.e70[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[4].left[i] = Filter88.elev70_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[4].right[i] = Filter88.elev70_4_r[i];


                    filterSet.e70[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[5].left[i] = Filter88.elev70_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[5].right[i] = Filter88.elev70_5_r[i];


                    filterSet.e70[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[6].left[i] = Filter88.elev70_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[6].right[i] = Filter88.elev70_6_r[i];


                    filterSet.e70[7] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[7].left[i] = Filter88.elev70_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[7].right[i] = Filter88.elev70_7_r[i];


                    filterSet.e70[8] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[8].left[i] = Filter88.elev70_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[8].right[i] = Filter88.elev70_8_r[i];


                    filterSet.e70[9] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[9].left[i] = Filter88.elev70_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[9].right[i] = Filter88.elev70_9_r[i];


                    filterSet.e70[10] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[10].left[i] = Filter88.elev70_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[10].right[i] = Filter88.elev70_10_r[i];


                    filterSet.e70[11] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[11].left[i] = Filter88.elev70_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[11].right[i] = Filter88.elev70_11_r[i];


                    filterSet.e70[12] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[12].left[i] = Filter88.elev70_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e70[12].right[i] = Filter88.elev70_12_r[i];




                    // e80
                    filterSet.e80[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[0].left[i] = Filter88.elev80_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[0].right[i] = Filter88.elev80_0_r[i];


                    filterSet.e80[1] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[1].left[i] = Filter88.elev80_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[1].right[i] = Filter88.elev80_1_r[i];


                    filterSet.e80[2] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[2].left[i] = Filter88.elev80_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[2].right[i] = Filter88.elev80_2_r[i];


                    filterSet.e80[3] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[3].left[i] = Filter88.elev80_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[3].right[i] = Filter88.elev80_3_r[i];


                    filterSet.e80[4] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[4].left[i] = Filter88.elev80_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[4].right[i] = Filter88.elev80_4_r[i];


                    filterSet.e80[5] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[5].left[i] = Filter88.elev80_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[5].right[i] = Filter88.elev80_5_r[i];


                    filterSet.e80[6] = new mit_hrtf_filter_88();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[6].left[i] = Filter88.elev80_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e80[6].right[i] = Filter88.elev80_6_r[i];




                    // e90
                    filterSet.e90[0] = new mit_hrtf_filter_88();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e90[0].left[i] = Filter88.elev90_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_88_TAPS; i++)
                        filterSet.e90[0].right[i] = Filter88.elev90_0_r[i];



                    // Finally, return the fully populated filter set.
                    return filterSet;
                }

            }
        }
        #endregion

        #region 96khz
        private static mit_hrtf_filter_set_96 normal_96
        {
            get
            {
                unsafe
                {
                    var filterSet = mit_hrtf_filter_set_96.Create();


                    // e_10
                    filterSet.e_10[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[0].left[i] = Filter96.elev_10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[0].right[i] = Filter96.elev_10_0_r[i];


                    filterSet.e_10[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[1].left[i] = Filter96.elev_10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[1].right[i] = Filter96.elev_10_1_r[i];


                    filterSet.e_10[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[2].left[i] = Filter96.elev_10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[2].right[i] = Filter96.elev_10_2_r[i];


                    filterSet.e_10[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[3].left[i] = Filter96.elev_10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[3].right[i] = Filter96.elev_10_3_r[i];


                    filterSet.e_10[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[4].left[i] = Filter96.elev_10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[4].right[i] = Filter96.elev_10_4_r[i];


                    filterSet.e_10[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[5].left[i] = Filter96.elev_10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[5].right[i] = Filter96.elev_10_5_r[i];


                    filterSet.e_10[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[6].left[i] = Filter96.elev_10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[6].right[i] = Filter96.elev_10_6_r[i];


                    filterSet.e_10[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[7].left[i] = Filter96.elev_10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[7].right[i] = Filter96.elev_10_7_r[i];


                    filterSet.e_10[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[8].left[i] = Filter96.elev_10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[8].right[i] = Filter96.elev_10_8_r[i];


                    filterSet.e_10[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[9].left[i] = Filter96.elev_10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[9].right[i] = Filter96.elev_10_9_r[i];


                    filterSet.e_10[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[10].left[i] = Filter96.elev_10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[10].right[i] = Filter96.elev_10_10_r[i];


                    filterSet.e_10[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[11].left[i] = Filter96.elev_10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[11].right[i] = Filter96.elev_10_11_r[i];


                    filterSet.e_10[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[12].left[i] = Filter96.elev_10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[12].right[i] = Filter96.elev_10_12_r[i];


                    filterSet.e_10[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[13].left[i] = Filter96.elev_10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[13].right[i] = Filter96.elev_10_13_r[i];


                    filterSet.e_10[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[14].left[i] = Filter96.elev_10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[14].right[i] = Filter96.elev_10_14_r[i];


                    filterSet.e_10[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[15].left[i] = Filter96.elev_10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[15].right[i] = Filter96.elev_10_15_r[i];


                    filterSet.e_10[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[16].left[i] = Filter96.elev_10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[16].right[i] = Filter96.elev_10_16_r[i];


                    filterSet.e_10[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[17].left[i] = Filter96.elev_10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[17].right[i] = Filter96.elev_10_17_r[i];


                    filterSet.e_10[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[18].left[i] = Filter96.elev_10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[18].right[i] = Filter96.elev_10_18_r[i];


                    filterSet.e_10[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[19].left[i] = Filter96.elev_10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[19].right[i] = Filter96.elev_10_19_r[i];


                    filterSet.e_10[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[20].left[i] = Filter96.elev_10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[20].right[i] = Filter96.elev_10_20_r[i];


                    filterSet.e_10[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[21].left[i] = Filter96.elev_10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[21].right[i] = Filter96.elev_10_21_r[i];


                    filterSet.e_10[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[22].left[i] = Filter96.elev_10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[22].right[i] = Filter96.elev_10_22_r[i];


                    filterSet.e_10[23] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[23].left[i] = Filter96.elev_10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[23].right[i] = Filter96.elev_10_23_r[i];


                    filterSet.e_10[24] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[24].left[i] = Filter96.elev_10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[24].right[i] = Filter96.elev_10_24_r[i];


                    filterSet.e_10[25] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[25].left[i] = Filter96.elev_10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[25].right[i] = Filter96.elev_10_25_r[i];


                    filterSet.e_10[26] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[26].left[i] = Filter96.elev_10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[26].right[i] = Filter96.elev_10_26_r[i];


                    filterSet.e_10[27] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[27].left[i] = Filter96.elev_10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[27].right[i] = Filter96.elev_10_27_r[i];


                    filterSet.e_10[28] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[28].left[i] = Filter96.elev_10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[28].right[i] = Filter96.elev_10_28_r[i];


                    filterSet.e_10[29] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[29].left[i] = Filter96.elev_10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[29].right[i] = Filter96.elev_10_29_r[i];


                    filterSet.e_10[30] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[30].left[i] = Filter96.elev_10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[30].right[i] = Filter96.elev_10_30_r[i];


                    filterSet.e_10[31] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[31].left[i] = Filter96.elev_10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[31].right[i] = Filter96.elev_10_31_r[i];


                    filterSet.e_10[32] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[32].left[i] = Filter96.elev_10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[32].right[i] = Filter96.elev_10_32_r[i];


                    filterSet.e_10[33] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[33].left[i] = Filter96.elev_10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[33].right[i] = Filter96.elev_10_33_r[i];


                    filterSet.e_10[34] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[34].left[i] = Filter96.elev_10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[34].right[i] = Filter96.elev_10_34_r[i];


                    filterSet.e_10[35] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[35].left[i] = Filter96.elev_10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[35].right[i] = Filter96.elev_10_35_r[i];


                    filterSet.e_10[36] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[36].left[i] = Filter96.elev_10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_10[36].right[i] = Filter96.elev_10_36_r[i];



                    // e_20
                    filterSet.e_20[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[0].left[i] = Filter96.elev_20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[0].right[i] = Filter96.elev_20_0_r[i];


                    filterSet.e_20[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[1].left[i] = Filter96.elev_20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[1].right[i] = Filter96.elev_20_1_r[i];


                    filterSet.e_20[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[2].left[i] = Filter96.elev_20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[2].right[i] = Filter96.elev_20_2_r[i];


                    filterSet.e_20[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[3].left[i] = Filter96.elev_20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[3].right[i] = Filter96.elev_20_3_r[i];


                    filterSet.e_20[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[4].left[i] = Filter96.elev_20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[4].right[i] = Filter96.elev_20_4_r[i];


                    filterSet.e_20[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[5].left[i] = Filter96.elev_20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[5].right[i] = Filter96.elev_20_5_r[i];


                    filterSet.e_20[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[6].left[i] = Filter96.elev_20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[6].right[i] = Filter96.elev_20_6_r[i];


                    filterSet.e_20[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[7].left[i] = Filter96.elev_20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[7].right[i] = Filter96.elev_20_7_r[i];


                    filterSet.e_20[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[8].left[i] = Filter96.elev_20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[8].right[i] = Filter96.elev_20_8_r[i];


                    filterSet.e_20[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[9].left[i] = Filter96.elev_20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[9].right[i] = Filter96.elev_20_9_r[i];


                    filterSet.e_20[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[10].left[i] = Filter96.elev_20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[10].right[i] = Filter96.elev_20_10_r[i];


                    filterSet.e_20[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[11].left[i] = Filter96.elev_20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[11].right[i] = Filter96.elev_20_11_r[i];


                    filterSet.e_20[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[12].left[i] = Filter96.elev_20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[12].right[i] = Filter96.elev_20_12_r[i];


                    filterSet.e_20[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[13].left[i] = Filter96.elev_20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[13].right[i] = Filter96.elev_20_13_r[i];


                    filterSet.e_20[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[14].left[i] = Filter96.elev_20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[14].right[i] = Filter96.elev_20_14_r[i];


                    filterSet.e_20[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[15].left[i] = Filter96.elev_20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[15].right[i] = Filter96.elev_20_15_r[i];


                    filterSet.e_20[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[16].left[i] = Filter96.elev_20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[16].right[i] = Filter96.elev_20_16_r[i];


                    filterSet.e_20[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[17].left[i] = Filter96.elev_20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[17].right[i] = Filter96.elev_20_17_r[i];


                    filterSet.e_20[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[18].left[i] = Filter96.elev_20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[18].right[i] = Filter96.elev_20_18_r[i];


                    filterSet.e_20[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[19].left[i] = Filter96.elev_20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[19].right[i] = Filter96.elev_20_19_r[i];


                    filterSet.e_20[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[20].left[i] = Filter96.elev_20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[20].right[i] = Filter96.elev_20_20_r[i];


                    filterSet.e_20[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[21].left[i] = Filter96.elev_20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[21].right[i] = Filter96.elev_20_21_r[i];


                    filterSet.e_20[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[22].left[i] = Filter96.elev_20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[22].right[i] = Filter96.elev_20_22_r[i];


                    filterSet.e_20[23] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[23].left[i] = Filter96.elev_20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[23].right[i] = Filter96.elev_20_23_r[i];


                    filterSet.e_20[24] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[24].left[i] = Filter96.elev_20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[24].right[i] = Filter96.elev_20_24_r[i];


                    filterSet.e_20[25] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[25].left[i] = Filter96.elev_20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[25].right[i] = Filter96.elev_20_25_r[i];


                    filterSet.e_20[26] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[26].left[i] = Filter96.elev_20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[26].right[i] = Filter96.elev_20_26_r[i];


                    filterSet.e_20[27] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[27].left[i] = Filter96.elev_20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[27].right[i] = Filter96.elev_20_27_r[i];


                    filterSet.e_20[28] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[28].left[i] = Filter96.elev_20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[28].right[i] = Filter96.elev_20_28_r[i];


                    filterSet.e_20[29] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[29].left[i] = Filter96.elev_20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[29].right[i] = Filter96.elev_20_29_r[i];


                    filterSet.e_20[30] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[30].left[i] = Filter96.elev_20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[30].right[i] = Filter96.elev_20_30_r[i];


                    filterSet.e_20[31] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[31].left[i] = Filter96.elev_20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[31].right[i] = Filter96.elev_20_31_r[i];


                    filterSet.e_20[32] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[32].left[i] = Filter96.elev_20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[32].right[i] = Filter96.elev_20_32_r[i];


                    filterSet.e_20[33] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[33].left[i] = Filter96.elev_20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[33].right[i] = Filter96.elev_20_33_r[i];


                    filterSet.e_20[34] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[34].left[i] = Filter96.elev_20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[34].right[i] = Filter96.elev_20_34_r[i];


                    filterSet.e_20[35] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[35].left[i] = Filter96.elev_20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[35].right[i] = Filter96.elev_20_35_r[i];


                    filterSet.e_20[36] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[36].left[i] = Filter96.elev_20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_20[36].right[i] = Filter96.elev_20_36_r[i];




                    // e_30
                    filterSet.e_30[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[0].left[i] = Filter96.elev_30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[0].right[i] = Filter96.elev_30_0_r[i];


                    filterSet.e_30[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[1].left[i] = Filter96.elev_30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[1].right[i] = Filter96.elev_30_1_r[i];


                    filterSet.e_30[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[2].left[i] = Filter96.elev_30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[2].right[i] = Filter96.elev_30_2_r[i];


                    filterSet.e_30[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[3].left[i] = Filter96.elev_30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[3].right[i] = Filter96.elev_30_3_r[i];


                    filterSet.e_30[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[4].left[i] = Filter96.elev_30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[4].right[i] = Filter96.elev_30_4_r[i];


                    filterSet.e_30[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[5].left[i] = Filter96.elev_30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[5].right[i] = Filter96.elev_30_5_r[i];


                    filterSet.e_30[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[6].left[i] = Filter96.elev_30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[6].right[i] = Filter96.elev_30_6_r[i];


                    filterSet.e_30[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[7].left[i] = Filter96.elev_30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[7].right[i] = Filter96.elev_30_7_r[i];


                    filterSet.e_30[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[8].left[i] = Filter96.elev_30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[8].right[i] = Filter96.elev_30_8_r[i];


                    filterSet.e_30[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[9].left[i] = Filter96.elev_30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[9].right[i] = Filter96.elev_30_9_r[i];


                    filterSet.e_30[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[10].left[i] = Filter96.elev_30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[10].right[i] = Filter96.elev_30_10_r[i];


                    filterSet.e_30[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[11].left[i] = Filter96.elev_30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[11].right[i] = Filter96.elev_30_11_r[i];


                    filterSet.e_30[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[12].left[i] = Filter96.elev_30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[12].right[i] = Filter96.elev_30_12_r[i];


                    filterSet.e_30[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[13].left[i] = Filter96.elev_30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[13].right[i] = Filter96.elev_30_13_r[i];


                    filterSet.e_30[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[14].left[i] = Filter96.elev_30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[14].right[i] = Filter96.elev_30_14_r[i];


                    filterSet.e_30[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[15].left[i] = Filter96.elev_30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[15].right[i] = Filter96.elev_30_15_r[i];


                    filterSet.e_30[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[16].left[i] = Filter96.elev_30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[16].right[i] = Filter96.elev_30_16_r[i];


                    filterSet.e_30[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[17].left[i] = Filter96.elev_30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[17].right[i] = Filter96.elev_30_17_r[i];


                    filterSet.e_30[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[18].left[i] = Filter96.elev_30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[18].right[i] = Filter96.elev_30_18_r[i];


                    filterSet.e_30[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[19].left[i] = Filter96.elev_30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[19].right[i] = Filter96.elev_30_19_r[i];


                    filterSet.e_30[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[20].left[i] = Filter96.elev_30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[20].right[i] = Filter96.elev_30_20_r[i];


                    filterSet.e_30[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[21].left[i] = Filter96.elev_30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[21].right[i] = Filter96.elev_30_21_r[i];


                    filterSet.e_30[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[22].left[i] = Filter96.elev_30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[22].right[i] = Filter96.elev_30_22_r[i];


                    filterSet.e_30[23] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[23].left[i] = Filter96.elev_30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[23].right[i] = Filter96.elev_30_23_r[i];


                    filterSet.e_30[24] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[24].left[i] = Filter96.elev_30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[24].right[i] = Filter96.elev_30_24_r[i];


                    filterSet.e_30[25] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[25].left[i] = Filter96.elev_30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[25].right[i] = Filter96.elev_30_25_r[i];


                    filterSet.e_30[26] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[26].left[i] = Filter96.elev_30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[26].right[i] = Filter96.elev_30_26_r[i];


                    filterSet.e_30[27] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[27].left[i] = Filter96.elev_30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[27].right[i] = Filter96.elev_30_27_r[i];


                    filterSet.e_30[28] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[28].left[i] = Filter96.elev_30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[28].right[i] = Filter96.elev_30_28_r[i];


                    filterSet.e_30[29] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[29].left[i] = Filter96.elev_30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[29].right[i] = Filter96.elev_30_29_r[i];


                    filterSet.e_30[30] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[30].left[i] = Filter96.elev_30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_30[30].right[i] = Filter96.elev_30_30_r[i];



                    // e_40
                    filterSet.e_40[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[0].left[i] = Filter96.elev_40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[0].right[i] = Filter96.elev_40_0_r[i];


                    filterSet.e_40[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[1].left[i] = Filter96.elev_40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[1].right[i] = Filter96.elev_40_1_r[i];


                    filterSet.e_40[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[2].left[i] = Filter96.elev_40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[2].right[i] = Filter96.elev_40_2_r[i];


                    filterSet.e_40[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[3].left[i] = Filter96.elev_40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[3].right[i] = Filter96.elev_40_3_r[i];


                    filterSet.e_40[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[4].left[i] = Filter96.elev_40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[4].right[i] = Filter96.elev_40_4_r[i];


                    filterSet.e_40[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[5].left[i] = Filter96.elev_40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[5].right[i] = Filter96.elev_40_5_r[i];


                    filterSet.e_40[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[6].left[i] = Filter96.elev_40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[6].right[i] = Filter96.elev_40_6_r[i];


                    filterSet.e_40[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[7].left[i] = Filter96.elev_40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[7].right[i] = Filter96.elev_40_7_r[i];


                    filterSet.e_40[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[8].left[i] = Filter96.elev_40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[8].right[i] = Filter96.elev_40_8_r[i];


                    filterSet.e_40[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[9].left[i] = Filter96.elev_40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[9].right[i] = Filter96.elev_40_9_r[i];


                    filterSet.e_40[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[10].left[i] = Filter96.elev_40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[10].right[i] = Filter96.elev_40_10_r[i];


                    filterSet.e_40[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[11].left[i] = Filter96.elev_40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[11].right[i] = Filter96.elev_40_11_r[i];


                    filterSet.e_40[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[12].left[i] = Filter96.elev_40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[12].right[i] = Filter96.elev_40_12_r[i];


                    filterSet.e_40[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[13].left[i] = Filter96.elev_40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[13].right[i] = Filter96.elev_40_13_r[i];


                    filterSet.e_40[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[14].left[i] = Filter96.elev_40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[14].right[i] = Filter96.elev_40_14_r[i];


                    filterSet.e_40[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[15].left[i] = Filter96.elev_40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[15].right[i] = Filter96.elev_40_15_r[i];


                    filterSet.e_40[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[16].left[i] = Filter96.elev_40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[16].right[i] = Filter96.elev_40_16_r[i];


                    filterSet.e_40[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[17].left[i] = Filter96.elev_40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[17].right[i] = Filter96.elev_40_17_r[i];


                    filterSet.e_40[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[18].left[i] = Filter96.elev_40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[18].right[i] = Filter96.elev_40_18_r[i];


                    filterSet.e_40[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[19].left[i] = Filter96.elev_40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[19].right[i] = Filter96.elev_40_19_r[i];


                    filterSet.e_40[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[20].left[i] = Filter96.elev_40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[20].right[i] = Filter96.elev_40_20_r[i];


                    filterSet.e_40[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[21].left[i] = Filter96.elev_40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[21].right[i] = Filter96.elev_40_21_r[i];


                    filterSet.e_40[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[22].left[i] = Filter96.elev_40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[22].right[i] = Filter96.elev_40_22_r[i];


                    filterSet.e_40[23] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[23].left[i] = Filter96.elev_40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[23].right[i] = Filter96.elev_40_23_r[i];


                    filterSet.e_40[24] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[24].left[i] = Filter96.elev_40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[24].right[i] = Filter96.elev_40_24_r[i];


                    filterSet.e_40[25] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[25].left[i] = Filter96.elev_40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[25].right[i] = Filter96.elev_40_25_r[i];


                    filterSet.e_40[26] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[26].left[i] = Filter96.elev_40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[26].right[i] = Filter96.elev_40_26_r[i];


                    filterSet.e_40[27] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[27].left[i] = Filter96.elev_40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[27].right[i] = Filter96.elev_40_27_r[i];


                    filterSet.e_40[28] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[28].left[i] = Filter96.elev_40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e_40[28].right[i] = Filter96.elev_40_28_r[i];




                    // e0
                    filterSet.e00[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[0].left[i] = Filter96.elev0_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[0].right[i] = Filter96.elev0_0_r[i];


                    filterSet.e00[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[1].left[i] = Filter96.elev0_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[1].right[i] = Filter96.elev0_1_r[i];


                    filterSet.e00[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[2].left[i] = Filter96.elev0_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[2].right[i] = Filter96.elev0_2_r[i];


                    filterSet.e00[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[3].left[i] = Filter96.elev0_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[3].right[i] = Filter96.elev0_3_r[i];


                    filterSet.e00[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[4].left[i] = Filter96.elev0_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[4].right[i] = Filter96.elev0_4_r[i];


                    filterSet.e00[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[5].left[i] = Filter96.elev0_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[5].right[i] = Filter96.elev0_5_r[i];


                    filterSet.e00[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[6].left[i] = Filter96.elev0_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[6].right[i] = Filter96.elev0_6_r[i];


                    filterSet.e00[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[7].left[i] = Filter96.elev0_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[7].right[i] = Filter96.elev0_7_r[i];


                    filterSet.e00[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[8].left[i] = Filter96.elev0_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[8].right[i] = Filter96.elev0_8_r[i];


                    filterSet.e00[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[9].left[i] = Filter96.elev0_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[9].right[i] = Filter96.elev0_9_r[i];


                    filterSet.e00[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[10].left[i] = Filter96.elev0_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[10].right[i] = Filter96.elev0_10_r[i];


                    filterSet.e00[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[11].left[i] = Filter96.elev0_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[11].right[i] = Filter96.elev0_11_r[i];


                    filterSet.e00[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[12].left[i] = Filter96.elev0_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[12].right[i] = Filter96.elev0_12_r[i];


                    filterSet.e00[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[13].left[i] = Filter96.elev0_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[13].right[i] = Filter96.elev0_13_r[i];


                    filterSet.e00[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[14].left[i] = Filter96.elev0_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[14].right[i] = Filter96.elev0_14_r[i];


                    filterSet.e00[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[15].left[i] = Filter96.elev0_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[15].right[i] = Filter96.elev0_15_r[i];


                    filterSet.e00[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[16].left[i] = Filter96.elev0_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[16].right[i] = Filter96.elev0_16_r[i];


                    filterSet.e00[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[17].left[i] = Filter96.elev0_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[17].right[i] = Filter96.elev0_17_r[i];


                    filterSet.e00[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[18].left[i] = Filter96.elev0_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[18].right[i] = Filter96.elev0_18_r[i];


                    filterSet.e00[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[19].left[i] = Filter96.elev0_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[19].right[i] = Filter96.elev0_19_r[i];


                    filterSet.e00[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[20].left[i] = Filter96.elev0_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[20].right[i] = Filter96.elev0_20_r[i];


                    filterSet.e00[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[21].left[i] = Filter96.elev0_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[21].right[i] = Filter96.elev0_21_r[i];


                    filterSet.e00[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[22].left[i] = Filter96.elev0_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[22].right[i] = Filter96.elev0_22_r[i];


                    filterSet.e00[23] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[23].left[i] = Filter96.elev0_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[23].right[i] = Filter96.elev0_23_r[i];


                    filterSet.e00[24] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[24].left[i] = Filter96.elev0_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[24].right[i] = Filter96.elev0_24_r[i];


                    filterSet.e00[25] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[25].left[i] = Filter96.elev0_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[25].right[i] = Filter96.elev0_25_r[i];


                    filterSet.e00[26] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[26].left[i] = Filter96.elev0_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[26].right[i] = Filter96.elev0_26_r[i];


                    filterSet.e00[27] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[27].left[i] = Filter96.elev0_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[27].right[i] = Filter96.elev0_27_r[i];


                    filterSet.e00[28] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[28].left[i] = Filter96.elev0_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[28].right[i] = Filter96.elev0_28_r[i];


                    filterSet.e00[29] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[29].left[i] = Filter96.elev0_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[29].right[i] = Filter96.elev0_29_r[i];


                    filterSet.e00[30] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[30].left[i] = Filter96.elev0_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[30].right[i] = Filter96.elev0_30_r[i];


                    filterSet.e00[31] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[31].left[i] = Filter96.elev0_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[31].right[i] = Filter96.elev0_31_r[i];


                    filterSet.e00[32] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[32].left[i] = Filter96.elev0_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[32].right[i] = Filter96.elev0_32_r[i];


                    filterSet.e00[33] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[33].left[i] = Filter96.elev0_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[33].right[i] = Filter96.elev0_33_r[i];


                    filterSet.e00[34] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[34].left[i] = Filter96.elev0_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[34].right[i] = Filter96.elev0_34_r[i];


                    filterSet.e00[35] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[35].left[i] = Filter96.elev0_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[35].right[i] = Filter96.elev0_35_r[i];


                    filterSet.e00[36] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[36].left[i] = Filter96.elev0_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e00[36].right[i] = Filter96.elev0_36_r[i];




                    // e10
                    filterSet.e10[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[0].left[i] = Filter96.elev10_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[0].right[i] = Filter96.elev10_0_r[i];


                    filterSet.e10[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[1].left[i] = Filter96.elev10_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[1].right[i] = Filter96.elev10_1_r[i];


                    filterSet.e10[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[2].left[i] = Filter96.elev10_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[2].right[i] = Filter96.elev10_2_r[i];


                    filterSet.e10[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[3].left[i] = Filter96.elev10_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[3].right[i] = Filter96.elev10_3_r[i];


                    filterSet.e10[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[4].left[i] = Filter96.elev10_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[4].right[i] = Filter96.elev10_4_r[i];


                    filterSet.e10[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[5].left[i] = Filter96.elev10_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[5].right[i] = Filter96.elev10_5_r[i];


                    filterSet.e10[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[6].left[i] = Filter96.elev10_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[6].right[i] = Filter96.elev10_6_r[i];


                    filterSet.e10[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[7].left[i] = Filter96.elev10_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[7].right[i] = Filter96.elev10_7_r[i];


                    filterSet.e10[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[8].left[i] = Filter96.elev10_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[8].right[i] = Filter96.elev10_8_r[i];


                    filterSet.e10[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[9].left[i] = Filter96.elev10_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[9].right[i] = Filter96.elev10_9_r[i];


                    filterSet.e10[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[10].left[i] = Filter96.elev10_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[10].right[i] = Filter96.elev10_10_r[i];


                    filterSet.e10[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[11].left[i] = Filter96.elev10_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[11].right[i] = Filter96.elev10_11_r[i];


                    filterSet.e10[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[12].left[i] = Filter96.elev10_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[12].right[i] = Filter96.elev10_12_r[i];


                    filterSet.e10[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[13].left[i] = Filter96.elev10_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[13].right[i] = Filter96.elev10_13_r[i];


                    filterSet.e10[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[14].left[i] = Filter96.elev10_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[14].right[i] = Filter96.elev10_14_r[i];


                    filterSet.e10[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[15].left[i] = Filter96.elev10_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[15].right[i] = Filter96.elev10_15_r[i];


                    filterSet.e10[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[16].left[i] = Filter96.elev10_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[16].right[i] = Filter96.elev10_16_r[i];


                    filterSet.e10[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[17].left[i] = Filter96.elev10_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[17].right[i] = Filter96.elev10_17_r[i];


                    filterSet.e10[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[18].left[i] = Filter96.elev10_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[18].right[i] = Filter96.elev10_18_r[i];


                    filterSet.e10[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[19].left[i] = Filter96.elev10_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[19].right[i] = Filter96.elev10_19_r[i];


                    filterSet.e10[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[20].left[i] = Filter96.elev10_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[20].right[i] = Filter96.elev10_20_r[i];


                    filterSet.e10[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[21].left[i] = Filter96.elev10_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[21].right[i] = Filter96.elev10_21_r[i];


                    filterSet.e10[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[22].left[i] = Filter96.elev10_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[22].right[i] = Filter96.elev10_22_r[i];


                    filterSet.e10[23] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[23].left[i] = Filter96.elev10_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[23].right[i] = Filter96.elev10_23_r[i];


                    filterSet.e10[24] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[24].left[i] = Filter96.elev10_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[24].right[i] = Filter96.elev10_24_r[i];


                    filterSet.e10[25] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[25].left[i] = Filter96.elev10_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[25].right[i] = Filter96.elev10_25_r[i];


                    filterSet.e10[26] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[26].left[i] = Filter96.elev10_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[26].right[i] = Filter96.elev10_26_r[i];


                    filterSet.e10[27] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[27].left[i] = Filter96.elev10_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[27].right[i] = Filter96.elev10_27_r[i];


                    filterSet.e10[28] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[28].left[i] = Filter96.elev10_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[28].right[i] = Filter96.elev10_28_r[i];


                    filterSet.e10[29] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[29].left[i] = Filter96.elev10_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[29].right[i] = Filter96.elev10_29_r[i];


                    filterSet.e10[30] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[30].left[i] = Filter96.elev10_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[30].right[i] = Filter96.elev10_30_r[i];


                    filterSet.e10[31] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[31].left[i] = Filter96.elev10_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[31].right[i] = Filter96.elev10_31_r[i];


                    filterSet.e10[32] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[32].left[i] = Filter96.elev10_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[32].right[i] = Filter96.elev10_32_r[i];


                    filterSet.e10[33] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[33].left[i] = Filter96.elev10_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[33].right[i] = Filter96.elev10_33_r[i];


                    filterSet.e10[34] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[34].left[i] = Filter96.elev10_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[34].right[i] = Filter96.elev10_34_r[i];


                    filterSet.e10[35] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[35].left[i] = Filter96.elev10_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[35].right[i] = Filter96.elev10_35_r[i];


                    filterSet.e10[36] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[36].left[i] = Filter96.elev10_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e10[36].right[i] = Filter96.elev10_36_r[i];




                    // e20
                    filterSet.e20[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[0].left[i] = Filter96.elev20_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[0].right[i] = Filter96.elev20_0_r[i];


                    filterSet.e20[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[1].left[i] = Filter96.elev20_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[1].right[i] = Filter96.elev20_1_r[i];


                    filterSet.e20[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[2].left[i] = Filter96.elev20_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[2].right[i] = Filter96.elev20_2_r[i];


                    filterSet.e20[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[3].left[i] = Filter96.elev20_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[3].right[i] = Filter96.elev20_3_r[i];


                    filterSet.e20[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[4].left[i] = Filter96.elev20_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[4].right[i] = Filter96.elev20_4_r[i];


                    filterSet.e20[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[5].left[i] = Filter96.elev20_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[5].right[i] = Filter96.elev20_5_r[i];


                    filterSet.e20[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[6].left[i] = Filter96.elev20_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[6].right[i] = Filter96.elev20_6_r[i];


                    filterSet.e20[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[7].left[i] = Filter96.elev20_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[7].right[i] = Filter96.elev20_7_r[i];


                    filterSet.e20[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[8].left[i] = Filter96.elev20_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[8].right[i] = Filter96.elev20_8_r[i];


                    filterSet.e20[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[9].left[i] = Filter96.elev20_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[9].right[i] = Filter96.elev20_9_r[i];


                    filterSet.e20[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[10].left[i] = Filter96.elev20_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[10].right[i] = Filter96.elev20_10_r[i];


                    filterSet.e20[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[11].left[i] = Filter96.elev20_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[11].right[i] = Filter96.elev20_11_r[i];


                    filterSet.e20[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[12].left[i] = Filter96.elev20_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[12].right[i] = Filter96.elev20_12_r[i];


                    filterSet.e20[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[13].left[i] = Filter96.elev20_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[13].right[i] = Filter96.elev20_13_r[i];


                    filterSet.e20[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[14].left[i] = Filter96.elev20_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[14].right[i] = Filter96.elev20_14_r[i];


                    filterSet.e20[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[15].left[i] = Filter96.elev20_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[15].right[i] = Filter96.elev20_15_r[i];


                    filterSet.e20[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[16].left[i] = Filter96.elev20_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[16].right[i] = Filter96.elev20_16_r[i];


                    filterSet.e20[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[17].left[i] = Filter96.elev20_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[17].right[i] = Filter96.elev20_17_r[i];


                    filterSet.e20[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[18].left[i] = Filter96.elev20_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[18].right[i] = Filter96.elev20_18_r[i];


                    filterSet.e20[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[19].left[i] = Filter96.elev20_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[19].right[i] = Filter96.elev20_19_r[i];


                    filterSet.e20[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[20].left[i] = Filter96.elev20_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[20].right[i] = Filter96.elev20_20_r[i];


                    filterSet.e20[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[21].left[i] = Filter96.elev20_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[21].right[i] = Filter96.elev20_21_r[i];


                    filterSet.e20[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[22].left[i] = Filter96.elev20_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[22].right[i] = Filter96.elev20_22_r[i];


                    filterSet.e20[23] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[23].left[i] = Filter96.elev20_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[23].right[i] = Filter96.elev20_23_r[i];


                    filterSet.e20[24] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[24].left[i] = Filter96.elev20_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[24].right[i] = Filter96.elev20_24_r[i];


                    filterSet.e20[25] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[25].left[i] = Filter96.elev20_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[25].right[i] = Filter96.elev20_25_r[i];


                    filterSet.e20[26] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[26].left[i] = Filter96.elev20_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[26].right[i] = Filter96.elev20_26_r[i];


                    filterSet.e20[27] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[27].left[i] = Filter96.elev20_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[27].right[i] = Filter96.elev20_27_r[i];


                    filterSet.e20[28] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[28].left[i] = Filter96.elev20_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[28].right[i] = Filter96.elev20_28_r[i];


                    filterSet.e20[29] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[29].left[i] = Filter96.elev20_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[29].right[i] = Filter96.elev20_29_r[i];


                    filterSet.e20[30] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[30].left[i] = Filter96.elev20_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[30].right[i] = Filter96.elev20_30_r[i];


                    filterSet.e20[31] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[31].left[i] = Filter96.elev20_31_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[31].right[i] = Filter96.elev20_31_r[i];


                    filterSet.e20[32] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[32].left[i] = Filter96.elev20_32_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[32].right[i] = Filter96.elev20_32_r[i];


                    filterSet.e20[33] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[33].left[i] = Filter96.elev20_33_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[33].right[i] = Filter96.elev20_33_r[i];


                    filterSet.e20[34] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[34].left[i] = Filter96.elev20_34_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[34].right[i] = Filter96.elev20_34_r[i];


                    filterSet.e20[35] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[35].left[i] = Filter96.elev20_35_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[35].right[i] = Filter96.elev20_35_r[i];


                    filterSet.e20[36] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[36].left[i] = Filter96.elev20_36_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e20[36].right[i] = Filter96.elev20_36_r[i];




                    // e30
                    filterSet.e30[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[0].left[i] = Filter96.elev30_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[0].right[i] = Filter96.elev30_0_r[i];


                    filterSet.e30[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[1].left[i] = Filter96.elev30_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[1].right[i] = Filter96.elev30_1_r[i];


                    filterSet.e30[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[2].left[i] = Filter96.elev30_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[2].right[i] = Filter96.elev30_2_r[i];


                    filterSet.e30[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[3].left[i] = Filter96.elev30_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[3].right[i] = Filter96.elev30_3_r[i];


                    filterSet.e30[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[4].left[i] = Filter96.elev30_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[4].right[i] = Filter96.elev30_4_r[i];


                    filterSet.e30[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[5].left[i] = Filter96.elev30_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[5].right[i] = Filter96.elev30_5_r[i];


                    filterSet.e30[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[6].left[i] = Filter96.elev30_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[6].right[i] = Filter96.elev30_6_r[i];


                    filterSet.e30[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[7].left[i] = Filter96.elev30_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[7].right[i] = Filter96.elev30_7_r[i];


                    filterSet.e30[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[8].left[i] = Filter96.elev30_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[8].right[i] = Filter96.elev30_8_r[i];


                    filterSet.e30[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[9].left[i] = Filter96.elev30_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[9].right[i] = Filter96.elev30_9_r[i];


                    filterSet.e30[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[10].left[i] = Filter96.elev30_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[10].right[i] = Filter96.elev30_10_r[i];


                    filterSet.e30[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[11].left[i] = Filter96.elev30_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[11].right[i] = Filter96.elev30_11_r[i];


                    filterSet.e30[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[12].left[i] = Filter96.elev30_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[12].right[i] = Filter96.elev30_12_r[i];


                    filterSet.e30[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[13].left[i] = Filter96.elev30_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[13].right[i] = Filter96.elev30_13_r[i];


                    filterSet.e30[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[14].left[i] = Filter96.elev30_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[14].right[i] = Filter96.elev30_14_r[i];


                    filterSet.e30[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[15].left[i] = Filter96.elev30_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[15].right[i] = Filter96.elev30_15_r[i];


                    filterSet.e30[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[16].left[i] = Filter96.elev30_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[16].right[i] = Filter96.elev30_16_r[i];


                    filterSet.e30[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[17].left[i] = Filter96.elev30_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[17].right[i] = Filter96.elev30_17_r[i];


                    filterSet.e30[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[18].left[i] = Filter96.elev30_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[18].right[i] = Filter96.elev30_18_r[i];


                    filterSet.e30[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[19].left[i] = Filter96.elev30_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[19].right[i] = Filter96.elev30_19_r[i];


                    filterSet.e30[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[20].left[i] = Filter96.elev30_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[20].right[i] = Filter96.elev30_20_r[i];


                    filterSet.e30[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[21].left[i] = Filter96.elev30_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[21].right[i] = Filter96.elev30_21_r[i];


                    filterSet.e30[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[22].left[i] = Filter96.elev30_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[22].right[i] = Filter96.elev30_22_r[i];


                    filterSet.e30[23] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[23].left[i] = Filter96.elev30_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[23].right[i] = Filter96.elev30_23_r[i];


                    filterSet.e30[24] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[24].left[i] = Filter96.elev30_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[24].right[i] = Filter96.elev30_24_r[i];


                    filterSet.e30[25] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[25].left[i] = Filter96.elev30_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[25].right[i] = Filter96.elev30_25_r[i];


                    filterSet.e30[26] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[26].left[i] = Filter96.elev30_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[26].right[i] = Filter96.elev30_26_r[i];


                    filterSet.e30[27] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[27].left[i] = Filter96.elev30_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[27].right[i] = Filter96.elev30_27_r[i];


                    filterSet.e30[28] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[28].left[i] = Filter96.elev30_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[28].right[i] = Filter96.elev30_28_r[i];


                    filterSet.e30[29] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[29].left[i] = Filter96.elev30_29_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[29].right[i] = Filter96.elev30_29_r[i];


                    filterSet.e30[30] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[30].left[i] = Filter96.elev30_30_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e30[30].right[i] = Filter96.elev30_30_r[i];




                    // e40
                    filterSet.e40[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[0].left[i] = Filter96.elev40_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[0].right[i] = Filter96.elev40_0_r[i];


                    filterSet.e40[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[1].left[i] = Filter96.elev40_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[1].right[i] = Filter96.elev40_1_r[i];


                    filterSet.e40[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[2].left[i] = Filter96.elev40_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[2].right[i] = Filter96.elev40_2_r[i];


                    filterSet.e40[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[3].left[i] = Filter96.elev40_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[3].right[i] = Filter96.elev40_3_r[i];


                    filterSet.e40[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[4].left[i] = Filter96.elev40_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[4].right[i] = Filter96.elev40_4_r[i];


                    filterSet.e40[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[5].left[i] = Filter96.elev40_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[5].right[i] = Filter96.elev40_5_r[i];


                    filterSet.e40[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[6].left[i] = Filter96.elev40_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[6].right[i] = Filter96.elev40_6_r[i];


                    filterSet.e40[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[7].left[i] = Filter96.elev40_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[7].right[i] = Filter96.elev40_7_r[i];


                    filterSet.e40[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[8].left[i] = Filter96.elev40_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[8].right[i] = Filter96.elev40_8_r[i];


                    filterSet.e40[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[9].left[i] = Filter96.elev40_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[9].right[i] = Filter96.elev40_9_r[i];


                    filterSet.e40[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[10].left[i] = Filter96.elev40_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[10].right[i] = Filter96.elev40_10_r[i];


                    filterSet.e40[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[11].left[i] = Filter96.elev40_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[11].right[i] = Filter96.elev40_11_r[i];


                    filterSet.e40[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[12].left[i] = Filter96.elev40_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[12].right[i] = Filter96.elev40_12_r[i];


                    filterSet.e40[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[13].left[i] = Filter96.elev40_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[13].right[i] = Filter96.elev40_13_r[i];


                    filterSet.e40[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[14].left[i] = Filter96.elev40_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[14].right[i] = Filter96.elev40_14_r[i];


                    filterSet.e40[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[15].left[i] = Filter96.elev40_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[15].right[i] = Filter96.elev40_15_r[i];


                    filterSet.e40[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[16].left[i] = Filter96.elev40_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[16].right[i] = Filter96.elev40_16_r[i];


                    filterSet.e40[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[17].left[i] = Filter96.elev40_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[17].right[i] = Filter96.elev40_17_r[i];


                    filterSet.e40[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[18].left[i] = Filter96.elev40_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[18].right[i] = Filter96.elev40_18_r[i];


                    filterSet.e40[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[19].left[i] = Filter96.elev40_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[19].right[i] = Filter96.elev40_19_r[i];


                    filterSet.e40[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[20].left[i] = Filter96.elev40_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[20].right[i] = Filter96.elev40_20_r[i];


                    filterSet.e40[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[21].left[i] = Filter96.elev40_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[21].right[i] = Filter96.elev40_21_r[i];


                    filterSet.e40[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[22].left[i] = Filter96.elev40_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[22].right[i] = Filter96.elev40_22_r[i];


                    filterSet.e40[23] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[23].left[i] = Filter96.elev40_23_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[23].right[i] = Filter96.elev40_23_r[i];


                    filterSet.e40[24] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[24].left[i] = Filter96.elev40_24_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[24].right[i] = Filter96.elev40_24_r[i];


                    filterSet.e40[25] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[25].left[i] = Filter96.elev40_25_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[25].right[i] = Filter96.elev40_25_r[i];


                    filterSet.e40[26] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[26].left[i] = Filter96.elev40_26_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[26].right[i] = Filter96.elev40_26_r[i];


                    filterSet.e40[27] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[27].left[i] = Filter96.elev40_27_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[27].right[i] = Filter96.elev40_27_r[i];


                    filterSet.e40[28] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[28].left[i] = Filter96.elev40_28_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e40[28].right[i] = Filter96.elev40_28_r[i];




                    // e50
                    filterSet.e50[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[0].left[i] = Filter96.elev50_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[0].right[i] = Filter96.elev50_0_r[i];


                    filterSet.e50[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[1].left[i] = Filter96.elev50_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[1].right[i] = Filter96.elev50_1_r[i];


                    filterSet.e50[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[2].left[i] = Filter96.elev50_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[2].right[i] = Filter96.elev50_2_r[i];


                    filterSet.e50[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[3].left[i] = Filter96.elev50_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[3].right[i] = Filter96.elev50_3_r[i];


                    filterSet.e50[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[4].left[i] = Filter96.elev50_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[4].right[i] = Filter96.elev50_4_r[i];


                    filterSet.e50[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[5].left[i] = Filter96.elev50_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[5].right[i] = Filter96.elev50_5_r[i];


                    filterSet.e50[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[6].left[i] = Filter96.elev50_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[6].right[i] = Filter96.elev50_6_r[i];


                    filterSet.e50[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[7].left[i] = Filter96.elev50_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[7].right[i] = Filter96.elev50_7_r[i];


                    filterSet.e50[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[8].left[i] = Filter96.elev50_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[8].right[i] = Filter96.elev50_8_r[i];


                    filterSet.e50[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[9].left[i] = Filter96.elev50_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[9].right[i] = Filter96.elev50_9_r[i];


                    filterSet.e50[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[10].left[i] = Filter96.elev50_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[10].right[i] = Filter96.elev50_10_r[i];


                    filterSet.e50[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[11].left[i] = Filter96.elev50_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[11].right[i] = Filter96.elev50_11_r[i];


                    filterSet.e50[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[12].left[i] = Filter96.elev50_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[12].right[i] = Filter96.elev50_12_r[i];


                    filterSet.e50[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[13].left[i] = Filter96.elev50_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[13].right[i] = Filter96.elev50_13_r[i];


                    filterSet.e50[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[14].left[i] = Filter96.elev50_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[14].right[i] = Filter96.elev50_14_r[i];


                    filterSet.e50[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[15].left[i] = Filter96.elev50_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[15].right[i] = Filter96.elev50_15_r[i];


                    filterSet.e50[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[16].left[i] = Filter96.elev50_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[16].right[i] = Filter96.elev50_16_r[i];


                    filterSet.e50[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[17].left[i] = Filter96.elev50_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[17].right[i] = Filter96.elev50_17_r[i];


                    filterSet.e50[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[18].left[i] = Filter96.elev50_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[18].right[i] = Filter96.elev50_18_r[i];


                    filterSet.e50[19] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[19].left[i] = Filter96.elev50_19_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[19].right[i] = Filter96.elev50_19_r[i];


                    filterSet.e50[20] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[20].left[i] = Filter96.elev50_20_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[20].right[i] = Filter96.elev50_20_r[i];


                    filterSet.e50[21] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[21].left[i] = Filter96.elev50_21_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[21].right[i] = Filter96.elev50_21_r[i];


                    filterSet.e50[22] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[22].left[i] = Filter96.elev50_22_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e50[22].right[i] = Filter96.elev50_22_r[i];




                    // e60
                    filterSet.e60[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[0].left[i] = Filter96.elev60_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[0].right[i] = Filter96.elev60_0_r[i];


                    filterSet.e60[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[1].left[i] = Filter96.elev60_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[1].right[i] = Filter96.elev60_1_r[i];


                    filterSet.e60[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[2].left[i] = Filter96.elev60_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[2].right[i] = Filter96.elev60_2_r[i];


                    filterSet.e60[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[3].left[i] = Filter96.elev60_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[3].right[i] = Filter96.elev60_3_r[i];


                    filterSet.e60[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[4].left[i] = Filter96.elev60_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[4].right[i] = Filter96.elev60_4_r[i];


                    filterSet.e60[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[5].left[i] = Filter96.elev60_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[5].right[i] = Filter96.elev60_5_r[i];


                    filterSet.e60[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[6].left[i] = Filter96.elev60_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[6].right[i] = Filter96.elev60_6_r[i];


                    filterSet.e60[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[7].left[i] = Filter96.elev60_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[7].right[i] = Filter96.elev60_7_r[i];


                    filterSet.e60[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[8].left[i] = Filter96.elev60_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[8].right[i] = Filter96.elev60_8_r[i];


                    filterSet.e60[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[9].left[i] = Filter96.elev60_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[9].right[i] = Filter96.elev60_9_r[i];


                    filterSet.e60[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[10].left[i] = Filter96.elev60_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[10].right[i] = Filter96.elev60_10_r[i];


                    filterSet.e60[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[11].left[i] = Filter96.elev60_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[11].right[i] = Filter96.elev60_11_r[i];


                    filterSet.e60[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[12].left[i] = Filter96.elev60_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[12].right[i] = Filter96.elev60_12_r[i];


                    filterSet.e60[13] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[13].left[i] = Filter96.elev60_13_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[13].right[i] = Filter96.elev60_13_r[i];


                    filterSet.e60[14] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[14].left[i] = Filter96.elev60_14_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[14].right[i] = Filter96.elev60_14_r[i];


                    filterSet.e60[15] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[15].left[i] = Filter96.elev60_15_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[15].right[i] = Filter96.elev60_15_r[i];


                    filterSet.e60[16] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[16].left[i] = Filter96.elev60_16_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[16].right[i] = Filter96.elev60_16_r[i];


                    filterSet.e60[17] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[17].left[i] = Filter96.elev60_17_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[17].right[i] = Filter96.elev60_17_r[i];


                    filterSet.e60[18] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[18].left[i] = Filter96.elev60_18_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e60[18].right[i] = Filter96.elev60_18_r[i];




                    // e70
                    filterSet.e70[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[0].left[i] = Filter96.elev70_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[0].right[i] = Filter96.elev70_0_r[i];


                    filterSet.e70[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[1].left[i] = Filter96.elev70_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[1].right[i] = Filter96.elev70_1_r[i];


                    filterSet.e70[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[2].left[i] = Filter96.elev70_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[2].right[i] = Filter96.elev70_2_r[i];


                    filterSet.e70[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[3].left[i] = Filter96.elev70_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[3].right[i] = Filter96.elev70_3_r[i];


                    filterSet.e70[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[4].left[i] = Filter96.elev70_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[4].right[i] = Filter96.elev70_4_r[i];


                    filterSet.e70[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[5].left[i] = Filter96.elev70_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[5].right[i] = Filter96.elev70_5_r[i];


                    filterSet.e70[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[6].left[i] = Filter96.elev70_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[6].right[i] = Filter96.elev70_6_r[i];


                    filterSet.e70[7] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[7].left[i] = Filter96.elev70_7_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[7].right[i] = Filter96.elev70_7_r[i];


                    filterSet.e70[8] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[8].left[i] = Filter96.elev70_8_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[8].right[i] = Filter96.elev70_8_r[i];


                    filterSet.e70[9] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[9].left[i] = Filter96.elev70_9_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[9].right[i] = Filter96.elev70_9_r[i];


                    filterSet.e70[10] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[10].left[i] = Filter96.elev70_10_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[10].right[i] = Filter96.elev70_10_r[i];


                    filterSet.e70[11] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[11].left[i] = Filter96.elev70_11_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[11].right[i] = Filter96.elev70_11_r[i];


                    filterSet.e70[12] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[12].left[i] = Filter96.elev70_12_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e70[12].right[i] = Filter96.elev70_12_r[i];




                    // e80
                    filterSet.e80[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[0].left[i] = Filter96.elev80_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[0].right[i] = Filter96.elev80_0_r[i];


                    filterSet.e80[1] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[1].left[i] = Filter96.elev80_1_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[1].right[i] = Filter96.elev80_1_r[i];


                    filterSet.e80[2] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[2].left[i] = Filter96.elev80_2_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[2].right[i] = Filter96.elev80_2_r[i];


                    filterSet.e80[3] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[3].left[i] = Filter96.elev80_3_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[3].right[i] = Filter96.elev80_3_r[i];


                    filterSet.e80[4] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[4].left[i] = Filter96.elev80_4_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[4].right[i] = Filter96.elev80_4_r[i];


                    filterSet.e80[5] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[5].left[i] = Filter96.elev80_5_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[5].right[i] = Filter96.elev80_5_r[i];


                    filterSet.e80[6] = new mit_hrtf_filter_96();

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[6].left[i] = Filter96.elev80_6_l[i];

                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e80[6].right[i] = Filter96.elev80_6_r[i];




                    // e90
                    filterSet.e90[0] = new mit_hrtf_filter_96();
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e90[0].left[i] = Filter96.elev90_0_l[i];
                    for (int i = 0; i < HRTFFilter.MIT_HRTF_96_TAPS; i++)
                        filterSet.e90[0].right[i] = Filter96.elev90_0_r[i];



                    // Finally, return the fully populated filter set.
                    return filterSet;
                }

            }
        }
        #endregion
    }
}
