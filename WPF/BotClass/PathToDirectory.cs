using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.BotClass
{
    public static class PathToDirectory
    {
        public static string FilesDir = @"..\..\..\Files\";
        public static string DocumentDir = FilesDir + @"Document\";
        public static string PhotoDir = FilesDir + @"Photo\";
        public static string VideoDir = FilesDir + @"Video\";
        public static string AudioDir = FilesDir + @"Audio\";
        public static string CertificateDir = FilesDir + @"Certificate\";
        public static string AnimationDir = FilesDir + @"Animation\";
        public static string ThumbnailDir = FilesDir + @"Thumbnail\";
    }
}
