using System;
using System.IO;
using aviationLib;

namespace fixToKml
{
    class Program
    {
        static StreamReader rowset;
        static String row;
        static String[] columns;

        static String fixId;

        static StreamWriter fixWaypoint;
        static StreamWriter fixRepPt;
        static StreamWriter fixMilRepPt;
        static StreamWriter fixCnf;
        static StreamWriter fixCoordnFix;
        static StreamWriter fixMilWaypoint;
        static StreamWriter fixRadar;
        static StreamWriter fixNrsWaypoint;
        static StreamWriter fixVfrWaypoint;

        static LatLon latLon;

        static void WriteKml(StreamWriter sw)
        {
            sw.WriteLine("\t<Placemark>");
            sw.WriteLine("\t\t<name>" + fixId + "</name>");
            sw.WriteLine("\t\t<Point>");
            sw.WriteLine("\t\t\t<coordinates>");

            sw.WriteLine("\t\t\t\t" + latLon.decimalLon.ToString("F6") + "," + latLon.decimalLat.ToString("F6"));

            sw.WriteLine("\t\t\t</coordinates>");
            sw.WriteLine("\t\t</Point>");
            sw.WriteLine("\t</Placemark>");
        }

        static StreamWriter InitNewWriter(String name)
        {
            StreamWriter writer = new StreamWriter(name);

            writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            writer.WriteLine("<kml xmlns=\"http://www.opengis.net/kml/2.2\">");
            writer.WriteLine("<Document>");

            return writer;
        }

        static void CloseWriter(StreamWriter writer)
        {
            writer.WriteLine("</Document>");
            writer.WriteLine("</kml>");

            writer.Close();
        }

        static void ProcessRow(String row)
        {
            columns = row.Split('~');

            fixId = columns[1];

            latLon = new LatLon(columns[4], columns[5]);

            switch (columns[8])
            {
            case "WAYPOINT":
            {
                WriteKml(fixWaypoint);

                break;
            }

            case "REP-PT":
            {
                WriteKml(fixRepPt);

                break;
            }

            case "MIL-REP-PT":
            {
                WriteKml(fixMilRepPt);

                break;
            }

            case "CNF":
            {
                WriteKml(fixCnf);

                break;
            }

            case "COORDN-FIX":
            {
                WriteKml(fixCoordnFix);

                break;
            }

            case "MIL-WAYPOINT":
            {
                WriteKml(fixMilWaypoint);

                break;
            }

            case "RADAR":
            {
                WriteKml(fixRadar);

                break;
            }

            case "NRS-WAYPOINT":
            {
                WriteKml(fixNrsWaypoint);

                break;
            }

            case "VFR-WP":
            {
                WriteKml(fixVfrWaypoint);

                break;
            }
            default:
            {
                Console.WriteLine("Unkown Type:" + columns[8]);
                
                break;
            }
            }
        }

        static void Main(string[] args)
        {
            rowset = new StreamReader(args[0], false);

            fixWaypoint = InitNewWriter("fixWaypoint.kml");
            fixRepPt = InitNewWriter("fixRepPt.kml");
            fixMilRepPt = InitNewWriter("fixMilRepPt.kml");
            fixCnf = InitNewWriter("fixCnf.kml");
            fixCoordnFix = InitNewWriter("fixCoordnFix.kml");
            fixMilWaypoint = InitNewWriter("fixMilWaypoint.kml");
            fixRadar = InitNewWriter("fixRadar.kml");
            fixNrsWaypoint = InitNewWriter("fixNrsWaypoint.kml");
            fixVfrWaypoint = InitNewWriter("fixVfrWaypoint.kml");

            
            row = rowset.ReadLine();

            while (!rowset.EndOfStream)
            {
                ProcessRow(row);

                row = rowset.ReadLine();
            }

            ProcessRow(row);

            
            CloseWriter(fixWaypoint);
            CloseWriter(fixRepPt);
            CloseWriter(fixMilRepPt);
            CloseWriter(fixCnf);
            CloseWriter(fixCoordnFix);
            CloseWriter(fixMilWaypoint);
            CloseWriter(fixRadar);
            CloseWriter(fixNrsWaypoint);
            CloseWriter(fixVfrWaypoint);

            rowset.Close();
        }
    }
}
