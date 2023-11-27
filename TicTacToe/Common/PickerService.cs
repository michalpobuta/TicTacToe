using Microsoft.Maui.Graphics.Skia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Common
{
    public class PickerService
    {
        public async Task<string> PickImage() 
        {
            try
            {
                var filePath = "";
                var result = await FilePicker.Default.PickAsync(PickOptions.Images);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var stream = await result.OpenReadAsync())
                        {
                            filePath =  SaveImage(stream, result.FileName);
                        }
                    }
                }

                return filePath;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }
            return null;


        }
        private string SaveImage(Stream stream, string fileName)
        {
            var image = (new SkiaImageLoadingService()).FromStream(stream);
            var path = Path.Combine(FileSystem.Current.AppDataDirectory, "Images");
            SkiaBitmapExportContext skiaBitmapExportContext = new((int)image.Width, (int)image.Height, 1);
            skiaBitmapExportContext.Canvas.DrawImage(image, 0, 0, (int)image.Width, (int)image.Height);
            EnsureDirectoryExist(path);
            skiaBitmapExportContext.WriteToFile(Path.Combine(path, fileName));
            return Path.Combine("Images", fileName);
        }
        private void EnsureDirectoryExist(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

    }
}
