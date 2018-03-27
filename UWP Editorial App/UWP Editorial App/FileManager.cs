using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Editorial_App
{
    class FileManager
    {
        public bool checkFileStructure(string Path)
        {
            try
            {
                bool exists = System.IO.Directory.Exists(Path + @"\SystemData\ScreenSaverVideo");


                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Path + @"\SystemData\ScreenSaverVideo");
                    System.IO.Directory.CreateDirectory(Path + @"\SystemData\CatalogueItems\TemplateItem\ThumbNail");
                    System.IO.Directory.CreateDirectory(Path + @"\SystemData\CatalogueItems\TemplateItem\Data");
                    System.IO.Directory.CreateDirectory(Path + @"\SystemData\CatalogueItems\TemplateItem\BackGround");
                    Process.Start(Path + @"\SystemData");
                }

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

    }
}
