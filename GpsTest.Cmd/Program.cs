using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GpsTest.Cmd
{
    class Program
    {
        static GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        static string outfile;
        static TimeSpan frequency = TimeSpan.FromSeconds(15);

        static void Main(string[] args)
        {
            outfile = string.Format(
                "GPS-Output-{0}.csv",
                DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")
            );
            File.WriteAllText(outfile,
              "TimeStamp,Lat,Long,Speed,VerticalAccuracy,HorizontalAccuracy,Altitude,Course\n"
            );
            Console.WriteLine("Writing to\n{0}", new FileInfo(outfile).FullName);

            DisplayMenu();
            Console.WriteLine();

            watcher.TryStart(true, TimeSpan.FromSeconds(5));
            watcher.StatusChanged += watcher_StatusChanged;

            var tracktask = Task.Factory.StartNew(TrackLatLong);


            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();


            } while (key.Key != ConsoleKey.Q);


            Console.WriteLine();
            Console.WriteLine("Exiting");
        }

        static void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            Console.WriteLine("GPS Status: {0}", e.Status);
        }


        private static void TrackLatLong()
        {
            while (true)
            {

                var coord = watcher.Position.Location;
                if (coord.IsUnknown)
                {
                    Console.WriteLine("Unable to locate");
                }
                else
                {
                    Console.WriteLine(coord);
                    var data = new[]{
                        DateTime.Now.ToString(),
                        coord.Latitude.ToString(),
                        coord.Longitude.ToString(),
                        coord.Speed.ToString(),
                        coord.VerticalAccuracy.ToString(),
                        coord.HorizontalAccuracy.ToString(),
                        coord.Altitude.ToString(),
                        coord.Course.ToString()
                    };
                    File.AppendAllText(outfile,
                        string.Join(",", data) + "\n"
                    );
                }

                Thread.Sleep(frequency);
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("GPS TEST");
            Console.WriteLine();
            //Console.WriteLine("(S)tart Trek");
            //Console.WriteLine("(E)nd Trek");
            Console.WriteLine("(Q)uit");
        }
    }
}
