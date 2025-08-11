using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Shared_Layer;
using System.Runtime.Remoting.Contexts;
namespace Presentation_Layer.Global_Classes
{
    public class clsUtility
    {
        private static string GenerateGUID()
        {
            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();
            // convert the GUID to a string
            return newGuid.ToString();
        }
        private static string ReplaceFileNameWithGUID(string SourceFile) //source file is the full path of the original place of the image
        {
            //this function just takes the original extension of the image form the original image path
            FileInfo fi = new FileInfo(SourceFile);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }
        private static bool CreateFolderIfDoesNotExists(string FolderPath, string SecuredImagesFolder = @"C:\Residences Management\Images\")
        {
            //Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    //create the folder
                    Directory.CreateDirectory(FolderPath);
                    if (!Directory.Exists(SecuredImagesFolder))
                        Directory.CreateDirectory(SecuredImagesFolder);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("خطأ في إنشاء مجلد الصور بالمسار:" + FolderPath, "خطأ في إنشاء المجلد",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsEventLogger.SaveLog("Application", $"Error creating folder: {ex.Message}",
                        System.Diagnostics.EventLogEntryType.Error);
                    return false;
                }
            }
            return true;
        }
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
        public static bool CopyImageToProjectImagesFolder(ref string SourceFile) //source file is the full path of the original place of the image
        {
            //this function will copy the image from it's original place, to the project's images folder, after renaming it with a GUID number
            //with the same extension, then the souce file name will be updated with the new name
            string SecuredImagesFolder = @"C:\Residences Management\Images\";
            string DestinationsFolder = GetDestinationImagesFolderDynamically();
            if (!CreateFolderIfDoesNotExists(DestinationsFolder, SecuredImagesFolder))
                return false;
            string GUIDdotExtension = ReplaceFileNameWithGUID(SourceFile);
            string DestinationFile = Path.Combine(DestinationsFolder, GUIDdotExtension);
            string SecuredDestinationFile = Path.Combine(SecuredImagesFolder, GUIDdotExtension);
            try
            {
                File.Copy(SourceFile, DestinationFile, true);
                File.Copy(SourceFile, SecuredDestinationFile, true);
            }
            catch(IOException iox)
            {
                clsEventLogger.SaveLog("Application", $"Error copying image to project images folder: {iox.Message}",
                    System.Diagnostics.EventLogEntryType.Error);
                return false;
            }
            SourceFile = DestinationFile;
            return true;
        }
    }
}