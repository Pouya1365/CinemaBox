using CinemaBox.Model.MediaInfo.MediaInfo;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace CinemaBox.Presentation.MediaInfo;

public static class MediaServices
{
    [DllImport("MediaInfo.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr MediaInfo_New();

    [DllImport("MediaInfo.dll", CharSet = CharSet.Unicode)]
    private static extern void MediaInfo_Delete(IntPtr handle);

    [DllImport("MediaInfo.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr MediaInfo_Open(IntPtr handle, string fileName);

    [DllImport("MediaInfo.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr MediaInfo_Inform(IntPtr handle, IntPtr reserved);

    [DllImport("MediaInfo.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr MediaInfo_Option(IntPtr handle, string option, string value);

    public static MediaInfoResult? GetInfoMedia(string path)
    {
        IntPtr handle = MediaInfo_New();
        try
        {
            // بررسی وجود فایل
            if (!File.Exists(path))
                return null;
            // باز کردن فایل و بررسی موفقیت
            if (MediaInfo_Open(handle, path) == IntPtr.Zero)
                return null;
            // تنظیم خروجی به JSON
            MediaInfo_Option(handle, "Output", "JSON");
            // دریافت اطلاعات
            IntPtr infoPtr = MediaInfo_Inform(handle, IntPtr.Zero);
            string json = Marshal.PtrToStringUni(infoPtr);
            MediaInfoResult? result = JsonConvert.DeserializeObject<MediaInfoResult>(json);
            return result;
        }
        finally
        {
            MediaInfo_Delete(handle);
        }
    }
}
