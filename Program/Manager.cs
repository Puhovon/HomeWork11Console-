using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Manager : Consult, IClientDataMonitor
    {


        public new void ChangeData()
        {

            Console.WriteLine("Id");
            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < clients.Count; i++)
            {
                Employee empl = this.clients[i];
                if (clients[id] != null)
                {
                    Console.WriteLine("Change PhoneNumber: \t");
                    string newPhoneNumber = Console.ReadLine();
                    if (newPhoneNumber != null)
                    {
                        Employee temp = new Employee(empl.Name, newPhoneNumber, empl.PassportData, Convert.ToDateTime(empl.DateOfChanged), "Manager");
                        clients[id] = temp;
                        SaveNewData();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("you don't written PhoneNumber");
                    }
                }
            }
        }

        private void SaveNewData(string path = "db.txt")
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                for (int i = 0; i < clients.Count; i++)
                {
                    Employee emp = this.clients[i];
                    sw.WriteLine(emp.Name + "#" + emp.PhoneNumber + "#" + emp.PassportData + "#" + emp.DateOfChanged + "#" + emp.WhoChanged);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Well done!");
            }

        }

        public new void ViewClientData()
        {

            int id = 1;

            for (int i = 0; i < clients.Count; i++)
            {
                Employee emp = this.clients[i];
                Console.WriteLine(id + " " + emp.Name + " " + emp.PhoneNumber + " " + emp.PassportData + " " + emp.DateOfChanged + " " + emp.WhoChanged);
                id++;
            }
        }
    }
}
