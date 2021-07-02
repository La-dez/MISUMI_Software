using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stereo_Vision
{
    public unsafe class ParallelDataUnit
    {
        public byte* l_data;
        public double* l_nf_pRes;
        public unsafe void Lambda(int j_par)
        {
            byte* _curpos_loc = l_data + j_par; ;
            double* _color_loc = l_nf_pRes + MainWindow.WH_global * (2 - j_par);

            for (int i = 0; i != MainWindow.WH_global; ++i)
            {
                *(_curpos_loc) = (byte)(*(_curpos_loc) * (*_color_loc)); ++_color_loc; ++_curpos_loc; ++_curpos_loc; ++_curpos_loc;
            }
        }
        
    }
}
