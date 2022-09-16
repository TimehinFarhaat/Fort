using Fort.DTOs;
using Fort.Interfaces.Service;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fort.Implementation.Service
{
    public class ResponseService : IResponseService
    {

        private readonly IConfiguration Configuration;

        public ResponseService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<BaseResponse> SendResponse(string phoneNumber,string Sendmessage)
        {
            var publicKey = Configuration.GetSection("SmsConfiguration")["publicKey"];
            var accessToken = Configuration.GetSection("SmsConfiguration")["accessToken"];
            string message = Sendmessage;
            SmsSender sender = new SmsSender(publicKey, accessToken, "farhaat");
            var result = await sender.SendSms(phoneNumber, message);

            if (!result) return new BaseResponse
            {
                Message = "Failure in sending sms",
                Status = false
            };

            return new BaseResponse
            {
                Message = "Successfully Sent",
                Status = true
            };
        }
    }

    class SmsSender
    {
        private readonly HttpClient _client;
        private readonly string _senderId;

        public SmsSender(string publicKey, string accessToken, string senderId)
        {
            _senderId = senderId;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://jusibe.com/smsapi/");
            _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                       $"{publicKey}:{accessToken}")));
        }

        public async Task<bool> SendSms(string recipient, string message)
        {
            HttpContent content = new StringContent(
              JsonSerializer.Serialize(new
              {
                  to = recipient,
                  from = this._senderId,
                  message
              })
            );
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync("send_sms", content);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.Error.WriteLine($"Request Failed with status: {response.StatusCode}");
                return false;
            }
            string responseString = await response.Content.ReadAsStringAsync();
            var parsedResponse = JsonSerializer.Deserialize<JusibeSmsResponse>(responseString);

            if (parsedResponse.Status.ToLowerInvariant() != "sent")
            {
                Console.Error.WriteLine($"Message not sent");
                return false;
            }

            return true;
        }
    }

    class JusibeSmsResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message_id")]
        public string MessageId { get; set; }

        [JsonPropertyName("sms_credits_used")]
        public int CreditsUsed { get; set; }
    }
}
