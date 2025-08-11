using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace Presentation_Layer.Global_Classes
{
    public class clsUtility
    {
        public static string GetDestinationImagesFolderDynamically()
        {
            // Geting path of running Exe
            string exePath = Application.StartupPath;
            // Go up to project root (usually two levels : bin/Debug)
            string PresentationLayerDir = Directory.GetParent(exePath).Parent.FullName; // = destination till Presentation Layer folder
            // Get the parent directory and then build the Images path
            string MainProjectFolderDirectory = Directory.GetParent(PresentationLayerDir).FullName; // goes up to Driving License folder
            string imgsDir = Path.Combine(MainProjectFolderDirectory, "Images");
            return imgsDir;
        }
    }
}