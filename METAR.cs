using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace ATISPlugin
{
    public class METAR
    {
        public bool SPECI { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string Cloud { get; set; }
        public string Weather { get; set; }
        public string Temperature { get; set; }
        public string DewPoint { get; set; }
        public string QNH { get; set; }

        public METAR Process(string metar)
        {
            if (metar.Length < 4)
                return null;
            string icao = "NONE";
            //bool speci = false;
            int startIndex = 0;
            if (metar.Contains("METAR "))
            {
                startIndex = metar.IndexOf("METAR ") + 6;
                if (metar.Length > startIndex + 5)
                    icao = metar.Substring(startIndex, 4);
            }
            else if (metar.Contains("SPECI "))
            {
                //speci = true;
                startIndex = metar.IndexOf("SPECI ") + 6;
                if (metar.Length > startIndex + 5)
                    icao = metar.Substring(startIndex, 4);
            }
            else
                icao = metar.Substring(0, 4);
            if (metar.Length < startIndex + 4)
                return null;
            string[] strArray1 = Regex.Replace(metar.Substring(startIndex + 4), "\\t|\\n|\\r", "").Split(' ');
            
            DateTime producttime = DateTime.MaxValue;

            for (int index = 0; index < strArray1.Length; ++index)
            {
                string str1 = strArray1[index].Trim().ToUpperInvariant();
                switch (str1)
                {
                    case "RMK":
                        continue;
                    case "AUTO":
                        continue;
                    default:
                        if (Regex.IsMatch(str1, "^\\d{6}Z$"))
                            producttime = new DateTime(1, 1, int.Parse(str1.Substring(0, 2)), int.Parse(str1.Substring(2, 2)), int.Parse(str1.Substring(4, 2)), 0);
                        if (Regex.IsMatch(str1, "^(\\d{3}|VRB)\\d{2}(KT|MPS|KPH)$") || Regex.IsMatch(str1, "^(\\d{3}|VRB)\\d{2}G\\d{2,3}(KT|MPS|KPH)$"))
                        {
                            str1 = str1.Replace("KT", "").Replace("MPS", "").Replace("KPH", "");
                            if (str1 == "00000") Wind = "CALM";
                            else if (str1.EndsWith("01") || str1.EndsWith("02")) Wind = "VRB";
                            else
                            {
                                string str2 = (str1[2] != '1' ? Wind + str1.Substring(0, 3) : Wind + str1.Substring(0, 2) + "0") + "/";
                                string source = str1.Substring(4);
                                if (str1[3] != '0')
                                    source = str1.Substring(3);
                                if (source.Contains<char>('G'))
                                {
                                    string[] strArray2 = source.Split('G');
                                    Wind = str2 + strArray2[0] + "-" + strArray2[1];
                                }
                                else
                                    Wind = str2 + source;
                            }
                        }
                        if (Wind != "CALM" && Regex.IsMatch(str1, "^\\d{3}V\\d{3}$"))
                        {
                            if (Wind != null)
                            {
                                string[] strArray3 = Wind.Split('/');
                                string[] strArray4 = str1.Split('V');
                                if (strArray3.Length == 2 && strArray4.Length == 2)
                                    Wind = strArray4[0] + "-" + strArray4[1] + "/" + strArray3[1];
                                else
                                    Wind = Wind + " " + str1;
                            }
                            else
                                Wind += str1;
                        }
                        if (str1 == "CAVOK" || Regex.IsMatch(str1, "^\\d{4}$"))
                        {
                            switch (str1)
                            {
                                case "CAVOK":
                                    Weather = "CAVOK";
                                    break;
                                case "9999":
                                    Visibility = "GT 10KM";
                                    break;
                                default:
                                    try
                                    {
                                        int num = int.Parse(str1);
                                        Visibility = num <= 5000 ? str1 + "M" : (num / 1000).ToString() + "KM";
                                        break;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                            }
                        }
                        if (Regex.IsMatch(str1, "^(\\d\\/\\d+|\\d{1,2})(KM|SM)$"))
                            Visibility = str1;
                        if (Regex.IsMatch(str1, "^(\\+|\\-){0,1}([A-Z]{2}){1,3}$"))
                        {
                            if (Weather != null)
                                Weather += " ";
                            Weather += str1;
                        }
                        if (Regex.IsMatch(str1, "^(FEW|SCT|BKN|OVC)\\d{3}(CB|TCU){0,1}$"))
                        {
                            try
                            {
                                if (int.Parse(str1.Substring(3, 3)) < 50)
                                {
                                    if (!str1.Contains("CB"))
                                    {
                                        if (!str1.Contains("TCU"))
                                        {
                                            if (Cloud != null)
                                                Cloud += ", ";
                                            Cloud += str1;
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                        if (str1 == "NCD" && Visibility == "GT 10KM" && Weather == null)
                        {
                            Visibility = null;
                            Weather = "CAVOK";
                        }
                        if (Regex.IsMatch(str1, "^M{0,1}\\d{2}\\/M{0,1}\\d{2}$"))
                        {
                            Temperature = str1[0] != '0' ? str1.Substring(0, 2) : str1.Substring(1, 1);
                            DewPoint = str1[3] != '0' ? str1.Substring(3) : str1.Substring(4);
                        }
                        if (Regex.IsMatch(str1, "^(Q|A)\\d{4}$"))
                        {
                            QNH = str1.Substring(1).TrimStart('0');
                        }
                        continue;
                }
            }
            return this;
        }

        public string GetField(METARField field)
        {
            switch (field)
            {
                case METARField.None:
                    return null;
                case METARField.Wind:
                    return Wind;
                case METARField.Visibility:
                    return Visibility;
                case METARField.Cloud:
                    return Cloud;
                case METARField.Weather:
                    return Weather;
                case METARField.Temperature:
                    return Temperature;
                case METARField.DewPoint:
                    return DewPoint;
                case METARField.QNH:
                    return QNH;
                default:
                    return null;
            }
        }
    }

    public enum METARField
    {
        None,
        Wind,
        Visibility,
        Cloud,
        Weather,
        Temperature,
        DewPoint,
        QNH,
    }
}
