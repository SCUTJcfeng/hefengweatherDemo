using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hefengWeatherDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Text = "fuqing";
            _Link_Url = " https://www.heweather.com/support/faq";
        }
        private string _Link_Url;

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://free-api.heweather.com/s6/weather/?location=" + textBox2.Text + "&key=b041051110024542923df86c7b925d9b";
            string jstext = HttpGet(url, "");
            
            JObject joRoot = JsonConvert.DeserializeObject<JObject>(jstext);
            JArray jAy = (JArray)joRoot["HeWeather6"];
            JObject joChild = (JObject)jAy[0];

            JObject joBasic = (JObject)joChild["basic"];
            JObject joUpdate = (JObject)joChild["update"];
            JObject joNow = (JObject)joChild["now"];
            JArray jAForecast = (JArray)joChild["daily_forecast"];
            JArray jALifeStyle = (JArray)joChild["lifestyle"];
            //daily_forecast 3 days
            JObject joForecastOne = (JObject)jAForecast[0];
            JObject joForecastTwo = (JObject)jAForecast[1];
            JObject joForecastThree = (JObject)jAForecast[2];
            //lifestyle 8 types
            JObject joLifestyle_Comf = (JObject)jALifeStyle[0];
            JObject joLifestyle_Cw = (JObject)jALifeStyle[1];
            JObject joLifestyle_Drsg = (JObject)jALifeStyle[2];
            JObject joLifestyle_Flu = (JObject)jALifeStyle[3];
            JObject joLifestyle_Sport = (JObject)jALifeStyle[4];
            JObject joLifestyle_Trav = (JObject)jALifeStyle[5];
            JObject joLifestyle_Uv = (JObject)jALifeStyle[6];
            JObject joLifestyle_Air = (JObject)jALifeStyle[7];

            //basic
            string _Location = joBasic["location"].ToString();//城市名称
            string _Cid = joBasic["cid"].ToString();//城市ID
            string _Lon = joBasic["lon"].ToString();//城市纬度
            string _Lat = joBasic["lat"].ToString();//城市经度
            string _ParentCity = joBasic["parent_city"].ToString();//城市的上级城市
            string _AdminArea = joBasic["admin_area"].ToString();//城市所属行政取余
            string _Cnty = joBasic["cnty"].ToString();//城市所属国家名称
            string _Tz = joBasic["tz"].ToString();//城市所在时区

            //update
            string _Loc = joUpdate["loc"].ToString();
            string _Utc = joUpdate["utc"].ToString();

            //now
            string _Cloud = joNow["cloud"].ToString();
            string _CondCode = joNow["cond_code"].ToString();
            string _CondTxt = joNow["cond_txt"].ToString();
            string _Fl = joNow["fl"].ToString();
            string _Hum = joNow["hum"].ToString();
            string _Pcpn = joNow["pcpn"].ToString();
            string _Pres = joNow["pres"].ToString();
            string _Tmp = joNow["tmp"].ToString();
            string _Vis = joNow["vis"].ToString();
            string _WindDeg = joNow["wind_deg"].ToString();
            string _WindDir = joNow["wind_dir"].ToString();
            string _WindSc = joNow["wind_sc"].ToString();
            string _WindSpd = joNow["wind_spd"].ToString();

            //daily_forecast
            //daily_forecast One
            string _One_Cond_Code_D = joForecastOne["cond_code_d"].ToString();
            string _One_Cond_Code_N = joForecastOne["cond_code_n"].ToString();
            string _One_Cond_Txt_D = joForecastOne["cond_txt_d"].ToString();
            string _One_Cond_Txt_N = joForecastOne["cond_txt_n"].ToString();
            string _One_Date = joForecastOne["date"].ToString();
            string _One_Hum = joForecastOne["hum"].ToString();
            string _One_Mr = joForecastOne["mr"].ToString();
            string _One_Ms = joForecastOne["ms"].ToString();
            string _One_Pcpn = joForecastOne["pcpn"].ToString();
            string _One_Pop = joForecastTwo["pop"].ToString();
            string _One_Pres = joForecastOne["pres"].ToString();
            string _One_Sr = joForecastOne["sr"].ToString();
            string _One_Ss = joForecastOne["ss"].ToString();
            string _One_Tmp_Max = joForecastOne["tmp_max"].ToString();
            string _One_Tmp_Min = joForecastOne["tmp_min"].ToString();
            string _One_Uv_Index = joForecastOne["uv_index"].ToString();
            string _One_Vis = joForecastOne["vis"].ToString();
            string _One_Wind_Deg = joForecastOne["wind_deg"].ToString();
            string _One_Wind_Dir = joForecastOne["wind_dir"].ToString();
            string _One_Wind_Sc = joForecastOne["wind_sc"].ToString();
            string _One_Wind_Spd = joForecastOne["wind_spd"].ToString();

            //daily_forecast Two
            string _Two_Cond_Code_D = joForecastTwo["cond_code_d"].ToString();
            string _Two_Cond_Code_N = joForecastTwo["cond_code_n"].ToString();
            string _Two_Cond_Txt_D = joForecastTwo["cond_txt_d"].ToString();
            string _Two_Cond_Txt_N = joForecastTwo["cond_txt_n"].ToString();
            string _Two_Date = joForecastTwo["date"].ToString();
            string _Two_Hum = joForecastTwo["hum"].ToString();
            string _Two_Mr = joForecastTwo["mr"].ToString();
            string _Two_Ms = joForecastTwo["ms"].ToString();
            string _Two_Pcpn = joForecastTwo["pcpn"].ToString();
            string _Two_Pop = joForecastTwo["pop"].ToString();
            string _Two_Pres = joForecastTwo["pres"].ToString();
            string _Two_Sr = joForecastTwo["sr"].ToString();
            string _Two_Ss = joForecastTwo["ss"].ToString();
            string _Two_Tmp_Max = joForecastTwo["tmp_max"].ToString();
            string _Two_Tmp_Min = joForecastTwo["tmp_min"].ToString();
            string _Two_Uv_Index = joForecastTwo["uv_index"].ToString();
            string _Two_Vis = joForecastTwo["vis"].ToString();
            string _Two_Wind_Deg = joForecastTwo["wind_deg"].ToString();
            string _Two_Wind_Dir = joForecastTwo["wind_dir"].ToString();
            string _Two_Wind_Sc = joForecastTwo["wind_sc"].ToString();
            string _Two_Wind_Spd = joForecastTwo["wind_spd"].ToString();

            //daily_forecast Three
            string _Three_Cond_Code_D = joForecastThree["cond_code_d"].ToString();
            string _Three_Cond_Code_N = joForecastThree["cond_code_n"].ToString();
            string _Three_Cond_Txt_D = joForecastThree["cond_txt_d"].ToString();
            string _Three_Cond_Txt_N = joForecastThree["cond_txt_n"].ToString();
            string _Three_Date = joForecastThree["date"].ToString();
            string _Three_Hum = joForecastThree["hum"].ToString();
            string _Three_Mr = joForecastThree["mr"].ToString();
            string _Three_Ms = joForecastThree["ms"].ToString();
            string _Three_Pcpn = joForecastThree["pcpn"].ToString();
            string _Three_Pop = joForecastThree["pop"].ToString();
            string _Three_Pres = joForecastThree["pres"].ToString();
            string _Three_Sr = joForecastThree["sr"].ToString();
            string _Three_Ss = joForecastThree["ss"].ToString();
            string _Three_Tmp_Max = joForecastThree["tmp_max"].ToString();
            string _Three_Tmp_Min = joForecastThree["tmp_min"].ToString();
            string _Three_Uv_Index = joForecastThree["uv_index"].ToString();
            string _Three_Vis = joForecastThree["vis"].ToString();
            string _Three_Wind_Deg = joForecastThree["wind_deg"].ToString();
            string _Three_Wind_Dir = joForecastThree["wind_dir"].ToString();
            string _Three_Wind_Sc = joForecastThree["wind_sc"].ToString();
            string _Three_Wind_Spd = joForecastThree["wind_spd"].ToString();

            //lifestyle
            //comf：舒适度指数
            string _Comf_Brf = joLifestyle_Comf["brf"].ToString();
            string _Comf_Txt = joLifestyle_Comf["txt"].ToString();
            string _Comf_Type = joLifestyle_Comf["type"].ToString();
            //cw：洗车指数
            string _Cw_Brf = joLifestyle_Cw["brf"].ToString();
            string _Cw_Txt = joLifestyle_Cw["txt"].ToString();
            string _Cw_Type = joLifestyle_Cw["type"].ToString();

            //drsg：穿衣指数
            string _Drsg_Brf = joLifestyle_Drsg["brf"].ToString();
            string _Drsg_Txt = joLifestyle_Drsg["txt"].ToString();
            string _Drsg_Type = joLifestyle_Drsg["type"].ToString();

            //flu：感冒指数
            string _Flu_Brf = joLifestyle_Flu["brf"].ToString();
            string _Flu_Txt = joLifestyle_Flu["txt"].ToString();
            string _Flu_Type = joLifestyle_Flu["type"].ToString();

            //sport：运动指数
            string _Sport_Brf = joLifestyle_Sport["brf"].ToString();
            string _Sport_Txt = joLifestyle_Sport["txt"].ToString();
            string _Sport_Type = joLifestyle_Sport["type"].ToString();

            //trav：旅游指数
            string _Trav_Brf = joLifestyle_Trav["brf"].ToString();
            string _Trav_Txt = joLifestyle_Trav["txt"].ToString();
            string _Trav_Type = joLifestyle_Trav["type"].ToString();

            //uv：紫外线指数
            string _Uv_Brf = joLifestyle_Uv["brf"].ToString();
            string _Uv_Txt = joLifestyle_Uv["txt"].ToString();
            string _Uv_Type = joLifestyle_Uv["type"].ToString();

            //air：空气污染扩散条件指数
            string _Air_Brf = joLifestyle_Air["brf"].ToString();
            string _Air_Txt = joLifestyle_Air["txt"].ToString();
            string _Air_Type = joLifestyle_Air["type"].ToString();


            string res = "";
            //basic
            res += "基础信息" + "\r\n";
            res += "城市名称：" + _Location + "\r\n";
            res += "城市ID：" + _Cid + "\r\n";
            res += "城市纬度：" + _Lon + "\r\n";
            res += "城市经度：" + _Lat + "\r\n";
            res += "城市的上级城市：" + _ParentCity + "\r\n";
            res += "城市所属行政区域：" + _AdminArea + "\r\n";
            res += "城市所属国家名称：" + _Cnty + "\r\n";
            res += "城市所在时区：" + _Tz + "\r\n";
            res += "\r\n";
            //update
            res += "接口更新时间" + "\r\n";
            res += "本地时间：" + _Loc + "\r\n";
            res += "UTC时间：" + _Utc + "\r\n";
            res += "\r\n";

            //now
            res += "今天天气" + "\r\n";
            res += "云量，百分比：" + _Cloud + "\r\n";
            res += "天气状况代码：" + _CondCode + "\r\n";
            res += "天气状况代码：" + _CondTxt + "\r\n";
            res += "体感温度，默认单位：摄氏度：" + _Fl + "\r\n";
            res += "相对湿度：" + _Hum + "\r\n";
            res += "降水量：" + _Pcpn + "\r\n";
            res += "大气压强：" + _Pres + "\r\n";
            res += "温度，默认单位：摄氏度：" + _Tmp + "\r\n";
            res += "能见度，默认单位：公里：" + _Vis + "\r\n";
            res += "风向360角度：" + _WindDeg + "\r\n";
            res += "风向：" + _WindDir + "\r\n";
            res += "风力：" + _WindSc + "\r\n";
            res += "风速，公里/小时：" + _WindSpd + "\r\n";
            res += "\r\n";

            //daily_forcast
            //One for tomorrow
            res += "天气预报" + "\r\n";
            res += "\r\n";
            res += "明天天气" + "\r\n";
            res += "白天天气状况代码：" + _One_Cond_Code_D + "\r\n";
            res += "晚间天气状况代码：" + _One_Cond_Code_N + "\r\n";
            res += "白天天气状况描述：" + _One_Cond_Txt_D + "\r\n";
            res += "晚间天气状况描述：" + _One_Cond_Txt_N + "\r\n";
            res += "预报日期：" + _One_Date + "\r\n";
            res += "相对湿度：" + _One_Hum + "\r\n";
            res += "月升时间：" + _One_Mr + "\r\n";
            res += "月落时间：" + _One_Ms + "\r\n";
            res += "降水量：" + _One_Pcpn + "\r\n";
            res += "降水概率：" + _One_Pop + "\r\n";
            res += "大气压强：" + _One_Pres + "\r\n";
            res += "日出时间：" + _One_Sr + "\r\n";
            res += "日落时间：" + _One_Ss + "\r\n";
            res += "最高温度：" + _One_Tmp_Max + "\r\n";
            res += "最低温度：" + _One_Tmp_Min + "\r\n";
            res += "紫外线强度指数：" + _One_Uv_Index + "\r\n";
            res += "能见度，单位：公里：" + _One_Vis + "\r\n";
            res += "风向360角度：" + _One_Wind_Deg + "\r\n";
            res += "风向：" + _One_Wind_Dir + "\r\n";
            res += "风力：" + _One_Wind_Sc + "\r\n";
            res += "风速，公里/小时：" + _One_Wind_Spd + "\r\n";
            res += "\r\n";

            //Two for the day after tomorrow
            res += "后天天气" + "\r\n";
            res += "白天天气状况代码：" + _Two_Cond_Code_D + "\r\n";
            res += "晚间天气状况代码：" + _Two_Cond_Code_N + "\r\n";
            res += "白天天气状况描述：" + _Two_Cond_Txt_D + "\r\n";
            res += "晚间天气状况描述：" + _Two_Cond_Txt_N + "\r\n";
            res += "预报日期：" + _Two_Date + "\r\n";
            res += "相对湿度：" + _Two_Hum + "\r\n";
            res += "月升时间：" + _Two_Mr + "\r\n";
            res += "月落时间：" + _Two_Ms + "\r\n";
            res += "降水量：" + _Two_Pcpn + "\r\n";
            res += "降水概率：" + _Two_Pop + "\r\n";
            res += "大气压强：" + _Two_Pres + "\r\n";
            res += "日出时间：" + _Two_Sr + "\r\n";
            res += "日落时间：" + _Two_Ss + "\r\n";
            res += "最高温度：" + _Two_Tmp_Max + "\r\n";
            res += "最低温度：" + _Two_Tmp_Min + "\r\n";
            res += "紫外线强度指数：" + _Two_Uv_Index + "\r\n";
            res += "能见度，单位：公里：" + _Two_Vis + "\r\n";
            res += "风向360角度：" + _Two_Wind_Deg + "\r\n";
            res += "风向：" + _Two_Wind_Dir + "\r\n";
            res += "风力：" + _Two_Wind_Sc + "\r\n";
            res += "风速，公里/小时：" + _Two_Wind_Spd + "\r\n";
            res += "\r\n";
            //Three for 大后天
            res += "大后天天气" + "\r\n";
            res += "白天天气状况代码：" + _Three_Cond_Code_D + "\r\n";
            res += "晚间天气状况代码：" + _Three_Cond_Code_N + "\r\n";
            res += "白天天气状况描述：" + _Three_Cond_Txt_D + "\r\n";
            res += "晚间天气状况描述：" + _Three_Cond_Txt_N + "\r\n";
            res += "预报日期：" + _Three_Date + "\r\n";
            res += "相对湿度：" + _Three_Hum + "\r\n";
            res += "月升时间：" + _Three_Mr + "\r\n";
            res += "月落时间：" + _Three_Ms + "\r\n";
            res += "降水量：" + _Three_Pcpn + "\r\n";
            res += "降水概率：" + _Three_Pop + "\r\n";
            res += "大气压强：" + _Three_Pres + "\r\n";
            res += "日出时间：" + _Three_Sr + "\r\n";
            res += "日落时间：" + _Three_Ss + "\r\n";
            res += "最高温度：" + _Three_Tmp_Max + "\r\n";
            res += "最低温度：" + _Three_Tmp_Min + "\r\n";
            res += "紫外线强度指数：" + _Three_Uv_Index + "\r\n";
            res += "能见度，单位：公里：" + _Three_Vis + "\r\n";
            res += "风向360角度：" + _Three_Wind_Deg + "\r\n";
            res += "风向：" + _Three_Wind_Dir + "\r\n";
            res += "风力：" + _Three_Wind_Sc + "\r\n";
            res += "风速，公里/小时：" + _Three_Wind_Spd + "\r\n";
            res += "\r\n";
            //lifestyle
            res += "生活指数" + "\r\n";
            //comf：舒适度指数
            res += "舒适度指数：" + _Comf_Brf + "\r\n";
            res += "内容：" + _Comf_Txt + "\r\n";
            //cw：洗车指数
            res += "洗车指数：" + _Cw_Brf + "\r\n";
            res += "内容：" + _Cw_Txt + "\r\n";
            //drsg：穿衣指数
            res += "穿衣指数：" + _Drsg_Brf + "\r\n";
            res += "内容：" + _Drsg_Txt + "\r\n";
            //flu：感冒指数
            res += "感冒指数：" + _Flu_Brf + "\r\n";
            res += "内容：" + _Flu_Txt + "\r\n";
            //sport：运动指数
            res += "运动指数：" + _Sport_Brf + "\r\n";
            res += "内容：" + _Sport_Txt + "\r\n";
            //trav：旅游指数
            res += "旅游指数：" + _Trav_Brf + "\r\n";
            res += "内容：" + _Trav_Txt + "\r\n";
            //uv：紫外线指数
            res += "紫外线指数：" + _Uv_Brf + "\r\n";
            res += "内容：" + _Uv_Txt + "\r\n";
            //air：空气污染扩散条件指数
            res += "空气污染扩散条件指数：" + _Air_Brf + "\r\n";
            res += "内容：" + _Air_Txt + "\r\n";

            textBox1.Text = res;
        }

        private string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
