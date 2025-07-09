using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;
        private static string _filePath = @"C:\\DVLD_UsersData\data.txt";

        public static bool StoreRememberUsers(string UserName, string Password)
        {
            string dataToSave = UserName + "#//#" + Password;

            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    writer.WriteLine(dataToSave);

                    return true;
                }
            } catch (Exception ex)
            {
                return false;
            }
        }

        public static bool GetStoredUsers(ref string UserName, ref string Password)
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            UserName = result[0];
                            Password = result[1];
                        }

                        return true;
                    }
                }
                else
                    return false;
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}
