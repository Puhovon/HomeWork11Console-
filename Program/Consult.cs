using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Consult : IClientDataMonitor
    {

        public List<Employee> clients
        {
            get; set;
        }
        public Consult()
        {
            this.clients = new List<Employee>();
            ReadData();
        }


        /// <summary>
        /// Read data into file
        /// </summary>
        public void ReadData(string path = "db.txt")
        {
            string AllData = "";

            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    AllData += sr.ReadLine();
                    string[] Split = AllData.Split('#');
                    if (Split.Length == 5)
                    {
                        Employee emp = new Employee(Split[0], Split[1], Split[2], Convert.ToDateTime(Split[3]), Split[4]);
                        clients.Add(emp);

                        Array.Clear(Split, 0, Split.Length);
                        AllData = "";

                    }
                    else
                    {
                        Employee emp = new Employee(Split[0], Split[1], Split[2], Convert.ToDateTime(DateTime.Now), "GOD");
                        clients.Add(emp);

                        Array.Clear(Split, 0, Split.Length);
                        AllData = "";
                    }
                }
            }
        }
        public void ViewClientData()
        {
            int id = 1;

            for (int i = 0; i < clients.Count; i++)
            {
                Employee emp = clients[i];
                Console.WriteLine(id + " " + emp.Name + " " + emp.PhoneNumber + " " + "*** " + emp.DateOfChanged + " " + emp.WhoChanged);
                id++;
            }
        }

        public void ChangeData()
        {
            Console.WriteLine("Id");

            int id = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < clients.Count; i++)
            {
                Employee empl = this.clients[i];
                if (clients[id] != null)
                {
                    Console.WriteLine("Change name: \t");
                    string newName = Console.ReadLine();
                    if (newName != null)
                    {
                        Employee temp = new Employee(newName, empl.PhoneNumber, empl.PassportData, DateTime.Now, "Consult");
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
    }
}