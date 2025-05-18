using System.Net;
using System.Text.Encodings.Web;
using HttpMethod = System.Net.Http.HttpMethod;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Application.Services.SMS;

public class SmsSender : ISmsSender
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IHttpClientFactory ClientFactory { get; }

    public SmsSender(IUnitOfWork unitOfWork, IHttpClientFactory clientFactory)
    {
        UnitOfWork = unitOfWork;
        ClientFactory = clientFactory;
    }


    #region FarazSms
    public async Task<string> SendPattern(string receiver, string message, string type)
    {
        string from;
        string uname;
        string pass;
        string domain;
        string patternCode = "";
        string input_data = "";

        var c = UnitOfWork.ConfigRepository.Table.AsQueryable()
            .Select(a => new
            {
                a.SmsCenter,
                a.SmsPass,
                a.SmsUser,
                a.Domain
            }).AsNoTracking().FirstOrDefault();

        from = c.SmsCenter;
        uname = c.SmsUser;
        pass = c.SmsPass;
        domain = c.Domain;

        if (type.Equals(SmsPatterns.RegisterActivateCode))
        {
            patternCode = "rtawk1bpa9g5kjl";
            input_data = JsonSerializer.Serialize(new Dictionary<string, string>
            {
                ["code"] = message
            });
        }
        else if (type.Equals(SmsPatterns.LoginCode))
        {
            patternCode = "1u62cjhob0vgumy";
            var messageFormat = message.Split('|');
            input_data = JsonSerializer.Serialize(new Dictionary<string, string>
            {
                ["code"] = messageFormat[0]
            });
        }
        else if (type.Equals(SmsPatterns.ResetPasswordCode))
        {
            patternCode = "628k78kez8nyh7q";
            input_data = JsonSerializer.Serialize(new Dictionary<string, string>
            {
                ["code"] = message
            });
        }
        else if (type.Equals(SmsPatterns.OrderAdmin))
        {
            patternCode = "plbtckfs8x";
            input_data = JsonSerializer.Serialize(new Dictionary<string, string>
            {
                ["number"] = message
            });
        }
        else if (type.Equals("order0"))
        {
            patternCode = "5cy4lopq26";
            var msg = message.Split('|');
            input_data = JsonSerializer.Serialize(new Dictionary<string, string>
            {
                ["order-number"] = msg[0],
                ["customer-name"] = msg[1],
                ["link"] = $"{domain}/profile/order"
            });

        }
        else if (type.Equals("order1"))
        {
            patternCode = "gqtu379dxa";
            var msg = message.Split('|');
            input_data = JsonSerializer.Serialize(new Dictionary<string, string>
            {
                ["order-number"] = msg[0],
                ["customer-name"] = msg[1],
                ["link"] = $"{domain}/profile/order"
            });

        }
        else if (type.Equals("order2"))
        {
            patternCode = "0ulzx436v6";
            var msg = message.Split('|');
            input_data = JsonSerializer.Serialize(new Dictionary<string, string>
            {
                ["order-number"] = msg[0],
                ["customer-name"] = msg[1],
                ["link"] = $"{domain}/profile/order"
            });
        }
        else if (type.Equals("acceptedJob"))
        {
            patternCode = "krkraekbj44uw8j";
        }
        else if (type.Equals("rejectedJob"))
        {
            patternCode = "2sa1f61ju06l1jv";
        }
        else if (type.Equals("addJobToAdmin"))
        {
            patternCode = "u6qkpr49r8y5h6b";
        }

        string toIp = "http://188.0.240.110";
        string to = receiver;
        string url = $"https://ippanel.com/patterns/pattern?username={uname}&password={UrlEncoder.Default.Encode(pass)}&from={from}&to={to}&input_data={UrlEncoder.Default.Encode(input_data)}&pattern_code={patternCode}";
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        using var client = ClientFactory.CreateClient();
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            response.Dispose();
            return "ok";
        }
        else
        {
            response.Dispose();
            return "nok";
        }
    }

    public async Task<string> SendPattern(string receiver, string patternCode, string input_data, string smsCenter, string smsPass, string smsUser)
    {
        string toIp = "http://188.0.240.110";
        string to = JsonSerializer.Serialize(new string[] { receiver });
        string url = $"https://ippanel.com/patterns/pattern?username={smsUser}&password={UrlEncoder.Default.Encode(smsPass)}&from={smsCenter}&to={to}&input_data={UrlEncoder.Default.Encode(input_data)}&pattern_code={patternCode}";
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        using var client = ClientFactory.CreateClient();
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            response.Dispose();
            return "ok";
        }
        else
        {
            response.Dispose();
            return "nok";
        }
    }

    public string SendSms(string receiver, string message)
    {
        string from = "";
        string uname = "";
        string pass = "";

        var c = UnitOfWork.ConfigRepository.Table.AsQueryable()
            .Select(a => new
            {
                a.SmsCenter,
                a.SmsPass,
                a.SmsUser
            }).AsNoTracking().FirstOrDefault();

        from = c.SmsCenter;
        uname = c.SmsUser;
        pass = c.SmsPass;

        string json = "";
        json = JsonSerializer.Serialize(receiver);
        WebRequest request = WebRequest.Create("http://ippanel.com/services.jspd");
        request.Method = "POST";
        string postData = $"op=send&uname={uname}&pass={pass}&message={message}&to={json}&from={from}";
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = byteArray.Length;
        Stream dataStream = request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        WebResponse response = request.GetResponse();
        Console.WriteLine(((HttpWebResponse)response).StatusDescription);
        dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        Console.WriteLine(responseFromServer);
        reader.Close();
        dataStream.Close();
        response.Close();
        List<string> smsResult = JsonSerializer.Deserialize<List<string>>(responseFromServer);
        return smsResult.First() switch
        {
            "0" => "ok",
            "1" => "متن پیام خالی می باشد.",
            "2" => "کاربر محدود گردیده است",
            "3" => "شماره ارسالی به شما تعلق ندارد",
            "4" => "دریافت کننده وارد نگردیده است",
            "5" => "اعتبار شما ناکافی است",
            "6" => "تعدا رشته پیام نامناسب می باشد",
            "7" => "خط مورد نظر برای ارسال انبوه مناسب نمیباشد",
            "98" => "حد بالای دریافت کننده رعایت نگردیده است",
            "99" => "اپراتور شماره ارسال کننده قطع میباشد",
            "962" => "نام کاربری یا رمز عبور اشتباه می باشد.",
            "963" => "کاربر شما محدود گردیده است.",
            "301" => "از حرف ویژه در نام کاربری استفاده گردیده است",
            "302" => "قیمت گذاری انجام نشده است",
            "303" => "نام کاربری وارد نگردیده است",
            "304" => "نام کاربری قبلا انتخاب گردیده است",
            "305" => "نام کاربری وارد نگردیده است",
            "306" => "کد ملی وارد نگردیده است",
            "307" => "کد ملی به خطا وارد شده است",
            "308" => "شماره شناسنامه نا معتبر است",
            "309" => "شماره شناسنامه وارد نگردیده است",
            "310" => "ایمیل کاربر وارد نگردیده است",
            "311" => "شماره تلفن وارد نگردیده است",
            "312" => "تلفن به درست یوارد نگردیده است",
            "313" => "آدرس شما وارد نگردیده است",
            "314" => "شماره موبایل را وارد نکرده اید",
            "315" => "شماره موبایل به نادرستی وارد گردیده است",
            "316" => "سطح دسترسی به نادرستی وارد گردیده است",
            _ => "خطای ناشناخته",
        };
    }

    #endregion

    #region KaveNegar Sms

    private string apiKey = "کد ارسال پیام";


    public async Task SendVerificationSms(string mobile, string activationCode)
    {
        //Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apiKey);
        //await api.VerifyLookup(mobile, activationCode, "Verification");
    }

    public async Task SendUserPasswordSms(string mobile, string password)
    {
        /*Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apiKey);
            await api.VerifyLookup(mobile, password, "Verification");*/
    }

    #endregion
}