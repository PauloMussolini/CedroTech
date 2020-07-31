using System;
using System.Collections.Generic;
using System.IO;
using CedroTechApi.Models;

namespace CedroTechApi.Utils
{
    public class FileUtils
    {

        public static bool CreateFile(User user, string userIp)
        {
            try
            {
                var relativePath = Path.Combine("Output", user.FullName.Trim() + ".txt");


                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(relativePath))
                {

                    file.WriteLine("Nome Completo: " + user.FullName );
                    file.WriteLine("Data de Nascimento: " + user.BornDate);
                    file.WriteLine("CPF: " + user.CPF);
                    file.WriteLine("RG: " + user.RG);
                    file.WriteLine("");
                    file.WriteLine("Usuario Autenticado");
                    file.WriteLine("Login: " + user.Email);
                    file.WriteLine("IP: " + userIp);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
