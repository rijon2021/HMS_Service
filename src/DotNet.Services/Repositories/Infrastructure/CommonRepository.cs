using System.Net.Http.Headers;

using DotNet.ApplicationCore.Entities;
using DotNet.Infrastructure.Persistence.Contexts;
using DotNet.Services.Repositories.Infrastructure;

using static DotNet.ApplicationCore.Utils.Enums.GlobalEnum;


namespace DotNet.Services.Repositories.Common
{
    public class CommonRepository(DotNetContext context) : ICommonRepository
    {
        private readonly DotNetContext dbContext = context;

        public async Task<bool> SendSMS(int UserID, string RecipientMobileNo, string messageBody, NotificationArea notificationArea, string otp)
        {
            try
            {
                SMSNotification notification = new()
                {
                    UserID = UserID,
                    RecipientMobileNo = RecipientMobileNo,
                    NotificationAreaID = notificationArea.NotificationAreaID,
                    OTP = otp,
                    ExpireDateTime = DateTime.Now.AddMinutes(notificationArea.ExpireTime),
                    MessageBody = messageBody
                };

                SendSMSToServer(notification);

                dbContext.SMSNotifications.Add(notification);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void SendSMSToServer(SMSNotification notification)
        {
            try
            {
                var globalSettings = dbContext.GlobalSettings.SingleOrDefault(x => x.GlobalSettingID == (int)GlobalSettingsEnum.SMS_Base_Url);

                if (globalSettings != null && globalSettings.IsActive == true && !string.IsNullOrEmpty(globalSettings.ValueInString))
                {
                    using var client = new HttpClient();

                    client.BaseAddress = new Uri(globalSettings.ValueInString);
                    client.DefaultRequestHeaders.ExpectContinue = false;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new FormUrlEncodedContent(
                    [
                        new KeyValuePair<string, string>("USER_CODE", "swl001"),
                        new KeyValuePair<string, string>("User_Pass", "123456"),
                        new KeyValuePair<string, string>("MOBILE_NUMBER", notification.RecipientMobileNo),
                        new KeyValuePair<string, string>("DTL_SMS", notification.MessageBody),
                        new KeyValuePair<string, string>("MASKING", "SWL")
                    ]);

                    var response = client.PostAsync("/api/SMS/PostSMSData", content).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw new Exception("SMS sending failed.");
            }
        }
    }
}
