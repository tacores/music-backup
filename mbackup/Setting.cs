using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mbackup
{
    public interface Setting
    {
        List<string> getSrcFolders();

        void addSrcFolder(string folder);
    }
}
