using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

public partial class ValidateImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string[] codes = {"商务学院","省属办公","青年湖","现代商务","食品科技",
            "现代制造","会计电算","经济管理","食品工程","机械工程","信息艺术",
            "商务外语","建筑工程","技术教学","双师素质","明德立新","精品课堂",
            "教师团队","教学名师","爱心学堂","绿色学院","技能学员","艺体学院",
            "技能学院","创新学院","实训中心","教学楼","高端技能","行业办公",
            "工学交替","顶岗实习","校企合作","工学结合","信息中心","教学研究",
            "审计实务","投资理财","国际贸易","连锁经营","商务经济","物流管理",
            "粮食工程","食品营养","粮油储存","生物工艺","网络技术","软件开发",
            "项目管理","网页设计","装潢艺术","广告设计","动漫设计","应用韩语",
            "商务日语","应用英语","数控技术","旅游管理","机电一体","港口业务",
            "工程造价","建筑装饰","技能鉴定","兼职教师","精细管理" };
        Color[] color = { Color.Black,Color.Red,Color.Blue,Color.Brown,Color.DarkBlue};
        string[] font = { "宋体","新宋体","幼圆","楷体_GB2312"};
        Random rnd = new Random();
        string chkCode = codes[rnd.Next(codes.Length)];
        Session["ValidateCode"] = chkCode;
        Bitmap bmp = new Bitmap(80, 17);
        Graphics g = Graphics.FromImage(bmp);
        g.Clear(Color.WhiteSmoke);
        int length = chkCode.Length;
        for (int i = 0; i < length; i++)
        {
            string fnt = font[rnd.Next(font.Length)];
            Font ft = new Font(fnt, 12);
            Color clr = color[rnd.Next(color.Length)];
            g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * 20, (float)1);
        }
        bmp.Save(Response.OutputStream, ImageFormat.Gif);

       
    }
}