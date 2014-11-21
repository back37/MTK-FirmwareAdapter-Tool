using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MTFAT
{
    public class IniFile
    {
        private string fileName;

        public IniFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException(fileName + " does not exist", fileName);
            this.fileName = fileName;
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section,
          string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileSection(string section, IntPtr lpReturnedString,
          int nSize, string lpFileName);

        public string ReadString(string section, string key)
        {
            const int bufferSize = 255;
            StringBuilder temp = new StringBuilder(bufferSize);
            GetPrivateProfileString(section, key, "", temp, bufferSize, fileName);
            return temp.ToString();
        }

        public string[] ReadSection(string section)
        {
            const int bufferSize = 2048;

            StringBuilder returnedString = new StringBuilder();

            IntPtr pReturnedString = Marshal.AllocCoTaskMem(bufferSize);
            try
            {
                int bytesReturned = GetPrivateProfileSection(section, pReturnedString, bufferSize, fileName);

                for (int i = 0; i < bytesReturned - 1; i++)
                    returnedString.Append((char)Marshal.ReadByte(new IntPtr((uint)pReturnedString + (uint)i)));
            }
            finally
            {
                Marshal.FreeCoTaskMem(pReturnedString);
            }

            string sectionData = returnedString.ToString();
            return sectionData.Split('\0');
        }

        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, fileName);
        }
    }
}